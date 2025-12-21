using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.ClassesEntity;

namespace Inversions.GUI
{
    public partial class MovimentsTab : TabX
    {
        private bool? comprant;
        private string vDesaToolTipGbPreuPartic;

        public MovimentsTab()
        {
            InitializeComponent();

            dgvMovimentsProd.AutoGenerateColumns = false;
        }

        internal override void refresca()
        {
            if (!_EnModeEdicio)
            {
                gestioProductesTabMoviments.refrescaDadesControl();

                base.refresca();
            }
        }

        internal override void canviUsuari()
        {
            base.canviUsuari();

            //gestioProductesTabMoviments.refrescaDadesControl(true);
            gestioProductesTabMoviments.refrescaDadesControl(null);

            dgvMovimentsProd.DataSource = null;
        }

        internal override void carregaInicial()
        {
            base.carregaInicial();

            gestioProductesTabMoviments._NomesAmbParticipacions = true;

            refresca();
        }

        internal override void obrePestanya(Producte prod)
        {
            gestioProductesTabMoviments.seleccionaProducte(prod);
        }


        /// <summary>
        ///     Canvia les dades del control a les del nou producte
        /// </summary>
        private void canviProducteSeleccionat()
        {
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                Producte prod = gestioProductesTabMoviments._ProducteSeleccionat;

                if (prod == null)
                {
                    cbTipusMoviment.Enabled = false;
                    btCancelaMoviment.Enabled = false;
                    //btFes.Enabled = false;
                    btDesaMoviment.Enabled = false;
                }
                else
                {
                    ompleTaulaMovimentsProducte(prod);

                    gbTraspas.Visible = false;
                    gbNumParticipacionsDesti.Visible = prod._TipusProducte == Producte.TipusProducte.Fons;
                    gbEdicio.Visible = false;

                    cbTipusMoviment.Enabled = true;
                    //btFes.Enabled = prod._TipusProducte == Producte.TipusProducte.Accions && prod._Participacions > 0;
                    btCancelaMoviment.Enabled = false;
                    btDesaMoviment.Enabled = false;


                    cbTipusMoviment.SuspendLayout();
                    cbTipusMoviment.Items.Clear();
                    cbTipusMoviment.Items.Add(TipusMoviment.Compra);
                    if (prod._Participacions > 0)
                    {
                        cbTipusMoviment.Items.Add(TipusMoviment.Venda);
                        cbTipusMoviment.Items.Add(TipusMoviment.Dividends);
                        if (prod._TipusProducte == Producte.TipusProducte.Accions)
                        {
                            cbTipusMoviment.Items.Add(TipusMoviment.Split);
                            cbTipusMoviment.Items.Add(TipusMoviment.ContraSplit);
                        }
                        else
                            cbTipusMoviment.Items.Add(TipusMoviment.Traspàs);
                    }

                    cbTipusMoviment.SelectedItem = null;
                    cbTipusMoviment.ResumeLayout();
                }
            }
            finally
            {
                Cursor = cursor;
            }
        }

        private void ompleTaulaMovimentsProducte(Producte prod)
        {
            //var movimentsProducte = Moviment.MovimentsUsuari.Where(w => w.Prod.Id == prod.Id).ToList();

            List<StrDgvMovimentsProd> movimentsProducte = StrDgvMovimentsProd.CarregaStruct(Moviment.MovimentsUsuari.Where(w => w.Prod.Id == prod.Id));

            dgvMovimentsProd.SuspendLayout();
            dgvMovimentsProd.DataSource = movimentsProducte.OrderBy(o => o._Data).ToList();
            dgvMovimentsProd.Columns["colTraspasOrigen"].Visible = movimentsProducte.Any(eo => eo._ProducteTraspasOrigen != null);
            dgvMovimentsProd.Columns["colTraspasDesti"].Visible = movimentsProducte.Any(eo => eo._ProducteTraspasDesti != null);
            dgvMovimentsProd.ClearSelection();
            int ultimaFila = dgvMovimentsProd.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (ultimaFila >= 0)
            {
                // Selecciona la última fila del dataGrid.
                dgvMovimentsProd.FirstDisplayedScrollingRowIndex = ultimaFila;
            }
            dgvMovimentsProd.ResumeLayout();
        }

