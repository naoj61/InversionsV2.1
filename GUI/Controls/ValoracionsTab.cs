using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;
using DevExpress.XtraEditors.Controls;

namespace Inversions.GUI
{
    public partial class ValoracionsTab : UserControl, ITabs
    {
        private enum TipusProd
        {
            Tot,
            Accions,
            Fons,
            RF,
            RV
        }

        private bool vEsNouValor = false;

        private Valoracio vValoracioSeleccionada = null;

        public ValoracionsTab()
        {
            enModeEdicio = false;
            InitializeComponent();

            chart1.GetToolTipText += chart1_GetToolTipText;

            dgvValoracions.AutoGenerateColumns = false;

            cData.Value = DateTime.Today;

            dtpDataIniciLlista.Value = DateTime.Now.AddMonths(-6);

            gestioProductesTabValoracions.refrescaDadesControl();

        }


        #region *** ITabs ***

        public bool enModeEdicio { get; private set; }

        public bool activaRefresca { get; set; }

        public bool carregaDadesInicial { get; set; }

        public Button AcceptButton
        {
            get { return btActualitzaLlista; }
        }

        public void refresca(bool? refrescaActivat)
        {
            if (refrescaActivat.HasValue)
                activaRefresca = refrescaActivat.Value;

            carregaDadesInicial = false;

            if (activaRefresca)
            {
                activaRefresca = false;

                if (dgvValoracionsPerData.Rows.Count > 0)
                    actualitzaLlistaValoracionsTotal();

                gestioProductesTabValoracions.refrescaDadesControl();
            }
        }

        public void canviUsuari(Usuari usuari)
        {
            gestioProductesTabValoracions._UsuariSeleccionat = usuari;
            dgvValoracions.DataSource = null;
            activaRefresca = true;
            refresca(true);
        }

        public void escape(object sender, KeyEventArgs e)
        {
        }

        #endregion *** ITabs ***


        public DateTime _Data
        {
            get { return cData.Value; }
        }

        public double _Import
        {
            get { return tbImport._DoubleValue; }
        }

        private void modeEdicio()
        {
            btNouValor.Enabled = false;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;
            btCopiaValorsDelPaste.Enabled = false;
            btCancela.Enabled = true;
            btDesa.Enabled = true;
            dgvValoracions.Enabled = false;
            gestioProductesTabValoracions.Enabled = false;
            cData.Enabled = true;
            tbImport.Enabled = true;
            gbFiltreTipusProducte.Enabled = false;

            ParentForm.AcceptButton = btDesa;

            // Si utilitzo CancelButton, la tecla ESC no funciona bé en un NumericTextBox,
            ParentForm.CancelButton = btCancela;

            enModeEdicio = true;
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

            dgvValoracions.Enabled = true;

            enModeEdicio = false;

            ParentForm.AcceptButton = null;
            ParentForm.CancelButton = null;
        }

        private void posaValorsDeLaFilaSeleccionada()
        {
            if (!enModeEdicio)
            {
                cData.Value = vValoracioSeleccionada.Data;
                tbImport.Valor = vValoracioSeleccionada.PreuParticipacio;
            }
        }

        private void actualitzaLlistaValoracionsPerProducte()
        {
            var valoracionsProducte = Program.Sessio.Valoracions
                .Where(w => w.Prod.Id == gestioProductesTabValoracions._ProducteSeleccionat.Id && w.Data > dtpDataIniciLlista.Value)
                .OrderBy(o => o.Data).ToList();

            dgvValoracions.SuspendLayout();
            dgvValoracions.DataSource = valoracionsProducte;
            var xx = dgvValoracions.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (xx >= 0)
            {
                dgvValoracions.FirstDisplayedScrollingRowIndex = xx;
                ompleGrafica1(valoracionsProducte);
            }
            else
            {
                chart1.Visible = false;
            }
            dgvValoracions.ResumeLayout();
        }

        private void ompleGrafica1(List<Valoracio> valoracionsProducte)
        {
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.00";

            chart1.ChartAreas[0].AxisY.Minimum = valoracionsProducte.Min(m => m.PreuParticipacio) / 1.02;

            chart1.ChartAreas[0].AxisY.Maximum = valoracionsProducte.Max(m => m.PreuParticipacio) * 1.02;

            chart1.DataSource = valoracionsProducte;
            chart1.DataBind();
            chart1.Update();

            chart1.Visible = true;
        }

