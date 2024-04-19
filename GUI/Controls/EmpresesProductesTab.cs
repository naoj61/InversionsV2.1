using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Controls;
using DevExpress.Utils.Paint;

namespace Inversions.GUI
{
    public partial class EmpresesProductesTab : TabX
    {
        private const string NomVarReg = "UltimaPestanyaSeleccionada";
        private InversionsBDContext vConnEmpreses;
        private InversionsBDContext vConnProductes;
        private Empresa vEmpresaSeleccionada;
        private Producte vProducteSeleccionat;

        public EmpresesProductesTab()
        {
            InitializeComponent();
            }


        #region *** Mètodes ***

        /// <summary>
        /// Mostra o amaga els controls en funvio del tipus d'empresa seleccionada.
        /// </summary>
        private void preparaControlsProducte()
        {
            if (vEmpresaSeleccionada == null)
                return;

            if (ckTotesLesEmpreses.Checked)
            {
                grNomProducte.Enabled = false;
                grMercatProducte.Visible = false;
                grMonedaProducte.Visible = false;
                grIsinProducte.Visible = false;
                grDescripcioProducte.Visible = false;

                ntbOrdreGridProducte.Focus();
            }
            else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
            {
                grNomProducte.Enabled = false;
                grMercatProducte.Visible = true;
                grMonedaProducte.Visible = true;
                grIsinProducte.Visible = false;
                grDescripcioProducte.Visible = false;

                ntbOrdreGridProducte.Focus();
            }
            else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
            {
                grNomProducte.Enabled = true;
                grMercatProducte.Visible = false;
                grMonedaProducte.Visible = false;
                grIsinProducte.Visible = true;
                grDescripcioProducte.Visible = true;

                tbNomProducte.Focus();
            }
        }

        private void carregaGridProductes(Empresa empresa)
        {
            vConnProductes = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.

            if (empresa == null)
            {
                vConnProductes.Productes.Load();
                dgvProductes.DataSource = vConnProductes.Productes.Local.ToBindingList();
            }
            else
            {
                if (empresa.TipusEmpresa == TipusEmpresa.Accions)
                {
                    vConnProductes.ProdAccions.Where(w => w.EmpresaId == empresa.Id).Load();
                    dgvProductes.DataSource = vConnProductes.ProdAccions.Local.ToBindingList();
                }
                else if (empresa.TipusEmpresa == TipusEmpresa.GestoraFons)
                {
                    vConnProductes.ProdFons.Where(w => w.EmpresaId == empresa.Id).Load();
                    dgvProductes.DataSource = vConnProductes.ProdFons.Local.ToBindingList();
                }
            }

            if (((ICollection) dgvProductes.DataSource).Count == 0)
            {
                tbNomProducte.Text = String.Empty;
                ntbOrdreGridProducte.Valor = 0;
                cbMercatProducte.SelectedItem = null;
                cbMonedaProducte.SelectedItem = null;
                cbTipusProducte.SelectedItem = null;
                tbIsinProducte.Text = String.Empty;
                tbDescripcioProducte.Text = String.Empty;

                modeConsulta();

                preparaControlsProducte();
            }
            else
            {
                if (empresa == null)
                    btNouProducte.Enabled = false;
                else
                    btNouProducte.Enabled = empresa.TipusEmpresa == TipusEmpresa.GestoraFons;
            }
        }

