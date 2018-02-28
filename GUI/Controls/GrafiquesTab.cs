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

            gestioProductesTabValoracions.aplicaFiltre();
        }


        private void gestioProductesTabValoracions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            activaBotoGrafiques(true);
        }


        private void btgActualitzaGrafiques_Click(object sender, EventArgs e)
        {
            btgActualitzaGrafiques.Enabled = false;

            chart1.Series.Clear();

            foreach (var productesSeleccionat in gestioProductesTabValoracions.productesSeleccionats())
            {
                creaGraficaDelProducte(productesSeleccionat);
            }
        }


        private void creaGraficaDelProducte(Producte producte)
        {
            Dictionary<Valoracio, double> valoracions = null;

            if (ckPonderat.Checked)
                valoracions = Valoracio.ValoracionsProductePonderades(producte, dtpInici.Value, dtpFinal.Value);
            else
                valoracions = Valoracio.ValoracionsProducte(producte, dtpInici.Value, dtpFinal.Value).ToDictionary(x => x, x => x.PreuParticipacio);

            if (!valoracions.Any())
            {
                MessageBox.Show("No hi ha cap valoració pel producte: " + producte._NomProducte, "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chart1.DataBindTable(valoracions.Select(x => new { x.Key.Data, x.Value }).ToList(), "Data");

            Series series1 = chart1.Series.Last();
            series1.XValueType = ChartValueType.Date;
            series1.ChartType = SeriesChartType.Line;
            series1.Name = producte._NomProducte;
            //series1.Legend = "Legend1";
        }

        private void ckPonderat_CheckedChanged(object sender, EventArgs e)
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
                    ParentForm.AcceptButton = btgActualitzaGrafiques;
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
