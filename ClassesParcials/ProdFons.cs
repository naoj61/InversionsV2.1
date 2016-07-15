using System.Linq;

namespace Inversions
{
    public partial class ProdFons
    {
        public override TipusProducte _TipusProducte
        {
            get { return TipusProducte.Fons; }
        }

        public override string _NomProducte
        {
            get { return Nom; }
        }

        public override string _TipusNomProducte
        {
            get { return "Fons - " + Nom + " - " + _NomEmpresa; }
        }


        /// <summary>
        /// PiG de tots els fons en una data determinada.
        /// </summary>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public static double PiG(DateTimeFinalDia dataFi)
        {
            return Enumerable.Sum(Program.Sessio.Productes.Where(w => w is ProdFons), producte => producte.pigValorat(dataFi));
        }


        /// <summary>
        /// Valor dels fons en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Valor(DateTimeFinalDia data)
        {
            double saldo = 0;

            foreach (Producte producte in Program.Sessio.Productes.Where(w => w is ProdFons))
            {
                saldo += producte.valorEnCartera(data);
            }

            return saldo;
        }
    }
}
