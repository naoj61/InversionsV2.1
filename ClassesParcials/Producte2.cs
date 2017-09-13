using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        /// Inicialitza el nou camp: PreuParticipacioOrigen.
        /// Només per posar-ho en marxa, després es pot esborrar.
        /// </summary>
        public static void PosaPreuOrigenATot()
        {
            /* 
             * 57 Compres
             * 11 Traspàs Compra
             * 27 Vendes
             * 11 Traspàs Venda
            */

            int contCompres = 0;
            int contVendes = 0;
            int contTraspasCompres = 0;
            try
            {
                using (var conn = new InversionsBDContext())
                {
                    foreach (Producte producte in conn.Productes.ToList())
                    {
                        // ** Inicialitza Compres.
                        //foreach (var moviment in producte.MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Compra && !w._EsTraspas).ToList())
                        //{
                        //    moviment.PreuParticipacioOrigen = CalculaPreuUnitariOriginal(moviment);
                        //    contCompres++;
                        //}


                        // ** Inicialitza Vendes i Traspas Vendes.
                        foreach (var moviment in producte.MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Venda).ToList())
                        {
                            var preu = moviment.Prod.calculaPreuUnitariOrigen(TipusMoviment.Venda, moviment.Data, moviment.Participacions, moviment.PreuParticipacio, null);
                            moviment.PreuParticipacioOrigen = preu.HasValue ? Math.Round(preu.Value, 4) : (double?) null;
                            contVendes++;
                        }


                        // ** Inicialitza Traspàs Compres.
                        // Calculat en un Excel
                    }


                    conn.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Quantitat de participacions cartera a la data.
        /// </summary>
        /// <param name="data">Data hora a partir de la que es buscarà el número de particions. </param>
        /// <returns></returns>
        public double numParticipacionsEnCartera(DateTime? data = null)
        {
            //var dataFinalDia = Utilitats.DataHoraFinalDia(data);

            if (!data.HasValue)
                data = DateTime.Now;

            var partsComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var partsVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return partsComprades - partsVenudes;
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        public IEnumerable<MovimentCompra> compresAnteriors(DateTime? dataHora = null, double? numParticipacions = null)
        {
            DateTime dataH = dataHora.HasValue ? dataHora.Value : DateTime.Now;

            double participacions = numParticipacions.HasValue ? numParticipacions.Value : numParticipacionsEnCartera(dataH);

            if (participacions <= 0)
                return null;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = Program.Sessio.Moviments.Where(w => w.ProdId == Id && w.Data < dataH && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();
            var trobadaPrimeraCompra = false;

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
            foreach (var compra in Program.Sessio.Moviments.Where(w => w.ProdId == Id && w.Data < dataH && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList())
            {
                if (!trobadaPrimeraCompra)
                {
                    if (participVenudesAbans > compra.Participacions)
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
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera en aquesta data: " + dataH.ToShortDateString()+" "+dataH.ToShortTimeString());

            return compresAmbParticipacio;
        }


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
        /// Calcula el Preu Unitari Origen del moviment.
        /// </summary>
        /// <param name="tipusMoviment"></param>
        /// <param name="dataHora"></param>
        /// <param name="numParticipacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="vendaVinculatTraspas"></param>
        /// <returns></returns>
        private double? calculaPreuUnitariOrigen(TipusMoviment tipusMoviment, DateTime dataHora, double numParticipacions, double preuParticipacio, Moviment vendaVinculatTraspas)
        {
            double? valorRetorn;

            if (tipusMoviment == TipusMoviment.Compra)
            {
                if (vendaVinculatTraspas == null)
                {
                    /* 
                     * És Compra normal. 
                     * Preu Unitari Origen = Preu Unitari.
                     */
                    valorRetorn = preuParticipacio;
                }
                else
                {
                    /* 
                     * És traspàs compra. 
                     * Preu Unitari Origen = Preu U. Venda Ponderat. Sempre està lligat a una sola venda.
                     */
                    //Moviment vendaTraspas = Program.Sessio.Moviments.Single(w => w.Id == traspasMovimentVinculat.IdRefVenda.Value);
                    valorRetorn = vendaVinculatTraspas.PreuParticipacioOrigen * vendaVinculatTraspas.Participacions / numParticipacions;
                }
            }
            else if (tipusMoviment == TipusMoviment.Venda)
            {
                /*
                 * És Venda o traspàs venda.
                 * Preu Unitari Origen = Mitjana del Preu Unitari Origen de les unitats de les compres afectades
                */
                double x = 0;
                double y = 0;
                foreach (var compra in compresAnteriors(dataHora, numParticipacions))
                {
                    x += compra._ParticipacionsRestants * compra._Moviment.PreuParticipacioOrigen.GetValueOrDefault();
                    y += compra._ParticipacionsRestants;
                }

                valorRetorn = x / y;
            }
            else
                throw new ApplicationException(String.Format("Tipus de moviment incorrecte. If={0}. Tipus mov.:{1})", Id, tipusMoviment));

            return valorRetorn;
        }


        private static DateTime FormaData(DateTime data, TimeSpan? hora)
        {
            return data.Date + (hora.HasValue ? hora.Value : DateTime.Now.TimeOfDay);
        }


        private void validacions(InversionsBDContext connexio, DateTime dataHora, double numParticipacions)
        {
            if (connexio == null)
                throw new ArgumentNullException("connexio");

            if (MovimentsProducteUsuari.Any())
            {
                var ultimaData = MovimentsProducteUsuari.Max(m => m.Data);

                // Valido que DateTime no sigui inferior a un moviment prèvi del mateix producte.
                if (ultimaData >= dataHora)
                {
                    if (MessageBox.Show("La data és inferior a la data del últim moviment del producte.\nVols continuar?", "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        throw new ApplicationException("Operació cancelada");
                }
            }

            if (numParticipacions <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacions");

        }


        internal void traspas(InversionsBDContext connexio, DateTime data, TimeSpan hora, double numParticipacionsVenda, double preuParticipacioVenda, string descripcio,
            Producte prodCompra, double numParticipacionsCompra)
        {
            DateTime dataHoraVenda = FormaData(data, hora);
            DateTime dataHoraCompra = dataHoraVenda.AddSeconds(1);
            double preuParticipacioCompra = Math.Round(preuParticipacioVenda * numParticipacionsVenda / numParticipacionsCompra, 4);

            var venda = this.venda(connexio, dataHoraVenda, numParticipacionsVenda, preuParticipacioVenda, 1, null, descripcio, prodCompra.Id, false);
            var compra = prodCompra.compra(connexio, dataHoraCompra, numParticipacionsCompra, preuParticipacioCompra, 1, null, descripcio, venda, false);
        }


        internal Moviment compra(InversionsBDContext connexio, DateTime data, TimeSpan hora, double numParticipacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true)
        {
            DateTime dataHora = FormaData(data, hora);

            return compra(connexio, dataHora, numParticipacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions);
        }


        private Moviment compra(InversionsBDContext connexio, DateTime dataHora, double numParticipacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Moviment movimentVendaVinculatTraspas, bool afegeigPreuAValoracions)
        {
            validacions(connexio, dataHora, numParticipacions);

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Compra;
            moviment.ProdId = this.Id;
            moviment.Participacions = numParticipacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            if (movimentVendaVinculatTraspas == null)
            {
                moviment.ProducteTraspasId = null;
                moviment.IdRefVenda = null;
            }
            else
            {
                moviment.ProducteTraspasId = movimentVendaVinculatTraspas.ProdId;
                moviment.IdRefVenda = movimentVendaVinculatTraspas.Id;
            }
            moviment.PreuParticipacioOrigen = calculaPreuUnitariOrigen(TipusMoviment.Venda, dataHora, numParticipacions, preuParticipacio, movimentVendaVinculatTraspas);

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            return moviment;
        }


        internal Moviment venda(InversionsBDContext connexio, DateTime data, TimeSpan hora, double numParticipacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true)
        {
            DateTime dataHora = FormaData(data, hora);

            return venda(connexio, dataHora, numParticipacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions);
        }


        private Moviment venda(InversionsBDContext connexio, DateTime dataHora, double numParticipacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, int? prodIdMovimentCompraVinculatTraspas, bool afegeigPreuAValoracions)
        {
            validacions(connexio, dataHora, numParticipacions);

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Venda;
            moviment.ProdId = Id;
            moviment.Participacions = numParticipacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            moviment.ProducteTraspasId = prodIdMovimentCompraVinculatTraspas;
            moviment.IdRefVenda = null;
            moviment.PreuParticipacioOrigen = calculaPreuUnitariOrigen(TipusMoviment.Venda, dataHora, numParticipacions, preuParticipacio, null);

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            return moviment;
        }


        internal Moviment dividents(InversionsBDContext connexio, DateTime data, TimeSpan hora, double preuParticipacio, double canviAplicat, double? despeses, string descripcio)
        {
            DateTime dataHora = FormaData(data, hora);

            return dividents(connexio, dataHora, preuParticipacio, canviAplicat, despeses, descripcio);
        }



        internal Moviment dividents(InversionsBDContext connexio, DateTime dataHora, double preuParticipacio, double canviAplicat, double? despeses, string descripcio)
        {
            validacions(connexio, dataHora, 1);

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
            moviment.ProducteTraspasId = null;
            moviment.IdRefVenda = null;
            moviment.PreuParticipacioOrigen = null;

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            return moviment;
        }
    }
}
