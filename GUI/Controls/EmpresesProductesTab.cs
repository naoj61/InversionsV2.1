using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;
using Controls;
using DevExpress.XtraEditors.Controls;

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

            dgvEmpreses.AutoGenerateColumns = false;
            dgvProductes.AutoGenerateColumns = false;


            cbMercatProducte.SuspendLayout();
            cbMercatProducte.DisplayMember = "Nom";
            cbMercatProducte.DataSource = Program.Sessio.Mercats.ToList();
            cbMercatProducte.SelectedItem = null;
            cbMercatProducte.ResumeLayout();

            cbMonedaProducte.SuspendLayout();
            cbMonedaProducte.DataSource = Enum.GetValues(typeof (Comuns.Utilitats.Monedes));
            cbMonedaProducte.SelectedItem = null;
            cbMonedaProducte.ResumeLayout();


            cbTipusProducte.SuspendLayout();
            cbTipusProducte.DataSource = Enum.GetValues(typeof (TipusFons));
            cbTipusProducte.SelectedItem = null;
            cbTipusProducte.ResumeLayout();

            modeConsulta();
        }
        
        public override void escape(object sender, KeyEventArgs e)
        {
            base.escape(sender, e);
        
            teclaEscapeEdicioProducte();
        }


        #region *** Mètodes ***

        /// <summary>
        /// Mostra o amaga els controls en funvio del tipus d'empresa seleccionada.
        /// </summary>
        private void preparaControlsProducte()
        {
            if (vEmpresaSeleccionada == null)
                return;

            if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
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

        private void carregaGridProductes(Empresa empresa)
        {
            if (empresa == null)
            {
                dgvProductes.Rows.Clear();
                return;
            }

            vConnProductes = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.

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
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                vConnEmpreses = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.
                vConnEmpreses.Empreses.Load();

                dgvEmpreses.DataSource = vConnEmpreses.Empreses.Local.ToBindingList();
            }
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

                vConnProductes.Productes.AddOrUpdate(vProducteSeleccionat);

                vConnProductes.SaveChanges();

                Program.Sessio.refrescaTaula(typeof (Producte));
                Program.Sessio.refrescaTaula(typeof (ProdAccions));
                Program.Sessio.refrescaTaula(typeof (ProdFons));

                if (esProdNou)
                {
                    // Selecciona la nova fila.
                    dgvProductes.CurrentCell = dgvProductes.Rows[dgvProductes.Rows.GetLastRow(DataGridViewElementStates.Visible)].Cells[0];
                }

                modeConsulta();
            }
            catch (DbEntityValidationException ex2)
            {
                Utilitats.EscriuLog(ex2);
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
        }

        private void btEsborraProducte_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Sessio.Moviments.Any(a => a.ProdId == vProducteSeleccionat.Id))
                    throw new ApplicationException("No es pot esborrar el producte perquè té moviments");

                var prod = vProducteSeleccionat;

                vConnProductes.Valoracions.RemoveRange(vConnProductes.Valoracions.Where(w => w.ProdId == prod.Id));

                vConnProductes.Productes.Remove(prod);

                vConnProductes.SaveChanges();

                Program.Sessio.refrescaTaula(typeof (Valoracio));
                Program.Sessio.refrescaTaula(typeof (Producte));
                Program.Sessio.refrescaTaula(typeof (ProdAccions));
                Program.Sessio.refrescaTaula(typeof (ProdFons));
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

                Program.Sessio.refrescaTaula(typeof (Empresa));

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
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                carregaGridEmpreses();
            }
        }

        #endregion *** Events ***
    }
}