        private void compra()
        {
            comprant = true;

            cProducteTraspas.SelectedItem = null;
            tbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            tbDespeses.Valor = 0;

            modeEdicio();
        }

        private void vendaTraspas()
        {
            comprant = false;

            Producte prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if (prod._TipusProducte == Producte.TipusProducte.Fons)
            {
                cProducteTraspas.SuspendLayout();
                cProducteTraspas.DisplayMember = "_NomProducte";
                cProducteTraspas.DataSource = Producte.Tuples.Where(w => w is ProdFons && w.Id != prod.Id).ToList();
                cProducteTraspas.ResumeLayout();
            }

            ntbPigVendaReal.Text = string.Empty;

            tbNumParticipacions.Valor = prod._Participacions;

            ntbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;

            modeEdicio();
        }

        private void dividents()
        {
            tbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            gbPreuPartic.Text = "Import Brut";

            modeEdicio();
        }

        private void split()
        {
            gbPreuPartic.Text = "Preu operació";
            vDesaToolTipGbPreuPartic = toolTip1.GetToolTip(gbPreuPartic);
            toolTip1.SetToolTip(gbPreuPartic, "Preu participació abans del Split");

            modeEdicio();
        }

        private void contraSplit()
        {
            gbPreuPartic.Text = "PV sobrants";
            vDesaToolTipGbPreuPartic = toolTip1.GetToolTip(gbPreuPartic);
            toolTip1.SetToolTip(gbPreuPartic, "Preu venda de les participacions sobrants del ContraSplit");

            modeEdicio();
        }

        /// <summary>
        ///     Modifica la tauma "Moviments"
        /// </summary>
        /// <param name="tipusMoviment">Compra o venda.</param>
        /// <param name="prodOrigen">Producte on es fa la compra/venda</param>
        /// <param name="prodDesti">
        ///     És el fons on van les participacions venudes en cas de traspàs. Si != null, ha de ser una venda
        ///     que es trapassa.
        /// </param>
        private void desaMoviment(TipusMoviment tipusMoviment, Producte prodOrigen, ProdFons prodDesti = null)
        {
            if (prodDesti != null && tipusMoviment != TipusMoviment.Traspàs)
                throw new ArgumentException("L'argument només pot estar informat si és un traspàs.", "prodDesti");

            using (var conn = new InversionsBDContext())
            {
                Producte prodOrigenContext = conn.Productes.Find(prodOrigen.Id);
                ProdFons prodDestiContext = prodDesti == null ? null : conn.ProdFons.Find(prodDesti.Id);

                using (DbContextTransaction dbContextTransaction = conn.Database.BeginTransaction())
                {
                    // Conserva la data però li posa l'hora actual.
                    DateTime data1 = cData1.Value.Date + DateTime.Now.TimeOfDay;

                    if (prodDestiContext == null)
                    {
                        if (tipusMoviment == TipusMoviment.Split)
                        {
                            prodOrigenContext.split(conn, data1, ntbFactorConversor._IntValue);
                        }
                        else if (tipusMoviment == TipusMoviment.ContraSplit)
                        {
                            prodOrigenContext.contraSplit(conn, data1, ntbFactorConversor._IntValue, ntbPreuParticipacio._DecimalValue, tbCanviAplicat._DecimalValue);
                        }
                        else
                        {
                            if (tipusMoviment == TipusMoviment.Compra)
                            {
                                prodOrigenContext.desaCompra(conn, data1, DateTime.Now.TimeOfDay, tbNumParticipacions._DecimalValue, ntbPreuParticipacio._DecimalValue,
                                    tbCanviAplicat._DecimalValue, tbDespeses._DecimalValue, tbDescripcio.Text);
                            }
                            else if (tipusMoviment == TipusMoviment.Venda)
                            {
                                decimal? pigVendaReal = String.IsNullOrEmpty(ntbPigVendaReal.Text) ? (decimal?) null : ntbPigVendaReal.Valor;

                                prodOrigenContext.desaVenda(conn, data1, DateTime.Now.TimeOfDay, tbNumParticipacions._DecimalValue, ntbPreuParticipacio._DecimalValue,
                                    tbCanviAplicat._DecimalValue, tbDespeses._DecimalValue, pigVendaReal, tbDescripcio.Text);
                            }
                            else if (tipusMoviment == TipusMoviment.Dividends)
                            {
                                prodOrigenContext.desaDividend(conn, data1, ntbPreuParticipacio._DecimalValue, tbCanviAplicat._DecimalValue, tbDespeses._DecimalValue, tbDescripcio.Text);
                            }
                        }
                    }
                    else
                    {
                        DateTime dataDesti = ckActivaDataDesti.Checked ? cDataDesti.Value : data1;
                        prodOrigenContext.desaTraspas(conn, data1, tbNumParticipacions._DecimalValue, ntbPreuParticipacio._DecimalValue, tbDescripcio.Text,
                            dataDesti, prodDestiContext, tbNumParticipacionsDesti._DecimalValue, ntbPreuParticipacioFonsCompra.Valor, ntbDespeses.Valor);
                    }

                    conn.SaveChanges();

                    dbContextTransaction.Commit();

                    Moviment.RefrescaTaula();
                    DesglosCompra.RefrescaTaula();
                }
            }

            Program.ConnectaSessio(); // Per refrescar les dades modificades.

            //gestioProductesTabMoviments.refrescaDadesControl(false);
            gestioProductesTabMoviments.refrescaDadesControl();

            ompleTaulaMovimentsProducte(prodDesti ?? prodOrigen);
        }

