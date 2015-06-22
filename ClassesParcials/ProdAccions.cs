using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
