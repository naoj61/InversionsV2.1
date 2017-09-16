using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        public struct MovimentCompra
        {
            public Moviment _Moviment { get; private set; }
            public double _ParticipacionsRestants { get; private set; }

            public MovimentCompra(Moviment moviment, double participacionsRestants) : this()
            {
                _Moviment = moviment;
                _ParticipacionsRestants = participacionsRestants;
            }

        }

        /// <summary>
        /// Forma DateTime a partir dels paràmetres data i hora.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hora">Si null, posa la hora actual.</param>
        /// <returns></returns>
        private static DateTime FormaData(DateTime data, TimeSpan? hora)
        {
            return data.Date + (hora.HasValue ? hora.Value : DateTime.Now.TimeOfDay);
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        public IEnumerable<MovimentCompra> compresAnteriors(InversionsBDContext connexio, DateTime? dataHora = null, double? numParticipacions = null)
        {
            DateTime dataH = dataHora.HasValue ? dataHora.Value : DateTime.Now;

            double participacions = numParticipacions.HasValue ? numParticipacions.Value : numParticipacionsEnData(dataH);

            if (participacions <= 0)
                return null;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = connexio.Moviments.Where(w => w.ProdId == Id && w.Data < dataH && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?) s.Participacions) ?? 0;
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();
            var trobadaPrimeraCompra = false;

            var xx = connexio.Moviments.Where(w =>w.IdUsuari == Usuari.Seleccionat.Id && w.ProdId == Id && w.Data < dataH && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList();

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
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
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera en aquesta data: " + dataH.ToShortDateString() + " " + dataH.ToShortTimeString());

            return compresAmbParticipacio;
        }


        /// <summary>
        /// Afegeig un preu a la taula "Valoracions"
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="preuParticipacio"></param>
        public void afegeigPreuAValoracions(InversionsBDContext connexio, DateTime dataHora, double preuParticipacio)
        {
            // Crea una valoració amb el preu del moviment
            Valoracio val = Valoracions.SingleOrDefault(a => a.ProdId == this.Id && a.Data == dataHora.Date);
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
        /// Calcula el preu de compra origen d'un moviment de compra, venda, traspàs.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="moviment"></param>
        /// <param name="movimentVendaVinculatCompra"></param>
        /// <returns></returns>
        public static double CalculaPreuOrigen(InversionsBDContext connexio, Moviment moviment, Moviment movimentVendaVinculatCompra = null)
        {
            double valorRetorn;

            if (moviment.TipusMoviment == TipusMoviment.Compra)
            {
                if (movimentVendaVinculatCompra == null)
                {
                    valorRetorn = moviment.PreuParticipacio;
                }
                else
                {
                    if (movimentVendaVinculatCompra.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'movimentVendaVinculatCompra' és NULL i hauria de tenir algún valor. Id moviment: " + movimentVendaVinculatCompra.Id);

                    valorRetorn = movimentVendaVinculatCompra.PreuParticipacioOrigen.Value * movimentVendaVinculatCompra.Participacions / moviment.Participacions;
                }
            }
            else
            {
                double x = 0;
                double y = 0;

                Producte prod = moviment.Prod ?? connexio.Productes.Single(s => s.Id == moviment.ProdId);
                foreach (var compra in prod.compresAnteriors(connexio, moviment.Data, moviment.Participacions))
                {
                    if (compra._Moviment.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'compra._Moviment.PreuParticipacioOrigen' és NULL i hauria de tenir algún valor. Id moviment: " + compra._Moviment.Id);

                    x += compra._ParticipacionsRestants * compra._Moviment.PreuParticipacioOrigen.Value;
                    y += compra._ParticipacionsRestants;
                }
                valorRetorn = x / y;
            }

            return Math.Round(valorRetorn, 4);
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
        internal void traspas(InversionsBDContext connexio, DateTime dataHoraVenda, double participacionsVenda, double preuParticipacioVenda, string descripcio,
            DateTime dataHoraCompra, Producte prodCompra, double participacionsCompra)
        {
            dataHoraVenda = Utilitats.ArrodoneixoDataASegons(dataHoraVenda);
            dataHoraCompra = Utilitats.ArrodoneixoDataASegons(dataHoraCompra);

            if (dataHoraVenda == dataHoraCompra)
                dataHoraCompra = dataHoraCompra.AddSeconds(1);


            double preuParticipacioCompra = Math.Round(preuParticipacioVenda * participacionsVenda / participacionsCompra, 4);

            var venda = this.venda(connexio, dataHoraVenda, participacionsVenda, preuParticipacioVenda, 1, null, descripcio, prodCompra, false, true);
            var compra = prodCompra.compra(connexio, dataHoraCompra, participacionsCompra, preuParticipacioCompra, 1, null, descripcio, venda, false, true);
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
        internal Moviment compra(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = FormaData(data, hora);

            return compra(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions, mostraFinestraAdvertencia);
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
        private Moviment compra(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Moviment movimentVendaVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
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
                moviment.ProducteTraspasId = movimentVendaVinculatTraspas.ProdId;
                moviment.IdRefVenda = movimentVendaVinculatTraspas.Id;
            }
            moviment.PreuParticipacioOrigen = CalculaPreuOrigen(connexio, moviment, movimentVendaVinculatTraspas);

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

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
        internal Moviment venda(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = FormaData(data, hora);

            return venda(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions, mostraFinestraAdvertencia);
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
        private Moviment venda(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Producte prodCompraMovimentVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Venda;
            moviment.ProdId = Id;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            moviment.ProducteTraspasId = prodCompraMovimentVinculatTraspas == null ? (int?) null : prodCompraMovimentVinculatTraspas.Id;
            moviment.PreuParticipacioOrigen = CalculaPreuOrigen(connexio, moviment);

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            return moviment;
        }


        internal Moviment dividents(InversionsBDContext connexio, DateTime data, TimeSpan hora, double preuParticipacio, double canviAplicat, double? despeses, string descripcio)
        {
            DateTime dataHora = FormaData(data, hora);

            validacionsCompraVenda(connexio, dataHora, 1, false);

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Dividends;
            moviment.ProdId = this.Id;
            moviment.Participacions = 0;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            return moviment;
        }


        internal void split(InversionsBDContext connexio, DateTime dataHora, int factorConversor)
        {
            var descripcio = String.Format("{0}. Factor conversor: {1}.", "ContraSplit", factorConversor);
            var compres = compresAnteriors(connexio, dataHora, _Participacions);

            foreach (var movimentCompra in compres)
            {
                var mov1 = movimentCompra._Moviment;

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.Split; // Modifico el tipus de moviment de la compra.
                connexio.Moviments.AddOrUpdate(mov1);

                var particSenseSplit = mov1.Participacions - movimentCompra._ParticipacionsRestants;
                if (particSenseSplit > 0)
                {
                    data1 = data1.AddSeconds(1);
                    // Creo una nova compra amb la part de la compra original que no li afecta el ContraSplit
                    compra(connexio, data1, particSenseSplit, mov1.PreuParticipacio, mov1.CanviAplicat, 0, descripcio, null, false, false);
                }

                // Calculo el nou preu i les participacions del contraSplit i creo una compra amb les participacions afectades.
                data1 = data1.AddSeconds(1);
                var participacions = Convert.ToInt32(mov1.Participacions - particSenseSplit) * factorConversor;
                var preuParticipacio = Math.Round(mov1.PreuParticipacio / factorConversor, 4);
                compra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, 0, descripcio, null, false, false);
            }

            connexio.SaveChanges();
        }

        internal void contraSplit(InversionsBDContext connexio, DateTime dataHora, int factorConversor, double preuOperacio, double canviAplicat)
        {
            var descripcio = String.Format("{0}. Factor conversor: {1}. Preu operació: {2}.", "ContraSplit", factorConversor, preuOperacio);
            List<double> preuUnitOrigenParticRestants = new List<double>();
            var compres = compresAnteriors(connexio, dataHora, _Participacions);

            foreach (var movimentCompra in compres)
            {
                var mov1 = movimentCompra._Moviment;

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.ContraSplit; // Modifico el tipus de moviment de la compra.
                connexio.Moviments.AddOrUpdate(mov1);

                var particSenseSplit = mov1.Participacions - movimentCompra._ParticipacionsRestants;
                if (particSenseSplit > 0)
                {
                    data1 = data1.AddSeconds(1);
                    // Creo una nova compra amb la part de la compra original que no li afecta el ContraSplit
                    compra(connexio, data1, particSenseSplit, mov1.PreuParticipacio, mov1.CanviAplicat, 0, descripcio, null, false, false);
                }

                // Participacions restants.
                var partRestants = Convert.ToInt32(mov1.Participacions - particSenseSplit) % factorConversor; // Calculo el número de participacions restants.
                for (int n = 0; n < partRestants; n++)
                {
                    // Acumulo el  preu origen de les participacions restants.
                    if (mov1.PreuParticipacioOrigen != null)
                        preuUnitOrigenParticRestants.Add(mov1.PreuParticipacioOrigen.Value);
                }

                // Calculo el nou preu i les participacions del contraSplit i creo una compra amb les participacions afectades.
                data1 = data1.AddSeconds(1);
                var participacions = Convert.ToInt32(mov1.Participacions - particSenseSplit) / factorConversor;
                var preuParticipacio = Math.Round(mov1.PreuParticipacio * factorConversor, 4);
                compra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, 0, descripcio, null, false, false);
            }

            // Faig la venda de les participacions restants
            if (preuUnitOrigenParticRestants.Count > 0)
            {
                var ven = venda(connexio, dataHora, preuUnitOrigenParticRestants.Count, preuOperacio, canviAplicat, 0, descripcio, null, false, false);
                ven.PreuParticipacioOrigen = preuUnitOrigenParticRestants.Average(a => a); // Modifico el PreuParticipacioOrigen.
                connexio.Moviments.AddOrUpdate(ven);
            }

            connexio.SaveChanges();
        }
    }
}
