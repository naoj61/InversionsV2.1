using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.GUI.Forms;

namespace Inversions.GUI
{
    public partial class PerduesGuanysTab : UserControl, ITabs
    {
        public PerduesGuanysTab()
        {
            InitializeComponent();

            splitContainer1.SplitterDistance = splitContainer1.Height / 2;
        }

        private void calculaPiG()
        {
            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Producte.TipusProducte tipusProducte = (Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem;

                //var primerAny = Program.Sessio.MovimentsUsuari.OrderBy(o => o.Data).First().Data.Year;
                var ultimAny = DateTime.Today.Year;

                dgvPiGAnualsTributen.Rows.Clear();
                dgvPiGAnualsTotal.Rows.Clear();
                double pigTotal = 0;
                for (int any = Program.PrimerAny; any <= ultimAny; any++)
                {
                    if (Program.Sessio.Productes.AsEnumerable().Any(producte => producte.tributaAquestAny(any)))
                    {
                        // Hi ha vendes en l'any.
                        var pigTributa = Producte.PigTributa(tipusProducte, any);

                        if (!Comuns.Utilitats.EsZero(pigTributa))
                            dgvPiGAnualsTributen.Rows.Add(any, 0, 0, pigTributa);
                    }

                    var pigAny = Producte.Pig(tipusProducte, any);

                    if (!Comuns.Utilitats.EsZero(pigAny))
                    {
                        if (any == DateTime.Today.Year)
                            pigAny += ntbDiferencia.Valor;

                        dgvPiGAnualsTotal.Rows.Add(any, pigAny);

                        pigTotal += pigAny;
                    }
                }
                int fila = dgvPiGAnualsTotal.Rows.Add("Total", pigTotal);
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

        public bool enModeEdicio
        {
            get { return false; }
        }

        public override void Refresh()
        {
            base.Refresh();
            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG();
            gestioProductesTabValoracions.refrescaDadesControl();
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG();
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat != null)
            {
                dgvPiGProducteTributaPerAny.ResumeLayout();
                if (Utilitats.EsZero(ntbPreuParticipacio.Valor))
                {
                    // Si cambio de producte i el PiP Simulat té valor, el poso a 0.
                    ntbPreuParticipacio.Valor = 0;
                    calculaPigSimulat();
                }
                else
                    actualitzaLlistaPerduesGuanys();

                colDataTraspas.Visible = gestioProductesTabValoracions._ProducteSeleccionat._TipusProducte != Producte.TipusProducte.Accions;
                dgvPiGProducte.Visible = true;
                ckPiGEntreDatesNomesProdSel.Enabled = true;
                tbPigEntreDates.Valor = 0;
            }
            else
                ckPiGEntreDatesNomesProdSel.Enabled = false;

            gbSimulacioPig.Enabled = gestioProductesTabValoracions._ProducteSeleccionat != null;
        }


        /// <summary>
        /// Actualitza grids
        /// </summary>
        private void actualitzaLlistaPerduesGuanys()
        {
            var proSeleccionat = gestioProductesTabValoracions._ProducteSeleccionat;

            SuspendLayout();

            dgvPiGProducte.SuspendLayout();
            dgvPiGProducte.DataSource = proSeleccionat.pigPerCompra();
            dgvPiGProducte.ClearSelection();
            dgvPiGProducte.ResumeLayout();

            var primerMovimentX = proSeleccionat.MovimentsProducteUsuari.OrderBy(o => o.Data).FirstOrDefault();
            if (primerMovimentX != null)
            {
                dgvPiGProducteTributaPerAny.SuspendLayout();
                dgvPiGProductePerAny.SuspendLayout();
                splitContainer1.SuspendLayout();

                Dictionary<int, double> anysPig = new Dictionary<int, double>();
                Dictionary<int, double> anysPigTributa = new Dictionary<int, double>();
                double pigTotal;
                int fila;

                for (int any = primerMovimentX.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    anysPig[any] = proSeleccionat.pig(any);
                    anysPigTributa[any] = proSeleccionat.pigTributa(any);
                }

                // Grid PiG Tributa del producte.
                if (anysPigTributa.Any(w => !Utilitats.EsZero(w.Value)))
                {
                    dgvPiGProducteTributaPerAny.Rows.Clear();
                    pigTotal = 0;

                    foreach (var anyPig in anysPigTributa.Where(w => !Utilitats.EsZero(w.Value)))
                    {
                        double pig = anyPig.Value;
                        if (anyPig.Key == DateTime.Today.Year)
                            pig += ntbDiferencia.Valor;

                        dgvPiGProducteTributaPerAny.Rows.Add(anyPig.Key, pig);

                        pigTotal += pig;
                    }
                    fila = dgvPiGProducteTributaPerAny.Rows.Add("Total", pigTotal);
                    dgvPiGProducteTributaPerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProducteTributaPerAny.Font, FontStyle.Bold);
                    dgvPiGProducteTributaPerAny.FirstDisplayedScrollingRowIndex = fila;
                    splitContainer1.Panel1Collapsed = false;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                }

                // Grid PiG Tributa del producte.
                dgvPiGProductePerAny.Rows.Clear();
                pigTotal = 0;

                foreach (var anyPig in anysPig.Where(w => !Utilitats.EsZero(w.Value)))
                {
                    double pig = anyPig.Value;
                    if (anyPig.Key == DateTime.Today.Year)
                        pig += ntbDiferencia.Valor;

                    dgvPiGProductePerAny.Rows.Add(anyPig.Key, pig);

                    pigTotal += pig;
                }
                fila = dgvPiGProductePerAny.Rows.Add("Total", pigTotal);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                dgvPiGProductePerAny.FirstDisplayedScrollingRowIndex = fila;


                splitContainer1.Panel1Collapsed = !anysPigTributa.Any(w => !Utilitats.EsZero(w.Value));


                dgvPiGProducteTributaPerAny.ResumeLayout();
                dgvPiGProductePerAny.ResumeLayout();
                splitContainer1.ResumeLayout();
            }
            ResumeLayout();
        }


        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            if (ckPiGEntreDatesNomesProdSel.Checked)
                tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat.pig(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value);
            else
            {
                tbPigEntreDates.Valor = Producte.Pig(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value);
            }
        }


