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
        }

        private void calculaPiG(Producte.TipusProducte tipusProducte)
        {
            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                //var primerAny = Program.Sessio.MovimentsUsuari.OrderBy(o => o.Data).First().Data.Year;
                var ultimAny = DateTime.Today.Year;

                dgvPiGAnualsTributen.Rows.Clear();
                dgvPiGAnualsTotal.Rows.Clear();

                for (int any = Program.PrimerAny; any <= ultimAny; any++)
                {
                    if (Program.Sessio.MovimentsUsuari.All(a => a.Data.Year != any))
                        // No hi ha moviments en l'any
                        continue;

                    var pigTributa = Producte.PigTributa(tipusProducte, any);
                    if (!Comuns.Utilitats.EsZero(pigTributa))
                        dgvPiGAnualsTributen.Rows.Add(any, 0, 0, pigTributa);

                    var pigAny = Producte.Pig(tipusProducte, any);
                    if (!Comuns.Utilitats.EsZero(pigAny))
                        dgvPiGAnualsTotal.Rows.Add(any, pigAny);
                }
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.Pig(tipusProducte));
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);
                dgvPiGAnualsTotal.FirstDisplayedScrollingRowIndex = fila;

                fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.PigTributa(tipusProducte));
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
                dgvPiGAnualsTributen.FirstDisplayedScrollingRowIndex = fila;
            }
        }


        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabValoracions._UsuariSeleccionat = usuari;
            dgvPiGProducte.DataSource = null;
            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG((Producte.TipusProducte)cbTipusProducteFiltreTab2.SelectedItem);
            gestioProductesTabValoracions.refrescaDadesControl();
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

            gbSimulacioPig.Enabled = gestioProductesTabValoracions._ProducteSeleccionat != null;
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
                    if (Program.Sessio.MovimentsUsuari.All(a => a.Data.Year != any))
                        // No hi ha moviments en l'any
                        continue;

                    //double pig = proSeleccionat.pigValorat(any);
                    double pig = proSeleccionat.pig(any);
                    
                    pigTotal += pig;

                    if (!Comuns.Utilitats.EsZero(pig))
                        dgvPiGProductePerAny.Rows.Add(any, pig);
                }
                //int fila = dgvPiGProductePerAny.Rows.Add("Total", proSeleccionat.pigValorat(Producte.DateTimeFinalDia.Today));
                int fila = dgvPiGProductePerAny.Rows.Add("Total", pigTotal);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                dgvPiGProductePerAny.FirstDisplayedScrollingRowIndex = fila;
            }
            dgvPiGProductePerAny.ResumeLayout();
        }

        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat.pig(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value);
        }

        private void PerduesGuanysTab_Load(object sender, EventArgs e)
        {
            dgvPiGProducte.AutoGenerateColumns = false;

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof(Producte.TipusProducte));
            cbTipusProducteFiltreTab2.SelectedIndex = -1;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.SelectedIndex = 0;
        }

        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            ntbPiG.Valor = gestioProductesTabValoracions._ProducteSeleccionat.pigEnCartera(preuParticipacio: ntbPreuParticipacio.Valor);
        }
    }
}