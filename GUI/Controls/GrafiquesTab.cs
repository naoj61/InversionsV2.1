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
    public partial class GrafiquesTab : UserControl
    {
        public GrafiquesTab()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        }


        private void gestioProductesTabValoracions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btgActualitzaGrafiques.Enabled = true;
        }

        private void btgActualitzaGrafiques_Click(object sender, EventArgs e)
        {
            btgActualitzaGrafiques.Enabled = false;

            chart1.Series.Clear();

            foreach (var productesSeleccionat in gestioProductesTabValoracions.productesSeleccionats())
            {
                afegeixProducte(Valoracio.ValoracionsProductePonderada(productesSeleccionat));
            }
        }

        private void afegeixProducte(Dictionary<Valoracio, double> producte)
        {
            Series series1 = new Series();
            series1.XValueType = ChartValueType.DateTime;
            series1.ChartType = SeriesChartType.Line;
            series1.Name = producte.First().Key.Prod._NomProducte;

            //series1.ChartArea = "ChartArea1";
            //series1.Legend = "Legend1";


            foreach (var val in producte)
            {
                series1.Points.AddXY(val.Key.Data, val.Value);
            }

            chart1.Series.Add(series1);
        }
    }
}
