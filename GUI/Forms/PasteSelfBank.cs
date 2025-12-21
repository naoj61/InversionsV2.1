using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.ClassesEntity;

namespace Inversions.GUI
{
    public partial class PasteSelfBank : Form
    {
        private const string NomVarRegTancaAlDesar = "PasteSelfBankTancaAlDesar";
        private const int DiferenciaMaimaxPreu = 10;

        public PasteSelfBank()
        {
            InitializeComponent();

            int xx = Convert.ToInt32(Program.LlegeigVariableEnRegistreWindows("ColumnaPreuParticio", false));
            cbColumnaPreuParticio.SelectedIndex = Convert.ToInt32(Program.LlegeigVariableEnRegistreWindows("ColumnaPreuParticio", false));
            cbColumnaPreuParticio.SelectedIndexChanged += cbColumnaPreuParticio_SelectedIndexChanged;

            dtpDataUnica.Value = Utilitats.AnteriorDiaLaborable(DateTime.Today);

            bool pasteSelfBankTancaAlDesar = Convert.ToBoolean(Program.LlegeigVariableEnRegistreWindows(NomVarRegTancaAlDesar, true));
            ckTancaAlDesar.Checked = pasteSelfBankTancaAlDesar;
            ckTancaAlDesar.CheckedChanged += ckTancaAlDesar_CheckedChanged;


            tbPaste.Text = Clipboard.GetText();
            // tbPaste.Select(0, 0);
        }

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
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                bool avis = false;

                data = data ?? DateTime.Now;

                dataGridView1.Rows.Clear();

                string text1 = tbPaste.Text.Replace(Environment.NewLine, "\t");
                string[] items = text1.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);

                ProdAccions prod = null;
                int pos = items[0] == "Kraken" ? 1 : 4;

