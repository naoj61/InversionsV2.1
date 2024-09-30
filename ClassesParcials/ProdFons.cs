using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Comuns;

namespace Inversions
{
    public partial class ProdFons
    {
        public new static DbSet<ProdFons> Tuples
        {
            get { return Program.Sessio.ProdFons; }
        }

        public new static void RefrescaTaula()
        {
            Producte.RefrescaTaula();
        }

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
    }
}
