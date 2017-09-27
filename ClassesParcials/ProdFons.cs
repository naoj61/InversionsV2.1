using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Comuns;

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
        /// Valor dels fons en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Valor(DateTime data)
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
