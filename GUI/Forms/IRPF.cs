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
    public sealed partial class IRPF : Form
    {
        private List<StProductes> vProdsAmbVendesAny;
        private List<Moviment> vVendesAny;
        private Dictionary<Inversions.Moviment, List<Moviment>> vCompresVendesAny;

        public IRPF(int any)
        {
            InitializeComponent();

            dgvVendes.AutoGenerateColumns = false;
            dgvProductes.AutoGenerateColumns = false;

            for (int i = 2013; i <= DateTime.Today.Year; i++)
            {
                cbAny.Items.Add(i);
            }

            cbAny.SelectedItem = any;

            carregaDades(any);
        }

        struct StProductes
        {
            public StProductes(int any, Producte prod) : this()
            {
                _Prod = prod;
                _Divident = prod.calculaDividents(any);
            }

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public Producte _Prod { get; private set; }
            public double _Divident { get; private set; }
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }


        private struct StVendesAny
        {
            public StVendesAny(Moviment venda) : this()
            {
                if (!venda._EsVenda)
                    throw new Exception("No és una venda");
                
                vVenda = venda;
            }

            private readonly Moviment vVenda;

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public int _Id
            {
                get { return vVenda.Id; }
            }

            public DateTime _Data
            {
                get { return vVenda.Data; }
            }

            public Producte _Prod
            {
                get { return vVenda.Prod; }
            }

            public double _Parts
            {
                get { return vVenda.Participacions; }
            }

            public double _PreuUnitari
            {
                get { return vVenda.PreuParticipacio; }
            }

            public double _Despeses
            {
                get { return vVenda.Despeses.GetValueOrDefault(); }
            }

            public double _ImportBrut
            {
                get { return vVenda._ImportBrut; }
            }

            public double _ImportNet
            {
                get { return vVenda._ImportNet; }
            }

            public double _PiG
            {
                get { return vVenda.pig2Venda(); }
            }
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
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


        private void carregaDades(int any)
        {



            //Valor de transmisión, Valor de adquisición 

            var tributs = Program.Sessio.Productes.AsEnumerable().Where(producte => producte.tributaAquestAny(any))
                .Select(prod => new Tributs(any, prod)).ToList();

            dgvVendes.DataSource = tributs.Where(w=>w._ImportVenda > 0).ToList();
           // dgvProductes.DataSource = tributs.Where(w=>w._Dividents > 0).ToList();

            tbPiG.Valor = tributs.Sum(t => t._ImportVenda - t._ImportCompra - t._DespesesCompra - t._DespesesVenda + t._Dividents);
        }

        private void dgvVendes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //var fila = dgvVendes.Rows[e.RowIndex];

            //var prod = ((Tributs) (fila.DataBoundItem))._Prod;
            //var ss = dgvVendes.SelectedRows;
        }



        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            var any = (int)cbAny.SelectedItem;

            vVendesAny = Program.Sessio.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == any).OrderBy(o => o.Prod).ThenBy(t => t.Data).ToList();
            vProdsAmbVendesAny = vVendesAny.Select(s => s.Prod).Distinct().Select(i => new StProductes(any, i)).ToList();
            vCompresVendesAny = vVendesAny.ToDictionary(x => x, x => x.compresDeLaVenda4().ToList());

            dgvProductes.DataSource = vProdsAmbVendesAny;
        }

        private void dgvProductes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductes.SelectedRows.Count == 0)
                dgvVendes.DataSource = null;
            else
            {
                // Crea llista dels productes seleccionats de "dgvProductes".
                var prodsSelec = (from DataGridViewRow row in dgvProductes.SelectedRows select (Producte)row.Cells[1].Value).ToList();

                List<StVendesAny> vendesAny = new List<StVendesAny>();
                foreach (Moviment venda in vVendesAny)
                {
                    if (prodsSelec.Contains(venda.Prod)) 
                        vendesAny.Add(new StVendesAny(venda));
                }

                dgvVendes.DataSource = vendesAny;
            }
        }

        private void IRPF_Shown(object sender, EventArgs e)
        {
            dgvProductes.ClearSelection();
        }
    }
}