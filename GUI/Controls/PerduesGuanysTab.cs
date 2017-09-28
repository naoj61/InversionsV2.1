using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class PerduesGuanysTab : UserControl, ITabs
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

        private void calculaPiG(Producte.TipusProducte tipusProducte)
        {
            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                var movsOrdenats = Program.Sessio.MovimentsUsuari.OrderBy(o => o.Data).Where(w => w.TipusMoviment == TipusMoviment.Venda && w.ProducteTraspas == null).ToList();
                if (movsOrdenats.Count == 0)
                    return;

                int anyPrimeraVenda = movsOrdenats.First().Data.Year;
                
                dgvPiGAnualsTributen.Rows.Clear();
                dgvPiGAnualsTotal.Rows.Clear();
                for (int any = anyPrimeraVenda; any <= DateTime.Today.Year; any++)
                {
                    //dgvPiGAnualsTributen.Rows.Add(any, 0, 0, Producte.PigReal(any, tipusProducte));
                    dgvPiGAnualsTributen.Rows.Add(any, 0, 0, Producte.PigTributa(tipusProducte, any));

                    //dgvPiGAnualsTotal.Rows.Add(any, Producte.PigValorat(any, tipusProducte));
                    dgvPiGAnualsTotal.Rows.Add(any, Producte.Pig(tipusProducte, any));
                }
                //int fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.PigValorat(tipusProducte));
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.Pig(tipusProducte));
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);

                //fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.PigReal(tipusProducte));
                fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.PigTributa(tipusProducte));
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
            }
        }


        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabValoracions._UsuariSeleccionat = usuari;
            dgvPiGProducte.DataSource = null;
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem);
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat != null)
            {
                actualitzaLlistaPerduesGuanys();
                colDataTraspas.Visible = gestioProductesTabValoracions._ProducteSeleccionat._TipusProducte != Producte.TipusProducte.Accions;
                dgvPiGProducte.Visible = true;
                gbFiltreDates.Enabled = true;
                tbPigEntreDates.Valor = 0;
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

            var primerMoviment = proSeleccionat.MovimentsProducteUsuari.OrderBy(o => o.Data).FirstOrDefault();
            if (primerMoviment != null)
            {
                double pigTotal = 0;
                for (int any = primerMoviment.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    //double pig = proSeleccionat.pigValorat(any);
                    double pig = proSeleccionat.pig(any);
                    
                    pigTotal += pig;

                    dgvPiGProductePerAny.Rows.Add(any, pig);
                }
                //int fila = dgvPiGProductePerAny.Rows.Add("Total", proSeleccionat.pigValorat(Producte.DateTimeFinalDia.Today));
                int fila = dgvPiGProductePerAny.Rows.Add("Total", pigTotal);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
            }
            dgvPiGProductePerAny.ResumeLayout();
        }

        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat.pig(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value);
        }
    }
}