using System;
using System.Collections.Generic;
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
        /// Inicialitza el nou camp: PreuParticipacioOrigen
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
                            var preu = moviment.calculaPreuUnitariOrigen();
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
        /// Llista de compres reals de les participacions que estan en cartera en la data especificada.
        /// El primer moviment pot estar venut parcialment.
        /// Pels fons, aquests moviments corresponen a les compres reals, no a traspassos.
        /// </summary>
        /// <param name="data">Data hora per trobar el número de participacions. Si null participacions actualment en cartera.</param>
        /// <param name="participacionsRestantsPrimerMoviment">Conté el número de participacions en cartera del primer moviment.</param>
        /// <returns></returns>
        public abstract IEnumerable<MovimentCompra> compresRealsPerParticipacionsEnCartera(DateTime data);

        
        /// <summary>
        /// Llista de compres de les participacions que estan en cartera en la data especificada.
        /// El primer moviment pot estar venut parcialment.
        /// Per les accions, fa el mateix que "primeraCompraRealEnCartera".
        /// Pels fons, podria ser un traspàs.
        /// </summary>
        /// <param name="data">Data hora per trobar el número de participacions. Si null participacions actualment en cartera.</param>
        /// <param name="participacionsRestantsPrimerMoviment">Conté el número de participacions en cartera del primer moviment.</param>
        /// <returns></returns>
        public IEnumerable<MovimentCompra> compresPerParticipacionsEnCartera(DateTime data)
        {
            var dataFinalDia = Utilitats.DataHoraFinalDia(data);
            var numPartEnData = numParticipacionsEnCartera(dataFinalDia);

            if (Utilitats.EsZero(numPartEnData))
                return null;

            Moviment primeraCompraAmbSaldo = null;
            Moviment ultimaCompraAmbSaldo = null;

            // Llegeig les compres anteriors a la data, de més nova a més antiga, fins que la suma de participacions superen les participacions en cartera en la data especificada.
            foreach (var compra in MovimentsProducteUsuari.Where(w => w.Data <= dataFinalDia && w.TipusMoviment == TipusMoviment.Compra).OrderByDescending(o => o.Data))
            {
                if (ultimaCompraAmbSaldo == null)
                    ultimaCompraAmbSaldo = compra;

                if (numPartEnData <= compra.Participacions)
                {
                    primeraCompraAmbSaldo = compra;
                    break;
                }

                numPartEnData -= compra.Participacions;
            }

            /* Número de participacions de la compra més antiga.
             * Ha de ser igual o inferior a les participacions de la primera compra */

            if (primeraCompraAmbSaldo == null)
                return null;

            List<MovimentCompra> xx = new List<MovimentCompra>();
            foreach (var movCompra in MovimentsProducteUsuari.Where(w => w.Id >= primeraCompraAmbSaldo.Id && w.Id <= ultimaCompraAmbSaldo.Id && w.TipusMoviment == TipusMoviment.Compra))
            {
                xx.Add(new MovimentCompra(movCompra, xx.Count == 0 ? numPartEnData : movCompra.Participacions));
            }

            return xx;
        }


        /// <summary>
        /// Quantitat de participacions cartera a la data.
        /// </summary>
        /// <param name="data">Data hora que es buscarà el número de particions.</param>
        /// <returns></returns>
        public double numParticipacionsEnCartera(DateTime data)
        {
            var dataFinalDia = Utilitats.DataHoraFinalDia(data);

            var partsComprades = MovimentsProducteUsuari.Where(w => w.Data <= dataFinalDia && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var partsVenudes = MovimentsProducteUsuari.Where(w => w.Data <= dataFinalDia && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return partsComprades - partsVenudes;
        }



        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="participacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        public IEnumerable<MovimentCompra> compresAnteriors(DateTime dataHora, double participacions)
        {
            if (participacions <= 0)
                return null;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = Program.Sessio.Moviments.Where(w => w.ProdId == Id && w.Data < dataHora && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();
            var trobadaPrimeraCompra = false;

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
            foreach (var compra in Program.Sessio.Moviments.Where(w => w.ProdId == Id && w.Data < dataHora && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList())
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
                    
                    if (Utilitats.EsZero(participacions))
                        break;
                }
            }

            if (participacions > 0.0000001)
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera");

            return compresAmbParticipacio;
        }

    }
}
