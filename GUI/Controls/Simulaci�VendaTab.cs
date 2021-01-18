using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.GUI.Forms;

namespace Inversions.GUI
{
    public partial class SimulacióVendaTab : UserControl, ITabs
    {
        public SimulacióVendaTab()
        {
            InitializeComponent();
        }


        public void refresca()
        {
            Refresh();
        }


        public void canviUsuari(Usuari usuari)
        {
            productes._UsuariSeleccionat = usuari;
            //dgvPiGProducte.DataSource = null;
            Refresh();
        }

        public bool enModeEdicio
        {
            get { return false; }
        }

        public bool activaRefresca { get; set; }


        public Button AcceptButton
        {
            get { return btSimulacio; }
        }

        public override void Refresh()
        {
            base.Refresh();
            productes.refrescaDadesControl();
            activaRefresca = false;
        }

        Producte vProducteSeleccionat = null;

        private void productes_ProducteSeleccionat(object sender, EventArgs e)
        {
            vProducteSeleccionat = sender as Producte;

            if (vProducteSeleccionat == null)
            {
                btSimulacio.Enabled = false;
                ntbNumParticipacions.Enabled = false;
                ntbNumParticipacions.Valor = 0;
                ntbPreuParticipacio.Valor = 0;
            }
            else
            {
                btSimulacio.Enabled = true;
                ntbNumParticipacions.Enabled = vProducteSeleccionat._Participacions > 0;
                ntbNumParticipacions.Valor = vProducteSeleccionat._Participacions;
                ntbPreuParticipacio.Valor = vProducteSeleccionat.ValoracionsProducte.Last().PreuParticipacio;
                ntbPig.Valor = 0;
            }
        }

        private void btSimulacio_Click(object sender, EventArgs e)
        {
            if (ntbNumParticipacions.Valor > vProducteSeleccionat._Participacions)
            {
                MessageBox.Show("Num. participacions massa gran");
                return;
            }
            var costParts = vProducteSeleccionat.costOriginalEnCartera2(numPartsMax: ntbNumParticipacions.Valor);
            var valorPartsEnData = vProducteSeleccionat.valorEnCartera(numPartsMax: ntbNumParticipacions.Valor);
            ntbPig.Valor = valorPartsEnData - costParts;
        }

    }
}