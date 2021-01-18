using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inversions
{
    interface ITabs
    {
        bool enModeEdicio { get; }

        bool activaRefresca { get; set; }

        void refresca();

        void canviUsuari(Usuari usuari);

        Button AcceptButton { get; }
    }
}
