using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Controls;
using Inversions.ClassesEntity;
using Inversions.GUI.Forms;

namespace Inversions.GUI
{
    public partial class PerduesGuanysTab : TabX
    {
        #region ***** Estructures per DataGrids *****

        /// <summary>
        /// Estructura per omplir DgvCompresProducte
        /// </summary>
        private struct StrDgvCompresProducte
        {
            private StrDgvCompresProducte(Moviment compra, bool ambCartera, bool ambDividends)
                : this()
            {
                if (!compra._EsCompra)
                    throw new Exception("El moviment no és una compra");

                _Id = compra.Id;
                _Data = compra.Data;
                _PreuParticipacio = compra.PreuParticipacio;
                _ImportCompraBrut = compra.PreuParticipacio * compra.Participacions;
                _PigDeLaCompra = compra.pigCompra4(true, false, ambCartera);
                _PigDeLaCompraOrigen = compra.pigCompra4(true, true, ambCartera);
                if (ambDividends)
                    _PigDeLaCompra += compra.dividendCompra4();

                _PercentPiG = _PigDeLaCompra / _ImportCompraBrut;
                _PercentPiGOrig = _PigDeLaCompraOrigen / _ImportCompraBrut;
            }

            internal static IEnumerable<StrDgvCompresProducte> CarregaStruct(IEnumerable<Moviment> compres, bool ambCartera, bool ambDividends)
            {
                return compres.Select(compra => new StrDgvCompresProducte(compra, ambCartera, ambDividends));
            }

// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
            public int _Id { get; private set; }

            public DateTime _Data { get; private set; }

            public decimal _PreuParticipacio { get; private set; }

            public decimal _ImportCompraBrut { get; private set; }

            public decimal _PigDeLaCompra { get; private set; }

            public decimal _PigDeLaCompraOrigen { get; private set; }

            public decimal _PercentPiG { get; private set; }

            public decimal _PercentPiGOrig { get; private set; }

            // ReSharper restore UnusedAutoPropertyAccessor.Local
            // ReSharper restore MemberCanBePrivate.Local
        }

        #endregion ***** Estructures per DataGrids *****


        public PerduesGuanysTab()
        {
            InitializeComponent();

            dgvCompresProducte.AutoGenerateColumns = false;

            vProdTotal._NomProducte = "Total";

            InitializeContextMenu();
        }


        #region *** Variables ***

        private readonly Producte vProdTotal = new ProdFons();

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private Producte vProdSelAnt;

        #endregion *** Variables ***


        #region *** Mètodes ***

