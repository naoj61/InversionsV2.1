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
            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
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

        public bool _FiltreAnyVisible
        {
            get { return pnFiltreAny.Visible; }
            set
            {
                pnFiltreAny.Visible = value;
            }
        }

        public Usuari _UsuariSeleccionat
        {
            //get { return (Usuari) cbUsuaris.SelectedItem; }
            //set { cbUsuaris.SelectedItem = value; }
            set
            {
                lbUsuari.Text = value.Nom;
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
                try
                {
                    if (ckNomesAmbParticipacions.Checked)
                        prods = prods.Where(w => w._Participacions > 0);

                    if (ckFiltreCompresAny.Checked || ckFiltreVendesAny.Checked)
                    {
                        var movs = Program.Sessio.MovimentsUsuari.Where(w => w.Data.Year == (int)cbFiltreAny.SelectedItem 
                            && ((ckFiltreCompresAny.Checked && w.TipusMoviment == TipusMoviment.Compra) || (ckFiltreVendesAny.Checked && w.TipusMoviment == TipusMoviment.Venda)));

                        prods = prods.Where(prod => movs.Any(mov => mov.ProdId == prod.Id));
                    }

                    lbProductesTab2.SuspendLayout();
                    lbProductesTab2.SelectedIndexChanged -= lbProductesTab2_SelectedIndexChanged;
                    lbProductesTab2.DisplayMember = "_TipusNomProducte";
                    lbProductesTab2.DataSource = prods.OrderBy(o => o.OrdreGrid).ToList();
                    lbProductesTab2.SelectedIndexChanged += lbProductesTab2_SelectedIndexChanged;
                    lbProductesTab2.SelectedItem = null;
                    lbProductesTab2.ResumeLayout();
                }
                catch (Exception)
                {
                    
                    throw;
                }
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
                lbMoneda.Text = prod.Moneda;
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


        private void GestioProductes_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                // Aquí només s'executa al entrar en la perstanya.
                for (int any = Program.Sessio.Moviments.OrderBy(o => o.Data).First().Data.Year; any <= DateTime.Today.Year; any++)
                {
                    cbFiltreAny.Items.Add(any);
                }
                cbFiltreAny.SelectedItem = DateTime.Today.Year;
            }
        }

        private void ckFiltreAny_CheckedChanged(object sender, EventArgs e)
        {
            cbFiltreAny.Enabled = ckFiltreCompresAny.Checked || ckFiltreVendesAny.Checked;
        }

        private void btFiltra_Click(object sender, EventArgs e)
        {
            carregaLbProductesTab2();
        }
    }
}