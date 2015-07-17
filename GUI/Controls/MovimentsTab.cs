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
            cTipusMovimentTab2.DataSource = Enum.GetValues(typeof(TipusMoviment));
            cTipusMovimentTab2.SelectedItem = null;
            cTipusMovimentTab2.ResumeLayout();
        }


        private static IEnumerable<Producte> LlistaProductes(Producte.TipusProducte tipusProducte)
        {
            List<Producte> prods = null;

            if (tipusProducte == Producte.TipusProducte.Accions)
            {
                prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdAccions>());
            }
            else if (tipusProducte == Producte.TipusProducte.Fons)
            {
                prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdFons>());
            }
            else
            {
                prods = MyClass.Sessio.Productes.ToList();
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
            else{
                var prod = (Producte)sender;

                ompleTaulaMovimentsProducte(prod);

                gbTraspas.Visible = false;
                gbNumParticipacionsDesti.Visible = prod._TipusProducte == Producte.TipusProducte.Fons;
                gbEdicio.Visible = false;

                btVenda.Enabled = prod._Participacions > 0;
                btDividends.Enabled = prod._TipusProducte == Producte.TipusProducte.Accions && prod._Participacions > 0;
                btCancelaMoviment.Enabled = false;
                btCompra.Enabled = true;
                btDesaMoviment.Enabled = false;
            }

        }

        private void ompleTaulaMovimentsProducte(Producte prod)
        {
            var movimentsProducte = MyClass.Sessio.Moviments.Where(w => w.Prod.Id == prod.Id).ToList();

            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = movimentsProducte.OrderBy(o=>o.Data).ToList();
            cDataGridView1.Columns["colTraspasOrigen"].Visible = movimentsProducte.Exists(eo => eo._NomProducteTraspasOrigen != null);
            cDataGridView1.Columns["colTraspasDesti"].Visible = movimentsProducte.Exists(eo => eo._NomProducteTraspasDesti != null);
            cDataGridView1.ClearSelection();
            cDataGridView1.ResumeLayout();
        }


        private void btCompra_Click(object sender, EventArgs e)
        {
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
            tbImport.Valor = 0;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";
        }

        private void btVenda_Click(object sender, EventArgs e)
        {
            var prod = gestioProductesTabMoviments._ProducteSeleccionat;

            if (prod._TipusProducte == Producte.TipusProducte.Fons)
            {
                gbTraspas.Visible = true;
                gbNumParticipacionsDesti.Visible = true;

                cProducteTraspas.SuspendLayout();
                cProducteTraspas.DisplayMember = "_NomProducte";
                cProducteTraspas.DataSource = MyClass.Sessio.Productes.Where(w => w is ProdFons && w.Id != prod.Id).ToList();
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

            tbNumParticipacions.Valor =prod._Participacions;

            cTipusMovimentTab2.SelectedItem = TipusMoviment.Venda;
            tbImport.Valor = 0;
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

            tbNumParticipacions.Valor =0;

            cTipusMovimentTab2.SelectedItem = TipusMoviment.Dividends;
            tbImport.Valor = 0;
            cProducteTraspas.SelectedItem = null;
            tbNumParticipacionsDesti.Valor = 0;
            tbDespeses.Valor = 0;
            tbDescripcio.Text = "";
        }


        private void btDesaMoviment_Click(object sender, EventArgs e)
        {
            TipusMoviment tp = (TipusMoviment)cTipusMovimentTab2.SelectedItem;

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

            if(tp== TipusMoviment.Venda && tbNumParticipacions.Valor > prod._Participacions)
            {
                MessageBox.Show("No hi ha proutes participacions per vemdre");
                return;
            }

            try
            {
                desaMoviment(tp, prod, (ProdFons)cProducteTraspas.SelectedItem);
            }
            catch (DbEntityValidationException ex1)
            {
                MessageBox.Show(ex1.Message);
                return;
            }


            //if (tp == TipusMoviment.Compra)
            //{
            //    // Compra

            //    try
            //    {
            //        desaMoviment(TipusMoviment.Compra, prod);
            //    }
            //    catch (DbEntityValidationException ex1)
            //    {
            //        MessageBox.Show(ex1.Message);
            //        return;
            //    }
            //}
            //else if (tp == TipusMoviment.Venda)
            //{
            //        // Venda/Traspàs

            //        try
            //        {
            //            desaMoviment(TipusMoviment.Venda, prod, (ProdFons)cProducteTraspas.SelectedItem);
            //        }
            //        catch (DbEntityValidationException ex1)
            //        {
            //            MessageBox.Show(ex1.Message);
            //            return;
            //        }
            //}
            //else if (tp == TipusMoviment.Dividends)
            //{
            //    // Pagament dividents

            //    try
            //    {
            //        desaMoviment(TipusMoviment.Dividends, prod);
            //    }
            //    catch (DbEntityValidationException ex1)
            //    {
            //        MessageBox.Show(ex1.Message);
            //        return;
            //    }
            //}

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
        }


        /// <summary>
        /// Modifica la tauma "Moviments"
        /// </summary>
        /// <param name="tipusMoviment">Compra o venda.</param>
        /// <param name="prod">Producte on es fa la compra/venda</param>
        /// <param name="movimentOrigen">Si != null, ha de ser una compra que vé d'un traspàs. </param>
        private void desaMoviment(TipusMoviment tipusMoviment, Producte prod, ProdFons movimentOrigen = null)
        {
            if ((tipusMoviment == TipusMoviment.Compra || tipusMoviment == TipusMoviment.Dividends) && movimentOrigen != null)
                throw new ArgumentException("L'argument només pot estar informat si és una venda.", "movimentOrigen");

            using (var dbContextTransaction = MyClass.Sessio.Database.BeginTransaction())
            {
                try
                {
                    Moviment mov = new Moviment();
                    mov.TipusMoviment = tipusMoviment;
                    mov.Import = tbImport._DoubleValue;
                    mov.Despeses = tbDespeses.Valor == 0 ? (double?) null : tbDespeses._DoubleValue;
                    mov.Data = cData1.Value;
                    mov.Descripcio = String.IsNullOrEmpty(tbDescripcio.Text) ? null : tbDescripcio.Text;
                    mov.Participacions = (double) tbNumParticipacions.Valor;
                    mov.Prod = prod;
                    mov.ProducteTraspas = movimentOrigen;

                    MyClass.Sessio.Moviments.Add(mov);
                    MyClass.Sessio.SaveChanges();

                    if (tipusMoviment == TipusMoviment.Venda && movimentOrigen != null)
                    {
                        // És un traspàs

                        Moviment mov2 = mov.Duplica();
                        mov2.TipusMoviment = TipusMoviment.Compra;
                        mov.Despeses = null;
                        mov2.Data = cDataDesti.Value;
                        mov2.Participacions = (double)tbNumParticipacionsDesti.Valor;
                        mov2.Prod = movimentOrigen;
                        mov2.ProducteTraspas = prod;
                        
                        MyClass.Sessio.Moviments.Add(mov2);
                        MyClass.Sessio.SaveChanges();
                    }

                    dbContextTransaction.Commit();

                    gestioProductesTabMoviments._ProducteSeleccionat = prod;
                    ompleTaulaMovimentsProducte(movimentOrigen ?? prod);
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
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
        }

        private void cProducteTraspas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cProducteTraspas.SelectedItem == null)
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
    }
}