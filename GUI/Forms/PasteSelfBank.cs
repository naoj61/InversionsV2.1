using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Comuns;
using Microsoft.Win32;

namespace Inversions.GUI
{
    public partial class PasteSelfBank : Form
    {
        public PasteSelfBank()
        {
            InitializeComponent();

            var xx = Convert.ToInt32(Program.LlegeigVariableEnRegistreWindows("ColumnaPreuParticio", false));
            cbColumnaPreuParticio.SelectedIndex = Convert.ToInt32(Program.LlegeigVariableEnRegistreWindows("ColumnaPreuParticio", false));
            cbColumnaPreuParticio.SelectedIndexChanged += cbColumnaPreuParticio_SelectedIndexChanged;

            dtpDataUnica.Value = Utilitats.AnteriorDiaLaborable(DateTime.Today);

            bool pasteSelfBankTancaAlDesar = Convert.ToBoolean(Program.LlegeigVariableEnRegistreWindows(NomVarRegTancaAlDesar, true));
            ckTancaAlDesar.Checked = pasteSelfBankTancaAlDesar;
            ckTancaAlDesar.CheckedChanged += ckTancaAlDesar_CheckedChanged;

            bool pasteSelfBankCapturaAutomaticament = Convert.ToBoolean(Program.LlegeigVariableEnRegistreWindows(NomVarRegCapturaAutomaticament, true));
            ckCapturaAutomaticament.Checked = pasteSelfBankCapturaAutomaticament;
            ckCapturaAutomaticament_CheckedChanged(ckCapturaAutomaticament, new EventArgs());
        }

        private const string NomVarRegTancaAlDesar = "PasteSelfBankTancaAlDesar";
        private const string NomVarRegCapturaAutomaticament = "PasteSelfBankCapturaAutomaticament";
        private const int DiferenciaMaimaxPreu = 10;

        private void capturaValorsPaste()
        {
            var cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                dataGridView1.Rows.Clear();

                var text1 = textBox1.Text.Replace(Environment.NewLine, "\t");
                var items = text1.Split(new char[] {'\t',}, StringSplitOptions.RemoveEmptyEntries);
                ProdFons prod = null;
                int posPreuPart = cbColumnaPreuParticio.SelectedIndex + 1;
                int posDataPreuPart = posPreuPart + 1;
                int conta = 0;
                bool avis = false;
                double preuPart = 0;
                foreach (var item in items)
                {
                    if (conta == 0)
                    {
                        prod = Program.Sessio.ProdFons.SingleOrDefault(w => w.ISIN == item);
                        if (prod != null)
                            conta++;
                        continue;
                    }
                    if (conta == posPreuPart)
                    {
                        preuPart = Convert.ToDouble(item.Replace("€", ""));

                        conta++;
                        continue;
                    }
                    if (conta == posDataPreuPart)
                    {
                        DateTime dataPreuPart = Convert.ToDateTime(item.Substring(1, item.Length - 2));

                        if (preuPart > 0)
                        {
                            var existeisValoracio = Program.Sessio.Valoracio.SingleOrDefault(w => w.Prod.Id == prod.Id && w.Data == dataPreuPart) != null;
                            var difPercent = (preuPart / prod._PreuParticipacioActual - 1) * 100;

                            int numFila = dataGridView1.Rows.Add(new object[] { !existeisValoracio, prod, !existeisValoracio, dataPreuPart
                                , prod._PreuParticipacioActual, preuPart, difPercent });

                            if (existeisValoracio)
                                dataGridView1.Rows[numFila].Cells[colData.Name].Style.ForeColor = Color.Blue;

                            if (difPercent < 0)
                                dataGridView1.Rows[numFila].Cells[colPercentatge.Name].Style.ForeColor = Color.Red;

                            if (Math.Abs(difPercent) >= DiferenciaMaimaxPreu)
                            {
                                // Diferència superior al 10% en el preu.
                                dataGridView1.Rows[numFila].Cells[colEstatOriginalCheckBox.Name].Value = false;
                                dataGridView1.Rows[numFila].Cells[colSeleccionat.Name].Value = false;
                                dataGridView1.Rows[numFila].Cells[colValorActual.Name].Style.ForeColor = Color.DarkOrange;
                                dataGridView1.Rows[numFila].Cells[colValorNou.Name].Style.ForeColor = Color.DarkOrange;

                                avis = true;
                            }
                        }
                        conta = 0;
                        continue;
                    }
                    conta++;
                }

                btDesa.Enabled = dataGridView1.Rows.Count > 0;

                if (avis && dataGridView1.Rows.Count > 0)
                    MessageBox.Show(String.Format("Diferència superior al {0}%. Comprova els valors", DiferenciaMaimaxPreu));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. Alguna cosa no quadra.\n" + ex.Message);
            }
            finally
            {
                Cursor = cursor;
            }
        }