        private void ompleCampsProducte(Producte producte)
        {
            if (vEmpresaSeleccionada == null)
                return;

            preparaControlsProducte();

            if (producte == null)
            {
                tbNomProducte.Text = String.Empty;
                ntbOrdreGridProducte.Valor = 0;
                cbMercatProducte.SelectedItem = null;
                cbMonedaProducte.SelectedItem = null;
                cbTipusProducte.SelectedItem = null;
                tbIsinProducte.Text = String.Empty;
                tbDescripcioProducte.Text = String.Empty;
            }
            else
            {
                tbNomProducte.Text = producte._NomProducte;
                ntbOrdreGridProducte.Valor = producte.OrdreGrid.GetValueOrDefault();

                if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
                {
                    cbMercatProducte.SelectedItem = producte._Mercat;
                    cbMonedaProducte.SelectedItem = (Utilitats.Monedes) Enum.Parse(typeof (Utilitats.Monedes), producte.Moneda);
                    gbTipusProducte.Visible = false;
                }
                else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
                {
                    tbIsinProducte.Text = producte._Isin;
                    tbDescripcioProducte.Text = producte._Descripcio;
                    cbTipusProducte.SelectedItem = ((ProdFons) producte).Tipus;
                    gbTipusProducte.Visible = true;
                }
            }
        }

        private void carregaGridEmpreses()
        {
            vConnEmpreses = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.
            vConnEmpreses.Empreses.Load();

            dgvEmpreses.DataSource = vConnEmpreses.Empreses.Local.ToBindingList();
        }

        private void teclaEscapeEdicioProducte()
        {
            IValorControlRestaurable control = ActiveControl as IValorControlRestaurable;
            if (control != null)
            {
                if (control.Modified)
                    control.Undo();
            }
        }

        internal override void carregaInicial()
        {
            base.carregaInicial();

            dgvEmpreses.AutoGenerateColumns = false;
            dgvProductes.AutoGenerateColumns = false;


            cbMercatProducte.SuspendLayout();
            cbMercatProducte.DisplayMember = "Nom";
            cbMercatProducte.DataSource = Mercat.Tuples.ToList();
            cbMercatProducte.SelectedItem = null;
            cbMercatProducte.ResumeLayout();

            cbMonedaProducte.SuspendLayout();
            cbMonedaProducte.DataSource = Enum.GetValues(typeof(Comuns.Utilitats.Monedes));
            cbMonedaProducte.SelectedItem = null;
            cbMonedaProducte.ResumeLayout();


            cbTipusProducte.SuspendLayout();
            cbTipusProducte.DataSource = Enum.GetValues(typeof(TipusFons));
            cbTipusProducte.SelectedItem = null;
            cbTipusProducte.ResumeLayout();

            modeConsulta();
        }

        protected override void modeEdicio()
        {
            base.modeEdicio();

            btDesaProducte.Enabled = true;
            btCancelaProducte.Enabled = true;
            btNouProducte.Enabled = false;
            btEsborraProducte.Enabled = false;
            btEditaProducte.Enabled = false;
            grEmpresa.Enabled = false;
            dgvProductes.Enabled = false;
            cbMonedaProducte.Enabled = true;
            cbMercatProducte.Enabled = true;
            cbTipusProducte.Enabled = true;
            //pnCampsProductes.Enabled = true;
            tbNomProducte.ReadOnly = false;
            ntbOrdreGridProducte.ReadOnly = false;
            tbIsinProducte.ReadOnly = false;
            tbDescripcioProducte.ReadOnly = false;
        }

        protected override void modeConsulta()
        {
            base.modeConsulta();

            btDesaProducte.Enabled = false;
            btCancelaProducte.Enabled = false;
            //btNouProducte.Enabled = vProducteSeleccionat != null;
            btNouProducte.Enabled = true;
            btEsborraProducte.Enabled = vProducteSeleccionat != null;
            btEditaProducte.Enabled = vProducteSeleccionat != null;
            grEmpresa.Enabled = true;
            dgvProductes.Enabled = true;
            cbMonedaProducte.Enabled = false;
            cbMercatProducte.Enabled = false;
            cbTipusProducte.Enabled = false;
            //pnCampsProductes.Enabled = false;
            tbNomProducte.ReadOnly = true;
            ntbOrdreGridProducte.ReadOnly = true;
            tbIsinProducte.ReadOnly = true;
            tbDescripcioProducte.ReadOnly = true;
        }

        internal override void escape(object sender, KeyEventArgs e)
        {
            base.escape(sender, e);

            teclaEscapeEdicioProducte();
        }

