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
    public partial class PerduesGuanysTab : TabX
    {

        private readonly Producte vProdTotal = new ProdFons();

        public PerduesGuanysTab()
        {
            InitializeComponent();

            dgvCompresProducte.AutoGenerateColumns = false;

            vProdTotal._NomProducte = "Total";
        }

        internal override void carregaInicial()
        {
            base.carregaInicial();

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
            cbTipusProducteFiltreTab2.SelectedIndex = -1;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.SelectedIndex = 0;

            for (int any = 2000; any <= DateTime.Today.Year; any++)
            {
                cbAnysPiGEnCartera.Items.Add(any);
            }
            cbAnysPiGEnCartera.SelectedIndexChanged += cbAnysPiGEnCartera_SelectedIndexChanged;
            cbAnysPiGEnCartera.SelectedItem = DateTime.Today.Year;
        }

        internal override void canviUsuari()
        {
            dgvCompresProducte.DataSource = null;

            refresca();

            base.canviUsuari();
        }

        internal override void refresca()
        {
            base.refresca();

            recalculaValorsControls();
        }

        /// <summary>
        /// S'executa si s'han canviat les dades a la BD o els filtres en la pestanya.
        /// </summary>
        private void recalculaValorsControls()
        {
            dgvCompresProducte.DataSource = null;

            if (cbTipusProducteFiltreTab2.SelectedItem != null)
                calculaPiG();

            if (cbAnysPiGEnCartera.SelectedItem != null)
                ompleDgvPiGEnCartera();

            gestioProductesTabValoracions.refrescaDadesControl(false);
        }

        private void calculaPiG()
        {
            Producte.TipusProducte tipusProducte = (Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem;

            var ultimAny = DateTime.Today.Year;

            dgvPiGAnualsTributen.Rows.Clear();
            decimal pigTotalTributa = 0;
            for (uint any = (uint) Program.PrimerAny; any <= ultimAny; any++)
            {
                // *** PiG Tributa ***
                var pigTributa = Producte.PigTributa(tipusProducte, null, any, true);
                pigTotalTributa += pigTributa;
                if (!Utilitats.EsZero(pigTributa) || any == ultimAny)
                {
                    // Hi ha vendes reals en l'any.
                    var ff = dgvPiGAnualsTributen.Rows.Add(any, 0, 0, pigTributa);
                    dgvPiGAnualsTributen.Rows[ff].Cells[3].Style.ForeColor = pigTributa < 0 ? Color.Red : Color.Black;
                }
            }


            int fila = dgvPiGAnualsTributen.Rows.Add(vProdTotal, 0, 0, pigTotalTributa);
            dgvPiGAnualsTributen.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGAnualsTributen.Font, FontStyle.Bold);
            dgvPiGAnualsTributen.Rows[fila].Cells[3].Style.ForeColor = pigTotalTributa < 0 ? Color.Red : Color.Black;
            dgvPiGAnualsTributen.FirstDisplayedScrollingRowIndex = fila;

            ntbPigActualPartsEnCartera.Valor = Producte.Pig2Cartera(tipusProducte, null, (uint) ultimAny, true, true);
            ntbPigRealMesCartera.Valor = ntbPigActualPartsEnCartera.Valor + pigTotalTributa;
        }


        private void ompleLlistaCompres(Producte prodSeleccionat)
        {
            if (prodSeleccionat == null)
            {
                dgvCompresProducte.ClearSelection();
                dgvCompresProducte.DataSource = null;
                return;
            }

            Moviment.AmbCartera = ckAmbCartera.Checked;
            Moviment.AmbDividents = ckAmbDividends.Checked;

            var compres = prodSeleccionat.MovimentsProducteUsuari.Where(w => w._EsCompra).OrderBy(o => o.Data).ToList();

            SuspendLayout();
            dgvCompresProducte.SuspendLayout();
            dgvCompresProducte.SelectionChanged -= dgvCompresProducte_SelectionChanged;
            dgvCompresProducte.ClearSelection();
            dgvCompresProducte.DataSource = compres;
            dgvCompresProducte.ClearSelection();
            dgvCompresProducte.SelectionChanged += dgvCompresProducte_SelectionChanged;
            dgvCompresProducte.ResumeLayout();
            ResumeLayout();

            ntbPigCompra.Valor = compres.Sum(s => s.__PigDeLaCompra);
            ntbPigCompraOrig.Valor = compres.Sum(s => s.__PigDeLaCompraOrigen);
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

                Dictionary<uint, decimal> anysPigTributa = new Dictionary<uint, decimal>();
                decimal pigTotal = 0;
                int fila;

                for (uint any = (uint) primerMovimentX.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    anysPigTributa[any] = proSeleccionat.pig3Total(any, false, false);
                }

                // Grid PiG Tributa del producte.
                dgvPiGProductePerAny.Rows.Clear();
                if (anysPigTributa.Any(w => !Utilitats.EsZero(w.Value)))
                {
                    pigTotal = 0;

                    foreach (var anyPig in anysPigTributa.Where(w => !Utilitats.EsZero(w.Value)))
                    {
                        decimal pig = anyPig.Value;
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



                fila = dgvPiGProductePerAny.Rows.Add(vProdTotal, pigTotal + enCartera);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                dgvPiGProductePerAny.FirstDisplayedScrollingRowIndex = fila;

                dgvPiGProductePerAny.ResumeLayout();
            }
            ResumeLayout();
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

        private void ompleDgvPiGEnCartera()
        {
            // PiG en cartera

            List<Producte> productes;

            switch ((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem)
            {
                case Producte.TipusProducte.Tots:
                    productes = Producte.Tuples.ToList();
                    break;
                case Producte.TipusProducte.Accions:
                    productes = new List<Producte>(ProdAccions.Tuples);
                    break;
                case Producte.TipusProducte.Fons:
                    productes = new List<Producte>(ProdFons.Tuples);
                    break;
                default:
                    return;
            }

            var anyDades = (int) cbAnysPiGEnCartera.SelectedItem;
            decimal pigTotalEncartera = 0;
            dgvPiGEnCartera.Rows.Clear();
            foreach (var prod in productes)
            {
                var pigEnCartera = prod.pigVariacioCartera(anyDades);
                if (!Utilitats.EsZero(pigEnCartera))
                {
                    int ff = dgvPiGEnCartera.Rows.Add(prod, pigEnCartera);

                    dgvPiGEnCartera.Rows[ff].Cells[1].Style.ForeColor = pigEnCartera < 0 ? Color.Red : Color.Black;

                    pigTotalEncartera += pigEnCartera;
                }
            }



            int fila2 = dgvPiGEnCartera.Rows.Add(vProdTotal, pigTotalEncartera);
            dgvPiGEnCartera.Rows[fila2].DefaultCellStyle.Font = new Font(dgvPiGEnCartera.Font, FontStyle.Bold);
            dgvPiGEnCartera.Rows[fila2].Cells[1].Style.ForeColor = pigTotalEncartera < 0 ? Color.Red : Color.Black;
            dgvPiGEnCartera.FirstDisplayedScrollingRowIndex = fila2;

            dgvPiGEnCartera.Rows[0].Selected = false;
        }


        #region *** Events ***

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            recalculaValorsControls();
        }

        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            ckAmbDividends.Visible = gestioProductesTabValoracions._ProducteSeleccionat is ProdAccions;
            PigOrigen.Visible = ckAmbCartera.Checked && gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;
            gbPigCompraOrig.Visible = PigOrigen.Visible;

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

        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            if (ckPiGEntreDatesNomesProdSel.Checked)
                tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat
                    .pig2Total(dtpFiltreDataInici.Value, dtpFiltreDataFi.Value, true, true);
            else
            {
                tbPigEntreDates.Valor = Producte.Pig2(Producte.TipusProducte.Tots, null,
                    dtpFiltreDataInici.Value.GetValueOrDefault(DateTime.MinValue), dtpFiltreDataFi.Value.GetValueOrDefault(DateTime.MaxValue), true, true);
            }
        }

        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            calculaPigSimulat();
        }

        private void dgvPiGAnualsTributen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvPiGAnualsTributen.Rows.Count - 1)
                return;

            var any = Convert.ToInt32(dgvPiGAnualsTributen[0, e.RowIndex].Value);

            IRPF trib = new IRPF(any);
            trib.ShowDialog(this);
        }

        private void dgvCompresProducte_SelectionChanged(object sender, EventArgs e)
        {
            decimal pig = 0;
            decimal pigOrig = 0;
            foreach (DataGridViewRow selectedRow in dgvCompresProducte.SelectedRows)
            {
                pig += ((Moviment) selectedRow.DataBoundItem).pigCompra(ckAmbCartera.Checked, false, null, true, ckAmbDividends.Checked);
                pigOrig += ((Moviment) selectedRow.DataBoundItem).pigCompra(ckAmbCartera.Checked, true, null, false, false);
            }
            ntbPigCompra.Valor = Math.Round(pig, 2);
            ntbPigCompraOrig.Valor = Math.Round(pigOrig, 2);
        }

        private void ckAmbCartera_CheckedChanged(object sender, EventArgs e)
        {
            PigOrigen.Visible = ckAmbCartera.Checked && gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;
            gbPigCompraOrig.Visible = PigOrigen.Visible;

            ompleLlistaCompres(gestioProductesTabValoracions._ProducteSeleccionat);
        }

        private void ckAmbDividends_CheckedChanged(object sender, EventArgs e)
        {
            ompleLlistaCompres(gestioProductesTabValoracions._ProducteSeleccionat);
        }

        private void cbAnysPiGEnCartera_SelectedIndexChanged(object sender, EventArgs e)
        {
            ompleDgvPiGEnCartera();
        }


        private void dgvPiGEnCartera_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // *** Faig que la línia "Total" sempre surti al final. ***

            var r1 = (Producte)dgvPiGEnCartera[0, e.RowIndex1].Value;
            var r2 = (Producte)dgvPiGEnCartera[0, e.RowIndex2].Value;

            if (r1._NomProducte == "Total")
            {
                e.SortResult = 1;
                e.Handled = true;
            }
            else if (r2._NomProducte == "Total")
            {
                e.SortResult = 0; // Pensava que hauria de ser -1 però no funciona,
                e.Handled = true;
            }
        }

        #endregion *** Events ***

    }
}