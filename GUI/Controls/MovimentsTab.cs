using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class MovimentsTab : UserControl
    {
        public MovimentsTab()
        {
            InitializeComponent();

            cDataGridView1.AutoGenerateColumns = false;

            cTipusMovimentTab2.SuspendLayout();
            cTipusMovimentTab2.DataSource = Enum.GetValues(typeof (TipusMoviment));
            cTipusMovimentTab2.SelectedItem = null;
            cTipusMovimentTab2.ResumeLayout();


            gestioProductesTabMoviments._NomesAmbParticipacions = true;
        }


        private static IEnumerable<Producte> LlistaProductes(Producte.TipusProducte tipusProducte)
        {
            List<Producte> prods = null;

            if (tipusProducte == Producte.TipusProducte.Accions)
            {
                prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdAccions>());
            }
            else if (tipusProducte == Producte.TipusProducte.Fons)
            {
                prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdFons>());
            }
            else
            {
                prods = Program.Sessio.Productes.ToList();
            }

            return prods.OrderBy(s => s._NomProducte);
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
            var movimentsProducte = Program.Sessio.Moviments.Where(w => w.Prod.Id == prod.Id).ToList();

            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = movimentsProducte.OrderBy(o => o.Data).ToList();
            cDataGridView1.Columns["colTraspasOrigen"].Visible = movimentsProducte.Exists(eo => eo._NomProducteTraspasOrigen != null);
            cDataGridView1.Columns["colTraspasDesti"].Visible = movimentsProducte.Exists(eo => eo._NomProducteTraspasDesti != null);
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

            cProducteTraspas.SelectedItem = null;
            cTipusMovimentTab2.SelectedItem = TipusMoviment.Compra;
            tbNumParticipacions.Valor = 0;
            tbPreuParticipacio.Valor = 0;
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

            gbEdicio.Visible = true;
            gestioProductesTabMoviments.Enabled = false;

            btVenda.Enabled = false;
            btDividends.Enabled = false;
            btCancelaMoviment.Enabled = true;
            btCompra.Enabled = false;
            btDesaMoviment.Enabled = true;

            tbNumParticipacions.Valor = prod._Participacions;

            cTipusMovimentTab2.SelectedItem = TipusMoviment.Venda;
            tbPreuParticipacio.Valor = 0;
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

            cTipusMovimentTab2.SelectedItem = TipusMoviment.Dividends;
            tbPreuParticipacio.Valor = 0;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";
        }


        private void btDesaMoviment_Click(object sender, EventArgs e)
        {
            TipusMoviment tp = (TipusMoviment) cTipusMovimentTab2.SelectedItem;

            //if (tbImport._DoubleValue <= 0)
            //{
            //    MessageBox.Show("Falta import");
            //    return;
            //}

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
            catch (DbEntityValidationException ex1)
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
            btDividends.Enabled = prod != null && prod._Participacions > 0;
            btCancelaMoviment.Enabled = false;
            btCompra.Enabled = true;
            btDesaMoviment.Enabled = false;

            cProducteTraspas.SelectedItem = null;

            comprant = null;
        }


        /// <summary>
        /// Modifica la tauma "Moviments"
        /// </summary>
        /// <param name="tipusMoviment">Compra o venda.</param>
        /// <param name="prod">Producte on es fa la compra/venda</param>
        /// <param name="producteOrigen">Si != null, ha de ser una compra que vé d'un traspàs. </param>
        private void desaMoviment(TipusMoviment tipusMoviment, Producte prod, ProdFons producteOrigen = null)
        {
            if ((tipusMoviment == TipusMoviment.Compra || tipusMoviment == TipusMoviment.Dividends) && producteOrigen != null)
                throw new ArgumentException("L'argument només pot estar informat si és una venda.", "movimentOrigen");

            using (var conn = new InversionsBDContext())
            {
                using (var dbContextTransaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        int prodId = prod.Id;
                        int? producteOrigenId = producteOrigen == null ?(int?) null : producteOrigen.Id;

                        Moviment mov = new Moviment();
                        mov.TipusMoviment = tipusMoviment;
                        mov.Participacions = (double)tbNumParticipacions.Valor;
                        mov.PreuParticipacio = tbPreuParticipacio._DoubleValue;
                        mov.Despeses = tbDespeses.Valor == 0 ? (double?)null : tbDespeses._DoubleValue;
                        mov.Data = cData1.Value;
                        mov.Descripcio = String.IsNullOrEmpty(tbDescripcio.Text) ? null : tbDescripcio.Text;
                        mov.ProdId = prodId;
                        mov.ProducteTraspasId = producteOrigenId;
                        
                        conn.Moviments.Add(mov);
                        //conn.SaveChanges();

                        if (tipusMoviment == TipusMoviment.Venda && producteOrigenId.HasValue)
                        {
                            // És un traspàs

                            //double importOriginal =  0;
                            //foreach (var VARIABLE in Program.Sessio.Moviments.Where(w=>w.ProdId == prodId && w._EsCompra && w.Data <= ))
                            //{
                                
                            //}

                            Moviment mov2 = new Moviment();
                            mov2.TipusMoviment = TipusMoviment.Compra;
                            mov2.Participacions = tbNumParticipacionsDesti.Valor;
                            mov2.PreuParticipacio = mov.Participacions * mov.PreuParticipacio / tbNumParticipacionsDesti.Valor;
                            mov.Despeses = null;
                            mov2.Data = cDataDesti.Value;
                            mov2.Descripcio = String.IsNullOrEmpty(tbDescripcio.Text) ? null : tbDescripcio.Text;
                            mov2.ProdId = producteOrigenId.Value;
                            mov2.ProducteTraspasId = prodId;

                            conn.Moviments.Add(mov2);
                            conn.SaveChanges();

                            // Ho faig així sinó dona error.
                            mov2.IdRefVenda = mov.Id;
                        }

                        conn.SaveChanges();

                        dbContextTransaction.Commit();

                        gestioProductesTabMoviments._ProducteSeleccionat = prod;
                        ompleTaulaMovimentsProducte(producteOrigen ?? prod);
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
            btDividends.Enabled = prod != null && prod._Participacions > 0;
            btCancelaMoviment.Enabled = false;
            btCompra.Enabled = true;
            btDesaMoviment.Enabled = false;

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

    }
}