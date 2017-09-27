using System;
using System.Collections.Generic;
using System.Linq;
using Comuns;

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
        /// Valor de les accions en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Valor(DateTime data)
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
