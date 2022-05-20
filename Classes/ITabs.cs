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
