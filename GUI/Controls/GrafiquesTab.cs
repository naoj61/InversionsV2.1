using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;

namespace Inversions.GUI
{
    public partial class GrafiquesTab : UserControl, ITabs
    {
        public GrafiquesTab()
        {
            InitializeComponent();

            dtpFinal.Value = DateTime.Now;

            vChartArea = chart1.ChartAreas[0];
            vChartArea.AxisX.LabelStyle.Angle = 45;
            vChartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            vChartArea.AxisX.IsStartedFromZero = false;
            vChartArea.AxisX.Interval = 1;
            vChartArea.AxisY.IsStartedFromZero = false;

            gestioProductesTabValoracions.aplicaFiltre();
        }

        public Button AcceptButton
        {
            get { return null; }
        }

        private readonly ChartArea vChartArea;

        private void gestioProductesTabValoracions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            activaBotoGrafiques(true);
        }


        private void btgActualitzaGrafiques_Click(object sender, EventArgs e)
        {
            btgActualitzaGrafiques.Enabled = false;

            vChartArea.AxisY.Interval = ntbIntervalEixY.Valor;

            // Troba la data d'inici de les gràfiques.
            DateTime dataInici = dtpInici.Value.GetValueOrDefault(DateTime.MinValue);
            if (ckDataIniciComu.Checked)
            {
                foreach (var producteSeleccionat in gestioProductesTabValoracions.productesSeleccionats())
                {
                    DateTime minDataVal = producteSeleccionat.ValoracionsProducte.Min(m => m.Data);
                    if (minDataVal > dataInici && minDataVal <= dtpFinal.Value)
                        // Modifica la dataInici a la data més petita del producte sempre que aquesta no sigui més gran a la data final.
                        dataInici = minDataVal;
                }
            }


            chart1.Series.Clear();

            foreach (var producteSeleccionat in gestioProductesTabValoracions.productesSeleccionats())
            {
                creaGraficaDelProducte(producteSeleccionat, dataInici, dtpFinal.Value);
            }
        }

        private void creaGraficaDelProducte(Producte producte, DateTime dataInici, DateTime dataFinal)
        {
            Dictionary<Valoracio, double> valoracions = producte.valoracionsPonderades(ckPonderat.Checked, dataInici, dataFinal);

            if (valoracions == null)
            {
                MessageBox.Show(String.Format("No hi ha cap valoració pel producte: {0} amb data d'inici: {1}", producte._NomProducte, dataInici.ToShortDateString()),
                    "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chart1.DataBindTable(valoracions.Select(x => new { x.Value, x.Key.Data }).ToList(), "Data");

            Series series1 = chart1.Series["Value"]; // És el nom de la variable del eix X.
            series1.XValueType = ChartValueType.Date;
            series1.ChartType = SeriesChartType.Line;
            series1.Name = producte._NomProducte;
            series1.Tag = producte;
            //series1.Legend = "Legend1";
        }

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            activaBotoGrafiques();
        }

        private void dtpInici_ValueChanged(object sender, EventArgs e)
        {
            activaBotoGrafiques();
        }

        private void ntbIntervalEixY_TextChanged(object sender, EventArgs e)
        {
            activaBotoGrafiques();
        }

        private void activaBotoGrafiques(bool forçaActivacio = false)
        {
            if (forçaActivacio || gestioProductesTabValoracions.productesSeleccionats().Any())
            {
                btgActualitzaGrafiques.Enabled = true;

                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btgActualitzaGrafiques;
                    if(Utilitats.TeFocus(gestioProductesTabValoracions))
                        panel2.Focus();
                }
            }
        }


        readonly int vNumElem = Enum.GetValues(typeof(ChartColorPalette)).Length;

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            
            var posElem = (int)chart1.Palette + 1;

            if (posElem == vNumElem)
                posElem = 1;

            chart1.Palette = (ChartColorPalette)(posElem);
        }

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                var producte = (Producte)e.HitTestResult.Series.Tag;
                if (producte == null) return;

                lbNomProducte.Text = e.HitTestResult.Series.Name;
                lbValorActual.Text = producte.valorEnCartera().ToString("#,##0.00€");

                var vals =producte.valoracionsPonderades(false, dtpInici.Value.GetValueOrDefault(DateTime.MinValue), dtpFinal.Value);
                var valIni = vals.First().Value;
                var valMax = vals.Last().Value;
                lbVariacio.Text = (valMax / valIni - 1).ToString("#0.00%");

            }
            else
            { 
                lbNomProducte.Text = String.Empty;
                lbValorActual.Text = String.Empty;
                lbVariacio.Text = String.Empty;
            }
        }

        #region Implementació d'ITabs

        public void refresca()
        {
            activaRefresca = false;
        }

        public void canviUsuari(Usuari usuari) { }

        public bool enModeEdicio
        {
            get { return false; }
        }

        public bool activaRefresca { get; set; }

        #endregion
    }
}
