using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.GUI.Forms;
using Microsoft.Win32;

namespace Inversions.GUI
{
    public partial class SimulacióVendaTab : UserControl, ITabs
    {
        private const string NomVarReg = "AnyRenda";

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
            Refresh();
        }

        public Button AcceptButton
        {
            get { return (Button) ParentForm.AcceptButton; }
            private set { ParentForm.AcceptButton = value; }
        }

        public bool enModeEdicio
        {
            get { return false; }
        }

        public bool activaRefresca { get; set; }

        public override void Refresh()
        {
            base.Refresh();
            productes.refrescaDadesControl();
            activaRefresca = false;
        }

        private Producte vProducteSeleccionat = null;

        private void productes_ProducteSeleccionat(object sender, EventArgs e)
        {
            vProducteSeleccionat = sender as Producte;

            if (vProducteSeleccionat == null)
            {
                btSimulacio.Enabled = false;

                ntbNumParticipacions.Enabled = false;
                ntbPreuParticipacio.Enabled = false;

                ntbNumParticipacions.Valor = 0;
                ntbPreuParticipacio.Valor = 0;
                ntbPerduesAnteriors.Valor = 0;
                ntbPigTributa.Valor = 0;
            }
            else
            {
                btSimulacio.Enabled = true;

                ntbNumParticipacions.Enabled = vProducteSeleccionat._Participacions > 0;
                ntbPreuParticipacio.Enabled = vProducteSeleccionat._Participacions > 0;

                ntbNumParticipacions.Valor = vProducteSeleccionat._Participacions;
                ntbPreuParticipacio.Valor = vProducteSeleccionat.ValoracionsProducte.Last().PreuParticipacio;

                ompleValors();
            }
        }

        private void btSimulacio_Click(object sender, EventArgs e)
        {
            if (ntbNumParticipacions.Valor > vProducteSeleccionat._Participacions)
            {
                MessageBox.Show("Num. participacions massa gran");
                return;
            }

            ompleValors();
        }

        private void btRecalcula_Click(object sender, EventArgs e)
        {
            calculaPerdues();

            if (btSimulacio.Enabled)
                ompleValors();
        }

        private void SimulacióVendaTab_Load(object sender, EventArgs e)
        {
            var anyRenda = Program.LlegeigVariableEnRegistreWindows(NomVarReg, true);
            ntbAnyRenda.Valor = Utilitats.EsNumeric(anyRenda) ? Convert.ToInt32(anyRenda) : DateTime.Today.Year;

            calculaPerdues();
        }

        private void calculaPerdues()
        {
            Program.DesaVariableEnRegistreWindows(NomVarReg, ntbAnyRenda._IntValue.ToString(CultureInfo.InvariantCulture), true);

            ntbPerduesAnteriors.Valor = Producte.PerduesDarrersQuatreAnys(ntbAnyRenda._IntValue);
        }


        private void ompleValors()
        {
            var costParts = vProducteSeleccionat.costOriginalEnCartera4(numPartsMax: ntbNumParticipacions.Valor);
            var valorParts = vProducteSeleccionat.valorEnCartera(numPartsMax: ntbNumParticipacions.Valor, preuParticipacio: ntbPreuParticipacio.Valor);

            ntbPig.Valor = valorParts - costParts;

            if (-ntbPerduesAnteriors.Valor > ntbPig.Valor)
                ntbPigTributa.Valor = 0;
            else
                ntbPigTributa.Valor = ntbPig.Valor + ntbPerduesAnteriors.Valor;

            ntbImportBrut.Valor = valorParts;
        }

        private void ntbNumParticipacions_Enter(object sender, EventArgs e)
        {
            AcceptButton = btSimulacio;
        }

        private void ntbPreuParticipacio_Enter(object sender, EventArgs e)
        {
            AcceptButton = btSimulacio;
        }

        private void ntbAnyRenda_Enter(object sender, EventArgs e)
        {
            AcceptButton = btRecalcula;
        }
    }
}