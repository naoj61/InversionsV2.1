using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inversions.GUI
{
    public partial class ValoracionsTab : UserControl
    {
        public ValoracionsTab()
        {
            InitializeComponent();

            cDataGridView1.AutoGenerateColumns = false;

            cData.Value = DateTime.Today;

            cbTipusProducteFiltre.SelectedIndexChanged -= cbTipusProducteFiltre_SelectedIndexChanged;
            cbTipusProducteFiltre.DataSource = Enum.GetValues(typeof(Producte.TipusProducte));
            cbTipusProducteFiltre.SelectedIndex = 0;
            cbTipusProducteFiltre.SelectedIndexChanged += cbTipusProducteFiltre_SelectedIndexChanged;
        }

        public DateTime _Data
        {
            get { return cData.Value; }
        }

        public double _Import
        {
            get { return tbImport._DoubleValue; }
        }

        private bool vEsNouValor = false;

        private void btNouValor_Click(object sender, EventArgs e)
        {
            tbImport.Valor = 0;
            vEsNouValor = true;

            modeEdicio();

            cData.Value = MyClass.AnteriorDiaLaborable(DateTime.Today);
            tbImport.Focus();
        }


        private void btModifica_Click(object sender, EventArgs e)
        {
            vEsNouValor = false;

            modeEdicio();

            tbImport.Focus();
        }


        private void btEsborra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format("S'esborrarà: {0}-{1}", vValoracioSeleccionada.Prod.Empresa.Nom, vValoracioSeleccionada.Data.ToShortDateString()), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    vEsNouValor = false;

                    MyClass.Sessio.Valoracions.Remove(vValoracioSeleccionada);
                    MyClass.Sessio.SaveChanges();

                    actualitzaLlistaValoracionsPerProducte();
                }
                catch (DbUpdateException ex2)
                {
                    MessageBox.Show(ex2.InnerException.InnerException.Message);
                    MyClass.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MyClass.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                }
            }
        }


        private void btCancela_Click(object sender, EventArgs e)
        {
            posaValorsDeLaFilaSeleccionada();
            modeConsulta();
        }

        private void modeEdicio()
        {
            btNouValor.Enabled = false;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;
            btCancela.Enabled = true;
            btDesa.Enabled = true;
            cDataGridView1.Enabled = false;
            gestioProductesTabValoracions.Enabled = false;
            cData.Enabled = true;
            tbImport.Enabled = true;
            gbFiltreTipusProducte.Enabled = false;

            ((Form)Parent.Parent.Parent).AcceptButton = btDesa;
            ((Form)Parent.Parent.Parent).CancelButton = btCancela;

            vModeEdicio = true;
        }

        private void modeConsulta()
        {
            btNouValor.Enabled = true;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;
            btCancela.Enabled = false;
            btDesa.Enabled = false;
            gestioProductesTabValoracions.Enabled = true;
            cData.Enabled = false;
            tbImport.Enabled = false;
            gbFiltreTipusProducte.Enabled = true;

            cDataGridView1.Enabled = true;

            vModeEdicio = false;

            ((Form)this.Parent.Parent.Parent).AcceptButton = null;
            ((Form)this.Parent.Parent.Parent).CancelButton = null;
        }


        private void btDesa_Click(object sender, EventArgs e)
        {
            Valoracio val = null;
            try
            {
                val = vEsNouValor ? new Valoracio() : vValoracioSeleccionada;
                val.Data = cData.Value;
                val.Import = tbImport._DoubleValue;

                if (vEsNouValor)
                {
                    val.Prod = gestioProductesTabValoracions._ProducteSeleccionat;
                    MyClass.Sessio.Valoracions.Add(val);
                }
                MyClass.Sessio.SaveChanges();

                modeConsulta();

                tbImport.Valor = 0;

                actualitzaLlistaValoracionsPerProducte();
            }
            catch (DbUpdateException ex2)
            {
                MessageBox.Show(ex2.InnerException.InnerException.Message);
                MyClass.UndoingChangesDbEntityPropertyLevel(val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MyClass.UndoingChangesDbEntityPropertyLevel(val);
            }
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            btNouValor.Enabled = true;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;

            Valoracio val = MyClass.Sessio.Valoracions.ToList().LastOrDefault(l => l.Prod == gestioProductesTabValoracions._ProducteSeleccionat);
            if (val == null)
            {
                tbImport.Valor = 0;
            }

            //pnEdicio.Visible = val != null;


            if (sender != null)
            {
                actualitzaLlistaValoracionsPerProducte();
            }
        }

        private Valoracio vValoracioSeleccionada = null;

        private void cDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cDataGridView1.CurrentRow == null)
            {
                vValoracioSeleccionada = null;
            }
            else if (vValoracioSeleccionada != (Valoracio) cDataGridView1.Rows[e.RowIndex].DataBoundItem)
            {
                vValoracioSeleccionada = (Valoracio) cDataGridView1.Rows[e.RowIndex].DataBoundItem;
                posaValorsDeLaFilaSeleccionada();
                btModifica.Enabled = true;
                btEsborra.Enabled = true;
            }
        }

        private bool vModeEdicio = false;

        private void posaValorsDeLaFilaSeleccionada()
        {
            if (!vModeEdicio)
            {
                cData.Value = vValoracioSeleccionada.Data;
                tbImport.Valor = vValoracioSeleccionada.Import;
            }
        }

        private void ValoracionsTab_Load(object sender, EventArgs e)
        {
            actualitzaLlistaValoracionsTotal();
        }

        private void btActualitzaLlista_Click(object sender, EventArgs e)
        {
            actualitzaLlistaValoracionsTotal();
        }

        private void cbTipusProducteFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualitzaLlistaValoracionsTotal();
        }

        private void actualitzaLlistaValoracionsTotal()
        {
            if (MyClass.DesignMode)
                return;

            var tipusProdFiltre = cbTipusProducteFiltre.SelectedItem == null ? Producte.TipusProducte.Tots : (Producte.TipusProducte) cbTipusProducteFiltre.SelectedItem;
            IQueryable<Valoracio> valoracions;
            switch (tipusProdFiltre)
            {
                case Producte.TipusProducte.Accions:
                    valoracions = MyClass.Sessio.Valoracions.Where(w => w.Prod is ProdAccions);
                    break;
                case Producte.TipusProducte.Fons:
                    valoracions = MyClass.Sessio.Valoracions.Where(w => w.Prod is ProdFons);
                    break;
                default:
                    valoracions = MyClass.Sessio.Valoracions;
                    break;
            }

            dgvValoracionsPerData.Rows.Clear();

            DateTime? dataAnt = null;
            double importAnt = 0;
            double importAct = 0;
            double importAcumulat = 0;

            double maxVal = 0;
            double minVal = double.MaxValue;

            chart2.Series[0].Points.Clear();
            //chart2.ChartAreas[0].AxisX.Minimum = valoracions.Min(m => m.Data).ToOADate();
            //chart2.ChartAreas[0].AxisX.Maximum = valoracions.Max(m => m.Data).ToOADate();
            //chart2.ChartAreas[0].AxisY.Minimum = double.MaxValue;
            chart2.ChartAreas[0].AxisY.Maximum = Math.Ceiling(valoracions.Max(m => m.Import));

            foreach (var valoracio in valoracions.OrderBy(o => o.Data))
            {
                if (!dataAnt.HasValue || dataAnt.Value != valoracio.Data)
                {
                    if (dataAnt.HasValue)
                    {
                        importAcumulat += (importAct - importAnt);

                        dgvValoracionsPerData.Rows.Add(dataAnt.Value, importAct, (importAct / importAnt - 1), importAct - importAnt, importAcumulat);

                        if (dataAnt.Value >= new DateTime(2015, 3, 20))
                        {
                            chart2.Series[0].Points.AddXY(dataAnt.Value.ToOADate(), importAcumulat);

                            if (maxVal < importAcumulat)
                                maxVal = Math.Ceiling(importAcumulat / 10) * 10;

                            if (minVal > importAcumulat)
                                minVal = Math.Floor(importAcumulat / 10) * 10;
                        }

                        importAnt = importAct;
                        importAct = 0;
                    }
                    dataAnt = valoracio.Data.Date;
                }

                importAct += valoracio.Import * valoracio.Prod.participacions(valoracio.Data);
            }

            if (dataAnt.HasValue && importAct > 0)
            {
                importAcumulat += (importAct - importAnt);
                dgvValoracionsPerData.Rows.Add(dataAnt.Value, importAct, (importAct / importAnt - 1), importAct - importAnt, importAcumulat);
            }

            dgvValoracionsPerData.FirstDisplayedScrollingRowIndex = dgvValoracionsPerData.Rows.GetLastRow(DataGridViewElementStates.Visible);

            chart2.ChartAreas[0].AxisY.Minimum = minVal;
            chart2.ChartAreas[0].AxisY.Maximum = maxVal;
            //chart2.DataBind();
            chart2.Update();

            //ompleGrafica2(valoracions.Where(w=>w.Data>=(new DateTime(2015,03,20))).OrderBy(o => o.Data).ToList());
        }


        private void actualitzaLlistaValoracionsPerProducte()
        {
            var valoracionsProducte = MyClass.Sessio.Valoracions.Where(w => w.Prod.Id == gestioProductesTabValoracions._ProducteSeleccionat.Id).OrderBy(o=>o.Data).ToList();

            cDataGridView1.SuspendLayout();
            cDataGridView1.DataSource = valoracionsProducte;
            var xx = cDataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (xx >= 0)
            {
                cDataGridView1.FirstDisplayedScrollingRowIndex = xx;
                ompleGrafica1(valoracionsProducte);
            }
            else
            {
                chart1.Visible = false;
            }
            cDataGridView1.ResumeLayout();
        }


        private void ompleGrafica1(List<Valoracio> valoracionsProducte)
        {
            //chart1.ChartAreas[0].AxisX.Minimum = valoracionsProducte.Min(m => m.Data).t;
            //chart1.ChartAreas[0].AxisX.Maximum = Maquina.Seleccionat._NumSegmentsTinter + 1;

            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.00";

            chart1.ChartAreas[0].AxisY.Minimum = valoracionsProducte.Min(m => m.Import) / 1.02;

            chart1.ChartAreas[0].AxisY.Maximum = valoracionsProducte.Max(m => m.Import) * 1.02;

            chart1.DataSource = valoracionsProducte;
            chart1.DataBind();
            chart1.Update();

            chart1.Visible = true;
        }
    }
}
