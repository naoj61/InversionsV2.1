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
using DevExpress.Utils;
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

        private void capturaValorsPaste(DateTime? data = null)
        {
            if (String.IsNullOrEmpty(tbPaste.Text))
                return;

            if (tbPaste.Text.IndexOf("Self Bank", StringComparison.OrdinalIgnoreCase) >= 0)
                capturaValorsPasteSelfBank(data);

            if (tbPaste.Text.IndexOf("Kraken", StringComparison.OrdinalIgnoreCase) >= 0)
                capturaValorsPasteKraken(data);
        }

        private void capturaValorsPasteKraken(DateTime? data = null)
        {
            var cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                dataGridView1.Rows.Clear();

                var text1 = tbPaste.Text.Replace(Environment.NewLine, "\t");
                var items = text1.Split(new char[] {'\t',}, StringSplitOptions.RemoveEmptyEntries);
                ProdAccions prod = null;
                //int posPreuPart = cbColumnaPreuParticio.SelectedIndex == 0 ? 4 : cbColumnaPreuParticio.SelectedIndex;
                int posPreuPart = 4;

                bool avis = false;


                // *** Format nou de Kraken ***

                data = null;

                bool vTerraClassic = false, vTerraUsd = false, vTerra2 = false;
                int contPos = 0;

                for (int i = 0; i < items.Count(); i++)
                {
                    try
                    {
                        // En el web de Kraken no apareix la data, agafo l'última data que apareix en la gràfica del web.
                        data = DateTime.Parse(items[i]);
                    }
                    catch (Exception)
                    {
                    }

                    if (items[i] == "Terra Classic")
                    {
                        vTerraClassic = true;
                    }
                    else if (items[i] == "TerraUSD Classic")
                    {
                        vTerraUsd = true;
                    }
                    else if (items[i] == "Terra 2.0")
                    {
                        vTerra2 = true;
                    }

                    if (vTerraClassic || vTerraUsd || vTerra2)
                        contPos++;

                    if (contPos == 3)
                    {
                        if (vTerraClassic)
                        {
                            prod = Program.Sessio.ProdAccions.Single(w => w.Empresa.Nom == "Terra Classic (LUNA)");

                            vTerraClassic = false;
                        }
                        else if (vTerraUsd)
                        {
                            prod = Program.Sessio.ProdAccions.Single(w => w.Empresa.Nom == "TerraUSD Classic (UST)");

                            vTerraUsd = false;
                        }
                        else if (vTerra2)
                        {
                            prod = Program.Sessio.ProdAccions.Single(w => w.Empresa.Nom == "Terra 2.0 (LUNA2)");

                            vTerra2 = false;
                        }

                        // *** Elimina el simbol de moneda al inici ***
                        string valor = Char.IsNumber(items[i][0]) ? items[i] : items[i].Substring(1);

                        decimal preuPart = Convert.ToDecimal(valor, CultureInfo.InvariantCulture);
                        creaValoracio(data, prod, preuPart, ref avis);

                        contPos = 0;
                    }
                }


                #region *** Format antic de Kraken ***

                if (dataGridView1.Rows.Count == 0)
                {

                    for (int i = 0; i < items.Count(); i++)
                    {
                        if (!data.HasValue && items[i].IndexOf("Current time:", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            string sData = items[i].Substring(14, 17);
                            try
                            {
                                data = Convert.ToDateTime(sData, CultureInfo.InvariantCulture);
                            }
                            catch (FormatException)
                            {
                                data = Convert.ToDateTime(sData, CultureInfo.CurrentCulture);
                            }
                            var difDiesDataActualIDataPaste = ((TimeSpan) (data - DateTime.Now)).Days;

                            if (Math.Abs(difDiesDataActualIDataPaste) > 7)
                            {
                                if (MessageBox.Show(String.Format("Diferència de dies {0} en la data {1} és massa gran. És correcte?"
                                    , difDiesDataActualIDataPaste, data.Value.ToShortDateString()), "Atenció", MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            }
                        }
                        else
                        {
                            var nom = items[i];
                            prod = Program.Sessio.ProdAccions.SingleOrDefault(w => w.Empresa.Nom == nom);
                            if (prod != null)
                            {
                                i += posPreuPart;
                                decimal preuPart = Convert.ToDecimal(items[i], CultureInfo.InvariantCulture);

                                creaValoracio(data, prod, preuPart, ref avis);
                            }
                        }
                    }
                }

                #endregion


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


        private void capturaValorsPasteSelfBank(DateTime? data = null)
        {
            var cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                dataGridView1.Rows.Clear();

                var text1 = tbPaste.Text.Replace(Environment.NewLine, "\t");
                var items = text1.Split(new char[] {'\t',}, StringSplitOptions.RemoveEmptyEntries);
                ProdFons prod = null;
                int? posPreuPart = null;
                int? pos = null;
                bool avis = false;

                for (int index = 0; index < items.Length; index++)
                {
                    var item = items[index];

                    if (item == "FONDOS NACIONALES" || item == "FONDOS INTERNACIONALES")
                    {
                        pos = 0;
                        posPreuPart = null;

                        for (; index < items.Length; index++)
                        {
                            if (items[index] == "Precio actual")
                            {
                                posPreuPart = pos;
                                pos = null;
                                break;
                            }
                            pos++;
                        }

                        continue;
                    }

                    if (posPreuPart.HasValue)
                    {
                        if (!pos.HasValue)
                        {
                            prod = Program.Sessio.ProdFons.SingleOrDefault(w => w.ISIN == item);
                            if (prod != null)
                                pos = 2;
                            continue;
                        }

                        if (pos == posPreuPart.Value)
                        {
                            decimal preuPart = Convert.ToDecimal(item.Replace("€", ""), CultureInfo.CurrentCulture);

                            item = items[++index];

                            DateTime dataPreuPart = Convert.ToDateTime(item.Substring(1, item.Length - 2));

                            if (preuPart > 0)
                            {
                                DateTime datax = data.GetValueOrDefault(dataPreuPart);

                                creaValoracio(datax, prod, preuPart, ref avis);
                            }
                            pos = null;
                            continue;
                        }
                        pos++;
                    }
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


        /// <summary>
        /// Crea les valoracions capturades del paste.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="prod"></param>
        /// <param name="preuPart"></param>
        /// <param name="avis"></param>
        /// <returns></returns>
        private void creaValoracio(DateTime? data, Producte prod, decimal preuPart, ref bool avis)
        {
            if (!data.HasValue)
                throw new Exception("Falta la data");

            var dataVal = data.Value.Date;

            var existeisValoracio = Program.Sessio.Valoracio.SingleOrDefault(w => w.Prod.Id == prod.Id && w.Data == dataVal) != null;
            var difPercent = (preuPart / prod._PreuParticipacioActual - 1);
            var difValor = ((preuPart - prod._PreuParticipacioActual) * prod._Participacions);

            int numFila = dataGridView1.Rows.Add(new object[] { !existeisValoracio, prod, !existeisValoracio, dataVal
                                , prod._PreuParticipacioActual, preuPart, difPercent, difValor });

            if (existeisValoracio)
                dataGridView1.Rows[numFila].Cells[colData.Name].Style.ForeColor = Color.Blue;

            if (difPercent < 0)
            {
                dataGridView1.Rows[numFila].Cells[colPercentatge.Name].Style.ForeColor = Color.Red;
                dataGridView1.Rows[numFila].Cells[colDif.Name].Style.ForeColor = Color.Red;
            }

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

                        var producte = (Producte) row.Cells[colNomFons.Name].Value;
                        DateTime data = ckDataUnica.Checked ? dtpDataUnica.Value : (DateTime) row.Cells[colData.Name].Value;
                        var preuPart = (decimal) row.Cells[colValorNou.Name].Value;

                        var val = connexio.Valoracions.SingleOrDefault(w => w.ProdId == producte.Id && w.Data == data);
                        if (val == null)
                        {
                            // Només noves valoracions. No modifica
                            val = connexio.Valoracions.Create();
                            val.ProdId = producte.Id;
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
                //var valorActualCheckBox = (bool)dataGridView1.CurrentCell.Value;
                var valorActualCheckBox = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!estatOriginalCheckBox && valorActualCheckBox && !ckSobreescriuValoracions.Checked)
                {
                    if (MessageBox.Show("Marco per sobreescriure valoracions?", "La valoració ja existeix", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ckSobreescriuValoracions.Checked = true;
                }
            }
        }

        private void ckDataUnica_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataUnica.Enabled = ckDataUnica.Checked;
        }

        private void dtpDataUnica_ValueChanged(object sender, EventArgs e)
        {
            validaDataUnica();
        }

        private void validaDataUnica()
        {

            // Comprovar si s'han de sobreescriure valors per la data.
            capturaValorsPaste(ckDataUnica.Checked ? dtpDataUnica.Value : (DateTime?) null);
        }
    }
}
