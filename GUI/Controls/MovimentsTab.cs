using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class MovimentsTab : UserControl, ITabs
    {
        // Todo - Moneda. Les valoracions del valors en dolars els hauria de veure convertits a Euros a partir del l'ultim canvi de moneda introduit.
        // Todo - Afegir pestanya amb simulació venda. Veuria les PiG i l'import a tributar en cas d'una venda.
        // Todo - La casella PiG actual no l'entenc, hauria de ser el PiG dels valors actualment en cartera.

        public MovimentsTab()
        {
            InitializeComponent();

            // if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                cDataGridView1.AutoGenerateColumns = false;
            }
        }

        private void gestioProductes1_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (sender == null)
            {
                cbTipusMoviment.Enabled = false;
                btCancelaMoviment.Enabled = false;
                //btFes.Enabled = false;
                btDesaMoviment.Enabled = false;
            }
            else
            {
                var prod = (Producte) sender;

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
                    if (prod._TipusProducte == Producte.TipusProducte.Accions)
                    {
                        cbTipusMoviment.Items.Add(TipusMoviment.Dividends);
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

        private void compra()
        {
            comprant = true;

            cProducteTraspas.SelectedItem = null;
            tbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            tbDespeses.Valor = 0;

            preparaPantallaEdicio();
        }

        private void vendaTraspas()
        {
            comprant = false;

            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if (prod._TipusProducte == Producte.TipusProducte.Fons)
            {
                cProducteTraspas.SuspendLayout();
                cProducteTraspas.DisplayMember = "_NomProducte";
                cProducteTraspas.DataSource = Program.Sessio.Productes.Where(w => w is ProdFons && w.Id != prod.Id).ToList();
                cProducteTraspas.ResumeLayout();
            }

            tbNumParticipacions.Valor = prod._Participacions;

            ntbPreuParticipacio.Valor = 0;
            tbCanviAplicat.Valor = 1;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;

            preparaPantallaEdicio();
        }


        private void dividents()
        {
            tbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            gbPreuPartic.Text = "Import Brut";

            preparaPantallaEdicio();
        }


        private string vDesaToolTipGbPreuPartic = null;
        private void split()
        {
            gbPreuPartic.Text = "Preu operació";
            vDesaToolTipGbPreuPartic = this.toolTip1.GetToolTip(this.gbPreuPartic);
            toolTip1.SetToolTip(this.gbPreuPartic, "Preu participació abans del Split");

            preparaPantallaEdicio();
        }


        private void contraSplit()
        {
            gbPreuPartic.Text = "Preu abans";
            vDesaToolTipGbPreuPartic = this.toolTip1.GetToolTip(this.gbPreuPartic);
            toolTip1.SetToolTip(this.gbPreuPartic, "Preu participació abans del ContraSplit");

            preparaPantallaEdicio();
        }

        private void btDesaMoviment_Click(object sender, EventArgs e)
        {
            TipusMoviment tp = (TipusMoviment) cbTipusMoviment.SelectedItem;

            if ((tp == TipusMoviment.Compra || tp == TipusMoviment.Venda || tp == TipusMoviment.Traspàs) && tbNumParticipacions.Valor <= 0)
            {
                MessageBox.Show("Falta num. participacions");
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

            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if ((tp == TipusMoviment.Venda || tp == TipusMoviment.Traspàs) && tbNumParticipacions.Valor > prod._Participacions)
            {
                MessageBox.Show("No hi ha prou participacions per vendre");
                return;
            }

            if (tp == TipusMoviment.Split || tp == TipusMoviment.ContraSplit)
            {
                if (ntbFactorConversor.Valor <= 0)
                {
                    MessageBox.Show("El valor del Split o Cantraplit ha de ser més gran de zero.");
                    return;
                }
                if (ntbPreuParticipacio.Valor <= 0)
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
                MessageBox.Show(ex1.Message);
                return;
            }

            preparaPantallaConsulta();
        }


        private void btCancelaMoviment_Click(object sender, EventArgs e)
        {
            preparaPantallaConsulta();
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
            if (prodDesti != null && tipusMoviment != TipusMoviment.Traspàs)
                throw new ArgumentException("L'argument només pot estar informat si és un traspàs.", "prodDesti");

            using (var conn = new InversionsBDContext())
            {
                using (var dbContextTransaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        if (prodDesti == null)
                        {
                            if (tipusMoviment == TipusMoviment.Split)
                            {
                                prodOrigen.split(conn, cData1.Value, ntbFactorConversor._IntValue);
                            }
                            else if (tipusMoviment == TipusMoviment.ContraSplit)
                            {
                                prodOrigen.contraSplit(conn, cData1.Value, ntbFactorConversor._IntValue, ntbPreuParticipacio._DoubleValue, tbCanviAplicat._DoubleValue);
                            }
                            else
                            {
                                //prodOrigen.compraVenda(conn, tipusMoviment, cData1.Value, tbNumParticipacions._DoubleValue, ntbPreuParticipacio._DoubleValue, tbCanviAplicat._DoubleValue, 
                                //    tbDespeses._DoubleValue, tbDescripcio.Text);
                                if (tipusMoviment == TipusMoviment.Compra)
                                {
                                    prodOrigen.compra(conn, cData1.Value, DateTime.Now.TimeOfDay, tbNumParticipacions._DoubleValue, ntbPreuParticipacio._DoubleValue, 
                                        tbCanviAplicat._DoubleValue, tbDespeses._DoubleValue, tbDescripcio.Text);
                                }
                                else if (tipusMoviment == TipusMoviment.Venda)
                                {
                                    prodOrigen.venda(conn, cData1.Value, DateTime.Now.TimeOfDay, tbNumParticipacions._DoubleValue, ntbPreuParticipacio._DoubleValue,
                                        tbCanviAplicat._DoubleValue, tbDespeses._DoubleValue, tbDescripcio.Text);
                                }
                            }
                        }
                        else
                        {
                            var dataDesti = ckActivaDataDesti.Checked ? cDataDesti.Value : cData1.Value;
                            prodOrigen.traspas(conn, cData1.Value, tbNumParticipacions._DoubleValue, ntbPreuParticipacio._DoubleValue, tbDescripcio.Text, dataDesti,
                                prodDesti, tbNumParticipacionsDesti._DoubleValue);
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
            var imp = ntbPreuParticipacio.Valor * tbNumParticipacions.Valor;
            if (comprant.GetValueOrDefault())
                imp += tbDespeses.Valor;
            else
                imp -= tbDespeses.Valor;

            tbImportTotal.Valor = imp;
        }


        private void cDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var prodTraspas = (Producte) cDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (prodTraspas != null)
                {
                    gestioProductesTabMoviments._ProducteSeleccionat = prodTraspas;
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


        private void preparaPantallaConsulta()
        {
            gbEdicio.Visible = false;
            
            cbTipusMoviment.Enabled = true;
            btCancelaMoviment.Enabled = false;
            btDesaMoviment.Enabled = false;
            gestioProductesTabMoviments.Enabled = true;
            
            gbPreuPartic.Text = "Preu Partic.";
            if (vDesaToolTipGbPreuPartic != null)
            {
                toolTip1.SetToolTip(this.gbPreuPartic, vDesaToolTipGbPreuPartic);
                vDesaToolTipGbPreuPartic = null;
            }


            cProducteTraspas.SelectedItem = null;
            cbTipusMoviment.SelectedItem = null;

            comprant = null;
        }


        private void preparaPantallaEdicio()
        {
            var tipusProd = gestioProductesTabMoviments._ProducteSeleccionat._TipusProducte;
            var esUnaAccio = tipusProd == Producte.TipusProducte.Accions;
            var tipusMov = (TipusMoviment) cbTipusMoviment.SelectedItem;

            gestioProductesTabMoviments.Enabled = false;
            cbTipusMoviment.Enabled = false;
            btFes.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btDesaMoviment.Enabled = true;

            gbDataMoviment.Visible = true;;
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
            gbDescripcio.Visible = !esUnaAccio;

            gbEdicio.Visible = true;
        }

        private void ckActivaDataDesti_CheckedChanged(object sender, EventArgs e)
        {
            gbDataDesti.Visible = ckActivaDataDesti.Checked;
        }
    }
}