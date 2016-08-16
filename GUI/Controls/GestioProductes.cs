using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class GestioProductes : UserControl
    {
        public GestioProductes()
        {
            InitializeComponent();

            tbIsin.Dock = DockStyle.Fill;
            tbMercat.Dock = DockStyle.Fill;

            cbTipusProducteFiltreTab2.SelectedIndexChanged -= cbTipusProducteFiltreTab2_SelectedIndexChanged;
            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof(Producte.TipusProducte));
            cbTipusProducteFiltreTab2.Focus();
            cbTipusProducteFiltreTab2.SelectedIndex = 0;
            cbTipusProducteFiltreTab2.SelectedIndexChanged += cbTipusProducteFiltreTab2_SelectedIndexChanged;

        }

        public event EventHandler ProducteSeleccionat;

        public Producte _ProducteSeleccionat
        {
            get { return (Producte) lbProductesTab2.SelectedItem; }
            set
            {
                lbProductesTab2.SelectedItem = value;
                if ((Producte) lbProductesTab2.SelectedItem != value && ckNomesAmbParticipacions.Checked)
                {
                    ckNomesAmbParticipacions.Checked = false;
                    lbProductesTab2.SelectedItem = value;
                }
            }
        }

        public Usuari _UsuariSeleccionat
        {
            //get { return (Usuari) cbUsuaris.SelectedItem; }
            //set { cbUsuaris.SelectedItem = value; }
            set
            {
                lbUsuari.Text = value.Nom;
                carregaLbProductesTab2();
            }
        }

        public bool _NomesAmbParticipacions
        {
            get { return ckNomesAmbParticipacions.Checked; }
            set { ckNomesAmbParticipacions.Checked = value; }
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducteFiltreTab2.SelectedIndex >= 0)
            {
                lbEmpresa.Text = "";
                tbParticipacions.Text = "";
                tbValorActual.Text = "";
                tbPiGReal.Text = "";
                tbIsin.Text = "";
                tbDescripcio.Text = "";
                tbMercat.Text = "";

                carregaLbProductesTab2();
            }
        }

        private void carregaLbProductesTab2()
        {
            IEnumerable<Producte> prods;

            switch ((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem)
            {
                case Producte.TipusProducte.Accions:
                    prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdAccions>());
                    break;
                case Producte.TipusProducte.Fons:
                    prods = new List<Producte>(Program.Sessio.Productes.OfType<ProdFons>());
                    break;
                default:
                    prods = Program.Sessio.Productes;
                    break;
            }

            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (ckNomesAmbParticipacions.Checked)
                    prods = prods.Where(w => w._Participacions > 0);
                lbProductesTab2.SuspendLayout();
                lbProductesTab2.SelectedIndexChanged -= lbProductesTab2_SelectedIndexChanged;
                lbProductesTab2.DisplayMember = "_TipusNomProducte";
                lbProductesTab2.DataSource = prods.OrderBy(o => o.OrdreGrid).ToList();
                lbProductesTab2.SelectedIndexChanged += lbProductesTab2_SelectedIndexChanged;
                lbProductesTab2.SelectedItem = null;
                lbProductesTab2.ResumeLayout();
            }
        }


        private void lbProductesTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producte prod = _ProducteSeleccionat;
            if (prod == null)
            {
                //lbIsin.Visible = true;
                //lbMercat.Visible = false;
                gbIsinMercat.Text = "ISIN";
                tbIsin.BringToFront();

                gbDescripcio.Visible = false;
            }
            else
            {
                lbEmpresa.Text = prod._NomEmpresa;
                tbParticipacions.Valor = prod._Participacions;
                tbDividends.Valor = prod.dividends(Producte.DateTimeFinalDia.Today);
                tbValorActual.Valor = prod._ValorActual;

                tbPiGActual.Valor = prod.pigValorat(Producte.DateTimeFinalDia.Today);
                tbPiGReal.Valor = prod.pigReal(Producte.DateTimeFinalDia.Today);

                if (prod is ProdFons)
                {
                    var prodFons = (ProdFons) prod;
                    tbIsin.Text = prodFons.ISIN;
                    tbDescripcio.Text = prodFons.Descripcio;

                    gbDescripcio.Visible = true;

                    //lbIsin.Visible = true;
                    //lbMercat.Visible = false;
                    gbIsinMercat.Text = "ISIN";
                    tbIsin.BringToFront();
                }
                else if (prod is ProdAccions)
                {
                    var prodAccions = (ProdAccions) prod;
                    tbMercat.Text = prodAccions.Mercat.Nom;

                    gbDescripcio.Visible = false;
                    //lbIsin.Visible = false;
                    //lbMercat.Visible = true;
                    gbIsinMercat.Text = "Mercat";
                    tbMercat.BringToFront();
                }
            }

            if (ProducteSeleccionat != null)
                ProducteSeleccionat(prod, EventArgs.Empty);
        }

        private void ckNomesAmbParticipacions_CheckedChanged(object sender, EventArgs e)
        {
            carregaLbProductesTab2();
        }


        

        private void GestioProductes_Load(object sender, EventArgs e)
        {
            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                // Aquí només s'executa al entrar en la perstanya.

                //cbUsuaris.DisplayMember = "Nom";
                //cbUsuaris.DataSource = Program.Sessio.Usuaris.ToList();
                //cbUsuaris.SelectedItem = Program.UsuariSeleccionat;
            }
        }
    }
}