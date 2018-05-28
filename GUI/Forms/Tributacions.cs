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
        }

        struct Tributs
        {
            internal Tributs(int any, Producte prod)
            {
                vAny = any;
                vProd = prod;
                vImportCompraVenda = prod.importCompraVenda(any);
                vDespeses = prod.calculaDespeses(any);
                vDividents = prod.calculaDividents(any);
            }

            private int vAny;
            private Producte vProd;
            private double vImportCompraVenda;
            private double vDespeses;
            private double vDividents;

            public int _Any
            {
                get { return vAny; }
            }

            public Producte _Prod
            {
                get { return vProd; }
            }

            public double _ImportCompraVenda
            {
                get { return vImportCompraVenda; }
            }

            public double _Despeses
            {
                get { return vDespeses; }
            }

            public double _Dividents
            {
                get { return vDividents; }
            }
        }


        public void carregaDades(int any)
        {
        
            List<Tributs> tributs = Program.Sessio.Productes.AsEnumerable().Where(producte => producte.tributaAquestAny(any))
                .Select(prod => new Tributs(any, prod)).ToList();

            dataGridView1.DataSource = tributs;

            tbTotal.Valor = tributs.Sum(t => t._ImportCompraVenda - t._Despeses + t._Dividents);
        }
    }
}