        internal override void refresca()
        {
            base.refresca();

            if (dgvEmpreses.CurrentRow == null)
            {
                carregaGridEmpreses();
                return;
            }

            var currentEmpreses = dgvEmpreses.CurrentRow.DataBoundItem;
            var currentProductes = dgvProductes.CurrentRow != null ? dgvProductes.CurrentRow.DataBoundItem : null;

            carregaGridEmpreses();

            foreach (DataGridViewRow row in dgvEmpreses.Rows)
            {
                if (currentEmpreses.Equals(row.DataBoundItem))
                {
                    dgvEmpreses.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    break;
                }
            }

            if (dgvEmpreses.CurrentRow != null && currentEmpreses.Equals(dgvEmpreses.CurrentRow.DataBoundItem))
            {
                if (currentProductes == null)
                    return;

                foreach (DataGridViewRow row in dgvProductes.Rows)
                {
                    if (currentProductes.Equals(row.DataBoundItem))
                    {
                        dgvProductes.CurrentCell = row.Cells[0];
                        row.Selected = true;
                        break;
                    }
                }
            }
        }


        #endregion *** Mètodes ***


        #region *** Events ***

        private void btEditaProducte_Click(object sender, EventArgs e)
        {
            modeEdicio();
        }

        private void btNouProducte_Click(object sender, EventArgs e)
        {
            if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
            {
                vProducteSeleccionat = vConnProductes.ProdAccions.Create();
            }
            else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
            {
                vProducteSeleccionat = vConnProductes.ProdFons.Create();
            }
            else
            {
                vProducteSeleccionat = null;
            }

            if (vProducteSeleccionat != null)
            {
                vProducteSeleccionat.Empresa = vConnProductes.Empreses.Find(vEmpresaSeleccionada.Id);
                vProducteSeleccionat.Moneda = Utilitats.Monedes.EUR.ToString();
                vProducteSeleccionat.OrdreGrid = 999;
            }

            ompleCampsProducte(vProducteSeleccionat);
            modeEdicio();
        }

        private void btDesaProducte_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNomProducte.Text.Length > 50)
                    throw new Exception("El nom del producte no pot ser més llarg de 50 caracters");

                bool esProdNou = vProducteSeleccionat.Id == 0;

                vProducteSeleccionat.OrdreGrid = ntbOrdreGridProducte._IntValue;

                if (!ckTotesLesEmpreses.Checked)
                {
                    if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
                    {
                        ((ProdAccions) vProducteSeleccionat).Mercat = vConnProductes.Mercats.Find(((Mercat) cbMercatProducte.SelectedItem).Id);
                        vProducteSeleccionat.Moneda = cbMonedaProducte.SelectedItem.ToString();
                    }
                    else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
                    {
                        ((ProdFons) vProducteSeleccionat).Nom = tbNomProducte.Text;
                        ((ProdFons) vProducteSeleccionat).ISIN = tbIsinProducte.Text;
                        ((ProdFons) vProducteSeleccionat).Tipus = ((TipusFons) cbTipusProducte.SelectedItem);
                        ((ProdFons) vProducteSeleccionat).Descripcio = tbDescripcioProducte.Text;
                    }
                }

                vConnProductes.Productes.AddOrUpdate(vProducteSeleccionat);

                vConnProductes.SaveChanges();

                Producte.RefrescaTaula();
                ProdAccions.RefrescaTaula();
                ProdFons.RefrescaTaula();
                
                TabX.ActivaRefrescaEnTabs(this);