        private void actualitzaLlistaValoracionsTotal()
        {
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            dgvValoracionsPerData.Rows.Clear();
            chart2.Series[0].Points.Clear();

            // Per saber que està seleccionat
            var accions = checkedComboBoxEdit1.Properties.Items[TipusProd.Accions].CheckState == CheckState.Checked;
            var rf = checkedComboBoxEdit1.Properties.Items[TipusProd.RF].CheckState == CheckState.Checked;
            var rv = checkedComboBoxEdit1.Properties.Items[TipusProd.RV].CheckState == CheckState.Checked;

            if (!(accions || rf || rv))
                return;

            var valData = Program.Sessio.Valoracions.Where(w => w.Data >= dtpDataIniciLlista.Value).ToList();
            var movData = Program.Sessio.MovimentsUsuari.Where(w => w.Data >= dtpDataIniciLlista.Value).ToList();

            List<Valoracio> valoracions = new List<Valoracio>();
            List<Moviment> moviments = new List<Moviment>();

            if (accions)
            {
                valoracions.AddRange(valData.Where(w => w.Prod is ProdAccions).ToList());
                moviments.AddRange(movData.Where(w => w.Prod is ProdAccions && w.Participacions > 0).ToList());
            }

            if (rv && rf)
            {
                valoracions.AddRange(valData.Where(w => w.Prod is ProdFons).ToList());
                moviments.AddRange(movData.Where(w => w.Prod is ProdFons && w.Participacions > 0).ToList());
            }
            else
            {
                if (rv)
                {
                    valoracions.AddRange(valData.Where(w => w.Prod is ProdFons && ((ProdFons) w.Prod).Tipus == TipusFons.RV).ToList());
                    moviments.AddRange(movData.Where(w => w.Prod is ProdFons && w.Participacions > 0 && ((ProdFons) w.Prod).Tipus == TipusFons.RV).ToList());
                }

                if (rf)
                {
                    valoracions.AddRange(valData.Where(w => w.Prod is ProdFons && ((ProdFons) w.Prod).Tipus == TipusFons.RF).ToList());
                    moviments.AddRange(movData.Where(w => w.Prod is ProdFons && w.Participacions > 0 && ((ProdFons) w.Prod).Tipus == TipusFons.RF).ToList());
                }
            }

            var valMovs = valoracions.Select(s => new {Data = s.Data.Date, s.PreuParticipacio}).
                Union(moviments.Select(s => new {Data = s.Data.Date, s.PreuParticipacio})).
                GroupBy(g => g.Data).OrderBy(o => o.Key);

            if (!valMovs.Any())
                return;


            double maxVal = 0;
            double minVal = double.MaxValue;

            double pigPerDataAnt = 0;
            foreach (var valoracio in valMovs)
            {
                DateTime data = Utilitats.DataHoraFinalDia(valoracio.Key);

                double pigPerData = 0;
                double saldo = 0;
                if (accions)
                {
                    pigPerData += Producte.Pig2(Producte.TipusProducte.Accions, null, DateTime.MinValue, data, true, true);
                    saldo += ProdAccions.Valor(data);
                }
                if (rv)
                {
                    pigPerData += Producte.Pig2(Producte.TipusProducte.Fons, TipusFons.RV, DateTime.MinValue, data, true, true);
                    saldo += ProdFons.Valor(data, TipusFons.RV);
                }
                if (rf)
                {
                    pigPerData += Producte.Pig2(Producte.TipusProducte.Fons, TipusFons.RF, DateTime.MinValue, data, true, true);
                    saldo += ProdFons.Valor(data, TipusFons.RF);
                }

                dgvValoracionsPerData.Rows.Add(data, pigPerData, (pigPerData / pigPerDataAnt - 1), pigPerData - pigPerDataAnt, saldo);

                if (data >= new DateTime(2015, 3, 20) && pigPerData > 0)
                {
                    chart2.Series[0].Points.AddXY(data.ToOADate(), pigPerData);

                    if (maxVal < pigPerData)
                        maxVal = Math.Ceiling(pigPerData / 10) * 10;

                    if (minVal > pigPerData)
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
        }
        

        #region *** Events ***

        private void btNouValor_Click(object sender, EventArgs e)
        {
            vEsNouValor = true;

            tbImport.Valor = 0;

            modeEdicio();

            cData.Value = Utilitats.AnteriorDiaLaborable(DateTime.Today);
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
            vEsNouValor = false;

            if (MessageBox.Show(String.Format("S'esborrarà: {0}-{1}", vValoracioSeleccionada.Prod.Empresa.Nom, vValoracioSeleccionada.Data.ToShortDateString()), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = new InversionsBDContext())
                {
                    try
                    {
                        //Valoracio valToRemove = conn.Valoracions.Single(s => s.Id == vValoracioSeleccionada.Id);
                        Valoracio valToRemove = conn.Valoracions.Find(vValoracioSeleccionada.Id);
                        conn.Valoracions.Remove(valToRemove);
                        conn.SaveChanges();
                    }
                    catch (DbUpdateException ex2)
                    {
                        Comuns.Utilitats.EscriuLog(ex2, Program.FitxerLog, Program.Versio);
                        //MessageBox.Show(ex2.InnerException.InnerException.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
                    catch (Exception ex)
                    {
                        Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                        //MessageBox.Show(ex.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
                }

                Program.Sessio.refrescaTaula(typeof(Valoracio));
                actualitzaLlistaValoracionsPerProducte();
            }
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            posaValorsDeLaFilaSeleccionada();
            modeConsulta();
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            var cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (var conn = new InversionsBDContext())
                {
                    {
                        try
                        {
                            if (vEsNouValor)
                            {
                                Valoracio.Nova(conn, gestioProductesTabValoracions._ProducteSeleccionat, cData.Value, tbImport._DoubleValue);
                            }
                            else
                            {
                                vValoracioSeleccionada.modifica(conn, cData.Value, tbImport._DoubleValue);
                            }

                            conn.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            var xx = Utilitats.ExtreuInnerException(ex);

                            if (xx is System.Data.SqlClient.SqlException && ((System.Data.SqlClient.SqlException)xx).Number == 2627)
                                MessageBox.Show("Valoració ja existeix", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show(xx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (vValoracioSeleccionada != null)
                    Program.Sessio.Entry(vValoracioSeleccionada).Reload();

                gestioProductesTabValoracions.refrescaDadesControl();

                Principal.ActivaRefresca(this);

                modeConsulta();

                tbImport.Valor = 0;

                actualitzaLlistaValoracionsPerProducte();
            }
            finally
            {
                this.Cursor = cursor;
            }
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

        private void cDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvValoracions.CurrentRow == null)
            {
                vValoracioSeleccionada = null;
            }
            else if (vValoracioSeleccionada != (Valoracio)dgvValoracions.Rows[e.RowIndex].DataBoundItem)
            {
                vValoracioSeleccionada = (Valoracio)dgvValoracions.Rows[e.RowIndex].DataBoundItem;
                posaValorsDeLaFilaSeleccionada();
                btModifica.Enabled = true;
                btEsborra.Enabled = true;
            }
        }

        private void btCopiaValorsDelPaste_Click(object sender, EventArgs e)
        {
            PasteSelfBank pSelf = new PasteSelfBank();
            if (pSelf.ShowDialog(this) == DialogResult.OK)
            {
                Principal.ActivaRefresca(this);
            }
        }

        private void checkedComboBoxEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                actualitzaLlistaValoracionsTotal();
            }
        }


        private void btActualitzaLlista_Click(object sender, EventArgs e)
        {
            actualitzaLlistaValoracionsTotal();
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

        private void checkedComboBoxEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                // Per saber que està seleccionat
                var accions = checkedComboBoxEdit1.Properties.Items[TipusProd.Accions].CheckState == CheckState.Checked;
                var rf = checkedComboBoxEdit1.Properties.Items[TipusProd.RF].CheckState == CheckState.Checked;
                var rv = checkedComboBoxEdit1.Properties.Items[TipusProd.RV].CheckState == CheckState.Checked;

                // Posa el títol en el combo.
                if (accions && rf && rv)
                    e.DisplayText = "Tot";
                else if (!accions && rf && rv)
                    e.DisplayText = "Fons";
                else if (accions && !rf && !rv)
                    e.DisplayText = "Accions";
            }
        }

        private void tbImport_ValorChanged(object sender, EventArgs e)
        {
            ParentForm.CancelButton = tbImport.Modified ? null : btCancela;
        }

        private void tbImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tbImport.Modified)
                {
                    ParentForm.CancelButton = btCancela;
                }
            }
        }
        
        #endregion *** Events ***
    }
}