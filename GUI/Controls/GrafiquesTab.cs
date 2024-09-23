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
    public partial class GrafiquesTab : TabX
    {
        readonly int vNumElem = Enum.GetValues(typeof(ChartColorPalette)).Length;
        private readonly ChartArea vChartArea;

        public GrafiquesTab()
        {
            InitializeComponent();

            vChartArea = chart1.ChartAreas[0];
            vChartArea.AxisX.LabelStyle.Angle = 45;
            vChartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            vChartArea.AxisX.IsStartedFromZero = false;
            vChartArea.AxisX.Interval = 1;
            vChartArea.AxisY.IsStartedFromZero = false;
        }

        internal override void carregaInicial()
        {
            base.carregaInicial();

            dtpFinal.Value = DateTime.Now;

            gestioProductesTabValoracions.aplicaFiltre();
        }

        private void activaBotoGrafiques(bool forçaActivacio = false)
        {
            if (forçaActivacio || gestioProductesTabValoracions.productesSeleccionats().Any())
            {
                btgActualitzaGrafiques.Enabled = true;

                acceptButton(btgActualitzaGrafiques);
                if (Utilitats.TeFocus(gestioProductesTabValoracions))
                    panel2.Focus();
            }
        }

        private void creaGrafica()
        {
            var dataInici = dtpInici.Value.GetValueOrDefault(DateTime.MinValue);

            // *** Troba la data comun mínima ***
            var dataIniciMin = dataInici;
            foreach (var prodSelect in gestioProductesTabValoracions.productesSeleccionats())
            {
                var vals = prodSelect.ValoracionsProducte.Where(w => w.Data >= dataInici && w.PreuParticipacio > 0)
                    .OrderBy(o => o.Data);

                dataIniciMin = new DateTime(Math.Max(dataIniciMin.Ticks, vals.First().Data.Ticks));
            }

            if (ckDataIniciComu.Checked)
                dataInici = dataIniciMin;


            // *** Troba el primer valor minim
            var primerValorMinim = Decimal.MaxValue;
            foreach (var prodSelect in gestioProductesTabValoracions.productesSeleccionats())
            {
                var vals = prodSelect.ValoracionsProducte.Where(w => w.Data >= dataInici && w.PreuParticipacio > 0)
                    .OrderBy(o => o.Data);

                primerValorMinim = Math.Min(primerValorMinim, vals.First().PreuParticipacio);
            }


            // ******* Crea gràfica **********

            var siPonderar = ckPonderat.Checked && gestioProductesTabValoracions.productesSeleccionats().Count() > 1;
            var valorMinim = Decimal.MaxValue;
            var valorMaxim = Decimal.MinValue;

            chart1.Series.Clear();

            foreach (var prodSelect in gestioProductesTabValoracions.productesSeleccionats())
            {
                var vals = prodSelect.ValoracionsProducte.Where(w => w.Data >= dataInici && w.PreuParticipacio > 0).OrderBy(o => o.Data);

                if (!vals.Any())
                {
                    MessageBox.Show(String.Format("No hi ha cap valoració pel producte: {0} amb data d'inici: {1}", prodSelect._NomProducte,
                        dataInici.ToShortDateString()), "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dictionary<Valoracio, decimal> valoracions = new Dictionary<Valoracio, decimal>(vals.Count());

                var coeficient = primerValorMinim / vals.First().PreuParticipacio;

                foreach (var valoracio in vals)
                {
                    var valorPonderat = ((siPonderar
                        ? (valoracio.PreuParticipacio * coeficient - primerValorMinim)
                        : valoracio.PreuParticipacio));

                    valoracions.Add(valoracio, valorPonderat);

                    valorMinim = Math.Min(valorMinim, valorPonderat);
                    valorMaxim = Math.Max(valorMaxim, valorPonderat);
                }

                vChartArea.AxisY.Interval = (double)(ckIntervalAutomatic.Checked ? (valorMaxim - valorMinim) / 10 : ntbIntervalEixY.Valor);
                vChartArea.AxisY.Minimum = (double)valorMinim;
                vChartArea.AxisY.Maximum = (double)valorMaxim;
                chart1.DataBindTable(valoracions.Select(x => new { x.Value, x.Key.Data }).ToList(), "Data");
                Series series1 = chart1.Series["Value"]; // És el nom de la variable del eix X.
                series1.XValueType = ChartValueType.Date;
                series1.ChartType = SeriesChartType.Line;
                series1.Name = prodSelect._NomProducte;
                series1.Tag = prodSelect;
                //series1.Legend = "Legend1";
            }
        }

        internal override void refresca()
        {
            base.refresca();

            creaGrafica();
        }

        #region *** Events ***

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
                var producte = (Producte) e.HitTestResult.Series.Tag;
                if (producte == null) return;

                lbNomProducte.Text = e.HitTestResult.Series.Name;

                var puntSenyalatGrafica = ((DataPoint) (e.HitTestResult.Object));
                //lbValorActual.Text = producte.valorEnCartera().ToString("#,##0.00€");
                lbValorActual.Text = puntSenyalatGrafica.YValues[0].ToString("#,##0.00€");
                lbData.Text = DateTime.FromOADate(puntSenyalatGrafica.XValue).ToShortDateString();
            }
        }

        private void gestioProductesTabValoracions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            activaBotoGrafiques(true);
        }

        private void btgActualitzaGrafiques_Click(object sender, EventArgs e)
        {
            btgActualitzaGrafiques.Enabled = false;

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

            creaGrafica();
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

        #endregion *** Events ***

    }
}
