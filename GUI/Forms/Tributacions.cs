using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inversions.GUI.Forms
{
    public partial class Tributacions : Form
    {
        public Tributacions()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
        }

        struct Tributs
        {
            internal Tributs(int any, Producte prod)
            {
                vAny = any;
                vProd = prod;
                vImportCompra = prod.importCompra(any);
                vImportVenda = prod.importVenda(any);
                vDespesesCompra = prod.calculaDespesesCompra(any);
                vDespesesVenda = prod.calculaDespesesVenda(any);
                vDividents = prod.calculaDividents(any);
            }

            private int vAny;
            private Producte vProd;
            private double vImportCompra;
            private double vImportVenda;
            private double vDespesesCompra;
            private double vDespesesVenda;
            private double vDividents;

            public int _Any
            {
                get { return vAny; }
            }

            public Producte _Prod
            {
                get { return vProd; }
            }

            public double _ImportCompra
            {
                get { return vImportCompra; }
            }

            public double _ImportVenda
            {
                get { return vImportVenda; }
            }

            public double _DespesesCompra
            {
                get { return vDespesesCompra; }
            }

            public double _DespesesVenda
            {
                get { return vDespesesVenda; }
            }

            public double _Dividents
            {
                get { return vDividents; }
            }

            public double _CompresNet
            {
                get { return vImportCompra + _DespesesCompra; }
            }

            public double _VendesNet
            {
                get { return vImportVenda - _DespesesVenda; }
            }

            public double _TotalNet
            {
                get { return _VendesNet - _CompresNet; }
            }
        }


        public void carregaDades(int any)
        {
            //Valor de transmisión, Valor de adquisición 

            var tributs = Program.Sessio.Productes.AsEnumerable().Where(producte => producte.tributaAquestAny(any))
                .Select(prod => new Tributs(any, prod)).ToList();

            dataGridView1.DataSource = tributs.Where(w=>w._ImportVenda > 0).ToList();
            dataGridView2.DataSource = tributs.Where(w=>w._Dividents > 0).ToList();

            tbAny.Valor = any;
            tbTotal.Valor = tributs.Sum(t => t._ImportVenda - t._ImportCompra - t._DespesesCompra - t._DespesesVenda + t._Dividents);
        }
    }
}