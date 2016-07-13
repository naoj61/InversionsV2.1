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

            dgvPiGProducte.AutoGenerateColumns = false;

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
            cbTipusProducteFiltreTab2.SelectedIndex = -1;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.SelectedIndex = 0;
        }

        private void calculaPiG()
        {
            if (!Program.DesignMode)
            {
                var movsOrdenats = Program.Sessio.Moviments.OrderBy(o => o.Data).Where(w => w.TipusMoviment == TipusMoviment.Venda && w.ProducteTraspas == null).ToList();
                if (movsOrdenats.Count == 0)
                    return;

                int anyPrimeraVenda = movsOrdenats.First().Data.Year;
                int anyUltimaVenda = movsOrdenats.Last().Data.Year;

            //    double pigTotal = 0;
            //    double pigActual = 0;

            //    dgvPiGAnualsTributen.Rows.Clear();
            //    dgvPiGAnualsTotal.Rows.Clear();
                for (int any = anyPrimeraVenda; any <= DateTime.Today.Year; any++)
                {
                    //double piGCurtTrib = 0;
                    //double piGLlargTrib = 0;
                    //double piGCurtTot = 0;
                    //double piGLlargTot = 0;
                    //double dividents = 0;

                    //foreach (var producte in Program.Sessio.Productes)
                    //{
                    //    double pigC, pigL, div;
                    //    producte.pigReal(true, any, out pigC, out pigL, out div);
                    //    piGCurtTrib += pigC;
                    //    piGLlargTrib += pigL;

                    //    producte.pigReal(false, any, out pigC, out pigL, out div);
                    //    piGCurtTot += pigC;
                    //    piGLlargTot += pigL;
                    //    dividents += div;
                    //    pigTotal += pigC + pigL + div;

                    //    if (any == DateTime.Today.Year)
                    //        pigActual += producte.pigActual();
                    //}
                    //dgvPiGAnualsTributen.Rows.Add(any, piGCurtTrib, piGLlargTrib, piGCurtTrib + piGLlargTrib);
                    dgvPiGAnualsTributen.Rows.Add(any, 0, 0, Producte.PigReal(any));

                    dgvPiGAnualsTotal.Rows.Add(any, Producte.PigValorat(any));
                }
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.PigValorat());
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);

                fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.PigReal());
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);

                //tbPiGTotConsolidat.Valor = Producte.PigReal();
                //tbPiGTotActual.Valor = pigActual;

            }
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculaPiG();
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat != null)
            {
                actualitzaLlistaPerduesGuanys();
                colDataTraspas.Visible = gestioProductesTabValoracions._ProducteSeleccionat._TipusProducte != Producte.TipusProducte.Accions;
                dgvPiGProducte.Visible = true;
            }
        }


        private void actualitzaLlistaPerduesGuanys()
        {
            var proSeleccionat = gestioProductesTabValoracions._ProducteSeleccionat;

            dgvPiGProducte.SuspendLayout();
            dgvPiGProducte.DataSource = proSeleccionat.pigPerCompra();
            dgvPiGProducte.ClearSelection();
            dgvPiGProducte.ResumeLayout();

            dgvPiGProductePerAny.SuspendLayout();

            dgvPiGProductePerAny.Rows.Clear();

            double pigAcumulat = 0;
            for (int any = proSeleccionat.MovimentsProducte.OrderBy(o => o.Data).First().Data.Year; any <= DateTime.Today.Year; any++)
            {
                dgvPiGProductePerAny.Rows.Add(any, proSeleccionat.pigValorat(any));
            }
            int fila = dgvPiGProductePerAny.Rows.Add("Total", proSeleccionat.pigValorat(Producte.DateTimeFinalDia.Today));
            dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);

            dgvPiGProductePerAny.ResumeLayout();
        }
    }
}