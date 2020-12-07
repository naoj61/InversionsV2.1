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
        }

        public Button AcceptButton
        {
            get { return null; }
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
                double pigAnyAnt = 0;
                for (int any = Program.PrimerAny; any <= ultimAny; any++)
                {
                    if (Program.Sessio.Productes.AsEnumerable().Any(producte => producte.tributaAquestAny(any)))
                    {
                        // Hi ha vendes en l'any.
                        var pigTributa = Producte.Pig2(tipusProducte, any, false);

                        if (!Utilitats.EsZero(pigTributa))
                            dgvPiGAnualsTributen.Rows.Add(any, 0, 0, pigTributa);
                    }


                    var pigAny = Producte.Pig2(tipusProducte, DateTime.MinValue, new DateTime(any + 1, 1, 1).AddMilliseconds(-1), true);

                    if (!Utilitats.EsZero(pigAny))
                    {
                        if (any == DateTime.Today.Year)
                            pigAny += ntbDiferencia.Valor;

                        dgvPiGAnualsTotal.Rows.Add(any, pigAny - pigAnyAnt);

                        pigAnyAnt = pigAny;
                    }
                }


                int fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.Pig2(tipusProducte, false));
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
                dgvPiGAnualsTributen.FirstDisplayedScrollingRowIndex = fila;

                
                fila = dgvPiGAnualsTotal.Rows.Add("Total", Producte.Pig2(tipusProducte, DateTime.MinValue, DateTime.MaxValue, true));
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);
                dgvPiGAnualsTotal.FirstDisplayedScrollingRowIndex = fila;
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
                dgvPiGProductePerAny.ResumeLayout();
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
                dgvPiGProductePerAny.SuspendLayout();

                Dictionary<int, double> anysPigTributa = new Dictionary<int, double>();
                double pigTotal = 0;
                int fila;

                for (int any = primerMovimentX.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    anysPigTributa[any] = proSeleccionat.pig2Total(any, false);
                }

                // Grid PiG Tributa del producte.
                dgvPiGProductePerAny.Rows.Clear();
                if (anysPigTributa.Any(w => !Utilitats.EsZero(w.Value)))
                {
                    pigTotal = 0;

                    foreach (var anyPig in anysPigTributa.Where(w => !Utilitats.EsZero(w.Value)))
                    {
                        double pig = anyPig.Value;
                        if (anyPig.Key == DateTime.Today.Year)
                            pig += ntbDiferencia.Valor;

                        dgvPiGProductePerAny.Rows.Add(anyPig.Key, pig);

                        pigTotal += pig;
                    }

                    fila = dgvPiGProductePerAny.Rows.Add("SubTotal", pigTotal);
                    dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                }


                var enCartera = proSeleccionat.pig2EnCartera();
                dgvPiGProductePerAny.Rows.Add("Cartera", enCartera);

                fila = dgvPiGProductePerAny.Rows.Add("Total", pigTotal + enCartera);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                dgvPiGProductePerAny.FirstDisplayedScrollingRowIndex = fila;

                dgvPiGProductePerAny.ResumeLayout();
            }
            ResumeLayout();
        }


        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            if (ckPiGEntreDatesNomesProdSel.Checked)
                tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat.pig2Total(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value);
            else
            {
                tbPigEntreDates.Valor = Producte.Pig2(Producte.TipusProducte.Tots, 
                    dtpFiltreDataInici.Value.GetValueOrDefault(DateTime.MinValue), dtpFiltreDataFi.Value.GetValueOrDefault(DateTime.MaxValue), true);
            }
        }


        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            calculaPigSimulat();
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

        private void calculaPigSimulat()
        {
            if (ntbPreuParticipacio.Valor == 0)
            {
                ntbPiG.Valor = 0;
                ntbDiferencia.Valor = 0;
            }
            else
            {
                var pigActual = gestioProductesTabValoracions._ProducteSeleccionat.pig2EnCartera();
                var pigCalculat = gestioProductesTabValoracions._ProducteSeleccionat.pig2EnCartera(preuParticipacio: ntbPreuParticipacio.Valor);
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