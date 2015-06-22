using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
