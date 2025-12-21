using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Windows.Forms;
using Comuns;

namespace Inversions.ClassesEntity
{
    public abstract partial class Producte : IComparable<Producte>
    {
        #region Variables

        // ReSharper disable UnusedMember.Global
        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; set; }
        public abstract string _TipusNomProducte { get; }
        public abstract Mercat _Mercat { get; set; }
        public abstract string _NomMercat { get; }
        public abstract string _Isin { get; }
        public abstract string _Descripcio { get; }
        // ReSharper restore UnusedMember.Global

        public IEnumerable<Moviment> MovimentsProducteUsuari
        {
            get { return this.Moviments.Where(w => w.UsuariId == Usuari.Seleccionat.Id); }
        }

        public enum TipusProducte
        {
            Tots = 0,
            Accions = 1,
            Fons = 2,
            Criptos = 3
        }

        #endregion


        #region Atributs

        public string _NomEmpresa
        {
            get { return Empresa == null ? null : Empresa.Nom; }
        }


        /// <summary>
        /// Torna les participacions actuals.
        /// </summary>
        public decimal _Participacions
        {
            get
            {
                // Utilitzo Now perqué amb Today, al fer un moviment, aquest no el compta fins el dia següent.
                return partsEnCartera(DateTime.Now);
            }
        }


        /// <summary>
        /// És el valor de les participacions avui.
        /// </summary>
        public decimal _ValorActualEnCartera
        {
            get { return valorEnCartera(); }
        }

        #endregion


        #region Mètodes

