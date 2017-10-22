using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            tabControl1.SelectTab(tabEmpreses.Name);
#else
            tabControl1.SelectTab(tabValoracions.Name);
#endif

            dgvEmpreses.AutoGenerateColumns = false;
            dgvProductes.AutoGenerateColumns = false;


            List<Producte.TipusProducte> tipusProductes = new List<Producte.TipusProducte>(Enum.GetValues(typeof (Producte.TipusProducte)).Cast<Producte.TipusProducte>());
            cbTipusProducteFiltreTab1.DataSource = tipusProductes;
            cbTipusProducte.DataSource = tipusProductes.Where(w => w != Producte.TipusProducte.Tots).ToList();

            OmpleEmpresesCombo();

            cbMercat.SuspendLayout();
            cbMercat.DisplayMember = "Nom";
            cbMercat.DataSource = Program.Sessio.Mercats.ToList();
            cbMercat.SelectedItem = null;
            cbMercat.ResumeLayout();

            cbMercat2.SuspendLayout();
            cbMercat2.DisplayMember = "Nom";
            cbMercat2.DataSource = Program.Sessio.Mercats.ToList();
            cbMercat2.SelectedItem = null;
            cbMercat2.ResumeLayout();

            cbMoneda.SuspendLayout();
            cbMoneda.DataSource = Enum.GetValues(typeof (Comuns.Utilitats.Monedes));
            cbMoneda.SelectedItem = null;
            cbMoneda.ResumeLayout();

            cbMoneda2.SuspendLayout();
            cbMoneda2.DataSource = Enum.GetValues(typeof (Comuns.Utilitats.Monedes));
            cbMoneda2.SelectedItem = null;
            cbMoneda2.ResumeLayout();


            cbMercatProducte.SuspendLayout();
            cbMercatProducte.DisplayMember = "Nom";
            cbMercatProducte.DataSource = Program.Sessio.Mercats.ToList();
            cbMercatProducte.SelectedItem = null;
            cbMercatProducte.ResumeLayout();

            cbMonedaProducte.SuspendLayout();
            cbMonedaProducte.DataSource = Enum.GetValues(typeof (Comuns.Utilitats.Monedes));
            cbMonedaProducte.SelectedItem = null;
            cbMonedaProducte.ResumeLayout();

            modeConsulta();
        }

        private void titolFinestra()
        {
            this.Text = String.Format("Producte. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }

        private void OmpleEmpresesCombo()
        {
            cbEmpresa.SuspendLayout();
            cbEmpresa.SelectedIndexChanged -= cbEmpresa_SelectedIndexChanged;
            cbEmpresa.DisplayMember = "Nom";
            cbEmpresa.ValueMember = "Id";
            //cbEmpresa.DataSource = MyClass.Sessio.Empreses.Include(emp => emp.Productes).OrderBy(o => o.Nom).ToList();
            cbEmpresa.DataSource = Program.Sessio.Empreses.OrderBy(o => o.Nom).ToList();
            cbEmpresa.SelectedIndexChanged += cbEmpresa_SelectedIndexChanged;
            cbEmpresa.SelectedItem = null;
            cbEmpresa.ResumeLayout();

        }


        private InversionsBDContext vConnEmpreses;

        private void carregaGridEmpreses()
        {
            vConnEmpreses = new InversionsBDContext(); // Creo la connexió per si he fet cancel rellegeixi les dades de la taula.
            vConnEmpreses.Empreses.Load();
            dgvEmpreses.DataSource = vConnEmpreses.Empreses.Local.ToBindingList();
        }

        private InversionsBDContext vConnProductes;

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

            if (((ICollection) dgvProductes.DataSource).Count == 0)
            {
                btCreaProducte.Enabled = true;
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
                btCreaProducte.Enabled = empresa.TipusEmpresa == TipusEmpresa.GestoraFons;
            }
        }


        private void Principal_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                SuspendLayout();
                cbUsuaris.SelectedIndexChanged -= cbUsuaris_SelectedIndexChanged;
                cbUsuaris.DisplayMember = "Nom";
                cbUsuaris.DataSource = Program.Sessio.Usuaris.ToList();
                cbUsuaris.SelectedItem = null;
                cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;
                ResumeLayout();
                if (Usuari.Seleccionat == null)
                    Usuari.Seleccionat = Program.Sessio.Usuaris.First();

                cbUsuaris.SelectedItem = Usuari.Seleccionat;

                carregaGridEmpreses();
            }
        }


        private void cbTipusProducte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducte.SelectedItem == null)
            {
                gbMercat.Visible = false;
                gbNom.Visible = false;
                gbIsin.Visible = false;
            }
            else
            {
                Producte.TipusProducte tp = (Producte.TipusProducte) cbTipusProducte.SelectedItem;
                switch (tp)
                {
                    case Producte.TipusProducte.Accions:
                        gbMercat.Visible = true;
                        gbNom.Visible = false;
                        gbIsin.Visible = false;
                        break;
                    case Producte.TipusProducte.Fons:
                        gbMercat.Visible = false;
                        gbNom.Visible = true;
                        gbIsin.Visible = true;
                        break;
                }
            }
        }


        private void cbProductesTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductesTab1.SelectedItem == null)
            {
                flpDades.Visible = false;
                btEditaProducte.Enabled = false;
            }
            else
            {
                flpDades.Visible = true;
                btEditaProducte.Enabled = true;

                var prod = cbProductesTab1.SelectedItem as Producte;

                if (prod != null)
                {
                    cbMoneda.SelectedItem = (Comuns.Utilitats.Monedes) Enum.Parse(typeof (Comuns.Utilitats.Monedes), prod.Moneda);
                    cbEmpresa.SelectedItem = prod.Empresa;

                    if (prod is ProdAccions)
                    {
                        ProdAccions accions = prod as ProdAccions;
                        cbMercat.SelectedItem = accions.Mercat;
                        cbMercat2.SelectedItem = accions.Mercat;
                        tbId.Text = accions.Id.ToString("0");
                    }
                    else if (prod is ProdFons)
                    {
                        ProdFons fons = prod as ProdFons;
                        cbTipusProducte.SelectedItem = Producte.TipusProducte.Accions;
                        tbId.Text = fons.Id.ToString("0");
                        tbIsin.Text = fons.ISIN;
                        tbNom.Text = fons.Nom;
                        tbDescripcio.Text = fons.Descripcio;
                    }
                }
            }
        }

        private void cbTipusProducteFiltreTab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducteFiltreTab1.SelectedIndex >= 0)
            {
                ompleTabProductes();
            }
        }


        private void ompleTabProductes(Producte prod = null)
        {
            IEnumerable<Producte> prods = LlistaProductes((Producte.TipusProducte) cbTipusProducteFiltreTab1.SelectedItem);

            if (prods == null) return;

            cbProductesTab1.SuspendLayout();
            cbProductesTab1.SelectedIndexChanged -= cbProductesTab1_SelectedIndexChanged;
            cbProductesTab1.DisplayMember = "_NomProducte";
            cbProductesTab1.DataSource = prods.ToList();
            cbProductesTab1.SelectedIndexChanged += cbProductesTab1_SelectedIndexChanged;
            //cbProductesTab1.SelectedItem = null;
            cbProductesTab1.ResumeLayout();

            cbProductesTab1.SelectedItem = prod;

            modeConsulta();
        }


        private static IEnumerable<Producte> LlistaProductes(Producte.TipusProducte tipusProducte)
        {
            List<Producte> prods;

            if (tipusProducte == Producte.TipusProducte.Accions)
            {
                prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdAccions>().Include(inc => inc.Empresa));
            }
            else if (tipusProducte == Producte.TipusProducte.Fons)
            {
                prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdFons>().Include(inc => inc.Empresa));
            }
            else
            {
                prods = Program.Sessio.Productes.Include(inc => inc.Empresa).ToList();
            }
            return prods.OrderBy(s => s._NomProducte);
        }


        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                switch (((Empresa) cbEmpresa.SelectedItem).TipusEmpresa)
                {
                    case TipusEmpresa.GestoraFons:
                        cbTipusProducte.SelectedItem = Producte.TipusProducte.Fons;
                        break;
                    case TipusEmpresa.Accions:
                        cbTipusProducte.SelectedItem = Producte.TipusProducte.Accions;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                cbTipusProducte.Enabled = false;
            }
        }

        private bool vAltaEmpresa = false;

        private void btNovaEmpresa_Click(object sender, EventArgs e)
        {
            modeEdicio();

            grAltaEmpresa.Enabled = true;
            flpDades.Visible = false;
            vAltaEmpresa = true;
        }

        private bool vProducteNou;

        private void btNouProducte_Click(object sender, EventArgs e)
        {
            var e1 = Program.Sessio.Empreses.Where(w => (w.TipusEmpresa == TipusEmpresa.GestoraFons)
                                                        || (w.TipusEmpresa == TipusEmpresa.Accions
                                                            && !Program.Sessio.Productes.Any(a => a.Empresa == w)));

            cbEmpresa.SuspendLayout();
            cbEmpresa.SelectedIndexChanged -= cbEmpresa_SelectedIndexChanged;
            cbEmpresa.DisplayMember = "Nom";
            cbEmpresa.ValueMember = "Id";
            cbEmpresa.DataSource = e1.ToList();
            cbEmpresa.SelectedIndexChanged += cbEmpresa_SelectedIndexChanged;
            cbEmpresa.SelectedItem = null;
            cbEmpresa.ResumeLayout();

            cbTipusProducte.SelectedItem = null;
            cbEmpresa.SelectedItem = null;
            cbMercat.SelectedItem = null;
            cbMercat2.SelectedItem = null;
            tbDescripcio.Text = "";
            tbIsin.Text = "";
            tbNom.Text = "";

            vProducteNou = true;

            modeEdicio();
        }

        private void btEditaProducte_Click(object sender, EventArgs e)
        {
            modeEdicio();

            vProducteNou = false;
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            if (vAltaEmpresa)
                altaEmpresa();
            else
                altaProducte();
        }

        private void altaProducte()
        {
            Producte prod = null;
            try
            {
                if (cbTipusProducte.SelectedItem == null)
                    throw new ApplicationException("Falta Tipus producte");
                if (cbEmpresa.SelectedItem == null)
                    throw new ApplicationException("Falta Empresa");
                if (cbMoneda2.SelectedItem == null)
                    throw new ApplicationException("Falta Moneda");

                using (var conn = new InversionsBDContext())
                {
                    Producte.TipusProducte tp = (Producte.TipusProducte) cbTipusProducte.SelectedItem;

                    //Empresa empresaSeleccionada = conn.Empreses.Single(s => s.Id == ((Empresa)cbEmpresa.SelectedItem).Id);
                    Empresa empresaSeleccionada = conn.Empreses.Find(((Empresa) cbEmpresa.SelectedItem).Id);
                    //Producte producteSeleccionat = vProducteNou ? null : conn.Productes.Single(s => s.Id == ((Producte)cbProductesTab1.SelectedItem).Id);
                    Producte producteSeleccionat = vProducteNou ? null : conn.Productes.Find(((Producte) cbProductesTab1.SelectedItem).Id);

                    if (tp == Producte.TipusProducte.Accions)
                    {
                        if (cbMercat.SelectedItem == null)
                            throw new ApplicationException("Falta Mercat");

                        //ProdAccions prodAccions = (ProdAccions)producteSeleccionat ?? new ProdAccions();
                        ProdAccions prodAccions = (ProdAccions) producteSeleccionat ?? conn.ProdAccions.Create();


                        prodAccions.Empresa = empresaSeleccionada;
                        prodAccions.MercatId = ((Mercat) cbMercat.SelectedItem).Id;
                        prodAccions.Moneda = cbMoneda2.SelectedText;

                        if (vProducteNou)
                            conn.Productes.Add(prodAccions);

                        conn.SaveChanges();

                        prod = prodAccions;
                    }
                    else if (tp == Producte.TipusProducte.Fons)
                    {
                        if (String.IsNullOrEmpty(tbNom.Text))
                            throw new ApplicationException("Falta Nom");
                        if (String.IsNullOrEmpty(tbIsin.Text))
                            throw new ApplicationException("Falta ISIN");

                        //ProdFons prodFons = (ProdFons)producteSeleccionat ?? new ProdFons();
                        ProdFons prodFons = (ProdFons) producteSeleccionat ?? conn.ProdFons.Create();

                        prodFons.Empresa = empresaSeleccionada;
                        prodFons.Nom = tbNom.Text;
                        prodFons.ISIN = tbIsin.Text;
                        prodFons.Descripcio = tbDescripcio.Text;
                        prodFons.Moneda = cbMoneda2.SelectedText;

                        if (vProducteNou)
                            conn.Productes.Add(prodFons);

                        conn.SaveChanges();

                        prod = prodFons;
                    }

                    if (!vProducteNou)
                        Program.Sessio.Entry(cbProductesTab1.SelectedItem).Reload();

                }

                ompleTabProductes(prod);
                OmpleEmpresesCombo();

                modeConsulta();

                MessageBox.Show("Fet!!");
            }
            catch (DbEntityValidationException ex1)
            {
                Comuns.Utilitats.EscriuLog(ex1, Program.FitxerLog, Program.Versio);
                //MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                //MessageBox.Show(ex.Message);
            }

        }

        private void altaEmpresa()
        {
            using (var connexio = new InversionsBDContext())
            {
                //using (var dbContextTransaction = connexio.Database.BeginTransaction())
                {
                    try
                    {
                        if (!rbCotitzada.Checked && !rbGestora.Checked)
                            throw new ApplicationException("No s'ha informat el tipus d'empresa");

                        if (String.IsNullOrEmpty(tbNomNovaEmpresa.Text))
                            throw new ApplicationException("Falta el nom de la empresa.");

                        if (rbCotitzada.Checked && cbMercat2.SelectedItem == null)
                            throw new ApplicationException("Falta el mercat.");


                        //Empresa emp = new Empresa();
                        var emp = connexio.Empreses.Create();
                        emp.Nom = tbNomNovaEmpresa.Text;
                        emp.TipusEmpresa = rbCotitzada.Checked ? TipusEmpresa.Accions : TipusEmpresa.GestoraFons;

                        connexio.Empreses.Add(emp);

                        if (rbCotitzada.Checked)
                        {
                            //ProdAccions prod = new ProdAccions();
                            var prod = connexio.ProdAccions.Create();
                            prod.MercatId = ((Mercat) cbMercat2.SelectedItem).Id;
                            prod.Empresa = emp;
                            prod.OrdreGrid = ntbOrdreGrid._IntValue;

                            connexio.ProdAccions.Add(prod);
                        }

                        connexio.SaveChanges();

                        //dbContextTransaction.Commit();

                        modeConsulta();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //dbContextTransaction.Rollback();
                    }
                }
            }
        }


        private void btCancela_Click(object sender, EventArgs e)
        {
            modeConsulta();

            ompleTabProductes((Producte) cbProductesTab1.SelectedItem);
            OmpleEmpresesCombo();

            vAltaEmpresa = false;
            grAltaEmpresa.Enabled = false;
        }

        private void modeConsulta()
        {
            grAltaEmpresa.Enabled = false;
            vAltaEmpresa = false;

            flpDades.Visible = cbProductesTab1.SelectedItem != null;

            ProdFons prodFons = cbProductesTab1.SelectedItem as ProdFons;
            if (prodFons != null)
            {
                gbMercat.Visible = false;
                gbNom.Visible = true;
                gbIsin.Visible = true;
                gbDescripcio.Visible = true;
            }
            else
            {
                ProdAccions prodAccions = cbProductesTab1.SelectedItem as ProdAccions;
                if (prodAccions != null)
                {
                    gbMercat.Visible = true;
                    gbNom.Visible = false;
                    gbIsin.Visible = false;
                    gbDescripcio.Visible = false;
                }
            }

            cbTipusProducteFiltreTab1.Enabled = true;
            cbProductesTab1.Enabled = true;

            btNovaEmpresa.Enabled = true;
            btNouProducte.Enabled = true;
            btEditaProducte.Enabled = cbProductesTab1.SelectedItem != null;
            btCancela.Enabled = false;
            btDesa.Enabled = false;
            cbEmpresa.Enabled = false;
            cbTipusProducte.Enabled = false;
            cbMercat.Enabled = false;
            cbMercat2.Enabled = false;
            tbNom.ReadOnly = true;
            tbIsin.ReadOnly = true;
            tbDescripcio.ReadOnly = true;

            vProducteNou = false;
        }


        private void modeEdicio()
        {
            flpDades.Visible = true;
            cbTipusProducteFiltreTab1.Enabled = false;
            cbProductesTab1.Enabled = false;

            btNouProducte.Enabled = false;
            btEditaProducte.Enabled = false;
            tbNom.ReadOnly = false;
            tbIsin.ReadOnly = false;
            tbDescripcio.ReadOnly = false;

            btNovaEmpresa.Enabled = false;

            btCancela.Enabled = true;
            btDesa.Enabled = true;
            cbEmpresa.Enabled = true;
            //cbTipusProducte.Enabled = true;
            cbMercat.Enabled = true;
            cbMercat2.Enabled = true;
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


        private void rbGestora_CheckedChanged(object sender, EventArgs e)
        {
            grMercat.Visible = false;
            gbOrdreGrid.Visible = false;
        }


        private void rbCotitzada_CheckedChanged(object sender, EventArgs e)
        {
            grMercat.Visible = true;
            gbOrdreGrid.Visible = true;
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

        private Empresa vEmpresaSeleccionada;
        private void dgvEmpreses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmpreses.CurrentRow != null && dgvEmpreses.CurrentRow.Index == e.RowIndex)
                return;

            vEmpresaSeleccionada = (Empresa) dgvEmpreses.Rows[e.RowIndex].DataBoundItem;

            carregaGridProductes(vEmpresaSeleccionada);
        }


        private void btDesaProducte_Click(object sender, EventArgs e)
        {
            try
            {
                Producte prod = dgvProductes.CurrentRow == null ? vConnProductes.Productes.Create() : (Producte) dgvProductes.CurrentRow.DataBoundItem;
                
                prod.OrdreGrid = ntbOrdreGridProducte._IntValue;

                if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.Accions)
                {
                    ((ProdAccions) prod).Mercat = vConnProductes.Mercats.Find(((Mercat) cbMercatProducte.SelectedItem).Id);
                    prod.Moneda = cbMonedaProducte.SelectedItem.ToString();
                }
                else if (vEmpresaSeleccionada.TipusEmpresa == TipusEmpresa.GestoraFons)
                {
                    ((ProdFons)prod).Nom = tbNomProducte.Text;
                    ((ProdFons)prod).ISIN = tbIsinProducte.Text;
                    ((ProdFons) prod).Descripcio = tbDescripcioProducte.Text;
                }

                vConnProductes.Productes.AddOrUpdate(prod);

                vConnProductes.SaveChanges();

                Program.Sessio.refrescaTaula(typeof (Producte));

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

            Producte producte = (Producte)dgvProductes.Rows[e.RowIndex].DataBoundItem;

            if (producte == null)
            {
                cbMercatProducte.SelectedItem = null;
                cbMonedaProducte.SelectedItem = null;

            }
            else
            {
                btDesaProducte.Enabled = false;
                btCancelaProducte.Enabled = false;

                btEsborraProducte.Enabled = true;

                ompleCampsProducte(producte);
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
                    cbMonedaProducte.SelectedItem = (Utilitats.Monedes) Enum.Parse(typeof (Utilitats.Monedes), producte.Moneda);
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


        private void tbProducte_TextChanged(object sender, EventArgs e)
        {
            if (vModeConsultaProducte && ((TextBoxBase)sender).Modified)
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

        private bool vModeEdicioProducte = false;
        private bool vModeConsultaProducte = true;
        private void modeEdicioProducte()
        {
            vModeEdicioProducte = true;
            vModeConsultaProducte = false;

            btDesaProducte.Enabled = true;
            btCancelaProducte.Enabled = true;
            grEmpresa.Enabled = false;
            dgvProductes.Enabled = false;
            btCreaProducte.Enabled = false;
            btEsborraProducte.Enabled = false;
        }

        private void modeConsultaProducte()
        {
            vModeEdicioProducte =false ;
            vModeConsultaProducte = true;

            btDesaProducte.Enabled = false;
            btCancelaProducte.Enabled = false;
            grEmpresa.Enabled = true;
            dgvProductes.Enabled = true;
            btCreaProducte.Enabled = true;
            btEsborraProducte.Enabled = true;
        }

        private void btCancelaProducte_Click(object sender, EventArgs e)
        {
            ompleCampsProducte((Producte)(dgvProductes.CurrentRow == null ? null : dgvProductes.CurrentRow.DataBoundItem));

            modeConsultaProducte();
        }


        private void teclaEscapeEdicioProducte()
        {
            if (ActiveControl is TextBoxBase)
            {
                if (((TextBoxBase)ActiveControl).Modified)
                    ((TextBoxBase)ActiveControl).Undo();
            }
            if (ActiveControl is IValorControlRestaurable)
            {
                if (((IValorControlRestaurable)ActiveControl).Modified)
                    ((IValorControlRestaurable)ActiveControl).Undo();
            }
        }

        private void btCreaProducte_Click(object sender, EventArgs e)
        {
            // todo Pendent "btCreaProducte_Click".
        }

        private void btEsborraProducte_Click(object sender, EventArgs e)
        {
            // todo Pendent "btEsborraProducte_Click".
        }
    }
}
