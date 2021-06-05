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

            dgvCompresProducte.AutoGenerateColumns = false;
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
                double pigFinsAnyAnt = 0;
                double pigTotal = 0;
                for (int any = Program.PrimerAny; any <= ultimAny; any++)
                {
                    // *** PiG Tributa ***
                    var pigTributa = Producte.Pig2(tipusProducte, any, false, false);
                    if (!Utilitats.EsZero(pigTributa))
                        // Hi ha vendes reals en l'any.
                        dgvPiGAnualsTributen.Rows.Add(any, 0, 0, pigTributa);


                    // *** PiG Real ***
                    var pigFinsAny = Producte.Pig2(tipusProducte, DateTime.MinValue, Utilitats.DataHoraFinalAny(any), true, true);
                    var pigAny = pigFinsAny - pigFinsAnyAnt;

                    if (!Utilitats.EsZero(pigAny))
                    {
                        if (any == DateTime.Today.Year)
                            pigFinsAny += ntbDiferencia.Valor;

                        dgvPiGAnualsTotal.Rows.Add(any, pigAny);

                        pigFinsAnyAnt = pigFinsAny;
                        pigTotal += pigAny;
                    }
                }

                int fila = dgvPiGAnualsTributen.Rows.Add("Total", 0, 0, Producte.Pig2(tipusProducte, false, false));
                dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
                dgvPiGAnualsTributen.FirstDisplayedScrollingRowIndex = fila;

                fila = dgvPiGAnualsTotal.Rows.Add("Total", pigTotal);
                dgvPiGAnualsTotal.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTotal.Font, FontStyle.Bold);
                dgvPiGAnualsTotal.FirstDisplayedScrollingRowIndex = fila;
            }
        }


        public void refresca()
        {
            Refresh();
        }

        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabValoracions._UsuariSeleccionat = usuari;
            Refresh();
        }

        public bool enModeEdicio
        {
            get { return false; }
        }

        public bool activaRefresca { get; set; }

        public override void Refresh()
        {
            base.Refresh();
            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG();
            gestioProductesTabValoracions.refrescaDadesControl();
            activaRefresca = false;
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            ompleLlistaCompres(gestioProductesTabValoracions._ProducteSeleccionat);

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

                ckPiGEntreDatesNomesProdSel.Enabled = true;
                tbPigEntreDates.Valor = 0;
            }
            else
                ckPiGEntreDatesNomesProdSel.Enabled = false;

            gbSimulacioPig.Enabled = gestioProductesTabValoracions._ProducteSeleccionat != null;
        }


        private void ompleLlistaCompres(Producte prodSeleccionat)
        {
            if (prodSeleccionat == null)
            {
                dgvCompresProducte.ClearSelection();
                dgvCompresProducte.DataSource = null;
                return;
            }
            
            var compres = prodSeleccionat.MovimentsProducteUsuari.Where(w => w._EsCompra).ToList();
            
            SuspendLayout();
            dgvCompresProducte.SuspendLayout();
            dgvCompresProducte.SelectionChanged -= dgvCompresProducte_SelectionChanged;
            dgvCompresProducte.ClearSelection();
            dgvCompresProducte.DataSource = compres;
            dgvCompresProducte.ClearSelection();
            dgvCompresProducte.SelectionChanged += dgvCompresProducte_SelectionChanged;
            dgvCompresProducte.ResumeLayout();
            ResumeLayout();
            
        }


        /// <summary>
        /// Actualitza grids
        /// </summary>
        private void actualitzaLlistaPerduesGuanys()
        {
            var proSeleccionat = gestioProductesTabValoracions._ProducteSeleccionat;


            var primerMovimentX = proSeleccionat.MovimentsProducteUsuari.OrderBy(o => o.Data).FirstOrDefault();
            if (primerMovimentX != null)
            {
                dgvPiGProductePerAny.SuspendLayout();

                Dictionary<int, double> anysPigTributa = new Dictionary<int, double>();
                double pigTotal = 0;
                int fila;

                for (int any = primerMovimentX.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    anysPigTributa[any] = proSeleccionat.pig2Total(any, false, false);
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
                tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat
                    .pig2Total(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value, true, true);
            else
            {
                tbPigEntreDates.Valor = Producte.Pig2(Producte.TipusProducte.Tots, 
                    dtpFiltreDataInici.Value.GetValueOrDefault(DateTime.MinValue), dtpFiltreDataFi.Value.GetValueOrDefault(DateTime.MaxValue), true, true);
            }
        }


        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            calculaPigSimulat();
        }


        private void PerduesGuanysTab_Load(object sender, EventArgs e)
        {
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

        private void dgvCompresProducte_SelectionChanged(object sender, EventArgs e)
        {
            double pig = 0;
            foreach (DataGridViewRow selectedRow in dgvCompresProducte.SelectedRows)
            {
                pig += ((Moviment)selectedRow.DataBoundItem)._PigDeLaCompra;
            }
            ntbPigCompra.Valor = Math.Round(pig, 2); 
        }
        }
}