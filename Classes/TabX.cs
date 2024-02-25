using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inversions.GUI;

namespace Inversions
{
    public class TabX : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private readonly IContainer components = null;

        private static readonly List<TabX> TabsX = new List<TabX>();

        protected TabX()
        {
            // Required method for Designer support - do not modify 
            // the contents of this method with the code editor.
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;

            _ActivaRefresca = true;
            _PendentCarregaInicial = true;

            TabsX.Add(this);
        }

        ~TabX()
        {
            TabsX.Remove(this);
        }

        protected static void ActivaRefrescaEnTabs(TabX noActivarAquestTabX)
        {
            // Marca pel refresc totes les pestanyes excepte la que s'acaba de modificar.
            foreach (TabX tabX in TabsX.Where(tabX => tabX != null))
            {
                tabX._ActivaRefresca = noActivarAquestTabX != tabX;
            }
        }

        /// <summary>
        /// Indica que la pestanya està s'està editant.
        /// </summary>
        public bool _EnModeEdicio { get; private set; }

        public bool _PendentCarregaInicial { get; private set; }

        /// <summary>
        /// Indica que s'han de recarregar les dades de la pestanya
        /// </summary>
        internal bool _ActivaRefresca { get; set ; }

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

        internal virtual void carregaInicial()
        {
            _PendentCarregaInicial = false;
        }

        /// <summary>
        /// Refresca les dades de la pestanya.
        /// </summary>
        /// <param name="refrescaActivat"> Si no null canvia el valor de 'activaRefresca' en la pestanya seleccionada.</param>
        internal virtual void refresca(bool? refrescaActivat)
        {
            if (refrescaActivat.HasValue)
                _ActivaRefresca = refrescaActivat.Value;
        }

        /// <summary>
        /// Quan Principal detecta canvi d'usuari, crida el mètode de la pestanya seleccionada.
        /// </summary>
        /// <param name="usuari">Usuari seleccionat</param>
        internal virtual void canviUsuari(Usuari usuari)
        {
            refresca(true);
        }

        /// <summary>
        /// Quan Principal detecta Escape, crida el mètode de la pestanya seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal virtual void escape(object sender, KeyEventArgs e)
        {
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
        /// Impideix sortir de la pastanya si està en mode edició.
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
        /// Clean up any resources being used.
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
