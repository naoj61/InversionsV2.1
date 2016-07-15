using System.Linq;

namespace Inversions
{
    public partial class ProdAccions
    {
        public override TipusProducte _TipusProducte
        {
            get { return TipusProducte.Accions; }
        }

        public override string _NomProducte
        {
            get { return _NomEmpresa; }
        }

        public override string _TipusNomProducte
        {
            get { return "Accions - " + _NomEmpresa; }
        }


        /// <summary>
        /// PiG de totes les accions en una data determinada.
        /// </summary>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public static double PiG(DateTimeFinalDia dataFi)
        {
            return Enumerable.Sum(Program.Sessio.Productes.Where(w => w is ProdAccions), producte => producte.pigValorat(dataFi));
        }


        /// <summary>
        /// Valor de les accions en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Valor(DateTimeFinalDia data)
        {
            double saldo = 0;

            foreach (Producte producte in Program.Sessio.Productes.Where(w=>w is ProdAccions))
            {
                saldo += producte.valorEnCartera(data);
            }

            return saldo;
        }

    }
}
