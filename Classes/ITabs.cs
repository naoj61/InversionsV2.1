using System.Windows.Forms;

namespace Inversions
{
    interface ITabs
    {
        /// <summary>
        /// Indica que la pestanya està s'està editant.
        /// </summary>
        bool enModeEdicio { get; }

        /// <summary>
        /// Indica que s'ha de recarregar les dades de la pestanya
        /// </summary>
        bool activaRefresca { get; set; }

        /// <summary>
        /// Si true, indica que s'han de carregar les dades de la pestanya per primer cop.
        /// </summary>
        bool carregaDadesInicial { get; set; }

        Button acceptButton { get; }

        /// <summary>
        /// Refresca les dades de la pestanya.
        /// </summary>
        /// <param name="refrescaActivat"> Si no null canvia el valor de 'activaRefresca' en la pestanya seleccionada.</param>
        void refresca(bool? refrescaActivat);

        /// <summary>
        /// Quan Principal detecta canvi d'usuari, crida el mètode de la pestanya seleccionada.
        /// </summary>
        /// <param name="usuari">Usuari seleccionat</param>
        void canviUsuari(Usuari usuari);

        /// <summary>
        /// Quan Principal detecta Escape, crida el mètode de la pestanya seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void escape(object sender, KeyEventArgs e);
    }
}
