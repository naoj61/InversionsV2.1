using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inversions.GUI
{
    public partial class GrafiquesTab : UserControl, ITabs
    {
        public GrafiquesTab()
        {

            InitializeComponent();

        }




        private Valoracio vValoracioSeleccionada = null;

        private bool vModeEdicio = false;


        public void canviUsuari(Usuari usuari)
        {
            throw new NotImplementedException();
        }

        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {

        }
    }
}
