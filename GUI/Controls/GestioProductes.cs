using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class GestioProductes : UserControl
    {
        public GestioProductes()
        {
            InitializeComponent();
            cbTipusProducteFiltreTab2.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
            cbTipusProducteFiltreTab2.Focus();
        }

        public event EventHandler ProducteSeleccionat;

        public Producte _ProducteSeleccionat
        {
            get { return (Producte)lbProductesTab2.SelectedItem; }
            set { lbProductesTab2.SelectedItem = value; }
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
                tbValorCompra.Text = "";
                tbValorVenda.Text = "";
                tbTotalInvertit.Text = "";
                tbValorActual.Text = "";
                tbPiG.Text = "";
                lbIsin.Text = "";
                tbDescripcio.Text = "";
                lbMercat.Text = "";

                carregaLbProductesTab2();
            }
        }

        private void carregaLbProductesTab2()
        {
            IEnumerable<Producte> prods;

            switch ((Producte.TipusProducte) cbTipusProducteFiltreTab2.SelectedItem)
            {
                case Producte.TipusProducte.Accions:
                    prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdAccions>());
                    break;
                case Producte.TipusProducte.Fons:
                    prods = new List<Producte>(MyClass.Sessio.Productes.OfType<ProdFons>());
                    break;
                default:
                    prods = MyClass.Sessio.Productes;
                    break;
            }

            if (!MyClass.DesignMode)
            {
                if (ckNomesAmbParticipacions.Checked)
                    prods = prods.Where(w => w._Participacions > 0);
                lbProductesTab2.SuspendLayout();
                lbProductesTab2.SelectedIndexChanged -= lbProductesTab2_SelectedIndexChanged;
                lbProductesTab2.DisplayMember = "_TipusNomProducte";
                lbProductesTab2.DataSource = prods.OrderBy(o => o._NomProducte).ToList();
                lbProductesTab2.SelectedIndexChanged += lbProductesTab2_SelectedIndexChanged;
                lbProductesTab2.SelectedItem = null;
                lbProductesTab2.ResumeLayout();
            }
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


        private void lbProductesTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producte prod = _ProducteSeleccionat;
            if (prod == null)
            {
                gbIsinProd.Visible = false;
                gbMercatProd.Visible = false;
                gbDescripcio.Visible = false;
            }
            else
            {
                lbEmpresa.Text = prod._NomEmpresa;
                tbParticipacions.Valor = prod._Participacions;
                tbValorCompra.Valor = prod._ImportTotalCompres;
                tbValorVenda.Valor = prod._ImportTotalVendes;
                tbTotalInvertit.Valor = prod._ImportTotalCompres - prod._ImportTotalVendes;
                tbInversioActual.Valor = prod._InversioActual;
                tbValorActual.Valor = prod._ValorActual;
                tbDiferencia.Valor = (prod._ValorActual - prod._InversioActual);
                tbPiG.Valor = prod._PiGTotal(true);

                if (prod is ProdFons)
                {
                    var prodFons = (ProdFons) prod;
                    lbIsin.Text = prodFons.ISIN;
                    tbDescripcio.Text = prodFons.Descripcio;

                    gbIsinProd.Visible = true;
                    gbDescripcio.Visible = true;
                    gbMercatProd.Visible = false;
                }
                else if (prod is ProdAccions)
                {
                    var prodAccions = (ProdAccions) prod;
                    lbMercat.Text = prodAccions.Mercat.Nom;

                    gbIsinProd.Visible = false;
                    gbDescripcio.Visible = false;
                    gbMercatProd.Visible = true;
                }
            }

            if (ProducteSeleccionat != null)
                ProducteSeleccionat(prod, EventArgs.Empty);
        }

        private void ckNomesAmbParticipacions_CheckedChanged(object sender, EventArgs e)
        {
            carregaLbProductesTab2();
        }
    }
}