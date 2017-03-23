using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class MovimentsTab : UserControl, ITabs
    {
        public MovimentsTab()
        {
            InitializeComponent();

           // if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                cDataGridView1.AutoGenerateColumns = false;

                cbTipusMovimentTab2.SuspendLayout();
                cbTipusMovimentTab2.DataSource = Enum.GetValues(typeof (TipusMoviment));
                cbTipusMovimentTab2.SelectedItem = null;
                cbTipusMovimentTab2.ResumeLayout();


                gestioProductesTabMoviments._NomesAmbParticipacions = true;
            }
        }

        private void gestioProductes1_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (sender == null)
            {
                btCancelaMoviment.Enabled = false;
                btCompra.Enabled = false;
                btVenda.Enabled = false;
                btDividends.Enabled = false;
                btDesaMoviment.Enabled = false;
            }
            else
            {
                var prod = (Producte) sender;

                ompleTaulaMovimentsProducte(prod);

                gbTraspas.Visible = false;
                gbNumParticipacionsDesti.Visible = prod._TipusProducte == Producte.TipusProducte.Fons;
                gbEdicio.Visible = false;

                btVenda.Enabled = prod._Participacions > 0;
                btDividends.Enabled = prod._TipusProducte == Producte.TipusProducte.Accions && prod._Participacions > 0;
                btCancelaMoviment.Enabled = false;
                btCompra.Enabled = true;
                btDesaMoviment.Enabled = false;

                btVenda.Text = prod._TipusProducte == Producte.TipusProducte.Fons ? "Venda\nTraspàs" : "Venda";

            }

        }

        private void ompleTaulaMovimentsProducte(Producte prod)
        {
            var movimentsProducte = Program.Sessio.MovimentsUsuari.Where(w => w.Prod.Id == prod.Id).ToList();

            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = movimentsProducte.OrderBy(o => o.Data).ToList();
            cDataGridView1.Columns["colTraspasOrigen"].Visible = movimentsProducte.Any(eo => eo._ProducteTraspasOrigen != null);
            cDataGridView1.Columns["colTraspasDesti"].Visible = movimentsProducte.Any(eo => eo._ProducteTraspasDesti != null);
            cDataGridView1.ClearSelection();
            var ultimaFila = cDataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (ultimaFila >= 0)
            {
                // Selecciona la última fila del dataGrid.
                cDataGridView1.FirstDisplayedScrollingRowIndex = ultimaFila;
            }
            cDataGridView1.ResumeLayout();
        }

        private bool? comprant = null;

        private void btCompra_Click(object sender, EventArgs e)
        {
            comprant = true;

            gbTraspas.Visible = false;
            gbNumParticipacionsDesti.Visible = false;
            gbEdicio.Visible = true;
            gestioProductesTabMoviments.Enabled = false;

            btVenda.Enabled = false;
            btDividends.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btCompra.Enabled = false;
            btDesaMoviment.Enabled = true;
            gbDespeses.Visible = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte == Producte.TipusProducte.Accions;
            gbCanviAplicat.Visible = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte == Producte.TipusProducte.Accions;

            cProducteTraspas.SelectedItem = null;
            cbTipusMovimentTab2.SelectedItem = TipusMoviment.Compra;
            tbNumParticipacions.Valor = 0;
            tbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";
        }

        private void btVenda_Click(object sender, EventArgs e)
        {
            comprant = false;

            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if (prod._TipusProducte == Producte.TipusProducte.Fons)
            {
                gbTraspas.Visible = true;
                gbNumParticipacionsDesti.Visible = true;

                cProducteTraspas.SuspendLayout();
                cProducteTraspas.DisplayMember = "_NomProducte";
                cProducteTraspas.DataSource = Program.Sessio.Productes.Where(w => w is ProdFons && w.Id != prod.Id).ToList();
                cProducteTraspas.ResumeLayout();
            }
            else
            {
                gbTraspas.Visible = false;
                gbNumParticipacionsDesti.Visible = false;
            }

            gbDespeses.Visible = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte == Producte.TipusProducte.Accions;
            gbCanviAplicat.Visible = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte == Producte.TipusProducte.Accions;

            gbEdicio.Visible = true;
            gestioProductesTabMoviments.Enabled = false;

            btVenda.Enabled = false;
            btDividends.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btCompra.Enabled = false;
            btDesaMoviment.Enabled = true;

            tbNumParticipacions.Valor = prod._Participacions;

            cbTipusMovimentTab2.SelectedItem = TipusMoviment.Venda;
            tbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";
        }


        private void btDividends_Click(object sender, EventArgs e)
        {
            gbTraspas.Visible = false;
            gbNumParticipacionsDesti.Visible = false;

            gbEdicio.Visible = true;
            gestioProductesTabMoviments.Enabled = false;
            gbParticipacions.Visible = false;

            btVenda.Enabled = false;
            btDividends.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btCompra.Enabled = false;
            btDesaMoviment.Enabled = true;
            gbDespeses.Visible = false;

            tbNumParticipacions.Valor = 0;

            cbTipusMovimentTab2.SelectedItem = TipusMoviment.Dividends;
            tbPreuParticipacio.Valor = 0;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";


            gbImportTotal.Visible = false;
            gbPreuPartic.Text = "Import Brut";

        }


        private void btDesaMoviment_Click(object sender, EventArgs e)
        {
            TipusMoviment tp = (TipusMoviment) cbTipusMovimentTab2.SelectedItem;

            if (tp != TipusMoviment.Dividends && tbNumParticipacions.Valor <= 0)
            {
                MessageBox.Show("Falta num. participacions");
                return;
            }

            if (cProducteTraspas.SelectedItem != null && tbNumParticipacionsDesti.Valor <= 0)
            {
                MessageBox.Show("Falta num. participacions producte destí");
                return;
            }

            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if (tp == TipusMoviment.Venda && tbNumParticipacions.Valor > prod._Participacions)
            {
                MessageBox.Show("No hi ha prou participacions per vendre");
                return;
            }

            try
            {
                desaMoviment(tp, prod, (ProdFons) cProducteTraspas.SelectedItem);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                return;
            }


            gbTraspas.Visible = false;
            gbNumParticipacionsDesti.Visible = false;
            gbEdicio.Visible = false;
            gestioProductesTabMoviments.Enabled = true;
            gbParticipacions.Visible = true;

            btVenda.Enabled = prod != null && prod._Participacions > 0;
            btDividends.Enabled = prod != null && prod._TipusProducte == Producte.TipusProducte.Accions && prod._Participacions > 0;
            btCancelaMoviment.Enabled = false;
            btCompra.Enabled = true;
            btDesaMoviment.Enabled = false;

            gbImportTotal.Visible = true;
            gbPreuPartic.Text = "Preu Partic.";


            cProducteTraspas.SelectedItem = null;

            comprant = null;
        }

        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabMoviments._UsuariSeleccionat = usuari;
            cDataGridView1.DataSource = null;
        }


        /// <summary>
        /// Modifica la tauma "Moviments"
        /// </summary>
        /// <param name="tipusMoviment">Compra o venda.</param>
        /// <param name="prodOrigen">Producte on es fa la compra/venda</param>
        /// <param name="prodDesti">És el fons on van les participacions venudes en cas de traspàs. Si != null, ha de ser una venda que es trapassa. </param>
        private void desaMoviment(TipusMoviment tipusMoviment, Producte prodOrigen, ProdFons prodDesti = null)
        {
            if (prodDesti != null && tipusMoviment != TipusMoviment.Venda)
                throw new ArgumentException("L'argument només pot estar informat si és una venda.", "prodDesti");

            using (var conn = new InversionsBDContext())
            {
                using (var dbContextTransaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        if (prodDesti == null)
                        {
                            prodOrigen.compraVenda(conn, tipusMoviment, cData1.Value, tbNumParticipacions._DoubleValue, tbPreuParticipacio._DoubleValue, tbCanviAplicat._DoubleValue,
                                tbDespeses._DoubleValue, tbDescripcio.Text);
                        }
                        else
                        {
                            prodOrigen.traspas(conn, cData1.Value, tbNumParticipacions._DoubleValue, tbPreuParticipacio._DoubleValue, 1, tbDescripcio.Text, 
                                cDataDesti.Value,  prodDesti, tbNumParticipacionsDesti._DoubleValue);
                        }

                        dbContextTransaction.Commit();

                        gestioProductesTabMoviments._ProducteSeleccionat = prodOrigen;
                        ompleTaulaMovimentsProducte(prodDesti ?? prodOrigen);
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                }
            }
        }


        private void btCancelaMoviment_Click(object sender, EventArgs e)
        {
            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            gbTraspas.Visible = false;
            gbEdicio.Visible = false;
            gestioProductesTabMoviments.Enabled = true;
            gbParticipacions.Visible = true;

            btVenda.Enabled = prod != null && prod._Participacions > 0;
            btDividends.Enabled = prod != null && prod._TipusProducte == Producte.TipusProducte.Accions && prod._Participacions > 0;
            btCancelaMoviment.Enabled = false;
            btCompra.Enabled = true;
            btDesaMoviment.Enabled = false;

            gbImportTotal.Visible = true;
            gbPreuPartic.Text = "Preu Partic.";

            cProducteTraspas.SelectedItem = null;

            comprant = null;
        }

        private void cProducteTraspas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cProducteTraspas.SelectedItem == null)
            {
                gbDataDesti.Visible = false;
                gbNumParticipacionsDesti.Visible = false;
            }
            else
            {
                cDataDesti.Value = cData1.Value;
                gbDataDesti.Visible = true;
                gbNumParticipacionsDesti.Visible = true;
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

        private void calculaImportTotal()
        {
            var imp = tbPreuParticipacio.Valor * tbNumParticipacions.Valor;
            if (comprant.GetValueOrDefault())
                imp += tbDespeses.Valor;
            else
                imp -= tbDespeses.Valor;

            tbImportTotal.Valor = imp;
        }

        private void cDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                var prodTraspas = (Producte)cDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (prodTraspas != null)
                {
                    gestioProductesTabMoviments._ProducteSeleccionat = prodTraspas;
                }
            }
        }
    }
}