using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    interface ITabs
    {
        bool enModeEdicio { get; }

        void canviUsuari(Usuari usuari);
    }
}
