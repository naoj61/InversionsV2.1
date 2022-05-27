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

        Button AcceptButton { get; }

        /// <summary>
        /// Refresca les dades de la pestanya.
        /// </summary>
        /// <param name="refrescaActivat"> Si no null canvia el valor de 'activaRefresca'</param>
        void refresca(bool? refrescaActivat);

        void canviUsuari(Usuari usuari);

        void escape(object sender, KeyEventArgs e);
    }
}
