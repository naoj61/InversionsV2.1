using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;

namespace Inversions.GUI
{
    public partial class UsuarisTab : TabX
    {

        public UsuarisTab()
        {
            InitializeComponent();
        }

        public event EventHandler _SelectedIndexChanged;

        internal override void carregaInicial()
        {
            base.carregaInicial();

            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                cbUsuaris.DisplayMember = "Nom";
                cbUsuaris.DataSource = Usuari.Tuples.ToList();
                cbUsuaris.SelectedItem = Usuari.Seleccionat;
                cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;
            }
        }

        internal override void canviUsuari(Usuari usuari)
        {
            cbUsuaris.SelectedItem = usuari;
        }

        /// <summary>
        /// Torna l'usuari següent al seleccionat.
        /// </summary>
        /// <returns></returns>
        internal Usuari tornaUsuariSeguent()
        {
            var ind = cbUsuaris.SelectedIndex + 1;
         
            if (ind >= cbUsuaris.Items.Count)
                ind = 0;

            return (Usuari) cbUsuaris.Items[ind];
        }
        

        void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler handler = _SelectedIndexChanged;
            if (handler != null) handler(cbUsuaris.SelectedItem, e);
        }
    }
}
