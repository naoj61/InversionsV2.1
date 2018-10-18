using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        #region Variables

        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; set;}
        public abstract string _TipusNomProducte { get; }
        public abstract Mercat _Mercat { get; set; }
        public abstract string _NomMercat { get; }
        public abstract string _Isin { get; }
        public abstract string _Descripcio { get; }

        public IEnumerable<Moviment> MovimentsProducteUsuari
        {
            get { return MovimentsProducte.Where(w => w.UsuariId == Usuari.Seleccionat.Id); }
        }

        public struct PiGPerCompra
        {
            public PiGPerCompra(Moviment compra, Moviment venda, double participacions, bool hisenda)
                : this()
            {
                _Hisenda = hisenda;
                _Compra = compra;
                _Venda = venda;
                _DataCompra = compra.Data;

                if (compra.TipusMoviment == TipusMoviment.Dividends)
                {
                    _PiG = compra.ImportNet;
                    _PreuVenda = compra.ImportNet;
                }
                else
                {
                    _DataVenda = venda == null ? (DateTime?)null : venda.Data;
                    _Participacions = participacions;
                    _PreuUnitariCompra = compra._PreuParticipacio;
                    _PreuUnitariVenda = venda == null ? 0 : venda._PreuParticipacio;
                    _PreuCompra = participacions * compra._PreuParticipacio;
                    _PreuVenda = venda == null ? 0 : participacions * venda._PreuParticipacio;
                    //_Despeses = (compra.Despeses.GetValueOrDefault(0) / compra.Participacions * participacions) + (venda == null ? 0 : (venda.Despeses.GetValueOrDefault(0) / venda.Participacions * participacions));
                    _DespesesC = (compra.Despeses.GetValueOrDefault(0) / compra.Participacions * participacions);
                    _DespesesV = (venda == null ? 0 : (venda.Despeses.GetValueOrDefault(0) / venda.Participacions * participacions));
                    _PiG = venda == null ? 0 : ((participacions * venda._PreuParticipacio) - (participacions * compra._PreuParticipacio) - (_DespesesC + _DespesesV));
                }
                ImpAcc += _PiG;
                _PiGAcumulat = ImpAcc;
            }

            private static double ImpAcc = 0;

            public string _Moviment
            {
                get { return _Compra.TipusMoviment.ToString(); }
            }

            public DateTime _DataCompra { get; private set; }
            public DateTime? _DataVenda { get; private set; }
            public double _Participacions { get; private set; }
            public Moviment _Compra { get; private set; }
            public Moviment _Venda { get; private set; }
            public double _PreuUnitariCompra { get; private set; }
            public double _PreuUnitariVenda { get; private set; }
            public double _PreuCompra { get; private set; }
            public double _PreuVenda { get; private set; }
            public double _DespesesC { get; private set; }
            public double _DespesesV { get; private set; }
            public double _PiG { get; private set; }
            public bool _Hisenda { get; private set; }
            public double _PiGAcumulat { get; private set; }


            /// <summary>
            /// Si és un traspà torna null.
            /// </summary>
            public DateTime? _DataVendaReal
            {
                get { return _Hisenda && _DataVenda.HasValue ? _DataVenda : null; }
            }

            /// <summary>
            /// Si hi ha data venda la torna sinò, torna la data compra.
            /// </summary>
            public DateTime? _DataMovimentReal
            {
                get { return _DataVenda.HasValue ? _DataVenda : _DataCompra; }
            }


            /// <summary>
            /// Si és una venda torna null
            /// </summary>
            public DateTime? _DataTraspas
            {
                get { return !_Hisenda && _DataVenda.HasValue ? _DataVenda : null; }
            }

            public bool _LlargPlaç
            {
                get { return _DataVenda.HasValue && _DataCompra.AddYears(1) <= _DataVenda.Value; }
            }

            //public double _PiGActual
            //{
            //    get { return _Compra.Prod.pigValorat(DateTimeFinalDia.Today); }
            //}

            public string _Termini
            {
                get { return !_Hisenda ? null : _LlargPlaç ? "Llarg" : "Curt"; }
            }

            public static void InicialitzaAcumulat()
            {
                ImpAcc = 0;
            }
        }

        public enum TipusProducte
        {
            Tots = 0,
            Accions = 1,
            Fons = 2
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
        public double _Participacions
        {
            get { return numParticipacionsEnData(DateTime.Today); }
        }


        /// <summary>
        /// És el valor de les participacions avui.
        /// </summary>
        public double _ValorActual
        {
            get { return valorEnCartera(DateTime.MaxValue); }
        }
        
        #endregion


        internal double dividends(DateTime dataFi)
        {
            return MovimentsProducteUsuari.Where(w => w._EsDividents && w.Data < Utilitats.DataFinalDia(dataFi)).Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal double numParticipacionsEnData(DateTime data)
        {
            var particComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var particVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);
            return particComprades - particVenudes;
        }


        /// <summary>
        /// Calcula les PiG d'un producte per cada compra feta i torna una llista.
        /// </summary>
        /// <returns></returns>
        public List<PiGPerCompra> pigPerCompra()
        {
            /* Quan hi ha una venda Pot ser que no sigui total i que les accions venudes tinguin diferents preus de compra
             * Pot ser que una compra tingui zero, una o varies vendes.
             * Pot ser que una venda tingui una o varies compres.
            */

            var piG = new List<PiGPerCompra>();

            var compres = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data));
            var vendes = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Venda).OrderBy(o => o.Data));

            if (!compres.Any())
            {
                if (vendes.Any())
                    throw new ApplicationException("Error. Hi ha vendes, però ni hi ha cap compra.");

                // No hi ha moviments.
                return piG;
            }


            var compra = compres.Dequeue();
            double participacionsCompradesRestants = compra.Participacions;

            Moviment venda = null;
            double participacionsVenudesRestants = 0;
            if (vendes.Any())
            {
                venda = vendes.Dequeue();
                participacionsVenudesRestants = venda.Participacions;
            }

            do
            {
                if (participacionsCompradesRestants > 0 && participacionsVenudesRestants > 0)
                {
                    if (compra.Data > venda.Data)
                        throw new ApplicationException("Error. La data de compra no pot ser mes gran que la de venda.");


                    if (participacionsVenudesRestants <= participacionsCompradesRestants)
                    {
                        // Hi ha mes participacions comprades que les que queden per vendre.

                        var part = participacionsVenudesRestants;

                        piG.Add(new PiGPerCompra(compra, venda, part, !venda._EsTraspas));

                        participacionsCompradesRestants = Math.Round(participacionsCompradesRestants - part, 4);
                        participacionsVenudesRestants = 0;

                        if (Math.Abs(participacionsCompradesRestants) < 0.0001) // Equival a participacionsCompradesRestants == 0
                        {
                            if (compres.Any())
                            {
                                compra = compres.Dequeue();
                                participacionsCompradesRestants = compra.Participacions;
                            }
                        }

                        if (vendes.Any())
                        {
                            venda = vendes.Dequeue();
                            participacionsVenudesRestants = venda.Participacions;
                        }
                    }
                    else
                    {
                        // Hi ha mes participacions per vendre que les comprades en aquest moviment.

                        var part = participacionsCompradesRestants;

                        piG.Add(new PiGPerCompra(compra, venda, part, !venda._EsTraspas));

                        if (Math.Abs(part) < 1)
                        {
                        }

                        participacionsCompradesRestants = 0;
                        participacionsVenudesRestants = Math.Round(participacionsVenudesRestants - part, 4);

                        if (compres.Any())
                        {
                            compra = compres.Dequeue();
                            participacionsCompradesRestants = compra.Participacions;
                        }
                    }
                }
                else if (participacionsCompradesRestants > 0)
                {
                    //piG.Add(new PiG(compra, null, participacionsCompradesRestants,false));
                    participacionsCompradesRestants = 0;

                    if (compres.Any())
                    {
                        compra = compres.Dequeue();
                        participacionsCompradesRestants = compra.Participacions;
                    }
                }
                else if (participacionsVenudesRestants > 0)
                {
                    throw new ApplicationException("Error. No hauria d'entrar aquí.");
                }
            } while (compres.Any() || vendes.Any() || participacionsVenudesRestants > 0);


            foreach (var divident in MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Dividends).OrderBy(o => o.Data))
            {
                piG.Add(new PiGPerCompra(divident, null, 0, true));
            }

            // Faig que acumuli les PiG en l'ordre real de la data del moviment.
            var piG2 = new List<PiGPerCompra>();
            PiGPerCompra.InicialitzaAcumulat();
            foreach (var g in piG.OrderBy(o => o._DataMovimentReal))
            {
                piG2.Add(new PiGPerCompra(g._Compra, g._Venda, g._Participacions, g._Hisenda));
            }

            return piG2;
        }

        /// <summary>
        /// Afegeig un preu a la taula "Valoracions"
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="preuParticipacio"></param>
        private void afegeigPreuAValoracions(InversionsBDContext connexio, DateTime dataHora, double preuParticipacio)
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
            else
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
                    valoracio.PreuParticipacio = Math.Round(valoracio.PreuParticipacio * factorConversor, 4);
                else if (tipusMoviment == TipusMoviment.Split)
                    valoracio.PreuParticipacio = Math.Round(valoracio.PreuParticipacio / factorConversor, 4);
                else
                    throw new ArgumentException("Paràmetre incorrecte", "tipusMoviment");

                connexio.Valoracions.AddOrUpdate(valoracio);
            }
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data hora actual.
        /// </summary>
        /// <returns></returns>
        internal double valorParticipacio()
        {
            return valorParticipacio(DateTime.Now);
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double valorParticipacio(DateTime data)
        {
            var valoracions = ValoracionsProducte.Where(w => w.Data <= data).Select(val => new { val.Data, val.PreuParticipacio });

            var moviments = MovimentsProducte.Where(w => w.Data <= data && (w.TipusMoviment == TipusMoviment.Compra || w.TipusMoviment == TipusMoviment.Venda))
                .Select(mov => new { mov.Data, mov.PreuParticipacio });

            var tot = valoracions.Union(moviments).OrderBy(o => o.Data).ToList();

            if (tot.Any())
            {
                return tot.Last().PreuParticipacio;
            }

            //throw new ApplicationException("No hi ha cap moviment ni cap valoració disponibles.");
            return 0;
        }


        /// <summary>
        /// Validacions en Compres o Vendes.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        private void validacionsCompraVenda(InversionsBDContext connexio, DateTime dataHora, double participacions, bool mostraFinestraAdvertencia)
        {
            if (connexio == null)
                throw new ArgumentNullException("connexio");

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
        internal void desaTraspas(InversionsBDContext connexio, DateTime dataHoraVenda, double participacionsVenda, double preuParticipacioVenda, string descripcio,
            DateTime dataHoraCompra, Producte prodCompra, double participacionsCompra)
        {
            dataHoraVenda = Utilitats.ArrodoneixoDataASegons(dataHoraVenda);
            dataHoraCompra = Utilitats.ArrodoneixoDataASegons(dataHoraCompra);

            if (dataHoraVenda == dataHoraCompra)
                dataHoraCompra = dataHoraCompra.AddSeconds(1);


            double preuParticipacioCompra = Math.Round(preuParticipacioVenda * participacionsVenda / participacionsCompra, 4);

            var venda = this.desaVenda(connexio, dataHoraVenda, participacionsVenda, preuParticipacioVenda, 1, null, descripcio, prodCompra, false, true);
            var compra = prodCompra.desaCompra(connexio, dataHoraCompra, participacionsCompra, preuParticipacioCompra, 1, null, descripcio, venda, false, true);
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
        internal Moviment desaCompra(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
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
        private Moviment desaCompra(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Moviment movimentVendaVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Compra;
            moviment.ProdId = this.Id;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            if (movimentVendaVinculatTraspas != null)
            {
                moviment.ProducteTraspas = movimentVendaVinculatTraspas.ProducteTraspas;
                moviment.MovimentRefVenda = movimentVendaVinculatTraspas; // Assigno la instancia i no l'Id, perque "movimentVendaVinculatTraspas.Id" és 0 i dona error de FK al fer el save.
            }
            connexio.Moviments.Add(moviment); // Carrega les referències. S'ha de fer abans de: calculaPreuOrigen(moviment)

            moviment.PreuParticipacioOrigen = moviment.calculaPreuOrigen(); // Després del Add per tenir les referèmcies creades.

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            return moviment;
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
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        internal Moviment desaVenda(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = Utilitats.FormaData(data, hora);

            return desaVenda(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions, mostraFinestraAdvertencia);
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
        /// <param name="prodCompraMovimentVinculatTraspas">Si != NULL, és un traspàs.</param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        private Moviment desaVenda(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Producte prodCompraMovimentVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Venda;
            moviment.ProdId = Id;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            moviment.ProducteTraspasId = prodCompraMovimentVinculatTraspas == null ? (int?)null : prodCompraMovimentVinculatTraspas.Id;

            connexio.Moviments.Add(moviment); // Carrega les referències.

            moviment.PreuParticipacioOrigen = moviment.calculaPreuOrigen(); // Després del Add per tenir les referèmcies creades.

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            return moviment;
        }


        internal Moviment desaDividend(InversionsBDContext connexio, DateTime dataHora, double importTotalDividend, double canviAplicat, double? despeses, string descripcio)
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
            var compres = compresAnteriors(dataHora, _Participacions).ToList();

            foreach (var movimentCompra in compres)
            {
                var mov1 = connexio.Moviments.Find(movimentCompra._Moviment.Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.Split; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int particSplit = (int)movimentCompra._ParticipacionsDisponibles;
                int particSenseSplit = (int)mov1.Participacions - particSplit;

                double despesesSenseSplit = 0;

                if (particSenseSplit > 0)
                {
                    // Creo una nova compra amb la part de la compra original que no li afecta el Split
                    data1 = data1.AddSeconds(1);
                    despesesSenseSplit = Math.Round(mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseSplit, 4);

                    desaCompra(connexio, data1, particSenseSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseSplit, descripcio, null, false, false);
                }

                // Calculo el nou preu i les participacions del Split i creo una compra amb les participacions afectades.
                data1 = data1.AddSeconds(1);
                int participacions = particSplit * factorConversor;
                double preuParticipacio = Math.Round(mov1.PreuParticipacio / factorConversor, 4);
                double despesesSplit = Math.Round(mov1.Despeses.GetValueOrDefault() - despesesSenseSplit, 4);
                desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesSplit, descripcio, null, false, false);
            }


            // Modifico les valoracions a partir de la data del Split.
            var dataPrimeraCompra = compres.First()._Moviment.Data;
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
        internal void contraSplit(InversionsBDContext connexio, DateTime dataHora, int factorConversor, double preuOperacio, double canviAplicat)
        {
            if (!(this is ProdAccions))
                throw new ApplicationException("No és una acció. Només es pot fer l'split si és una acció.");

            var descripcio = String.Format("{0}. Factor conversor: {1}. Preu operació: {2}.", "ContraSplit", factorConversor, preuOperacio);
            var compresAnt = compresAnteriors(dataHora, _Participacions).ToList();

            foreach (var movimentCompra in compresAnt)
            {
                var mov1 = connexio.Moviments.Find(movimentCompra._Moviment.Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.ContraSplit; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int partRestants = (int)movimentCompra._ParticipacionsDisponibles % factorConversor; // Calculo el número de participacions que sobren i s'hauran de vendre.
                int particContraSplit = (int)movimentCompra._ParticipacionsDisponibles - partRestants;
                int particSenseContraSplit = (int)mov1.Participacions - particContraSplit;

                double despesesSenseContraSplit = 0;

                if (particSenseContraSplit > 0)
                {
                    data1 = data1.AddSeconds(1);
                    despesesSenseContraSplit = Math.Round(mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseContraSplit, 4);

                    // Creo una nova compra amb la part de la compra original que no li afecta el ContraSplit
                    desaCompra(connexio, data1, particSenseContraSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseContraSplit, descripcio, null, false, false);
                }

                if (particContraSplit > 0)
                {
                    // Creo una compra amb el nou numero de participacions i nou preu.
                    data1 = data1.AddSeconds(1);
                    int participacions = particContraSplit / factorConversor;
                    var preuParticipacio = Math.Round(mov1.PreuParticipacio * factorConversor, 4); // Calculo el nou preu i les participacions del contraSplit
                    double despesesContraSplit = Math.Round(mov1.Despeses.GetValueOrDefault() - despesesSenseContraSplit, 4);
                    desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesContraSplit, descripcio, null, false, false);
                }


                if (partRestants > 0)
                {
                    // Venc les participacions restants.
                    data1 = data1.AddSeconds(1);
                    var ven = desaVenda(connexio, data1, partRestants, preuOperacio, canviAplicat, 0, descripcio, null, false, false);
                    ven.PreuParticipacioOrigen = mov1.PreuParticipacioOrigen.GetValueOrDefault(); // Modifico el PreuParticipacioOrigen.
                }
            }

            // Modifico les valoracions a partir de la data del ContraSplit.
            var dataPrimeraCompra = compresAnt.First()._Moviment.Data;
            modificaValoracions(connexio, TipusMoviment.ContraSplit, dataPrimeraCompra.Date, factorConversor);

            //connexio.SaveChanges();
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora, fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        internal IEnumerable<MovimentCompra> compresAnteriors(DateTime dataHora, double? numParticipacions = null)
        {
            double participacions = numParticipacions.HasValue ? numParticipacions.Value : numParticipacionsEnData(dataHora);
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();

            if (participacions <= 0)
                return compresAmbParticipacio;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = MovimentsProducteUsuari
                .Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
            var trobadaPrimeraCompra = false;

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
            var xx = MovimentsProducteUsuari.Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList();
            foreach (var compra in xx)
            {
                if (!trobadaPrimeraCompra)
                {
                    if (participVenudesAbans >= compra.Participacions)
                    {
                        // Son les participacions que ja estan venude per una venda anterior.
                        participVenudesAbans -= compra.Participacions;
                    }
                    else
                    {
                        var part = compra.Participacions - participVenudesAbans;
                        if (part > participacions)
                            part = participacions;
                        compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                        participacions -= part;
                        trobadaPrimeraCompra = true;
                    }
                }
                else
                {
                    //double part = participacions > compra.Participacions ? participacions - compra.Participacions : participacions;
                    double part = participacions > compra.Participacions ? compra.Participacions : participacions;
                    compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                    participacions -= part;
                }

                if (Utilitats.EsZero(participacions))
                    break;
            }

            if (participacions > 0.0000001)
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera en aquesta data: " + dataHora.ToShortDateString() + " " + dataHora.ToShortTimeString());

            return compresAmbParticipacio;
        }


        internal static double Pig(DateTime? dataInici = null, DateTime? dataFinal = null)
        {
            return Pig(TipusProducte.Tots, dataInici.GetValueOrDefault(DateTime.MinValue), dataFinal.GetValueOrDefault(DateTime.MaxValue));
        }

        internal static double Pig(TipusProducte tipusProducte, DateTime dataFinal)
        {
            return Pig(tipusProducte, DateTime.MinValue, dataFinal);
        }


        internal static double Pig(TipusProducte tipusProducte, DateTime dataInici, DateTime dataFinal)
        {
            double pig = 0;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pig(dataInici, dataFinal));
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pig(dataInici, dataFinal));
            }

            return pig;
        }


        public static double Pig(TipusProducte tipusProducte, int? any = null)
        {
            double pig = 0;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                if (any.HasValue)
                    pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pig(any.Value));
                else
                    pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pig());
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                if (any.HasValue)
                    pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pig(any.Value));
                else
                    pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pig());
            }

            return pig;
        }


        /// <summary>
        /// PiG de tots els moviments del producte.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        internal double pig(DateTime? dataInici = null, DateTime? dataFi = null)
        {
            return pig(dataInici.GetValueOrDefault(DateTime.MinValue), dataFi.GetValueOrDefault(DateTime.MaxValue));
        }


        /// <summary>
        /// Quant ha guanyat en un periode. (Vendes o vendesT dins el periode) + (participacions en cartera al final del periode).
        /// Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
        /// Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
        /// </summary>
        /// <param name="any">Del 1 de gener al 31 de desembre de l'any.</param>
        /// <returns></returns>
        internal double pig(int any)
        {
            return pig(new DateTime(any, 1, 1), new DateTime(any, 12, 31));
        }


        /// <summary>
        /// PiG dels moviments amb data igual o anterior a dataFinal.
        /// </summary>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal double pig(DateTime dataFinal)
        {
            return pig(DateTime.MinValue, dataFinal);
        }


        /// <summary>
        /// Quant ha guanyat en un periode. (Vendes o vendesT dins el periode) + (participacions en cartera al final del periode).
        /// Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
        /// Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        private double pig(DateTime dataInici, DateTime dataFinal)
        {
            var dInici = dataInici.Date; // Poso la d'inici hora a zero.
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var compres = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Compra).ToList();
            var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Venda).ToList();

            double totalDividends = 0;
            double totalDespeses = 0;
            if (this is ProdAccions)
            {
                foreach (var venda in vendes)
                {
                    totalDespeses += venda.Despeses.GetValueOrDefault();
                    var compresAnt = venda.compresAnteriors();
                    foreach (MovimentCompra movimentCompra in compresAnt)
                    {
                        totalDespeses += movimentCompra._Moviment.Despeses.GetValueOrDefault() * movimentCompra._ParticipacionsDisponibles / movimentCompra._Moviment.Participacions;
                    }
                }

                totalDividends = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Dividends).Sum(s => s.PreuParticipacio);
            }

            // Calcula total compres mes valor en cartera a l'inici.
            // Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
            var particEnCarteraInicial = numParticipacionsEnData(dInici);
            double valorInicialParticEnCartera = 0;
            if (particEnCarteraInicial > 0)
            {
                var dataValoracio = dInici == DateTime.MinValue ? dInici : dInici.AddTicks(-1); // Necessito la valoració anterior a la data dinici.
                valorInicialParticEnCartera = valorParticipacio(dataValoracio) * particEnCarteraInicial;
            }

            var importCompres = compres.Sum(s => s.Participacions * s.PreuParticipacio) + valorInicialParticEnCartera;

            // Calcula total vendes mes valor en cartera al final.
            // Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
            var particEnCarteraFinal = numParticipacionsEnData(dFinal);
            double valorFinalParticEnCartera = 0;
            if (particEnCarteraFinal > 0)
                valorFinalParticEnCartera = valorParticipacio(dFinal) * particEnCarteraFinal;
            var importVendes = vendes.Sum(s => s.Participacions * s.PreuParticipacio) + valorFinalParticEnCartera;

            return importVendes - importCompres + totalDividends - totalDespeses;
        }


        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="any"></param>
        /// <returns></returns>
        public static double PigTributa(TipusProducte? tipusProducte = null, int? any = null)
        {
            double pig = 0;

            tipusProducte = tipusProducte.HasValue ? tipusProducte : TipusProducte.Tots;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                if (any.HasValue)
                    pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pigTributa(any.Value));
                else
                    pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pigTributa());
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                if (any.HasValue)
                    pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pigTributa(any.Value));
                else
                    pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pigTributa());
            }

            return pig;
        }


        /// <summary>
        /// PiG que tributen. Vendes reals de qualsevol periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <returns></returns>
        internal double pigTributa()
        {
            return pigTributa(DateTime.MinValue, DateTime.MaxValue);
        }


        /// <summary>
        /// PiG que tributen en un periode. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double pigTributa(int any)
        {
            return pigTributa(new DateTime(any, 1, 1), new DateTime(any, 12, 31));
        }


        /// <summary>
        /// PiG que tributen en un periode. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        private double pigTributa(DateTime dataInici, DateTime dataFinal)
        {
            var dInici = dataInici.Date; // Poso la d'inici hora a zero.
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var totalCompraVenda = importVenda(dInici, dFinal) - importCompra(dInici, dFinal);

            double totalDividends = 0;
            double totalDespeses = 0;
            if (this is ProdAccions)
            {
                totalDespeses = calculaDespesesCompra(dInici, dFinal) + calculaDespesesVenda(dInici, dFinal);

                totalDividends = calculaDividents(dInici, dFinal);
            }

            return Math.Round(totalCompraVenda + totalDividends - totalDespeses, 3);
        }

        /// <summary>
        /// Calcula la diferencia de compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double importCompra(int any)
        {
            return importCompra(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }

        /// <summary>
        /// Calcula la diferencia de compra/venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double importCompra(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.
                Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).
                Sum(s => s.Participacions * s.PreuParticipacioOrigen.GetValueOrDefault());
        }


        /// <summary>
        /// Calcula la diferencia de compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double importVenda(int any)
        {
            return importVenda(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula la diferencia de compra/venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double importVenda(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.
                Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).
                Sum(s => s.Participacions * s.PreuParticipacio);
        }


        /// <summary>
        /// Calcula les despeses per compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDespesesCompra(int any)
        {
            return calculaDespesesCompra(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula les despeses per compra en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDespesesCompra(DateTime dInici, DateTime dFinal)
        {
            // Calcula despeses i dividents.
            double totalDespeses = 0;
            
            foreach (var venda in MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).ToList())
            {              
                // Despeses de la compra.
                totalDespeses += venda.compresAnteriors()
                    .Sum(movCompra => movCompra._Moviment.Despeses.GetValueOrDefault() * movCompra._ParticipacionsDisponibles / movCompra._Moviment.Participacions);
            }

            return totalDespeses;
        }



        /// <summary>
        /// Calcula les despeses per compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDespesesVenda(int any)
        {
            return calculaDespesesVenda(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula les despeses per venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDespesesVenda(DateTime dInici, DateTime dFinal)
        {
            // Calcula despeses i dividents.
            double totalDespeses = 0;

            foreach (var venda in MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).ToList())
            {
                // Despeses de la venda.
                totalDespeses += venda.Despeses.GetValueOrDefault();
            }

            return totalDespeses;
        }

        /// <summary>
        /// Calcula els dividents en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDividents(int any)
        {
            return calculaDividents(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }

        /// <summary>
        /// Calcula els dividents en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDividents(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsDividents).Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Indica si un producte ha de tributar en un any deterninat.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal bool tributaAquestAny(int any)
        {
            return MovimentsProducteUsuari.Any(w => w.Data.Year == any && (w._EsVendaReal || w._EsDividents));
        }


        /// <summary>
        /// PiG de les perticipacions en cartera a la data. Vendes reals dins el periode.
        /// Preu compra --> Preu compra.
        /// Preu venda  --> Valoració actual.
        /// </summary>
        /// <param name="dataFinal">Si null, dataFinal=DateTime.MaxValue.</param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        internal double pigEnCartera(DateTime? dataFinal = null, double? preuParticipacio = null)
        {
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var participacions = numParticipacionsEnData(dFinal);

            if (Utilitats.EsZero(participacions))
                return 0;

            var compresAnt = compresAnteriors(dFinal, participacions);

            double totalCompres = compresAnt.Sum(compra => compra._ParticipacionsDisponibles * compra._Moviment.PreuParticipacio + compra._Moviment.Despeses.GetValueOrDefault());

            double valorPartic = preuParticipacio.HasValue ? _Participacions * preuParticipacio.Value : valorEnCartera(dFinal);

            return valorPartic - totalCompres;
        }


        /// <summary>
        /// Torna el valor de les participacions en cartera en una data determinada.
        /// </summary>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal double valorEnCartera(DateTime? dataFinal = null)
        {
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var participacions = numParticipacionsEnData(dFinal);

            if (Utilitats.EsZero(participacions))
                return 0;

            return participacions * valorParticipacio(dFinal);
        }


        /// <summary>
        /// Torna les valoracions entre les dates, ponderades si s'indica..
        /// </summary>
        /// <param name="ponderar"></param>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal Dictionary<Valoracio, double> valoracionsPonderades(bool ponderar, DateTime dataInici, DateTime dataFinal)
        {
            var valsProd = ValoracionsProducte
                .Where(w => w.Data >= dataInici && w.Data <= dataFinal)
                .OrderBy(o => o.Data)
                .ToList();

            if (valsProd.Any())
            {
                if (!ponderar)
                    // Sense ponderar.
                    return valsProd.ToDictionary(x => x, x => x.PreuParticipacio);
                const double pond = 10;
                double valorPonderacio = pond / valsProd.First().PreuParticipacio;
                return valsProd.ToDictionary(x => x, x => (x.PreuParticipacio * valorPonderacio) - pond);
            }

            return null;
        }
        

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
    }
}
