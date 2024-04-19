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

            carregaCombo();
        }

        private void carregaCombo()
        {
            cbUsuaris.SelectedIndexChanged -= cbUsuaris_SelectedIndexChanged;
            cbUsuaris.DisplayMember = "Nom";
            cbUsuaris.DataSource = Usuari.Tuples.ToList();
            cbUsuaris.SelectedItem = Usuari.Seleccionat;
            cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;
        }

        internal override void refresca()
        {
            carregaCombo();

            base.refresca();
        }

        internal override void canviUsuari()
        {
            base.canviUsuari();

            cbUsuaris.SelectedIndexChanged -= cbUsuaris_SelectedIndexChanged;
            cbUsuaris.SelectedItem = Usuari.Seleccionat;
            cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;
        }
       

        void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandler handler = _SelectedIndexChanged;
            if (handler != null) handler(cbUsuaris.SelectedItem, e);
        }
    }
}
