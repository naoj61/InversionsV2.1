using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Inversions.ClassesEntity;

namespace Inversions
{
    public class TabX : UserControl
    {
        private static readonly List<TabX> TabsX = new List<TabX>();

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private readonly IContainer components;

        protected TabX()
        {
            // Required method for Designer support - do not modify 
            // the contents of this method with the code editor.
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;

            _PendentRefrescar = false;
            _PendentCarregaInicial = true;

            TabsX.Add(this);
        }

        /// <summary>
        ///     Indica que la pestanya està s'està editant.
        /// </summary>
        public bool _EnModeEdicio { get; private set; }

        /// <summary>
        ///     Indica si ja s'ha carregat la pestanya.
        /// </summary>
        public bool _PendentCarregaInicial { get; private set; }

        /// <summary>
        ///     Indica que s'han de recarregar les dades de la pestanya.
        /// </summary>
        internal bool _PendentRefrescar { get; private set; }

        /// <summary>
        ///     Indica que s'ha canviat d'usuari i la pestanya stà pendent d'actualitzar;
        /// </summary>
        internal bool _PendentCanviUsuari { get; private set; }

        ~TabX()
        {
            TabsX.Remove(this);
        }

        /// <summary>
        ///     Marca les pestanyes per refrescar.
        /// </summary>
        /// <param name="noActivarAquestTabX">No activa la pestanya del paràmetre.</param>
        internal static void ActivaRefrescaEnTabs(TabX noActivarAquestTabX)
        {
            // Marca pel refresc totes les pestanyes excepte "noActivarAquestTabX" i les que encara no s'ha fet la càrrega inicial.
            foreach (TabX tabX in TabsX.Where(tabX => tabX != null && tabX != noActivarAquestTabX && !tabX._PendentCarregaInicial))
            {
                tabX._PendentRefrescar = true;
            }
        }

        internal static void ActivaPendentCanviUsuariEnTabs()
        {
            // Marca pel refresc totes les pestanyes.
            foreach (TabX tabX in TabsX.Where(tabX => tabX != null))
            {
                tabX._PendentCanviUsuari = true;
            }
        }

        protected void acceptButton(Button botoAccept)
        {
            if (ParentForm != null)
                ParentForm.AcceptButton = botoAccept;
        }

        protected void cancelButton(Button botoCancel)
        {
            if (ParentForm != null)
                ParentForm.CancelButton = botoCancel;
        }


        /// <summary>
        ///     Càrrega inicial de la pestanya. Marca com a fet.
        /// </summary>
        internal virtual void carregaInicial()
        {
            _PendentCarregaInicial = false;
        }

        /// <summary>
        ///     Refresca les dades de la pestanya i marco com refrescat.
        /// </summary>
        internal virtual void refresca()
        {
            _PendentRefrescar = false;
        }

        /// <summary>
        ///     Obre la pestanya amb el producte seleccionat.
        /// </summary>
        /// <param name="prod"></param>
        internal virtual void obrePestanya(Producte prod)
        {
        }

        /// <summary>
        ///     Quan Principal detecta canvi d'usuari, crida el mètode de la pestanya seleccionada.
        /// </summary>
        internal virtual void canviUsuari()
        {
            _PendentCanviUsuari = false;
        }

        /// <summary>
        ///     Quan Principal detecta Escape, crida el mètode de la pestanya seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal virtual void escape(object sender, KeyEventArgs e)
        {
            refresca();
        }

        protected virtual void modeEdicio()
        {
            _EnModeEdicio = true;
        }

        protected virtual void modeConsulta()
        {
            _EnModeEdicio = false;
        }

        /// <summary>
        ///     Impideix sortir de la pastanya si està en mode edició.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void validating(object sender, CancelEventArgs e)
        {
            if (_EnModeEdicio)
            {
                if (MessageBox.Show("Està en mode edició. Tanco igualment?", "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
        }


        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}