using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Controls;

namespace Inversions.GUI
{
    public partial class Principal : Form
    {
        private InversionsBDContext vConnEmpreses;
        private InversionsBDContext vConnProductes;
        private bool vModeConsultaProducte = true;
        private Empresa vEmpresaSeleccionada;
        private Producte vProducteSeleccionat;

        public Principal()
        {
            InitializeComponent();

            //using (var conn = new InversionsBDContext())
            //{
            //    //var conn = Program.Sessio;

            //    using (var dbContextTransaction = conn.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            //var ges = conn.Gestors.Single(s => s.Id == 1);
            //            var ges = conn.Gestors.Create();
            //            ges.Nom = "jlklkh";
            //            ges.Empresa = conn.Empreses.First();

            //            conn.Gestors.AddOrUpdate(ges);
            //            conn.SaveChanges();

            //            //dbContextTransaction.Rollback();
            //            //dbContextTransaction.Commit();

            //            conn.Gestors.Remove(ges);
            //            conn.SaveChanges();

            //            ////dbContextTransaction.Rollback();
            //            dbContextTransaction.Commit();


            //        }
            //        catch (Exception)
            //        {
            //            dbContextTransaction.Rollback();
            //            throw;
            //        }
            //    }
            //}

            //var cc = Program.Sessio.Gestors.Count();
            //var gess = Program.Sessio.Gestors.Single(s => s.Id == 1);
            //Program.Sessio.ChangeTracker.DetectChanges();
            //var gess2 = Program.Sessio.Gestors.Single(s => s.Id == 1);

            titolFinestra();

#if DEBUG
            tabControl1.SelectTab(tabValoracions.Name);
#else
            tabControl1.SelectTab(tabValoracions.Name);
#endif

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

            modeConsultaProducte();
        }


        #region *** Mètodes ***

        private void titolFinestra()
        {
            this.Text = String.Format("Producte. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }


        private void carregaGridEmpreses()
        {
            vConnEmpreses = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.
            vConnEmpreses.Empreses.Load();
            dgvEmpreses.DataSource = vConnEmpreses.Empreses.Local.ToBindingList();
        }


        private void carregaGridProductes(Empresa empresa)
        {
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

            if (((ICollection)dgvProductes.DataSource).Count == 0)
            {
                btNouProducte.Enabled = true;
                btEsborraProducte.Enabled = false;

                tbNomProducte.Text = String.Empty;
                ntbOrdreGridProducte.Valor = 0;
                cbMercatProducte.SelectedItem = null;
                cbMonedaProducte.SelectedItem = null;
                tbIsinProducte.Text = String.Empty;
                tbDescripcioProducte.Text = String.Empty;

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
                    cbMonedaProducte.SelectedItem = (Utilitats.Monedes)Enum.Parse(typeof(Utilitats.Monedes), producte.Moneda);
                }
                else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
                {
                    tbIsinProducte.Text = producte._Isin;
                    tbDescripcioProducte.Text = producte._Descripcio;
                }
            }
        }


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
            }
            else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
            {
                grNomProducte.Enabled = true;
                grMercatProducte.Visible = false;
                grMonedaProducte.Visible = false;
                grIsinProducte.Visible = true;
                grDescripcioProducte.Visible = true;
            }
        }


        private void modeEdicioProducte()
        {
            vModeConsultaProducte = false;

            btDesaProducte.Enabled = true;
            btCancelaProducte.Enabled = true;
            grEmpresa.Enabled = false;
            dgvProductes.Enabled = false;
            btNouProducte.Enabled = false;
            btEsborraProducte.Enabled = false;
        }


        private void modeConsultaProducte()
        {
            vModeConsultaProducte = true;

            btDesaProducte.Enabled = false;
            btCancelaProducte.Enabled = false;
            grEmpresa.Enabled = true;
            dgvProductes.Enabled = true;
            btNouProducte.Enabled = true;
            btEsborraProducte.Enabled = true;
        }


