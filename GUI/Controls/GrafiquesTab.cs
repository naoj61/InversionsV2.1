using System;
using System.Collections.Generic;
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

            dtpFinal.Value = DateTime.Now;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Angle = 45;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Months;
            chartArea.AxisX.IsStartedFromZero = false;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.AxisY.Interval = 1;

            gestioProductesTabValoracions.aplicaFiltre();
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
                    if (minDataVal > dataInici)
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

        private void activaBotoGrafiques(bool forçaActivacio = false)
        {
            if (forçaActivacio || gestioProductesTabValoracions.productesSeleccionats().Any())
            {
                btgActualitzaGrafiques.Enabled = true;

                if (ParentForm != null)
                {
                    ParentForm.AcceptButton = btgActualitzaGrafiques;
                    panel2.Focus();
                }
            }
        }

        #region Implementació d'ITabs
        
        public void canviUsuari(Usuari usuari) { }

        public bool enModeEdicio
        {
            get { return false; }
        } 

        #endregion
    }
}
