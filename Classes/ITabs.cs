using System.Windows.Forms;

namespace Inversions
{
    interface ITabs
    {
        bool enModeEdicio { get; }

        /// <summary>
        /// Indica que s'ha de recarregar les dades de la pestanya
        /// </summary>
        bool activaRefresca { get; set; }

        /// <summary>
        /// Si true, indica que s'han de carregar les dades de la pestanya per primer cop.
        /// </summary>
        bool carregaDadesInicial { get; set; }

        void refresca();

        void canviUsuari(Usuari usuari);

        Button AcceptButton { get; }
    }
}
