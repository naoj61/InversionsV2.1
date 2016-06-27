using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class Principal : Form
    {
        public Principal()
        {

            //foreach (var moviment in MyClass.Sessio.Moviments)
            //{
            //    moviment.PreuParticipacio = moviment.Participacions == 0 ? moviment.Import :
            //        moviment.Import / moviment.Participacions;
            //    MyClass.Sessio.Entry(moviment).State = EntityState.Modified;
            //}

            //int ii = MyClass.Sessio.SaveChanges();


            //foreach (var prod in MyClass.Sessio.Productes)
            //{
            //    System.Diagnostics.Debug.WriteLine("Id: {0}. Nom: {1}", prod.Id, prod._NomProducte);
            //}

            //var ss = MyClass.Sessio.Productes.Single(s => s.Id == 9).pigAny(2014);

            //double dd = 0;
            //System.Diagnostics.Debug.WriteLine("Nom Prod\tNum part\tPreu part inici\tpreu part actual");
            //foreach (var prod in MyClass.Sessio.Productes)
            //{
            //    var numPart = prod._Participacions;
            //if (numPart > 0)
            //    System.Diagnostics.Debug.WriteLine("{0}\t{1}\t{2}\t{3}", prod._NomProducte, numPart.ToString("0.0000"),
            //        prod.valorParticipacio(new Producte.DateTimeFinalDia(2016, 1, 1)).ToString("0.0000"),
            //        prod.valorParticipacio(new Producte.DateTimeFinalDia(DateTime.Today)).ToString("0.0000"));

            //    var cc = prod.pigPerDates(new Producte.DateTimeIniciDia(2014, 1, 1), new Producte.DateTimeFinalDia(2016, 6, 20));
            //    System.Diagnostics.Debug.WriteLine("Id:\t{2}\tNom producte:\t{0}\tPiG:\t{1}", prod._NomProducte, cc.ToString("#,##0.00"), prod.Id);
            //    dd += cc;
            //}

            InitializeComponent();

            this.Text = "Producte. Ver: " + Application.ProductVersion;

            tabControl1.SelectTab(2);

            List<Producte.TipusProducte> tipusProductes = new List<Producte.TipusProducte>(Enum.GetValues(typeof(Producte.TipusProducte)).Cast<Producte.TipusProducte>());
            cbTipusProducteFiltreTab1.DataSource = tipusProductes;
            cbTipusProducte.DataSource = tipusProductes.Where(w => w != Producte.TipusProducte.Tots).ToList();

            OmpleEmpresesCombo();

            cbMercat.SuspendLayout();
            cbMercat.DisplayMember = "Nom";
            cbMercat.DataSource = MyClass.Sessio.Mercats.ToList();
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
            cbEmpresa.DataSource = MyClass.Sessio.Empreses.OrderBy(o => o.Nom).ToList();
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
            IEnumerable<Producte> prods = LlistaProductes((Producte.TipusProducte)cbTipusProducteFiltreTab1.SelectedItem);

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
                prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdAccions>().Include(inc => inc.Empresa));
            }
            else if (tipusProducte == Producte.TipusProducte.Fons)
            {
                prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdFons>().Include(inc => inc.Empresa));
            }
            else
            {
                prods = MyClass.Sessio.Productes.Include(inc => inc.Empresa).ToList();
            }
            return prods.OrderBy(s => s._NomProducte);
        }


        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpresa.SelectedItem != null)
            {
                switch(((Empresa) cbEmpresa.SelectedItem).TipusEmpresa)
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
            var e1 = MyClass.Sessio.Empreses.Where(w => (w.TipusEmpresa == TipusEmpresa.GestoraFons)
                                                        || (w.TipusEmpresa == TipusEmpresa.Accions
                                                            && !MyClass.Sessio.Productes.Any(a => a.Empresa == w)));

            cbEmpresa.SuspendLayout(); ;
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

                Producte.TipusProducte tp = (Producte.TipusProducte) cbTipusProducte.SelectedItem;

                if (tp == Producte.TipusProducte.Accions)
                {
                    if (cbMercat.SelectedItem == null)
                        throw new ApplicationException("Falta Mercat");

                    ProdAccions prodAccions;
                    if (vProducteNou)
                        prodAccions = new ProdAccions();
                    else
                        prodAccions = (ProdAccions) cbProductesTab1.SelectedItem;

                    prodAccions.Empresa = (Empresa) cbEmpresa.SelectedItem;
                    prodAccions.Mercat = (Mercat) cbMercat.SelectedItem;

                    if (vProducteNou)
                        MyClass.Sessio.Productes.Add(prodAccions);

                    MyClass.Sessio.SaveChanges();

                    prod = prodAccions;
                }
                else if (tp == Producte.TipusProducte.Fons)
                {
                    if (String.IsNullOrEmpty(tbNom.Text))
                        throw new ApplicationException("Falta Nom");
                    if (String.IsNullOrEmpty(tbIsin.Text))
                        throw new ApplicationException("Falta ISIN");

                    ProdFons prodFons;
                    if (vProducteNou)
                        prodFons = new ProdFons();
                    else
                        prodFons = (ProdFons) cbProductesTab1.SelectedItem;

                    prodFons.Empresa = (Empresa) cbEmpresa.SelectedItem;
                    prodFons.Nom = tbNom.Text;
                    prodFons.ISIN = tbIsin.Text;
                    prodFons.Descripcio = tbDescripcio.Text;

                    if (vProducteNou)
                        MyClass.Sessio.Productes.Add(prodFons);

                    MyClass.Sessio.SaveChanges();

                    prod = prodFons;
                }

                ompleTabProductes(prod);
                OmpleEmpresesCombo();

                modeConsulta();

                MessageBox.Show("Fet!!");
            }
            catch (DbEntityValidationException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btCancela_Click(object sender, EventArgs e)
        {
            modeConsulta();

            ompleTabProductes((Producte)cbProductesTab1.SelectedItem);
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
    }
}
