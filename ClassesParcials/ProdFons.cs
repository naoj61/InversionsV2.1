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
            set { Nom = value; }
        }

        public override string _TipusNomProducte
        {
            get { return "Fons - " + Nom + " - " + _NomEmpresa; }
        }

        public override Mercat _Mercat
        {
            get { return null; }
            set { }
        }

        public override string _NomMercat
        {
            get { return null; }
        }

        public override string _Isin
        {
            get { return ISIN; }
        }

        public override string _Descripcio
        {
            get { return Descripcio; }
        }

        /// <summary>
        /// Valor dels fons en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tipusFons"></param>
        /// <returns></returns>
        public static decimal Valor(DateTime data, TipusFons tipusFons)
        {
            var prods = tipusFons == TipusFons.Tots ? Program.Sessio.ProdFons : Program.Sessio.ProdFons.Where(w => w.Tipus == tipusFons);

            return prods.ToList().Sum(producte => producte.valorEnCartera(data));
        }
    }
}