        public static DbSet<Producte> Tuples
        {
            get { return Program.Sessio.Productes; }
        }


        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof (Producte));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }


        internal decimal dividends()
        {
            return dividends(DateTime.MinValue, DateTime.Today);
        }
        
        internal decimal dividends(int any)
        {
            var dataInici = new DateTime(any, 1, 1);
            var dataFinal = Utilitats.DataHoraFinalAny(any);

            return dividends(dataInici, dataFinal);
        }

        private decimal dividends(DateTime dataInici, DateTime dataFi)
        {
            dataFi = Utilitats.DataHoraFinalDia(dataFi);
            
            return MovimentsProducteUsuari
                .Where(w => w._EsDividents && w.Data >= dataInici.Date && w.Data <= dataFi)
                .Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data hora actual.
        /// </summary>
        /// <returns></returns>
        public decimal _PreuParticipacioActual
        {
            get { return preuParticipacioEnData(DateTime.Now); }
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data hora del paràmetre 'dataHora'.
        /// </summary>
        /// <param name="dataHora"></param>
        /// <returns></returns>
        public decimal preuParticipacioEnData(DateTime dataHora)
        {
            return valorParticipacio(dataHora); 
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private decimal valorParticipacio(DateTime data)
        {
            var valoracions = ValoracionsProducte.Where(w => w.Data <= data).Select(val => new {val.Data, val.PreuParticipacio}).ToList();

            var moviments = Moviments.Where(w => w.Data <= data && (w.TipusMoviment == TipusMoviment.Compra || w.TipusMoviment == TipusMoviment.Venda))
                .Select(mov => new {mov.Data, mov.PreuParticipacio}).ToList();

            var tot = valoracions.Union(moviments).OrderBy(o => o.Data).ToList();

            if (tot.Any())
            {
                return tot.Last().PreuParticipacio;
            }

            //throw new ApplicationException("No hi ha cap moviment ni cap valoració disponibles.");
            return 0;
        }


        /// <summary>
        /// Torna el valor de les participacions en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="numPartsMax">Limita el cost a num de participacions</param>
        /// <param name="preuParticipacio">Si no null, utilitza aquest preu en lloc del actual a la data.</param>
        /// <returns></returns>
        public decimal valorEnCartera(DateTime? data = null, decimal? numPartsMax = null, decimal? preuParticipacio = null)
        {
            var dFinal = Utilitats.PosoHora(data);

            var participacions = partsEnCartera(dFinal);

            if (numPartsMax.HasValue)
                if (numPartsMax.Value > participacions && numPartsMax.Value < 0)
                    throw new ArgumentException("El numero de participacions del paràmetre supera les participacions en cartera o és negatiu", "numPartsMax");
                else
                    participacions = numPartsMax.Value;

            if (Utilitats.EsZero(participacions))
                return 0;

            return participacions * preuParticipacio.GetValueOrDefault(valorParticipacio(dFinal));
        }


        /// <summary>
        /// Suma les perdues dels 4 anys anteriors
        /// </summary>
        /// <param name="anyRenda"></param>
        /// <returns></returns>
        internal static decimal PerduesDarrersQuatreAnys(int? anyRenda = null)
        {
            if (!anyRenda.HasValue || anyRenda.Value == 0)
                return 0;

            var any = anyRenda.Value - 4;
            decimal pigT = 0;


            for (int i = 0; i < 4; i++)
            {
                var dataInici = new DateTime(any, 1, 1);
                var dataFi = Utilitats.DataHoraFinalAny(any);

                var pigAny = Pig4(dataInici, dataFi, true, false, true, false);
               
                if (pigAny + pigT >= 0)
                    pigT = 0;
                else
                    pigT += pigAny;

                any++;
            }

            return pigT;
        }

        /// <summary>
        /// Crea una llista de productes en funció dels paràmetres: "tipusProducte", "tipusFons"
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="tipusFons"></param>
        /// <returns></returns>
        private static IEnumerable<Producte> SeleccionaProds(TipusProducte tipusProducte, TipusFons? tipusFons)
        {
            List<Producte> prods = null;

            switch (tipusProducte)
            {
                case TipusProducte.Criptos:
                    prods = new List<Producte>(ProdAccions.Tuples.Where(w => w.Mercat.Id == 4));
                    break;
                case TipusProducte.Accions:
                    prods = new List<Producte>(ProdAccions.Tuples.Where(w => w.Mercat.Id != 4));
                    break;
                case TipusProducte.Fons:
                    if (tipusFons.HasValue)
                    {
                        switch (tipusFons.Value)
                        {
                            case TipusFons.RF:
                                prods = new List<Producte>(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RF));
                                break;
                            case TipusFons.RV:
                                prods = new List<Producte>(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RV));
                                break;
                            default:
                                prods = new List<Producte>(ProdFons.Tuples);
                                break;
                        }
                    }
                    else
                        prods = new List<Producte>(ProdFons.Tuples);
                    break;
                default:
                    prods = Producte.Tuples.ToList();
                    break;
            }

            return prods;
        }
        

        /// <summary>
        /// Participacions en cartera d'un producte en una data.
        /// </summary>
        /// <param name="dataHora">Si null, data d'avui.</param>
        /// <returns></returns>
        internal decimal partsEnCartera(DateTime? dataHora = null)
        {
            var dataH = dataHora.GetValueOrDefault(DateTime.Now);
            var partsComprades = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data <= dataH).Sum(s => s.Participacions);
            var partsVenudes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data <= dataH).Sum(s => s.Participacions);

            return partsComprades - partsVenudes;
        }

        #endregion


        #region *** Mètodes que modifiquen la BD ***

        /// <summary>
        /// Validacions en Compres o Vendes.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        private void validacionsCompraVenda(InversionsBDContext connexio, DateTime dataHora, decimal participacions, bool mostraFinestraAdvertencia)
        {
            if (connexio == null)
                throw new ArgumentNullException("connexio");

            // Valida que s'hagi creat una transacció abans de començar el procés.
            if (connexio.Database.CurrentTransaction == null)
                throw new ArgumentNullException("No s'ha creat cap transacció. És obligatori per aquest procés.");


            if (MovimentsProducteUsuari.Any())
            {
                var ultimaData = MovimentsProducteUsuari.Max(m => m.Data);

                // Valido que DateTime no sigui inferior a un moviment prèvi del mateix producte.
                if (ultimaData >= dataHora && mostraFinestraAdvertencia)
                {
                    if (MessageBox.Show("La data és inferior a la data del últim moviment del producte.\nVols continuar?", "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        throw new ApplicationException("Operació cancelada");
                }
            }

            if (participacions <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacions");
        }

        public void desaTraspasTest(InversionsBDContext connexio, DateTime dataHoraVenda, decimal participacionsVenda, decimal preuParticipacioVenda,
            string descripcio, DateTime dataHoraCompra, Producte prodCompra, decimal participacionsCompra, bool afegeigPreuAValoracions = true)
        {
            desaTraspas(connexio, dataHoraVenda, participacionsVenda, preuParticipacioVenda,
                descripcio, dataHoraCompra, prodCompra, participacionsCompra, (participacionsVenda * preuParticipacioVenda / participacionsCompra), 0,
                afegeigPreuAValoracions);
        }

        /// <summary>
        /// Traspàs de un fons.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHoraVenda"></param>
        /// <param name="participacionsVenda"></param>
        /// <param name="preuParticipacioVenda"></param>
        /// <param name="descripcio"></param>
        /// <param name="dataHoraCompra"></param>
        /// <param name="prodCompra"></param>
        /// <param name="participacionsCompra"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        internal void desaTraspas(InversionsBDContext connexio, DateTime dataHoraVenda, decimal participacionsVenda, decimal preuParticipacioVenda,
            string descripcio, DateTime dataHoraCompra, Producte prodCompra, decimal participacionsCompra, decimal preuParticipacioCompra, decimal despeses,
            bool afegeigPreuAValoracions = true)
        {
            dataHoraVenda = Utilitats.ArrodoneixoDataASegons(dataHoraVenda);
            dataHoraCompra = Utilitats.ArrodoneixoDataASegons(dataHoraCompra);

            if (dataHoraVenda == dataHoraCompra)
                dataHoraCompra = dataHoraCompra.AddSeconds(1);


            //decimal preuParticipacioCompra = preuParticipacioVenda * participacionsVenda / participacionsCompra;

            var venda = this.desaVenda(connexio, dataHoraVenda, participacionsVenda, preuParticipacioVenda, 1, null, descripcio, afegeigPreuAValoracions,
                true);
            var compra = prodCompra.desaCompra(connexio, dataHoraCompra, participacionsCompra, preuParticipacioCompra, 1, despeses, descripcio, venda,
                afegeigPreuAValoracions, true);
        }


        /// <summary>
        /// Compra. No es crida en els traspassos.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        public Moviment desaCompra(InversionsBDContext connexio, DateTime data, TimeSpan hora, decimal participacions, decimal preuParticipacio, decimal canviAplicat,
            decimal? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = Utilitats.FormaData(data, hora);

            return desaCompra(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions, mostraFinestraAdvertencia);
        }


        /// <summary>
        /// Compra o traspàs compra.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="movimentVendaVinculatTraspas">Si != NULL, és un traspàs.</param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        private Moviment desaCompra(InversionsBDContext connexio, DateTime dataHora, decimal participacions, decimal preuParticipacio, decimal canviAplicat,
            decimal? despeses, string descripcio, Moviment movimentVendaVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment novaCompra = connexio.Moviments.Create();
            novaCompra.UsuariId = Usuari.Seleccionat.Id; // Utilitzo Id perquè "Usuari.Seleccionat" està en un context diferent.
            novaCompra.TipusMoviment = TipusMoviment.Compra;
            novaCompra.Participacions = participacions;
            novaCompra.PreuParticipacio = preuParticipacio;
            novaCompra.CanviAplicat = canviAplicat;
            novaCompra.Despeses = despeses;
            novaCompra.Data = dataHora;
            novaCompra.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            if (movimentVendaVinculatTraspas != null)
            {
                //// Asigno valor a "ProducteTraspasId" en la venda.
                //this.MovimentsTraspas.Add(movimentVendaVinculatTraspas);

                //// Asigno valor a "ProducteTraspasId" en la compra.
                //movimentVendaVinculatTraspas.Prod.MovimentsTraspas.Add(moviment);

                // Asigno valor a "RefTraspasId" en la venda.
                novaCompra.RefTraspas1.Add(movimentVendaVinculatTraspas);

                // Asigno valor a "RefTraspasId" en la compra.
                movimentVendaVinculatTraspas.RefTraspas1.Add(novaCompra);
            }

            this.Moviments.Add(novaCompra); // Carrega les referències.
            connexio.Entry(novaCompra).Reference(c => c.Prod).Load();

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio, false);

            connexio.SaveChanges();

            novaCompra.desgloçarCompra(connexio, movimentVendaVinculatTraspas);

            return novaCompra;
        }


        /// <summary>
        /// Venda. No s'utilitza ens traspassos.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="pigVendaReal"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        internal Moviment desaVenda(InversionsBDContext connexio, DateTime data, TimeSpan hora, decimal participacions, decimal preuParticipacio
            , decimal canviAplicat, decimal? despeses, decimal? pigVendaReal, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = Utilitats.FormaData(data, hora);

            return desaVenda(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, afegeigPreuAValoracions
                , mostraFinestraAdvertencia, pigVendaReal);
        }


        /// <summary>
        /// Venda o traspàs venda.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <param name="pigVendaReal"></param>
        /// <returns></returns>
        private Moviment desaVenda(InversionsBDContext connexio, DateTime dataHora, decimal participacions, decimal preuParticipacio,
            decimal canviAplicat, decimal? despeses, string descripcio, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia,
            decimal? pigVendaReal = null)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id; // Utilitzo Id perquè "Usuari.Seleccionat" està en un context diferent.
            moviment.TipusMoviment = TipusMoviment.Venda;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.PiGVendaReal = pigVendaReal;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;

            this.Moviments.Add(moviment);
            connexio.Entry(moviment).Reference(c => c.Prod).Load(); // Carrega les referències.

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio, false);

            connexio.SaveChanges();

            return moviment;
        }


        internal Moviment desaDividend(InversionsBDContext connexio, DateTime dataHora, decimal importTotalDividend, decimal canviAplicat, decimal? despeses, string descripcio)
        {
            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Dividends;
            moviment.ProdId = this.Id;
            moviment.Participacions = 0;
            moviment.PreuParticipacio = importTotalDividend;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;

            connexio.Moviments.Add(moviment);
            //connexio.SaveChanges();

            return moviment;
        }


        /// <summary>
        /// Split de les accions en cartera del producte
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="factorConversor"></param>
        internal void split(InversionsBDContext connexio, DateTime dataHora, int factorConversor)
        {
            if (!(this is ProdAccions))
                throw new ApplicationException("No és una acció. Només es pot fer l'split si és una acció.");

            var descripcio = String.Format("{0}. Factor conversor: {1}.", "Split", factorConversor);
            var compres = basicCompresDePartipacionsEnData4(dataHora, _Participacions).ToList();

            foreach (var compraExt in compres)
            {
                var mov1 = connexio.Moviments.Find(compraExt._Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.Split; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int particSplit = (int) compraExt._PartsUtilitzades;
                int particSenseSplit = (int) mov1.Participacions - particSplit;

                decimal despesesSenseSplit = 0;

                if (particSenseSplit > 0)
                {
                    // Creo una nova compra amb la part de la compra original que no li afecta el Split
                    data1 = data1.AddSeconds(1);
                    despesesSenseSplit = (mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseSplit);

                    desaCompra(connexio, data1, particSenseSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseSplit, descripcio, null, false, false);
                }

                // Calculo el nou preu i les participacions del Split i creo una compra amb les participacions afectades.
                data1 = data1.AddSeconds(1);
                int participacions = particSplit * factorConversor;
                decimal preuParticipacio = (mov1.PreuParticipacio / factorConversor);
                decimal despesesSplit = (mov1.Despeses.GetValueOrDefault() - despesesSenseSplit);
                desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesSplit, descripcio, null, false, false);
            }

            // Modifico les valoracions a partir de la data del Split.
            var dataPrimeraCompra = compres.First()._Data;
            modificaValoracions(connexio, TipusMoviment.Split, dataPrimeraCompra.Date, factorConversor);

            //connexio.SaveChanges();
        }


        /// <summary>
        /// ContraSplit de les accions en cartera del producte
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="factorConversor"></param>
        /// <param name="preuOperacio"></param>
        /// <param name="canviAplicat"></param>
        internal void contraSplit(InversionsBDContext connexio, DateTime dataHora, int factorConversor, decimal preuOperacio, decimal canviAplicat)
        {
            if (!(this is ProdAccions))
                throw new ApplicationException("No és una acció. Només es pot fer l'split si és una acció.");

            var descripcio = String.Format("{0}. Factor conversor: {1}. Preu operació: {2}.", "ContraSplit", factorConversor, preuOperacio);
            var compresAnt = basicCompresDePartipacionsEnData4(dataHora, _Participacions).ToList();

            foreach (var compraExt in compresAnt)
            {
                var mov1 = connexio.Moviments.Find(compraExt._Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.ContraSplit; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int partRestants = (int) compraExt._PartsUtilitzades % factorConversor; // Calculo el número de participacions que sobren i s'hauran de vendre.
                int particContraSplit = (int) compraExt._PartsUtilitzades - partRestants;
                int particSenseContraSplit = (int) mov1.Participacions - particContraSplit;

                decimal despesesSenseContraSplit = 0;

                if (particSenseContraSplit > 0)
                {
                    data1 = data1.AddSeconds(1);
                    despesesSenseContraSplit = (mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseContraSplit);

                    // Creo una nova compra amb la part de la compra original que no li afecta el ContraSplit
                    desaCompra(connexio, data1, particSenseContraSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseContraSplit, descripcio, null, false, false);
                }


                if (partRestants > 0)
                {
                    // Venc les participacions restants.
                    data1 = data1.AddSeconds(1);
                    var ven = desaVenda(connexio, data1, partRestants, preuOperacio, canviAplicat, 0, descripcio, false, false);
                }


                if (particContraSplit > 0)
                {
                    // Creo una compra amb el nou numero de participacions i nou preu.
                    data1 = data1.AddSeconds(1);
                    int participacions = particContraSplit / factorConversor;
                    var preuParticipacio = (mov1.PreuParticipacio * factorConversor); // Calculo el nou preu i les participacions del contraSplit
                    decimal despesesContraSplit = (mov1.Despeses.GetValueOrDefault() - despesesSenseContraSplit);
                    desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesContraSplit, descripcio, null, false, false);
                }
            }

            // Modifico les valoracions a partir de la data del ContraSplit.
            var dataPrimeraCompra = compresAnt.First()._Data;
            modificaValoracions(connexio, TipusMoviment.ContraSplit, dataPrimeraCompra.Date, factorConversor);

            //connexio.SaveChanges();
        }


        /// <summary>
        /// Afegeig un preu a la taula "Valoracions"
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="sobreescriuSiExisteix">Indica que se sobreescriurà la valoració si ja existeix.</param>
        private void afegeigPreuAValoracions(InversionsBDContext connexio, DateTime dataHora, decimal preuParticipacio, bool sobreescriuSiExisteix)
        {
            // Crea una valoració amb el preu del moviment
            Valoracio val = ValoracionsProducte.SingleOrDefault(a => a.Data.Date == dataHora.Date);
            if (val == null)
            {
                try
                {
                    Valoracio.Nova(connexio, this, dataHora, preuParticipacio);
                }
                catch (SqlException ex)
                {
                    if (ex.Number != 2627) // Si Duplicate Key en Valoracions no fa cas
                        throw;
                }
            }
            else if (sobreescriuSiExisteix)
                val.modifica(connexio, dataHora, preuParticipacio);
        }


        /// <summary>
        /// Modifica les valoracions al fer Split o ContraSplit
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="tipusMoviment"></param>
        /// <param name="dataPrimeraCompra"></param>
        /// <param name="factorConversor"></param>
        private void modificaValoracions(InversionsBDContext connexio, TipusMoviment tipusMoviment, DateTime dataPrimeraCompra, int factorConversor)
        {
            foreach (var valoracio in connexio.Valoracions.Where(w => w.ProdId == Id && w.Data >= dataPrimeraCompra.Date))
            {
                if (tipusMoviment == TipusMoviment.ContraSplit)
                    valoracio.PreuParticipacio = (valoracio.PreuParticipacio * factorConversor);
                else if (tipusMoviment == TipusMoviment.Split)
                    valoracio.PreuParticipacio = (valoracio.PreuParticipacio / factorConversor);
                else
                    throw new ArgumentException("Paràmetre incorrecte", "tipusMoviment");

                connexio.Valoracions.AddOrUpdate(valoracio);
            }
        }

        #endregion *** Mètodes que modifiquen la BD ***


        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Producte a, Producte b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null,return false.
            if ((object) a == null || (object) b == null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(Producte a, Producte b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Producte))
                return false;

            return this == (Producte) obj;
        }

        public override string ToString()
        {
            return _NomProducte;
        }

        public int CompareTo(Producte other)
        {
            if (Id < other.Id)
                return -1;
            return Id > other.Id ? 1 : 0;
        }

        #endregion


        #region **** Mètodes cridats des de Test *****

        public decimal partsEnCarteraTest(DateTime? dataHora = null)
        {
            return partsEnCartera(dataHora);
        }


        public decimal numParticipacionsEnDataTest(DateTime? data = null)
        {
            return partsEnCartera(data);
        }

        #endregion
    }
}