        private void PerduesGuanysTab_Load(object sender, EventArgs e)
        {
            dgvPiGProducte.AutoGenerateColumns = false;

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
            cbTipusProducteFiltreTab2.SelectedIndex = -1;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.SelectedIndex = 0;
        }


        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            calculaPigSimulat();
        }

        private void calculaPigSimulat()
        {
            if (ntbPreuParticipacio.Valor == 0)
            {
                ntbPiG.Valor = 0;
                ntbDiferencia.Valor = 0;
            }
            else
            {
                var pigActual = gestioProductesTabValoracions._ProducteSeleccionat.pigEnCartera();
                var pigCalculat = gestioProductesTabValoracions._ProducteSeleccionat.pigEnCartera(preuParticipacio: ntbPreuParticipacio.Valor);
                ntbPiG.Valor = pigCalculat;
                ntbDiferencia.Valor = pigCalculat - pigActual;
            }
            actualitzaLlistaPerduesGuanys();
            calculaPiG();
        }

        private IButtonControl vAcceptButton = null;

        private void canviaAcceptButton(IButtonControl boto)
        {
            vAcceptButton = ParentForm.AcceptButton;
            ParentForm.AcceptButton = boto;
        }

        private void restauraAcceptButton()
        {
            ParentForm.AcceptButton = vAcceptButton;
        }

        private void ntbPreuParticipacio_Enter(object sender, EventArgs e)
        {
            canviaAcceptButton(btSimulacioPiG);
        }

        private void ntbPreuParticipacio_Leave(object sender, EventArgs e)
        {
            restauraAcceptButton();
        }

        private void dtpFiltreDataInici_Enter(object sender, EventArgs e)
        {
            canviaAcceptButton(btFiltreDates);
        }

        private void dtpFiltreDataInici_Leave(object sender, EventArgs e)
        {
            restauraAcceptButton();
        }

        private void dtpFiltreDataFi_Enter(object sender, EventArgs e)
        {
            canviaAcceptButton(btFiltreDates);
        }

        private void dtpFiltreDataFi_Leave(object sender, EventArgs e)
        {
            restauraAcceptButton();
        }


        private void dgvPiGAnualsTributen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvPiGAnualsTributen.Rows.Count - 1)
                return;

            var any = (int) dgvPiGAnualsTributen[0, e.RowIndex].Value;

            Tributacions trib = new Tributacions();
            trib.carregaDades(any);
            trib.ShowDialog(this);
        }
    }
}