                for (int i = 0; i < items.Count(); i++)
                {
                    switch (items[i])
                    {
                        case "LUNA":
                            prod = ProdAccions.Tuples.Single(w => w.Empresa.Nom == "Terra Classic (LUNA)");
                            break;
                        case "UST":
                            prod = ProdAccions.Tuples.Single(w => w.Empresa.Nom == "TerraUSD Classic (UST)");
                            break;
                        case "LUNA2":
                            prod = ProdAccions.Tuples.Single(w => w.Empresa.Nom == "Terra 2.0 (LUNA2)");
                            break;
                    }

                    if (prod != null)
                    {
                        i += pos;

                        // *** Elimina el simbol de euro al inici ***
                        string valorStr = Char.IsNumber(items[i][0]) ? items[i] : items[i].Substring(1);

                        // Si pos = 1 -> valor = Preu moneda. Si pos = 4 -> valor = Valor inversió.
                        decimal valor = Convert.ToDecimal(valorStr, CultureInfo.InvariantCulture);

                        if (items[0] == "Kraken")
                            // *** Paste a partir de la pantalla de preus, sense fer login.
                            // 'valor' és el preu de la moneda.
                            creaValoracio(data.GetValueOrDefault(DateTime.Now), prod, valor, ref avis);
                        else
                            // Per obtenir més precisió en el valor de la criptomoneda(Kraken no la dona) divideixo valor de la inversió actual per numparts.
                            // 'valor' és el valor de la inversió.
                            creaValoracio(data.GetValueOrDefault(DateTime.Now), prod, valor / prod._Participacions, ref avis);

                        prod = null;
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


        private void capturaValorsPasteSelfBank(DateTime? data = null)
        {
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                dataGridView1.Rows.Clear();

                string text1 = tbPaste.Text.Replace(Environment.NewLine, "\t");
                string[] items = text1.Split(new[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);
                ProdFons prod = null;
                int? posPreuPart = null;
                int? pos = null;
                bool avis = false;

                for (int index = 0; index < items.Length; index++)
                {
                    string item = items[index];

                    if (item.Equals("FONDOS NACIONALES", StringComparison.OrdinalIgnoreCase)
                        || item.Equals("FONDOS INTERNACIONALES", StringComparison.OrdinalIgnoreCase))
                    {
                        pos = 0;
                        posPreuPart = null;

                        for (; index < items.Length; index++)
                        {
                            if (items[index].Equals("Precio actual", StringComparison.OrdinalIgnoreCase))
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
                            prod = ProdFons.Tuples.SingleOrDefault(w => w.ISIN == item);
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
        ///     Crea les valoracions capturades del paste.
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

            DateTime dataVal = data.Value.Date;

            bool existeisValoracio = Valoracio.Tuples.SingleOrDefault(w => w.Prod.Id == prod.Id && w.Data == dataVal) != null;
            decimal difPercent = (preuPart / prod._PreuParticipacioActual - 1);
            decimal difValor = ((preuPart - prod._PreuParticipacioActual) * prod._Participacions);

            int numFila = dataGridView1.Rows.Add(new object[]
            {
                !existeisValoracio, prod, !existeisValoracio, dataVal
                , prod._PreuParticipacioActual, preuPart, difPercent, difValor
            });

            if (existeisValoracio)
                dataGridView1.Rows[numFila].Cells[colData.Name].Style.ForeColor = Color.Blue;

            if (difPercent < 0)
            {
                dataGridView1.Rows[numFila].Cells[colPercentatge.Name].Style.ForeColor = Color.Red;
                dataGridView1.Rows[numFila].Cells[colDif.Name].Style.ForeColor = Color.Red;
            }

            if (Math.Abs(difPercent) >= DiferenciaMaimaxPreu / 100M)
            {
                // Diferència superior al 10% en el preu.
                dataGridView1.Rows[numFila].Cells[colEstatOriginalCheckBox.Name].Value = false;
                dataGridView1.Rows[numFila].Cells[colSeleccionat.Name].Value = false;
                dataGridView1.Rows[numFila].Cells[colValorActual.Name].Style.ForeColor = Color.DarkOrange;
                dataGridView1.Rows[numFila].Cells[colValorNou.Name].Style.ForeColor = Color.DarkOrange;

                avis = true;
            }
        }


        private void btDesa_Click(object sender, EventArgs e)
        {
            using (var connexio = new InversionsBDContext())
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!(bool) (row.Cells[colSeleccionat.Name]).Value)
                            continue;

                        var producte = (Producte) row.Cells[colNomFons.Name].Value;
                        DateTime data = ckDataUnica.Checked ? dtpDataUnica.Value : (DateTime) row.Cells[colData.Name].Value;
                        var preuPart = (decimal) row.Cells[colValorNou.Name].Value;

                        Valoracio val = connexio.Valoracions.SingleOrDefault(w => w.ProdId == producte.Id && w.Data == data);
                        if (val == null)
                        {
                            // Només noves valoracions. No modifica
                            val = connexio.Valoracions.Create();
                            val.ProdId = producte.Id;
                            val.Data = data;

                            connexio.Valoracions.Add(val);
                        }

                        val.PreuParticipacio = preuPart;
                    }

                    connexio.SaveChanges();

                    Valoracio.RefrescaTaula();

                    btDesa.Enabled = false;

                    if (ckTancaAlDesar.Checked ||
                        MessageBox.Show("Fet!" + Environment.NewLine + "Vols tancar la finestra?", "Fet",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
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


        private void cbColumnaPreuParticio_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.DesaVariableEnRegistreWindows("ColumnaPreuParticio", cbColumnaPreuParticio.SelectedIndex.ToString(), false);
            capturaValorsPaste();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSeleccionat.Index)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && e.ColumnIndex == colSeleccionat.Index)
            {
                var estatOriginalCheckBox = (bool) dataGridView1.Rows[e.RowIndex].Cells[colEstatOriginalCheckBox.Name].Value;
                //var valorActualCheckBox = (bool)dataGridView1.CurrentCell.Value;
                var valorActualCheckBox = (bool) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

        private void btCapturaValorPaste_Click(object sender, EventArgs e)
        {
            capturaValorsPaste();
        }
    }
}