        private void btCapturaValors_Click(object sender, EventArgs e)
        {
            capturaValorsPaste();
        }


        private void btDesa_Click(object sender, EventArgs e)
        {
            using (var connexio = new InversionsBDContext())
            {
                try
                {
                    bool hiHaUpdate = false;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!(bool) (row.Cells[colSeleccionat.Name]).Value)
                            continue;

                        var prodFons = (ProdFons) row.Cells[colNomFons.Name].Value;
                        DateTime data = ckDataUnica.Checked ? dtpDataUnica.Value : (DateTime) row.Cells[colData.Name].Value;
                        var preuPart = (double) row.Cells[colValorNou.Name].Value;

                        var val = connexio.Valoracions.SingleOrDefault(w => w.ProdId == prodFons.Id && w.Data == data);
                        if (val == null)
                        {
                            // Només noves valoracions. No modifica
                            val = connexio.Valoracions.Create();
                            val.ProdId = prodFons.Id;
                            val.Data = data;

                            connexio.Valoracions.Add(val);
                        }
                        else if (ckSobreescriuValoracions.Checked)
                        {
                            hiHaUpdate = true;
                        }

                        val.PreuParticipacio = preuPart;
                    }

                    connexio.SaveChanges();

                    if (hiHaUpdate)
                        Program.Sessio.refrescaTaula(typeof (Valoracio));

                    btDesa.Enabled = false;

                    if (ckTancaAlDesar.Checked ||
                        MessageBox.Show("Fet!" + Environment.NewLine + "Vols tancar la finestra?", "Fet",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                }
            }
        }

        private void ckTancaAlDesar_CheckedChanged(object sender, EventArgs e)
        {
            Program.DesaVariableEnRegistreWindows(NomVarRegTancaAlDesar, ckTancaAlDesar.Checked.ToString(), true);
        }

        private void ckCapturaAutomaticament_CheckedChanged(object sender, EventArgs e)
        {
            Program.DesaVariableEnRegistreWindows(NomVarRegCapturaAutomaticament, ckCapturaAutomaticament.Checked.ToString(), true);
            btCapturaValors.Enabled = !ckCapturaAutomaticament.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ckCapturaAutomaticament.Checked)
                capturaValorsPaste();
        }

        private void cbColumnaPreuParticio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.DesaVariableEnRegistreWindows("ColumnaPreuParticio", cbColumnaPreuParticio.SelectedIndex.ToString(), false);
            capturaValorsPaste();
        }

        private void ckDataUnica_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataUnica.Enabled = ckDataUnica.Checked;
            colData.Visible = !ckDataUnica.Checked;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == colSeleccionat.Index)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && e.ColumnIndex == colSeleccionat.Index)
            {
                var estatOriginalCheckBox = (bool)dataGridView1.Rows[e.RowIndex].Cells[colEstatOriginalCheckBox.Name].Value;
                var valorActualCheckBox = (bool) dataGridView1.CurrentCell.Value;
                if (!estatOriginalCheckBox && valorActualCheckBox && !ckSobreescriuValoracions.Checked)
                {
                    if (MessageBox.Show("Marco per sobreescriure valoracions?", "La valoració ja existeix", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ckSobreescriuValoracions.Checked = true;
                }
            }
        }
    }
}