                if (esProdNou)
                {
                    // Selecciona la nova fila.
                    dgvProductes.CurrentCell = dgvProductes.Rows[dgvProductes.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells[0];
                }

                modeConsulta();
            }
            catch (DbUpdateException ex3)
            {
                bool escriuLog = true;

                Exception inEx = ex3;

                while (inEx != null)
                {
                    if (inEx is SqlException)
                    {
                        var sqlEx = (SqlException) inEx;

                        if (sqlEx.Number == 2601 || sqlEx.Number == 2627)
                        {
                            // Esborra el producte creat amb errors.
                            vConnProductes.UndoingChangesDbEntityPropertyLevel(vProducteSeleccionat);

                            escriuLog = false;
                            MessageBox.Show(sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    }

                    inEx = inEx.InnerException;
                }

                if (escriuLog)
                    Utilitats.EscriuLog(ex3);
            }
            catch (DbEntityValidationException ex)
            {
                string message = "\nValidation Errors: ";

                foreach (var error in ex.EntityValidationErrors.SelectMany(entity => entity.ValidationErrors))
                {
                    message += String.Format("\nNom camp: {0}, Missatge: {1}", error.PropertyName, error.ErrorMessage);
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Esborra el producte creat amb errors.
                vConnProductes.UndoingChangesDbEntityPropertyLevel(vProducteSeleccionat);


                //// Retrieve the error messages as a list of strings.
                //var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                //var xx = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);

                //// Join the list to a single string.
                //var fullErrorMessage = string.Join("; ", errorMessages);

                //// Combine the original exception message with the new one.
                //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                //// Throw a new DbEntityValidationException with the improved exception message.
                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);




                //if (ex.HResult == -2146232032)
                //{
                //    foreach (var validationErrors in ex.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            var valorDuplicat = validationErrors.Entry.Entity;
                //            var missatge = validationError.ErrorMessage;
                //        }
                //    }
                //}
                //else
                //    Utilitats.EscriuLog(ex);
            }
            catch (Exception ex1)
            {
                Utilitats.EscriuLog(ex1, true);
            }
        }

        private void dgvEmpreses_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                var cela = dgvEmpreses[e.ColumnIndex, e.RowIndex];
                var valorNou = (string) cela.EditedFormattedValue;
                if (cela.OwningRow.DataBoundItem != null)
                {
                    switch (cela.OwningColumn.DataPropertyName)
                    {
                        case "Nom":
                            if (String.IsNullOrWhiteSpace(valorNou))
                                throw new ApplicationException("El nom no pot ser buit o null");
                            break;

                        case "TipusEmpresa":
                            var valorInicial = cela.Value;
                            var tipusEmp = (TipusEmpresa) Enum.Parse(typeof (TipusEmpresa), valorNou);

                            if ((TipusEmpresa) valorInicial != tipusEmp)
                            {
                                var empresa = (Empresa) cela.OwningRow.DataBoundItem;
                                if (empresa.Productes.Any())
                                    throw new Exception("No es pot canviar el tipus d'empresa si ja te productes");
                            }
                            break;
                    }
                }
            }
            catch (ApplicationException ex1)
            {
                Utilitats.EscriuLog(ex1.Message);
                e.Cancel = true;
            }
            catch (Exception ex2)
            {
                Utilitats.EscriuLog(ex2);
                e.Cancel = true;
            }
        }

        private void dgvEmpreses_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvEmpreses.IsCurrentRowDirty)
            {
                pnDesaCanvisEmpreses.Enabled = true;
            }
        }

        private void dgvEmpreses_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            pnDesaCanvisEmpreses.Enabled = true;
        }

        private void dgvEmpreses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpreses.CurrentRow != null && dgvEmpreses.CurrentRow.Index == e.RowIndex)
                return;

            vProducteSeleccionat = null;
            vEmpresaSeleccionada = (Empresa) dgvEmpreses.Rows[e.RowIndex].DataBoundItem;

            carregaGridProductes(vEmpresaSeleccionada);

            if (vEmpresaSeleccionada != null)
                colIsin.Visible = vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons;
        }


        private void btEsborraProducte_Click(object sender, EventArgs e)
        {
            try
            {
                if (Moviment.Tuples.Any(a => a.ProdId == vProducteSeleccionat.Id))
                    throw new ApplicationException("No es pot esborrar el producte perquè té moviments");

                var prod = vProducteSeleccionat;

                vConnProductes.Valoracions.RemoveRange(vConnProductes.Valoracions.Where(w => w.ProdId == prod.Id));

                vConnProductes.Productes.Remove(prod);

                vConnProductes.SaveChanges();

                Valoracio.RefrescaTaula();
                Producte.RefrescaTaula();
                ProdAccions.RefrescaTaula();
                ProdFons.RefrescaTaula();
            }
            catch (Exception ex1)
            {
                Utilitats.EscriuLog(ex1);
            }
        }

        private void btCancelaProducte_Click(object sender, EventArgs e)
        {
            ompleCampsProducte((Producte) (dgvProductes.CurrentRow == null ? null : dgvProductes.CurrentRow.DataBoundItem));

            modeConsulta();
        }

        private void tbNomProducte_TextChanged(object sender, EventArgs e)
        {
            if (!_EnModeEdicio && ((TextBoxBase) sender).Modified)
            {
                modeEdicio();
            }
        }

        private void cbTipusProducte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((IValorControlRestaurable) sender).Modified)
            {
                modeEdicio();
            }
        }

        private void btDesaCanvisEmpreses_Click(object sender, EventArgs e)
        {
            try
            {
                vConnEmpreses.SaveChanges();

                Empresa.RefrescaTaula();
                
                TabX.ActivaRefrescaEnTabs(this);

                pnDesaCanvisEmpreses.Enabled = false;
            }
            catch (DbEntityValidationException ex2)
            {
                Utilitats.EscriuLog(ex2);
            }
            catch (Exception ex1)
            {
                Utilitats.EscriuLog(ex1);
            }
        }

        private void btCancelaCanvisEmpreses_Click(object sender, EventArgs e)
        {
            try
            {
                carregaGridEmpreses();
                dgvEmpreses.Refresh();

                pnDesaCanvisEmpreses.Enabled = false;
            }
            catch (DbEntityValidationException ex2)
            {
                Utilitats.EscriuLog(ex2);
            }
            catch (Exception ex1)
            {
                Utilitats.EscriuLog(ex1);
            }
        }

        private void dgvProductes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductes.CurrentRow != null && dgvProductes.CurrentRow.Index == e.RowIndex)
                return;

            vProducteSeleccionat = (Producte) dgvProductes.Rows[e.RowIndex].DataBoundItem;

            if (vProducteSeleccionat == null)
            {
                cbMercatProducte.SelectedItem = null;
                cbMonedaProducte.SelectedItem = null;
                cbTipusProducte.SelectedItem = null;
            }
            else
            {
                btDesaProducte.Enabled = false;
                btCancelaProducte.Enabled = false;

                btNouProducte.Enabled = true;
                btEsborraProducte.Enabled = true;
                btEditaProducte.Enabled = true;

                ompleCampsProducte(vProducteSeleccionat);
            }

            if (ckTotesLesEmpreses.Checked && vProducteSeleccionat != null)
            {
                foreach (DataGridViewRow dgvEmprese in dgvEmpreses.Rows)
                {
                    var empresa = (Empresa) dgvEmprese.DataBoundItem;

                    if (empresa.Id == vProducteSeleccionat.Empresa.Id)
                    {
                        dgvEmprese.Selected = true;
                        dgvEmpreses.FirstDisplayedScrollingRowIndex = dgvEmprese.Index;
                        vEmpresaSeleccionada = empresa;
                        break;
                    }
                }
            }
        }

        private void ntbOrdreGridProducte_TextChanged(object sender, EventArgs e)
        {
            if (!_EnModeEdicio && ((TextBoxBase) sender).Modified)
            {
                modeEdicio();
            }
        }

        private void EmpresesProductesTab_Load(object sender, EventArgs e)
        {
            carregaGridEmpreses();
        }

        private void ckTotesLesEmpreses_CheckedChanged(object sender, EventArgs e)
        {
            dgvEmpreses.Enabled = !ckTotesLesEmpreses.Checked;

            if (ckTotesLesEmpreses.Checked)
                carregaGridProductes(null);
            else
                carregaGridProductes(vEmpresaSeleccionada);
        }

        #endregion *** Events ***
    }
}