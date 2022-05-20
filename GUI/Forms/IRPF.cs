using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comuns;

namespace Inversions.GUI.Forms
{
    public sealed partial class IRPF : Form
    {
        private List<StProductes> vProdsAmbVendesAny;
        private List<Moviment> vVendesAny;
        private Dictionary<Inversions.Moviment, List<CompraExt>> vCompresVendesAny;
        private int vAny;

        public IRPF(int any)
        {
            InitializeComponent();

            dgvProductes.AutoGenerateColumns = false;
            dgvVendes.AutoGenerateColumns = false;
            dgvCompresVenda.AutoGenerateColumns = false;

            dgvProductes.AutoSize = true;

            for (int i = 2013; i <= DateTime.Today.Year; i++)
            {
                cbAny.Items.Add(i);
            }

            cbAny.SelectedItem = any;
        }

        private struct StProductes
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

            public Moviment _Venda
            {
                get { return vVenda; }
            }

            public int _Id
            {
                get { return _Venda.Id; }
            }

            public DateTime _Data
            {
                get { return _Venda.Data; }
            }

            public Producte _Prod
            {
                get { return _Venda.Prod; }
            }

            public double _Parts
            {
                get { return _Venda.Participacions; }
            }

            public double _PreuUnitari
            {
                get { return _Venda.PreuParticipacio; }
            }

            public double _Despeses
            {
                get { return _Venda.Despeses.GetValueOrDefault(); }
            }

            public double _ImportBrut
            {
                get { return _Venda._ImportBrut; }
            }

            public double _ImportNet
            {
                get { return _Venda._ImportNet; }
            }

            public double _PiG
            {
                get { return _Venda.pig2Venda(true); }
            }


            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }


        private struct StCompresVenda
        {
            public StCompresVenda(Moviment venda, CompraExt compra)
                : this()
            {
                if (!venda._EsVenda)
                    throw new Exception("No és una venda");
           

                vVenda = venda;
                vCompra = compra;

                vParticipacionsUtilitzades = compra._PartsUtilitzades;
            }
            
            private readonly Moviment vVenda;
            private readonly CompraExt vCompra;
            private double vParticipacionsUtilitzades;

            private double _DespesesCompraUtil
            {
                get { return vCompra._DespesesPartsUtilitzades / vCompra._Participacions * vParticipacionsUtilitzades; }
            }

            private double _DespesesVendaUtil
            {
                get { return vVenda.Despeses.GetValueOrDefault() / vVenda.Participacions * vParticipacionsUtilitzades; }
            }


            public void afegeigParticipacionsUtilitzades(double participacionsUtilitzades)
            {
                vParticipacionsUtilitzades += participacionsUtilitzades;
            }

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local

            public double _ParticipacionsUtilitzades
            {
                get { return vParticipacionsUtilitzades; }
            }

            public double _DespesesUtil
            {
                get { return _DespesesCompraUtil + _DespesesVendaUtil; }
            }

            public double _DespesesCompra
            {
                get { return vCompra._Despeses; }
            }

            public double _DespesesVenda
            {
                get { return vVenda.Despeses.GetValueOrDefault(); }
            }

            public Moviment _Venda
            {
                get { return vVenda; }
            }

            public CompraExt _CompraExt
            {
                get { return vCompra; }
            }

            public int _IdVenda
            {
                get { return _Venda.Id; }
            }

            public int _Id
            {
                get { return _CompraExt._Id; }
            }

            public DateTime _Data
            {
                get { return _CompraExt._Data; }
            }

            public double _Participacions
            {
                get { return _CompraExt._Participacions; }
            }

            public double _PreuUnitari
            {
                get { return _CompraExt._PreuParticipacio; }
            }

            public double _ImportCompraBrutUtil
            {
                get { return _ParticipacionsUtilitzades * vCompra._PreuParticipacio; }
            }

            public double _ImportVendaBrutUtil
            {
                get { return _ParticipacionsUtilitzades * vVenda.PreuParticipacio; }
            }

            public double _ImportCompraNetUtil
            {
                get { return _ImportCompraBrutUtil + _DespesesCompraUtil; }
            }

            public double _ImportVendaNetUtil
            {
                get { return _ImportVendaBrutUtil - _DespesesVendaUtil; }
            }

            public double _PiG
            {
                get { return _ImportVendaNetUtil - _ImportCompraNetUtil; }
            }

            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local


            #region Overrides

            public override int GetHashCode()
            {
                return (vCompra != null ? vCompra.GetHashCode() : 0);
            }

            public static bool operator ==(StCompresVenda a, StCompresVenda b)
            {
                return a.vCompra == b.vCompra;
            }

            public static bool operator !=(StCompresVenda a, StCompresVenda b)
            {
                return !(a == b);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is StCompresVenda))
                    return false;

