using System;
using System.Drawing;
using System.Linq;
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
            if (Program.RuntimeMode)
            {
                var movsOrdenats = Program.Sessio.MovimentsUsuari.OrderBy(o => o.Data).Where(w => w.TipusMoviment == TipusMoviment.Venda && w.ProducteTraspas == null).ToList();
                if (movsOrdenats.Count == 0)
                    return;

                int anyPrimeraVenda = movsOrdenats.First().Data.Year;
                
                for (int any = anyPrimeraVenda; any <= DateTime.Today.Year; any++)
                {
                    dgvPiGAnualsTributen.Rows.Add(any, 0, 0, Producte.PigReal(any));

                    dgvPiGAnualsTotal.Rows.Add(any, Producte.PigValorat(any));
                }
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.PigValorat());
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);

                fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.PigReal());
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
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

            var primerMoviment = proSeleccionat.MovimentsProducteUsuari.OrderBy(o => o.Data).FirstOrDefault();
            if (primerMoviment != null)
            {
                for (int any = primerMoviment.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    dgvPiGProductePerAny.Rows.Add(any, proSeleccionat.pigValorat(any));
                }
                int fila = dgvPiGProductePerAny.Rows.Add("Total", proSeleccionat.pigValorat(Producte.DateTimeFinalDia.Today));
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
            }
            dgvPiGProductePerAny.ResumeLayout();
        }
    }
}