using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Inversions.GUI
{
    public partial class GestioProductes : UserControl
    {
        private ListBox lbProductesTab2;
        private bool vMostraLlistaAmbChecks;

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
        }

        public bool _FiltreAnyVisible
        {
            get { return pnFiltreAny.Visible; }
            set { pnFiltreAny.Visible = value; }
        }

        public Usuari _UsuariSeleccionat
        {
            set { lbUsuari.Text = value.Nom; }
        }

        public bool _NomesAmbParticipacions
        {
            get { return ckNomesAmbParticipacions.Checked; }
            set { ckNomesAmbParticipacions.Checked = value; }
        }

        public bool _AmbMoviments
        {
            get { return ckAmbMoviments.Checked; }
            set { ckAmbMoviments.Checked = value; }
        }

        public bool _MostraLlistaAmbChecks
        {
            get { return vMostraLlistaAmbChecks; }
            set
            {
                vMostraLlistaAmbChecks = value;
                preparaLlistaProductes(value);
            }
        }


        /// <summary>
        /// Refresca les dades que mostra control.
        /// </summary>
        public void refrescaDadesControl()
        {
            // No entenc perquè, però he de fer-ho així perquè es refresqui.
            var index = lbProductesTab2.SelectedIndex;
            lbProductesTab2.SelectedItem = null;
            lbProductesTab2.SelectedIndex = index;
            lbProductesTab2.SelectedItem = null;
            lbProductesTab2.SelectedIndex = index;
        }

        public void seleccionaProducte(Producte prod)
        {
            lbProductesTab2.SelectedItem = prod;
        }

        private void cbTipusProducteFiltreTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipusProducteFiltreTab2.SelectedIndex >= 0)
            {
                lbEmpresa.Text = "";
                tbParticipacions.Text = "";
                ntbPreuPartActual.Text = "";
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

            if ((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem == Producte.TipusProducte.Accions)
            {
                prods = Program.Sessio.ProdAccions;
            }
            else if ((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem == Producte.TipusProducte.Fons)
            {
                prods = Program.Sessio.ProdFons;
            }
            else
            {
                prods = Program.Sessio.Productes;
            }

            //if (Program.RuntimeMode)
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                if (ckNomesAmbParticipacions.Checked)
                    // Filtra els productes amb participacions actualment pel usuari seleccionat.
                    prods = prods.Where(w => w._Participacions > 0);

                if (ckAmbMoviments.Checked)
                    // Filtra els productes amb algun moviment en algun moment pel usuari seleccionat.
                    prods = prods.Where(w => w.MovimentsProducteUsuari.Any());


                if (ckFiltreCompresAny.Checked || ckFiltreVendesAny.Checked)
                {
                    var movs = Program.Sessio.MovimentsUsuari.Where(w => w.Data.Year == (int) cbFiltreAny.SelectedItem
                                                                         && ((ckFiltreCompresAny.Checked && w.TipusMoviment == TipusMoviment.Compra) || (ckFiltreVendesAny.Checked && w.TipusMoviment == TipusMoviment.Venda)));

                    prods = prods.Where(prod => movs.Any(mov => mov.ProdId == prod.Id));
                }

                var llistaProds = prods.OrderBy(o => o.OrdreGrid).ToList();
                if (_MostraLlistaAmbChecks)
                {
                    lbProductesTab2.DataSource = llistaProds;
                }
                else
                {
                    lbProductesTab2.SelectedIndexChanged -= lbProductesTab2_SelectedIndexChanged;
                    lbProductesTab2.DataSource = llistaProds;
                    lbProductesTab2.SelectedIndexChanged += lbProductesTab2_SelectedIndexChanged;
                    lbProductesTab2.SelectedItem = null;
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
                ntbPreuPartActual.Valor = prod.valorParticipacio();
                tbDividends.Valor = prod.dividends(DateTime.Today);
                tbValorActual.Valor = prod._ValorActual;

                //tbPiGActual.Valor = prod.pigValorat(Producte.DateTimeFinalDia.Today);
                tbPiGActual.Valor = prod.pigEnCartera();

                //tbPiGReal.Valor = prod.pigReal(Producte.DateTimeFinalDia.Today);
                tbPiGReal.Valor = prod.pig();

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
            //if(!Comuns.Utilitats.IsInDesignMode())
            //{
            //    // Aquí només s'executa al entrar en la perstanya.
            //    for (int any = Program.Sessio.Moviments.OrderBy(o => o.Data).First().Data.Year; any <= DateTime.Today.Year; any++)
            //    {
            //        cbFiltreAny.Items.Add(any);
            //    }
            //    cbFiltreAny.SelectedItem = DateTime.Today.Year;
            //}

            // Aquí només s'executa al entrar en la perstanya.
            for (int any = Program.PrimerAny; any <= DateTime.Today.Year; any++)
            {
                cbFiltreAny.Items.Add(any);
            }
            cbFiltreAny.SelectedItem = DateTime.Today.Year;
        }

        private void ckFiltreAny_CheckedChanged(object sender, EventArgs e)
        {
            cbFiltreAny.Enabled = ckFiltreCompresAny.Checked || ckFiltreVendesAny.Checked;
        }

        private void btFiltra_Click(object sender, EventArgs e)
        {
            carregaLbProductesTab2();
        }


        private void preparaLlistaProductes(bool mostraLlistaAmbChecks )
        {
            if (mostraLlistaAmbChecks)
            {
                pnDadesProducte.Visible = false;
                gbEmpresa.Visible = false;
                pnSelDeselChecksProds.Visible = true;

                lbProductesTab2 = new CheckedListBox();
                ((CheckedListBox) lbProductesTab2).CheckOnClick = true;
                ((CheckedListBox) lbProductesTab2).ItemCheck += lbProductesTab2_ItemCheck;
            }
            else
            {
                pnDadesProducte.Visible = true;
                gbEmpresa.Visible = true;
                pnSelDeselChecksProds.Visible = false;

                lbProductesTab2 = new ListBox();
            }

            lbProductesTab2.SuspendLayout();
            groupBox6.Controls.Add(lbProductesTab2);
            lbProductesTab2.Dock = DockStyle.Fill;
            lbProductesTab2.DisplayMember = "_TipusNomProducte";
            lbProductesTab2.FormattingEnabled = true;
            lbProductesTab2.Margin = new Padding(3, 4, 3, 4);
            //lbProductesTab2.ItemHeight = 20;
            //lbProductesTab2.Location = new System.Drawing.Point(6, 25);
            //lbProductesTab2.Name = "lbProductesTab2";
            //lbProductesTab2.Size = new System.Drawing.Size(594, 528);
            //lbProductesTab2.TabIndex = 0;
            lbProductesTab2.ResumeLayout();
        }

        void lbProductesTab2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btRefrescaGrafica.Enabled = true;
        }

        private void btSeleccionaTot_Click(object sender, EventArgs e)
        {
            // Selecciona tots els productes de la llista.
            selDeselTot(true);         
        }

        private void btDeseleccionaTot_Click(object sender, EventArgs e)
        {
            // Deselecciona tots els productes de la llista.
            selDeselTot(false);         
        }

        private void selDeselTot(bool selecciona)
        {
            bool hiHaCanvis = false;

            CheckedListBox chLb = (CheckedListBox) lbProductesTab2;

            for (int i = 0; i < chLb.Items.Count; i++)
            {
                if (chLb.GetItemChecked(i) != selecciona)
                {
                    hiHaCanvis = true;
                    chLb.SetItemChecked(i, selecciona);
                }
            }

            if (hiHaCanvis)
                btRefrescaGrafica.Enabled = true;
        }


        private void btActualitzaGrafica_Click(object sender, EventArgs e)
        {

        }
        

    }
}