                return this == (StCompresVenda)obj;
            }
            
            #endregion
        }
        

        private void IRPF_Shown(object sender, EventArgs e)
        {
            ckAgrupaCompres.Checked = true;

            dgvProductes.ClearSelection();

            dgvProductes.SelectionChanged += dgvProductes_SelectionChanged;

            seleccionaFilesDataGrid();
        }

        private void ompleGridCompresDeLaVenda()
        {
            // Crea llista de les vendes seleccionades de "dgvVendes".
            var vendessSelec = (from DataGridViewRow row in dgvVendes.SelectedRows select (Moviment)row.Cells[0].Value).ToList();

            List<StCompresVenda> compresVenda = new List<StCompresVenda>();
            foreach (Moviment venda in vendessSelec)
            {
                compresVenda.AddRange(venda.compresDeLaVenda().Select(compraExt => new StCompresVenda(venda, compraExt)));
            }

            if (ckAgrupaCompres.Checked)
            {
                ColDespesesCompra.Visible = false;
                ColDespesesVenda.Visible = false;

                List<StCompresVenda> compresVendaAgrup = new List<StCompresVenda>();
                foreach (var compraVenda in compresVenda)
                {
                    if (compresVendaAgrup.Contains(compraVenda))
                    {
                        // Aixó és perquè "compraVenda" son strucs i la llista retorna una còpia no una referència.
                        var idx = compresVendaAgrup.IndexOf(compraVenda);
                        compraVenda.afegeigParticipacionsUtilitzades(compresVendaAgrup[idx]._ParticipacionsUtilitzades);
                        compresVendaAgrup[idx] = compraVenda;
                    }
                    else
                        compresVendaAgrup.Add(compraVenda);
                }
                dgvCompresVenda.DataSource = compresVendaAgrup.OrderBy(o => o._Venda.Data).ThenBy(o => o._CompraExt._Data).ToList();
            }
            else
            {
                ColDespesesCompra.Visible = true;
                ColDespesesVenda.Visible = true;

                dgvCompresVenda.DataSource = compresVenda.OrderBy(o => o._Venda.Data).ThenBy(o => o._CompraExt._Data).ToList();
            }
        }

        private void calculaTotalATributar()
        {
            var totATributar = ntbPiG.Valor - ntbPerduesAnysAnteriors.Valor - ntbMinimContribuent.Valor;
            ntbTotalTributar.Valor = totATributar <= 0 ? 0 : totATributar;
        }


        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            vAny = (int)cbAny.SelectedItem;

            vVendesAny = Program.Sessio.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == vAny).OrderBy(o => o.Prod).ThenBy(t => t.Data).ToList();
            vProdsAmbVendesAny = vVendesAny.Select(s => s.Prod).Distinct().Select(i => new StProductes(vAny, i)).ToList();
            vCompresVendesAny = vVendesAny.ToDictionary(x => x, x => x.compresDeLaVenda().ToList());

            dgvProductes.DataSource = vProdsAmbVendesAny;

            ntbPerduesAnysAnteriors.Valor = -Producte.PerduesDarrersQuatreAnys(vAny);

            seleccionaFilesDataGrid();
        }

        private void seleccionaFilesDataGrid()
        {
            dgvProductes.SelectAll();

            dgvVendes.SelectAll();

            dgvCompresVenda.ClearSelection();
        }

        private void dgvProductes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductes.SelectedRows.Count == 0)
            {
                dgvVendes.DataSource = null;
                ntbDividents.Valor = 0;
            }
            else
            {

                // Crea llista dels productes seleccionats de "dgvProductes".
                var prodsSelec = (from DataGridViewRow row in dgvProductes.SelectedRows select (Producte) row.Cells[1].Value).ToList();

                List<StVendesAny> vendesAny = new List<StVendesAny>();
                foreach (Moviment venda in vVendesAny)
                {
                    if (prodsSelec.Contains(venda.Prod))
                        vendesAny.Add(new StVendesAny(venda));
                }

                dgvVendes.DataSource = vendesAny;

                ntbDividents.Valor = dgvProductes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StProductes) row.DataBoundItem)._Divident);
            }
        }

        private void dgvVendes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendes.SelectedRows.Count == 0)
                dgvVendes.DataSource = null;
            else
            {
                ompleGridCompresDeLaVenda();

                ntbPiG.Valor = dgvVendes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StVendesAny)row.DataBoundItem)._PiG);

                calculaTotalATributar();
            }
        }

        private void ckAgrupaCompres_CheckedChanged(object sender, EventArgs e)
        {
            ompleGridCompresDeLaVenda();
        }

        private void ntbMinimContribuent_Validated(object sender, EventArgs e)
        {
            calculaTotalATributar();
        }
    }
}