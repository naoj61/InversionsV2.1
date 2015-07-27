using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class PerduesGuanysTab : UserControl
    {
        public PerduesGuanysTab()
        {
            InitializeComponent();

            cDataGridView1.AutoGenerateColumns = false;

            gestioProductesTabValoracions._NomesAmbParticipacions = false;


            if (!MyClass.DesignMode)
            {
                tbPiGTotConsolidat.Valor = Enumerable.Aggregate<Producte, double>(MyClass.Sessio.Productes, 0, (current, producte) => Math.Round(current + producte._PiGReal(), 4));
                tbPiGTotActual.Valor = Enumerable.Aggregate<Producte, double>(MyClass.Sessio.Productes, 0, (current, producte) => Math.Round(current + producte._PiGActual(), 4));

                Dictionary<int, double> dictPiGs = new Dictionary<int, Double>();

                foreach (Producte producte in MyClass.Sessio.Productes)
                {
                    foreach (Producte.PiG piG in producte._PiG())
                    {
                        if (piG._DataVenda.HasValue)
                        {
                            int clau = piG._DataVenda.Value.Year * 10 + Convert.ToInt32(piG._LlargPlaç);

                            if (dictPiGs.ContainsKey(clau))
                                dictPiGs[clau] += piG._PiG;
                            else
                                dictPiGs[clau] = piG._PiG;
                        }
                    }
                }

                foreach (KeyValuePair<int, double> keyValuePair in dictPiGs.OrderBy(o => o.Key))
                {
                    int any = (int) Math.Truncate(keyValuePair.Key / 10m);
                    string termini = Convert.ToBoolean(keyValuePair.Key % 10) ? "Llarg" : "Curt";
                    dgvPiGAnuals.Rows.Add(any, termini, keyValuePair.Value);
                }
            }
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat != null)
            {
                actualitzaLlistaPerduesGuanys();
                colDataTraspas.Visible = gestioProductesTabValoracions._ProducteSeleccionat._TipusProducte != Producte.TipusProducte.Accions;
                cDataGridView1.Visible = true;
            }
        }


        private void actualitzaLlistaPerduesGuanys()
        {
            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = gestioProductesTabValoracions._ProducteSeleccionat._PiG();
            cDataGridView1.ClearSelection();
            cDataGridView1.ResumeLayout();
        }


        //private Valoracio vValoracioSeleccionada = null;

        //private void cDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (cDataGridView1.CurrentRow == null)
        //    {
        //        vValoracioSeleccionada = null;
        //    }
        //    else if (vValoracioSeleccionada != (Valoracio) cDataGridView1.Rows[e.RowIndex].DataBoundItem)
        //    {
        //        vValoracioSeleccionada = (Valoracio) cDataGridView1.Rows[e.RowIndex].DataBoundItem;
        //    }
        //}
    }
}