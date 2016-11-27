using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inversions.GUI
{
    public partial class ValoracionsTab : UserControl, ITabs
    {
        public ValoracionsTab()
        {

            InitializeComponent();

            chart1.GetToolTipText += chart1_GetToolTipText;

            cDataGridView1.AutoGenerateColumns = false;

            cData.Value = DateTime.Today;

            cbTipusProducteFiltre.SelectedIndexChanged -= cbTipusProducteFiltre_SelectedIndexChanged;
            cbTipusProducteFiltre.DataSource = Enum.GetValues(typeof (Producte.TipusProducte));
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


        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            // Check selected chart element and set tooltip text for it
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    if (e.HitTestResult.Series != null)
                    {
                        var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];

                        e.Text = string.Format("Import:\t{0}", dataPoint.YValues[0]);
                    }
                    break;
            }
        }


        private void btNouValor_Click(object sender, EventArgs e)
        {
            tbImport.Valor = 0;

            modeEdicio();

            cData.Value = Program.AnteriorDiaLaborable(DateTime.Today);
            tbImport.Focus();
        }


        private void btModifica_Click(object sender, EventArgs e)
        {
            modeEdicio();

            tbImport.Focus();
        }


        private void btEsborra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format("S'esborrarà: {0}-{1}", vValoracioSeleccionada.Prod.Empresa.Nom, vValoracioSeleccionada.Data.ToShortDateString()), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new InversionsBDContext())
                {
                    try
                    {
                        Valoracio valToRemove = conn.Valoracions.Single(s => s.Id == vValoracioSeleccionada.Id);
                        conn.Valoracions.Remove(valToRemove);
                        conn.SaveChanges();

                        actualitzaLlistaValoracionsPerProducte();
                    }
                    catch (DbUpdateException ex2)
                    {
                        Comuns.Utilitats.EscriuLog(ex2, Program.FitxerLog);
                        //MessageBox.Show(ex2.InnerException.InnerException.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
                    catch (Exception ex)
                    {
                        Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog);
                        //MessageBox.Show(ex.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
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
            btCopiaValorsDelPaste.Enabled = false;
            btCancela.Enabled = true;
            btDesa.Enabled = true;
            cDataGridView1.Enabled = false;
            gestioProductesTabValoracions.Enabled = false;
            cData.Enabled = true;
            tbImport.Enabled = true;
            gbFiltreTipusProducte.Enabled = false;

            ((Form) Parent.Parent.Parent).AcceptButton = btDesa;
            ((Form) Parent.Parent.Parent).CancelButton = btCancela;

            vModeEdicio = true;
        }

        private void modeConsulta()
        {
            btNouValor.Enabled = true;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;
            btCopiaValorsDelPaste.Enabled = true;
            btCancela.Enabled = false;
            btDesa.Enabled = false;
            gestioProductesTabValoracions.Enabled = true;
            cData.Enabled = false;
            tbImport.Enabled = false;
            gbFiltreTipusProducte.Enabled = true;

            cDataGridView1.Enabled = true;

            vModeEdicio = false;

            ((Form) this.Parent.Parent.Parent).AcceptButton = null;
            ((Form) this.Parent.Parent.Parent).CancelButton = null;
        }


        private void btDesa_Click(object sender, EventArgs e)
        {
            using (var conn = new InversionsBDContext())
            {
                try
                {
                    if (vValoracioSeleccionada == null)
                    {
                        Valoracio.Nova(conn, gestioProductesTabValoracions._ProducteSeleccionat, cData.Value, tbImport._DoubleValue);
                    }
                    else
                    {
                        vValoracioSeleccionada.modifica(conn, cData.Value, tbImport._DoubleValue);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            modeConsulta();

            tbImport.Valor = 0;

            actualitzaLlistaValoracionsPerProducte();
        }


        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            btNouValor.Enabled = true;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;

            Valoracio val = Program.Sessio.Valoracions.ToList().LastOrDefault(l => l.Prod == gestioProductesTabValoracions._ProducteSeleccionat);
            if (val == null)
            {
                tbImport.Valor = 0;
            }

            pnEdicio.Visible = sender != null;

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
                tbImport.Valor = vValoracioSeleccionada.PreuParticipacio;
            }
        }


        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabValoracions._UsuariSeleccionat = usuari;
            cDataGridView1.DataSource = null;
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
            //if (!Program.RuntimeMode)
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            var tipusProdFiltre = cbTipusProducteFiltre.SelectedItem == null ? Producte.TipusProducte.Tots : (Producte.TipusProducte) cbTipusProducteFiltre.SelectedItem;
            List<Valoracio> valoracions;
            List<Moviment> moviments;
            switch (tipusProdFiltre)
            {
                case Producte.TipusProducte.Accions:
                    //valoracions = MyClass.Sessio.Valoracions.Where(w => w.Prod is ProdAccions);
                    valoracions = Program.Sessio.Valoracions.Where(w => w.Prod is ProdAccions).ToList();
                    moviments = Program.Sessio.MovimentsUsuari.Where(w => w.Prod is ProdAccions && w.Participacions > 0).ToList();
                    break;
                case Producte.TipusProducte.Fons:
                    //valoracions = MyClass.Sessio.Valoracions.Where(w => w.Prod is ProdFons);
                    valoracions = Program.Sessio.Valoracions.Where(w => w.Prod is ProdFons).ToList();
                    moviments = Program.Sessio.MovimentsUsuari.Where(w => w.Prod is ProdFons && w.Participacions > 0).ToList();
                    break;
                default:
                    //valoracions = MyClass.Sessio.Valoracions;
                    valoracions = Program.Sessio.Valoracions.ToList();
                    moviments = Program.Sessio.MovimentsUsuari.Where(w => w.Participacions > 0).ToList();
                    break;
            }

            var valMovs = valoracions.Select(s => new {Data = s.Data.Date, PreuParticipacio = s.PreuParticipacio}).
                Union(moviments.Select(s => new {Data = s.Data.Date, PreuParticipacio = s.PreuParticipacio})).
                GroupBy(g => g.Data).OrderBy(o => o.Key);

            if (!valMovs.Any())
                return;


            dgvValoracionsPerData.Rows.Clear();

            double importAcumulat = 0;

            double maxVal = 0;
            double minVal = double.MaxValue;

            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisY.Maximum = Math.Ceiling(valoracions.Max(m => m.PreuParticipacio));

            double pigPerDataAnt = 0;
            foreach (var valoracio in valMovs)
            {
                DateTime data = valoracio.Key;

                double pigPerData;
                double saldo;
                switch (tipusProdFiltre)
                {
                    case Producte.TipusProducte.Accions:
                        pigPerData = ProdAccions.PiG(new Producte.DateTimeFinalDia(data));
                        saldo = ProdAccions.Valor(new Producte.DateTimeFinalDia(data));
                        break;
                    case Producte.TipusProducte.Fons:
                        pigPerData = ProdFons.PiG(new Producte.DateTimeFinalDia(data));
                        saldo = ProdFons.Valor(new Producte.DateTimeFinalDia(data));
                        break;
                    default:
                        pigPerData = ProdAccions.PiG(new Producte.DateTimeFinalDia(data)) + ProdFons.PiG(new Producte.DateTimeFinalDia(data));
                        saldo = ProdAccions.Valor(new Producte.DateTimeFinalDia(data)) + ProdFons.Valor(new Producte.DateTimeFinalDia(data));
                        break;
                }

                importAcumulat += (pigPerData - pigPerDataAnt);

                dgvValoracionsPerData.Rows.Add(data, pigPerData, (pigPerData / pigPerDataAnt - 1), pigPerData - pigPerDataAnt, saldo);

                if (data >= new DateTime(2015, 3, 20) && pigPerData > 0)
                {
                    chart2.Series[0].Points.AddXY(data.ToOADate(), pigPerData);

                    if (maxVal < pigPerData)
                        maxVal = Math.Ceiling(pigPerData / 10) * 10;

                    if (minVal > importAcumulat)
                        minVal = Math.Floor(pigPerData / 10) * 10;
                }

                pigPerDataAnt = pigPerData;
            }


            var ultimaFila = dgvValoracionsPerData.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (ultimaFila >= 0)
                dgvValoracionsPerData.FirstDisplayedScrollingRowIndex = ultimaFila;

            chart2.ChartAreas[0].AxisY.Minimum = minVal;
            chart2.ChartAreas[0].AxisY.Maximum = maxVal;
            chart2.Update();

            //ompleGrafica2(valoracions.Where(w=>w.Data>=(new DateTime(2015,03,20))).OrderBy(o => o.Data).ToList());
        }


        private void actualitzaLlistaValoracionsPerProducte()
        {
            var valoracionsProducte = Program.Sessio.Valoracions
                .Where(w => w.Prod.Id == gestioProductesTabValoracions._ProducteSeleccionat.Id).OrderBy(o => o.Data).ToList();

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

            chart1.ChartAreas[0].AxisY.Minimum = valoracionsProducte.Min(m => m.PreuParticipacio) / 1.02;

            chart1.ChartAreas[0].AxisY.Maximum = valoracionsProducte.Max(m => m.PreuParticipacio) * 1.02;

            chart1.DataSource = valoracionsProducte;
            chart1.DataBind();
            chart1.Update();

            chart1.Visible = true;
        }

        private void btCopiaValorsDelPaste_Click(object sender, EventArgs e)
        {
            PasteSelfBank pSelf = new PasteSelfBank();
            pSelf.ShowDialog(this);
        }
    }
}