        private void InitializeContextMenu()
        {
            // Crea el ContextMenuStrip
            contextMenuStrip1 = new ContextMenuStrip();

            // Crea els elements del menú contextual
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1.Text = "Moviments";
            toolStripMenuItem1.Click += ToolStripMenuItem1_Click;

            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem2.Text = "Valoracions";
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;

            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem3.Text = "Simulació venda";
            toolStripMenuItem3.Click += ToolStripMenuItem3_Click;

            // Afegir els elements al ContextMenuStrip
            contextMenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                toolStripMenuItem1,
                toolStripMenuItem2,
                toolStripMenuItem3
            });
        }

        internal override void carregaInicial()
        {
            base.carregaInicial();

            gestioProductesTabValoracions._NomesAmbParticipacions = true;

            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof(Producte.TipusProducte));
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

            //gestioProductesTabValoracions.refrescaDadesControl(false);
            gestioProductesTabValoracions.refrescaDadesControl();
        }

        private void calculaPiG()
        {
            Producte.TipusProducte tipusProducte = (Producte.TipusProducte)cbTipusProducteFiltreTab2.SelectedItem;

            var ultimAny = DateTime.Today.Year;

            dgvPiGAnualsTributen.Rows.Clear();
            decimal pigTotalTributa = 0;
            for (int any = Program.PrimerAny; any <= ultimAny; any++)
            {
                var ingressosExterns = IngresExtern.Tuples.ToList().Where(w => w.Any == any && w.Usuari == Usuari.Seleccionat).Sum(s => s.Import);

                // *** PiG Tributa ***
                var pigTributa = Producte.PigTributa4(tipusProducte, any, true);
                pigTotalTributa += pigTributa;
                if (pigTributa != 0 || any == ultimAny)
                {
                    // Hi ha vendes reals en l'any.
                    var fila = dgvPiGAnualsTributen.Rows.Add(any, pigTributa + ingressosExterns);
                    dgvPiGAnualsTributen.Rows[fila].Cells["colPigTributa"].Style.ForeColor = pigTributa < 0 ? Color.Red : Color.Black;
                }
            }

            if (dgvPiGAnualsTributen.RowCount > 0)
                dgvPiGAnualsTributen.FirstDisplayedScrollingRowIndex = dgvPiGAnualsTributen.RowCount - 1;

            dgvPiGAnualsTributen.ClearSelection();

            lbTotalPigTributen.ForeColor = pigTotalTributa < 0 ? Color.Red : Color.Black;
            lbTotalPigTributen.Text = pigTotalTributa.ToString("#,##0.00 €");

            ntbPigActualPartsEnCartera.Valor = Producte.PigEnCartera4(tipusProducte, null, ultimAny, true, true);
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

            var compres = StrDgvCompresProducte.CarregaStruct(prodSeleccionat.MovimentsProducteUsuari
                .Where(w => w._EsCompra), ckAmbCartera.Checked, ckAmbDividends.Checked).OrderBy(o => o._Data).ToList();

            SuspendLayout();
            dgvCompresProducte.SuspendLayout();
            dgvCompresProducte.SelectionChanged -= dgvCompresProducte_SelectionChanged;
            dgvCompresProducte.DataSource = compres;
            dgvCompresProducte.ClearSelection();
            dgvCompresProducte.FirstDisplayedScrollingRowIndex = dgvCompresProducte.RowCount - 1;
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

                Dictionary<int, decimal> anysPigTributa = new Dictionary<int, decimal>();
                decimal pigTotal = 0;
                int fila;

                for (int any = primerMovimentX.Data.Year; any <= DateTime.Today.Year; any++)
                {
                    anysPigTributa[any] = proSeleccionat.pigEnAny4(any, true, true, false, true);
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

                        fila = dgvPiGProductePerAny.Rows.Add(anyPig.Key, pig);

                        dgvPiGProductePerAny.Rows[fila].Cells[1].Style.ForeColor = pig < 0 ? Color.Red : Color.Black;

                        pigTotal += pig;
                    }

                    fila = dgvPiGProductePerAny.Rows.Add("SubTotal", pigTotal);
                    dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                    dgvPiGProductePerAny.Rows[fila].Cells[1].Style.ForeColor = pigTotal < 0 ? Color.Red : Color.Black;
                }

                var enCartera = proSeleccionat.pigEnCartera4(true, true);
                fila = dgvPiGProductePerAny.Rows.Add("Cartera", enCartera);
                dgvPiGProductePerAny.Rows[fila].Cells[1].Style.ForeColor = enCartera < 0 ? Color.Red : Color.Black;

                fila = dgvPiGProductePerAny.Rows.Add(vProdTotal, pigTotal + enCartera);
                dgvPiGProductePerAny.Rows[fila].DefaultCellStyle.Font = new Font(dgvPiGProductePerAny.Font, FontStyle.Bold);
                dgvPiGProductePerAny.Rows[fila].Cells[1].Style.ForeColor = pigTotal + enCartera < 0 ? Color.Red : Color.Black;

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
                var pigActual = gestioProductesTabValoracions._ProducteSeleccionat.pigEnCartera4(true, true);
                var pigCalculat = gestioProductesTabValoracions._ProducteSeleccionat
                    .pigEnCartera4(true, true, null, ntbPreuParticipacio.Valor);

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

            switch ((Producte.TipusProducte)cbTipusProducteFiltreTab2.SelectedItem)
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

            var anyDades = (int)cbAnysPiGEnCartera.SelectedItem;
            var dataIni = new DateTime(anyDades, 1, 1);
            var dataFi = new DateTime(anyDades + 1, 1, 1).AddTicks(-1);

            // ** Selecciones només productes amb cartera i els ordena.
            productes = productes.Where(producte => producte.partsEnCartera(dataFi) > 0).OrderBy(o => o.OrdreGrid).ToList();

            decimal pigTotalEncartera = 0;
            dgvPiGEnCartera.Rows.Clear();
            foreach (var prod in productes)
            {
                //var pigProdAny = prod.pigEnAny4(anyDades, false, false) + prod.pigHistoric4(anyDades, false, true, true);
                //var pigProdAny = prod.pigEnAny4(anyDades, false, true, true, true);
                if (dataFi > DateTime.Now)
                    dataFi = DateTime.Now;

                var pigProdAny = prod.pigEnCarteraEntreDates(dataIni, dataFi, true);

                
                if (!Utilitats.EsZero(pigProdAny))
                {
                    int ff = dgvPiGEnCartera.Rows.Add(prod, pigProdAny);

                    dgvPiGEnCartera.Rows[ff].Cells[1].Style.ForeColor = pigProdAny < 0 ? Color.Red : Color.Black;

                    pigTotalEncartera += pigProdAny;
                }
            }

            if (dgvPiGEnCartera.RowCount > 0)
                dgvPiGEnCartera.FirstDisplayedScrollingRowIndex = 0;

            dgvPiGEnCartera.ClearSelection();

            lbTotalPigEnCartera.ForeColor = pigTotalEncartera < 0 ? Color.Red : Color.Black;
            lbTotalPigEnCartera.Text = pigTotalEncartera.ToString("#,##0.00 €");
        }

        #endregion *** Mètodes ***


        #region *** Events ***

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            recalculaValorsControls();
        }

        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            var prodSel = (Producte) sender;

            if (vProdSelAnt != prodSel)
            {
                var cursor = Cursor;
                Cursor = Cursors.WaitCursor;

                try
                {
                    vProdSelAnt = prodSel;

                    dgvCompresProducte.ClearSelection();

                    ckAmbDividends.Visible = gestioProductesTabValoracions._ProducteSeleccionat is ProdAccions;
                    //PigOrigen.Visible = ckAmbCartera.Checked && gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;
                    PigOrigen.Visible = gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;
                    gbPigCompraOrig.Visible = PigOrigen.Visible;
                    PercentPiGOrig.Visible = gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;

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
                finally
                {
                    Cursor = cursor;
                }
            }
        }

        private void btFiltreDates_Click(object sender, EventArgs e)
        {
            var dataIni = dtpFiltreDataInici.Value.GetValueOrDefault(DateTime.MinValue);
            var dataFi = dtpFiltreDataFi.Value.GetValueOrDefault(DateTime.Now);

            if (ckPiGEntreDatesNomesProdSel.Checked)
            {
                tbPigEntreDates.Valor = gestioProductesTabValoracions._ProducteSeleccionat
                    .pigEntreDates4(dataIni, dataFi, true, true, true, true);
            }
            else
            {
                tbPigEntreDates.Valor = Producte.Pig4(dataIni, dataFi, true, true, true, true);
            }
        }

        private void btSimulacioPiG_Click(object sender, EventArgs e)
        {
            calculaPigSimulat();
        }

        private void dgvPiGAnualsTributen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var any = Convert.ToInt32(dgvPiGAnualsTributen[0, e.RowIndex].Value);

            IRPF trib = new IRPF(any);
            trib.ShowDialog(this);

            if (trib._ShaModificat)
                TabX.ActivaRefrescaEnTabs(this);
        }

        private void dgvCompresProducte_SelectionChanged(object sender, EventArgs e)
        {
            decimal pig = 0;
            decimal pigOrig = 0;
            foreach (DataGridViewRow selectedRow in dgvCompresProducte.SelectedRows)
            {
                pig += (decimal) selectedRow.Cells["PigDeLaCompra"].Value;
                pigOrig += (decimal) selectedRow.Cells["PigOrigen"].Value;
            }

            ntbPigCompra.Valor = pig;
            ntbPigCompraOrig.Valor = pigOrig;
        }

        private void ckAmbCartera_CheckedChanged(object sender, EventArgs e)
        {
            //PigOrigen.Visible = ckAmbCartera.Checked && gestioProductesTabValoracions._ProducteSeleccionat is ProdFons;
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

            var r1 = (Producte) dgvPiGEnCartera[0, e.RowIndex1].Value;
            var r2 = (Producte) dgvPiGEnCartera[0, e.RowIndex2].Value;

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

        private void dgvPiGEnCartera_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Comprova si s'ha fet clic amb el botó dret
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    // Selecciona la fila en la qual s'ha fet clic amb el botó dret
                    dgvPiGEnCartera.ClearSelection();
                    dgvPiGEnCartera.Rows[e.RowIndex].Selected = true;

                    // Especifica la ubicació on vols que aparegui el menú
                    Point pt = dgvPiGEnCartera.PointToScreen(e.Location);
                    contextMenuStrip1.Show(pt);
                }
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var prod = (Producte) dgvPiGEnCartera.SelectedRows[0].Cells[0].Value;
            var parentForm = (Principal) ParentForm;
            if (parentForm != null)
                parentForm.obreMovimentsTab(prod);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var prod = (Producte) dgvPiGEnCartera.SelectedRows[0].Cells[0].Value;
            var parentForm = (Principal) ParentForm;
            if (parentForm != null)
                parentForm.obreValoracionsTab(prod);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var prod = (Producte) dgvPiGEnCartera.SelectedRows[0].Cells[0].Value;
            var parentForm = (Principal) ParentForm;
            if (parentForm != null)
                parentForm.obreSimulacióVendaTab(prod);
        }

        private void ntbPreuParticipacio_Enter(object sender, EventArgs e)
        {
            acceptButton(btSimulacioPiG);
        }

        private void dtpFiltreDataInici_Enter(object sender, EventArgs e)
        {
            acceptButton(btFiltreDates);
        }

        private void dtpFiltreDataFi_Enter(object sender, EventArgs e)
        {
            acceptButton(btFiltreDates);
        }

        private void ntb_Leave(object sender, EventArgs e)
        {
            acceptButton(null);
        }

        #endregion *** Events ***
    }
}