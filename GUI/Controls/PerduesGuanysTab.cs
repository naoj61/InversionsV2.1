using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class PerduesGuanysTab : UserControl
    {
        public PerduesGuanysTab()
        {
            InitializeComponent();

            cDataGridView1.AutoGenerateColumns = false;

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof(Producte.TipusProducte));
            cbTipusProducteFiltreTab2.SelectedIndex = -1;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.SelectedIndex = 0;
        }

        private void calculaPiG()
        {
            if (!MyClass.DesignMode)
            {
                var movsOrdenats = MyClass.Sessio.Moviments.OrderBy(o => o.Data).Where(w => w.TipusMoviment == TipusMoviment.Venda && w.ProducteTraspas == null).ToList();
                if (movsOrdenats.Count == 0)
                    return;

                int anyPrimeraVenda = movsOrdenats.First().Data.Year;
                int anyUltimaVenda = movsOrdenats.Last().Data.Year;

                double pigTotal = 0;
                double pigActual = 0;
                double pigAcumulat = 0;

                dgvPiGAnualsTributen.Rows.Clear();
                dgvPiGAnualsTotal.Rows.Clear();
                for (int any = anyPrimeraVenda; any <= DateTime.Today.Year; any++)
                {
                    double piGCurtTrib = 0;
                    double piGLlargTrib = 0;
                    double piGCurtTot = 0;
                    double piGLlargTot = 0;
                    double dividents = 0;

                    foreach (var producte in MyClass.Sessio.Productes)
                    {
                        double pigC, pigL, div;
                        producte._PiGReal(true, any, out pigC, out pigL, out div);
                        piGCurtTrib += pigC;
                        piGLlargTrib += pigL;

                        producte._PiGReal(false, any, out pigC, out pigL, out div);
                        piGCurtTot += pigC;
                        piGLlargTot += pigL;
                        dividents += div;
                        pigTotal += pigC + pigL + div;

                        if (any == DateTime.Today.Year)
                            pigActual += producte.pigActual();
                    }
                    dgvPiGAnualsTributen.Rows.Add(any, piGCurtTrib, piGLlargTrib, piGCurtTrib + piGLlargTrib);

                    double pigTotAnual = 0;
                    foreach (var prod in MyClass.Sessio.Productes)
                    {
                        var cc = prod.pigPerDates(any);
                        pigTotAnual += cc;
                    }

                    //dgvPiGAnualsTotal.Rows.Add(any, piGCurtTot + piGLlargTot + dividents, pigActual);
                    dgvPiGAnualsTotal.Rows.Add(any, pigTotAnual);

                    pigAcumulat += pigTotAnual;
                }
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", pigAcumulat);
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);

                tbPiGTotConsolidat.Valor = pigTotal;
                tbPiGTotActual.Valor = pigActual;

            }
        }

        void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculaPiG();
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat != null)
            {
                actualitzaLlistaPerduesGuanys();
                colDataTraspas.Visible = gestioProductesTabValoracions._ProducteSeleccionat._TipusProducte != Producte.TipusProducte.Accions;
                cDataGridView1.Visible = true;
            }
        }


        private void actualitzaLlistaPerduesGuanys()
        {
            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = gestioProductesTabValoracions._ProducteSeleccionat._PiGPerCompra();
            cDataGridView1.ClearSelection();
            cDataGridView1.ResumeLayout();
        }

    }
}