        private void teclaEscapeEdicioProducte()
        {
            if (ActiveControl is TextBoxBase)
            {
                var control = (TextBoxBase)ActiveControl;
                if (control.Modified)
                    control.Undo();
            }
            if (ActiveControl is IValorControlRestaurable)
            {
                var control = (IValorControlRestaurable)ActiveControl;
                if (control.Modified)
                    control.Undo();
            }
        }

        #endregion *** Mètodes ***

        #region *** Events ***

        private void Principal_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                SuspendLayout();
                cbUsuaris.SelectedIndexChanged -= cbUsuaris_SelectedIndexChanged;
                cbUsuaris.DisplayMember = "Nom";
                cbUsuaris.DataSource = Program.Sessio.Usuaris.ToList();
                cbUsuaris.SelectedItem = null;
                ResumeLayout();
                if (Usuari.Seleccionat == null)
                    Usuari.Seleccionat = Program.Sessio.Usuaris.First();

                cbUsuaris.SelectedItem = Usuari.Seleccionat;
                cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;

                carregaGridEmpreses();
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


        private void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuari.Seleccionat = (Usuari) cbUsuaris.SelectedItem;
            movimentsTab1.canviUsuari(Usuari.Seleccionat);
            valoracionsTab1.canviUsuari(Usuari.Seleccionat);
            perduesGuanysTab1.canviUsuari(Usuari.Seleccionat);
        }


        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)
            {
                var numUsuaris = cbUsuaris.Items.Count;
                if (cbUsuaris.SelectedIndex == numUsuaris - 1)
                {
                    cbUsuaris.SelectedIndex = 0;
                }
                else
                {
                    cbUsuaris.SelectedIndex++;
                }

                titolFinestra();
            }
            else if (e.KeyCode == Keys.F5)
            {
                tabControl1.SelectedTab.Controls[0].Refresh();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (ActiveControl.Parent.Parent == pnCampsProductes)
                    teclaEscapeEdicioProducte();
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


        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pnDesaCanvisEmpreses.Enabled)
            {
                if (MessageBox.Show("Hi han canvis pendents de desar en la taula Empreses. \nVols tancar igualment?", "Atenció",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }


        private void dgvEmpreses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpreses.CurrentRow != null && dgvEmpreses.CurrentRow.Index == e.RowIndex)
                return;

            vProducteSeleccionat = null;
            vEmpresaSeleccionada = (Empresa) dgvEmpreses.Rows[e.RowIndex].DataBoundItem;

            carregaGridProductes(vEmpresaSeleccionada);
        }


        private void btDesaProducte_Click(object sender, EventArgs e)
        {
            try
            {
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

                modeConsultaProducte();
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

            }
            else
            {
                btDesaProducte.Enabled = false;
                btCancelaProducte.Enabled = false;

                btEsborraProducte.Enabled = true;

                ompleCampsProducte(vProducteSeleccionat);
            }
        }


        private void tbProducte_TextChanged(object sender, EventArgs e)
        {
            if (vModeConsultaProducte && ((TextBoxBase) sender).Modified)
            {
                modeEdicioProducte();
            }
        }


        private void cbProducte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((IValorControlRestaurable) sender).Modified)
            {
                modeEdicioProducte();
            }
        }


        private void btCancelaProducte_Click(object sender, EventArgs e)
        {
            ompleCampsProducte((Producte) (dgvProductes.CurrentRow == null ? null : dgvProductes.CurrentRow.DataBoundItem));

            modeConsultaProducte();
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

            vProducteSeleccionat.Empresa = vConnProductes.Empreses.Find(vEmpresaSeleccionada.Id);
            vProducteSeleccionat.Moneda = Utilitats.Monedes.EUR.ToString();

            ompleCampsProducte(vProducteSeleccionat);
            modeEdicioProducte();
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

        #endregion *** Events ***
    }
}
