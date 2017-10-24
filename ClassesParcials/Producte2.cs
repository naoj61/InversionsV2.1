using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        private struct MovimentCompra
        {
            public Moviment _Moviment { get; private set; }
            public double _ParticipacionsDisponibles { get; private set; }

            public MovimentCompra(Moviment moviment, double participacionsDisponibles) : this()
            {
                _Moviment = moviment;
                _ParticipacionsDisponibles = participacionsDisponibles;
            }

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
        /// Torma una llista amb les Compres o "Traspassos compres" de la venda del paràmetre.
        /// </summary>
        /// <param name="venda"></param>
        /// <returns></returns>
        private IEnumerable<MovimentCompra> compresAnteriors(Moviment venda)
        {
            if(venda.TipusMoviment != TipusMoviment.Venda)
                throw new ArgumentException("El moviment ha de ser una venda.", "venda");

            return compresAnteriors(venda.Data, venda.Participacions);
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora, fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        private IEnumerable<MovimentCompra> compresAnteriors(DateTime dataHora, double? numParticipacions = null)
        {
            double participacions = numParticipacions.HasValue ? numParticipacions.Value : numParticipacionsEnData(dataHora);
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();
            
            if (participacions <= 0)
                return compresAmbParticipacio;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = MovimentsProducteUsuari.Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
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


        /// <summary>
        /// Calcula el preu de compra origen d'un moviment de compra, venda, traspàs.
        /// </summary>
        /// <param name="moviment"></param>
        /// <returns></returns>
        internal double calculaPreuOrigen(Moviment moviment)
        {
            double valorRetorn;

            if (moviment.TipusMoviment == TipusMoviment.Compra)
            {
                if (moviment.MovimentRefVenda == null)
                {
                    valorRetorn = moviment.PreuParticipacio;
                }
                else
                {
                    if (moviment.MovimentRefVenda.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'movimentVendaVinculatCompra' és NULL i hauria de tenir algún valor.");

                    valorRetorn = moviment.MovimentRefVenda.PreuParticipacioOrigen.Value * moviment.MovimentRefVenda.Participacions / moviment.Participacions;
                }
            }
            else
            {
                double x = 0;
                double y = 0;

                foreach (var compra in compresAnteriors(moviment.Data, moviment.Participacions))
                {
                    if (compra._Moviment.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'compra._Moviment.PreuParticipacioOrigen' és NULL i hauria de tenir algún valor. Id moviment: " + compra._Moviment.Id);

                    x += compra._ParticipacionsDisponibles * compra._Moviment.PreuParticipacioOrigen.Value;
                    y += compra._ParticipacionsDisponibles;
                }
                valorRetorn = x / y;
            }

            return Math.Round(valorRetorn, 4);
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
            var valoracions = ValoracionsProducte.Where(w => w.Data <= data).Select(val => new {val.Data, val.PreuParticipacio});
            
            var moviments = MovimentsProducte.Where(w => w.Data <= data && (w.TipusMoviment == TipusMoviment.Compra || w.TipusMoviment == TipusMoviment.Venda))
                .Select(mov => new {mov.Data, mov.PreuParticipacio});

            var tot = valoracions.Union(moviments).OrderBy(o=>o.Data).ToList();

            if(tot.Any())
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

            moviment.PreuParticipacioOrigen = calculaPreuOrigen(moviment); // Després del Add per tenir les referèmcies creades.

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
            moviment.ProducteTraspasId = prodCompraMovimentVinculatTraspas == null ? (int?) null : prodCompraMovimentVinculatTraspas.Id;

            connexio.Moviments.Add(moviment); // Carrega les referències.

            moviment.PreuParticipacioOrigen = calculaPreuOrigen(moviment); // Després del Add per tenir les referèmcies creades.

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
            if(!(this is ProdAccions))
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


        internal static double Pig(TipusProducte tipusProducte, DateTime dataFinal)
        {
            double pig = 0;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pig(dataFinal));
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pig(dataFinal));
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
                    var compresAnt = compresAnteriors(venda);
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
            if(particEnCarteraFinal > 0)
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

            var totalVendes = MovimentsProducteUsuari.
                Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Venda && !w._EsTraspas).
                Sum(s => s.Participacions * (s.PreuParticipacio - s.PreuParticipacioOrigen.GetValueOrDefault()));

            double totalDividends = 0;
            double totalDespeses = 0;
            if (this is ProdAccions)
            {
                var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Venda && !w._EsTraspas).ToList();
                foreach (var venda in vendes)
                {
                    totalDespeses += venda.Despeses.GetValueOrDefault();
                    var compresAnt = compresAnteriors(venda);
                    foreach (MovimentCompra movimentCompra in compresAnt)
                    {
                        totalDespeses += movimentCompra._Moviment.Despeses.GetValueOrDefault() * movimentCompra._ParticipacionsDisponibles / movimentCompra._Moviment.Participacions;
                    }
                }

                totalDividends = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Dividends).Sum(s => s.PreuParticipacio);
            }


            return Math.Round(totalVendes + totalDividends - totalDespeses, 3);
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
    }
}