        private void calculaImportTotal()
        {
            decimal imp = ntbPreuParticipacio.Valor * tbNumParticipacions.Valor;
            if (comprant.GetValueOrDefault())
                imp += tbDespeses.Valor;
            else
                imp -= tbDespeses.Valor;

            tbImportTotal.Valor = imp;
        }

        protected override void modeConsulta()
        {
            base.modeConsulta();

            gbEdicio.Visible = false;

            cbTipusMoviment.Enabled = true;
            btCancelaMoviment.Enabled = false;
            btDesaMoviment.Enabled = false;
            gestioProductesTabMoviments.Enabled = true;

            gbPreuPartic.Text = "Preu Partic.";
            if (vDesaToolTipGbPreuPartic != null)
            {
                toolTip1.SetToolTip(gbPreuPartic, vDesaToolTipGbPreuPartic);
                vDesaToolTipGbPreuPartic = null;
            }

            cProducteTraspas.SelectedItem = null;
            cbTipusMoviment.SelectedItem = null;

            comprant = null;
        }

        protected override void modeEdicio()
        {
            base.modeEdicio();

            Producte.TipusProducte tipusProd = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte;
            bool esUnaAccio = tipusProd == Producte.TipusProducte.Accions;
            var tipusMov = (TipusMoviment) cbTipusMoviment.SelectedItem;

            gestioProductesTabMoviments.Enabled = false;
            cbTipusMoviment.Enabled = false;
            btFes.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btDesaMoviment.Enabled = true;

            gbDataMoviment.Visible = true;

            gbParticipacions.Visible = tipusMov == TipusMoviment.Compra || tipusMov == TipusMoviment.Venda || tipusMov == TipusMoviment.Traspàs;
            gbFactorConversor.Visible = tipusMov == TipusMoviment.Split || tipusMov == TipusMoviment.ContraSplit;
            gbPreuPartic.Visible = tipusMov != TipusMoviment.Split;
            gbCanviAplicat.Visible = esUnaAccio && tipusMov != TipusMoviment.Split;
            gbDespeses.Visible = esUnaAccio && (tipusMov == TipusMoviment.Compra || tipusMov == TipusMoviment.Venda);
            gbImportTotal.Visible = tipusMov == TipusMoviment.Compra || tipusMov == TipusMoviment.Venda || tipusMov == TipusMoviment.Traspàs;
            gbTraspas.Visible = tipusMov == TipusMoviment.Traspàs;
            ckActivaDataDesti.Visible = tipusMov == TipusMoviment.Traspàs;
            ckActivaDataDesti.Checked = false;
            gbDataDesti.Visible = false;
            gbNumParticipacionsDesti.Visible = tipusMov == TipusMoviment.Traspàs;
            gbDescripcio.Visible = !esUnaAccio || tipusMov == TipusMoviment.Dividends;
            gbPigVendaReal.Visible = !esUnaAccio && tipusMov == TipusMoviment.Venda;

            gbEdicio.Visible = true;
        }


        private void calculaPreuPartTraspasCompra()
        {
            ntbPreuParticipacioFonsCompra.Valor = tbImportTotal.Valor / tbNumParticipacionsDesti.Valor;
        }

