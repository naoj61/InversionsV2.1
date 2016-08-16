using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class Principal : Form
    {
        public Principal()
        {

            InitializeComponent();

            this.Text = "Producte. Ver: " + Application.ProductVersion;

            tabControl1.SelectTab(tabValoracions.Name);

            List<Producte.TipusProducte> tipusProductes = new List<Producte.TipusProducte>(Enum.GetValues(typeof (Producte.TipusProducte)).Cast<Producte.TipusProducte>());
            cbTipusProducteFiltreTab1.DataSource = tipusProductes;
            cbTipusProducte.DataSource = tipusProductes.Where(w => w != Producte.TipusProducte.Tots).ToList();

            OmpleEmpresesCombo();

            cbMercat.SuspendLayout();
            cbMercat.DisplayMember = "Nom";
            cbMercat.DataSource = Program.Sessio.Mercats.ToList();
            cbMercat.SelectedItem = null;
            cbMercat.ResumeLayout();

            modeConsulta();
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

                ProdAccions accions = cbProductesTab1.SelectedItem as ProdAccions;
                if (accions != null)
                {
                    cbEmpresa.SelectedItem = accions.Empresa;
                    //cbTipusProducte.SelectedIndex = 0;
                    cbMercat.SelectedItem = accions.Mercat;
                    tbId.Text = accions.Id.ToString("0");
                }
                else
                {
                    ProdFons fons = cbProductesTab1.SelectedItem as ProdFons;
                    if (fons != null)
                    {
                        cbTipusProducte.SelectedItem = Producte.TipusProducte.Accions;
                        tbId.Text = fons.Id.ToString("0");
                        cbEmpresa.SelectedItem = fons.Empresa;
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
            Producte prod = null;
            try
            {
                if (cbTipusProducte.SelectedItem == null)
                    throw new ApplicationException("Falta Tipus producte");
                if (cbEmpresa.SelectedItem == null)
                    throw new ApplicationException("Falta Empresa");

                using (var conn = new InversionsBDContext())
                {
                    Producte.TipusProducte tp = (Producte.TipusProducte) cbTipusProducte.SelectedItem;

                    Empresa empresaSeleccionada = conn.Empreses.Single(s => s.Id == ((Empresa) cbEmpresa.SelectedItem).Id);
                    Producte producteSeleccionat = vProducteNou ? null : conn.Productes.Single(s => s.Id == ((Producte) cbProductesTab1.SelectedItem).Id);

                    if (tp == Producte.TipusProducte.Accions)
                    {
                        if (cbMercat.SelectedItem == null)
                            throw new ApplicationException("Falta Mercat");

                        ProdAccions prodAccions = producteSeleccionat == null ? new ProdAccions() : (ProdAccions) producteSeleccionat;


                        prodAccions.Empresa = empresaSeleccionada;
                        prodAccions.MercatId = ((Mercat) cbMercat.SelectedItem).Id;

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

                        ProdFons prodFons = producteSeleccionat == null ? new ProdFons() : (ProdFons) producteSeleccionat;

                        prodFons.Empresa = empresaSeleccionada;
                        prodFons.Nom = tbNom.Text;
                        prodFons.ISIN = tbIsin.Text;
                        prodFons.Descripcio = tbDescripcio.Text;

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
                Comuns.Utilitats.EscriuLog(ex1, Program.FitxerLog);
                //MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog);
                //MessageBox.Show(ex.Message);
            }
        }


        private void btCancela_Click(object sender, EventArgs e)
        {
            modeConsulta();

            ompleTabProductes((Producte) cbProductesTab1.SelectedItem);
            OmpleEmpresesCombo();
        }


        private void modeConsulta()
        {
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

            btNouProducte.Enabled = true;
            btEditaProducte.Enabled = cbProductesTab1.SelectedItem != null;
            btCancela.Enabled = false;
            btDesa.Enabled = false;
            cbEmpresa.Enabled = false;
            cbTipusProducte.Enabled = false;
            cbMercat.Enabled = false;
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

            btCancela.Enabled = true;
            btDesa.Enabled = true;
            cbEmpresa.Enabled = true;
            //cbTipusProducte.Enabled = true;
            cbMercat.Enabled = true;
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
            }
        }

        private void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuari.Seleccionat = (Usuari) cbUsuaris.SelectedItem;
            movimentsTab1.canviUsuari(Usuari.Seleccionat);
            valoracionsTab1.canviUsuari(Usuari.Seleccionat);
            perduesGuanysTab1.canviUsuari(Usuari.Seleccionat);
        }
    }
}