        private void calculaDespesesTraspas()
        {
            decimal impTotalCompra = ntbPreuParticipacioFonsCompra.Valor * tbNumParticipacionsDesti.Valor;

            ntbDespeses.Valor = tbImportTotal.Valor == impTotalCompra ? 0 : tbImportTotal.Valor - impTotalCompra;
        }

        private void ntbPreuParticipacioFonsCompra_Leave(object sender, EventArgs e)
        {
            calculaDespesesTraspas();
        }

        private void ntbPreuParticipacioFonsCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                calculaDespesesTraspas();
        }

        #region *** Events ***

        private void ckActivaDataDesti_CheckedChanged(object sender, EventArgs e)
        {
            gbDataDesti.Visible = ckActivaDataDesti.Checked;
        }

        private void gestioProductes1_ProducteSeleccionat(object sender, EventArgs e)
        {
            canviProducteSeleccionat();
        }

        private void btDesaMoviment_Click(object sender, EventArgs e)
        {
            var tp = (TipusMoviment) cbTipusMoviment.SelectedItem;

            if (tp == TipusMoviment.Venda && !String.IsNullOrEmpty(ntbPigVendaReal.Text) && ntbPigVendaReal.Valor == 0)
            {
                // ntbPigVendaReal conté 0 i el control no està buit..
                if (MessageBox.Show("El valor de 'PiG Real és 0. Això és correcte?", "Avís",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    ntbPigVendaReal.Focus();
                    return;
                }
            }

            if ((tp == TipusMoviment.Compra || tp == TipusMoviment.Venda || tp == TipusMoviment.Traspàs) && tbNumParticipacions.Valor <= 0)
            {
                MessageBox.Show("Falta num. participacions");
                return;
            }

            if (tbNumParticipacions.Valor < 0)
            {
                MessageBox.Show("El num. participacions no pot ser negatiu");
                return;
            }

            if (ntbPreuParticipacio.Valor < 0)
            {
                MessageBox.Show("El preu participació no pot ser negatiu");
                return;
            }

            if (tp == TipusMoviment.Traspàs && cProducteTraspas.SelectedItem == null)
            {
                MessageBox.Show("Falta informar el producte destí");
                return;
            }

            if (cProducteTraspas.SelectedItem != null && tbNumParticipacionsDesti.Valor <= 0)
            {
                MessageBox.Show("Falta num. participacions producte destí");
                return;
            }

            if (tbNumParticipacionsDesti.Valor < 0)
            {
                MessageBox.Show("El num. participacions producte destí no pot ser negatiu");
                return;
            }

            Producte prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if ((tp == TipusMoviment.Venda || tp == TipusMoviment.Traspàs) && tbNumParticipacions.Valor > prod._Participacions)
            {
                MessageBox.Show("No hi ha prou participacions per vendre");
                return;
            }

            if (tp == TipusMoviment.Split || tp == TipusMoviment.ContraSplit)
            {
                if (ntbFactorConversor.Valor <= 0)
                {
                    MessageBox.Show("El valor del factor conversor de Split o Cantraplit ha de ser més gran de zero.");
                    return;
                }
                if (tp == TipusMoviment.ContraSplit && ntbPreuParticipacio.Valor <= 0)
                {
                    MessageBox.Show("El nou import de l'acció ha de ser més gran de zero.");
                    return;
                }
            }

            try
            {
                desaMoviment(tp, prod, (ProdFons) cProducteTraspas.SelectedItem);
            }
            catch (Exception ex1)
            {
                FileInfo log = Utilitats.EscriuLog(ex1, true, true);
                return;
            }

            ActivaRefrescaEnTabs(this);

            modeConsulta();
        }

        private void btCancelaMoviment_Click(object sender, EventArgs e)
        {
            modeConsulta();
        }

        private void cProducteTraspas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cProducteTraspas.SelectedItem == null)
            {
                gbDataDesti.Visible = false;
                gbNumParticipacionsDesti.Visible = false;
                pnProddesti.Visible = false;
            }
            else
            {
                cDataDesti.Value = cData1.Value;
                gbDataDesti.Visible = ckActivaDataDesti.Checked;
                gbNumParticipacionsDesti.Visible = true;
                pnProddesti.Visible = true;
            }
        }

        private void tbNumParticipacions_Leave(object sender, EventArgs e)
        {
            calculaImportTotal();
        }

        private void tbPreuParticipacio_Leave(object sender, EventArgs e)
        {
            calculaImportTotal();
        }

        private void tbDespeses_Leave(object sender, EventArgs e)
        {
            calculaImportTotal();
        }

        private void cDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                {
                    var prodTraspas = (Producte) dgvMovimentsProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (prodTraspas != null)
                    {
                        gestioProductesTabMoviments.seleccionaProducte(prodTraspas);
                    }
                }
            }
        }

        private void cbTipusMoviment_SelectedIndexChanged(object sender, EventArgs e)
        {
            btFes.Enabled = cbTipusMoviment.SelectedItem != null;
        }

        private void btFes_Click(object sender, EventArgs e)
        {
            if (cbTipusMoviment.SelectedItem != null)
            {
                switch ((TipusMoviment) cbTipusMoviment.SelectedItem)
                {
                    case TipusMoviment.Compra:
                        compra();
                        break;
                    case TipusMoviment.Venda:
                    case TipusMoviment.Traspàs:
                        vendaTraspas();
                        break;
                    case TipusMoviment.Dividends:
                        dividents();
                        break;
                    case TipusMoviment.Split:
                        split();
                        break;
                    case TipusMoviment.ContraSplit:
                        contraSplit();
                        break;
                    default:
                        break;
                }
            }
        }


        private void tbNumParticipacionsDesti_Leave(object sender, EventArgs e)
        {
            calculaPreuPartTraspasCompra();
        }

        private void tbNumParticipacionsDesti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                calculaPreuPartTraspasCompra();
        }

        #endregion *** Events ***

        /// <summary>
        ///     Estructura per omplir DgvCompresProducte
        /// </summary>
        private struct StrDgvMovimentsProd
        {
            private StrDgvMovimentsProd(Moviment moviment)
                : this()
            {
                _Id = moviment.Id;
                _Prod = moviment.Prod;
                _Data = moviment.Data;
                _Participacions = moviment.Participacions;
                _PreuParticipacio = moviment.PreuParticipacio;
                _ImportBrut = moviment.Participacions == 0 ? moviment.PreuParticipacio : moviment.Participacions * moviment.PreuParticipacio;
                _ImportNet = _ImportBrut + (moviment._EsCompra ? moviment.Despeses.GetValueOrDefault() : -moviment.Despeses.GetValueOrDefault());
                _CanviAplicat = moviment.CanviAplicat;
                _Despeses = moviment.Despeses.GetValueOrDefault();
                if (moviment.RefTraspas == null)
                {
                    _TipusMoviment = moviment.TipusMoviment.ToString();
                }
                else
                {
                    _TipusMoviment = (moviment.TipusMoviment == TipusMoviment.Compra ? "Traspàs C" : "Traspàs V");

                    _ProducteTraspasOrigen = moviment.TipusMoviment == TipusMoviment.Compra ? moviment.RefTraspas.Prod : null;
                    _ProducteTraspasDesti = moviment.TipusMoviment == TipusMoviment.Venda ? moviment.RefTraspas.Prod : null;
                }
                _Descripcio = moviment.Descripcio;
            }


// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local
            public int _Id { get; private set; }

            public string _TipusMoviment { get; private set; }

            public DateTime _Data { get; private set; }

            public Producte _Prod { get; private set; }

            public decimal _Participacions { get; private set; }

            public decimal _PreuParticipacio { get; private set; }

            public decimal _ImportBrut { get; private set; }

            public decimal _ImportNet { get; private set; }

            public decimal _CanviAplicat { get; private set; }

            public decimal _Despeses { get; private set; }

            public Producte _ProducteTraspasOrigen { get; private set; }

            public Producte _ProducteTraspasDesti { get; private set; }

            public string _Descripcio { get; private set; }

            internal static List<StrDgvMovimentsProd> CarregaStruct(IEnumerable<Moviment> movimentsProducte)
            {
                return movimentsProducte.Select(moviment => new StrDgvMovimentsProd(moviment)).ToList();
            }

// ReSharper restore UnusedAutoPropertyAccessor.Local
// ReSharper restore MemberCanBePrivate.Local
        }
    }
}