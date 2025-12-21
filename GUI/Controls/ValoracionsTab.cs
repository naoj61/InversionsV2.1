using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;
using DevExpress.XtraEditors.Controls;
using Inversions.ClassesEntity;
using Cursor = System.Windows.Forms.Cursor;

namespace Inversions.GUI
{
    public partial class ValoracionsTab : TabX
    {
        #region *** Structs per DataGridViews ***

        /// <summary>
        ///     Estructura per omplir DgvCompresProducte
        /// </summary>
        private struct StrDgvValoracions
        {
            private StrDgvValoracions(Valoracio valoracioAnterior, Valoracio valoracio)
                : this()
            {
                decimal partsEnCartera = valoracio.Prod.partsEnCartera(Utilitats.PosoHora(valoracio.Data));

                _Valoracio = valoracio;
                _Id = valoracio.Id;
                _Prod = valoracio.Prod;
                _Data = valoracio.Data;
                _NumParticipacions = partsEnCartera;
                _PreuParticipacio = valoracio.PreuParticipacio;
                _ValoracioTotal = valoracio.PreuParticipacio * partsEnCartera;
                if (valoracioAnterior == null || valoracioAnterior.PreuParticipacio == 0)
                {
                    _VariacioEuros = 0;
                    _VariacioPercentatge = 0;
                }
                else
                {
                    _VariacioPercentatge = valoracio.PreuParticipacio / valoracioAnterior.PreuParticipacio - 1;

                    decimal partsEnCarteraAnt = valoracioAnterior.Prod.partsEnCartera(Utilitats.PosoHora(valoracioAnterior.Data));
                    if (partsEnCarteraAnt < partsEnCartera)
                    {
                        // Hi ha hagut una compra, calculo només amb les parts anteriors.
                        _VariacioEuros = (valoracio.PreuParticipacio - valoracioAnterior.PreuParticipacio) * partsEnCarteraAnt;
                    }
                    else
                    {
                        // Si no hi ha hagut moviment o ha sigut una venda, calculo amb les parts actuals.
                        _VariacioEuros = (valoracio.PreuParticipacio - valoracioAnterior.PreuParticipacio) * partsEnCartera;
                    }
                }
            }


            internal Valoracio _Valoracio { get; private set; }

            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable MemberCanBePrivate.Local

            public int _Id { get; private set; }

            public Producte _Prod { get; private set; }

            public DateTime _Data { get; private set; }

            public decimal _NumParticipacions { get; private set; }

            public decimal _PreuParticipacio { get; private set; }

            public decimal _ValoracioTotal { get; private set; }

            public decimal _VariacioPercentatge { get; private set; }

            public decimal _VariacioEuros { get; private set; }

            internal static List<StrDgvValoracions> CarregaStruct(List<Valoracio> valoracions)
            {
                var llista = new List<StrDgvValoracions>();

                if (valoracions == null || !valoracions.Any())
                    return llista;

                Valoracio valAnt = valoracions.First().trobaValoracioAnterior(true);

                foreach (Valoracio valoracio in valoracions)
                {
                    llista.Add(new StrDgvValoracions(valAnt, valoracio));
                    valAnt = valoracio;
                }

                return llista;
            }

            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        /// <summary>
        ///     Estructura per omplir DgvCompresProducte
        /// </summary>
        private struct StrDgvValoracionsPerData
        {
            private StrDgvValoracionsPerData(DateTime data, decimal pig, decimal variacioPercentatge, decimal variacioImport, decimal valorTotal)
                : this()
            {
                _Data = data;
                _Pig = pig;
                _ValorTotal = valorTotal;
                _VariacioPercentatge = variacioPercentatge;
                _VariacioImport = variacioImport;
            }


            public DateTime _Data { get; private set; }

            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable MemberCanBePrivate.Local
            public decimal _Pig { get; private set; }

            public decimal _VariacioPercentatge { get; set; }

            public decimal _VariacioImport { get; private set; }

            public decimal _ValorTotal { get; private set; }

            internal static IEnumerable<StrDgvValoracionsPerData> CarregaStruct(DateTime dataH, byte valor, Chart chart)
            {
                var llista = new List<StrDgvValoracionsPerData>();

                // Per saber que està seleccionat
                bool accions = (valor & (1 << 0)) != 0;
                bool criptos = (valor & (1 << 1)) != 0;
                bool rf = (valor & (1 << 2)) != 0;
                bool rv = (valor & (1 << 3)) != 0;

                var prods = new List<Producte>();

                if (criptos)
                    prods.AddRange(ProdAccions.Tuples.Where(w => w.Mercat.Id == 4));
                if (accions)
                    prods.AddRange(ProdAccions.Tuples.Where(w => w.Mercat.Id != 4));
                if (rf)
                    prods.AddRange(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RF));
                if (rv)
                    prods.AddRange(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RV));


                List<Valoracio> valoracions = Valoracio.Tuples.ToList().Where(w => prods.Contains(w.Prod)).ToList();
                DateTime dataAnt = valoracions.Where(w => w.Data.Date < dataH.Date).Max(m => m.Data).Date.AddDays(1).AddTicks(-1);
                valoracions = valoracions.Where(w => w.Data.Date >= dataH.Date).ToList();

                List<Moviment> moviments = Moviment.MovimentsUsuari.ToList().Where(w => w.Data >= dataH && prods.Contains(w.Prod)).ToList();

                List<DateTime> dates = valoracions.Select(valoracio => valoracio.Data.Date).ToList();
                dates = dates.Distinct().OrderBy(o => o).ToList();

                decimal valorTotalAnt = prods.Sum(s => s.valorEnCartera(dataAnt));

                chart.Series[0].Points.Clear();

                decimal maxVal = 0;
                decimal minVal = decimal.MaxValue;

                foreach (DateTime data in dates)
                {
                    DateTime dataFinalDia = data.Date.AddDays(1).AddTicks(-1);

                    List<Producte> prods2 = prods.Where(w => w.partsEnCartera(dataFinalDia) > 0).ToList();

                    decimal pig = prods2.Sum(prod => prod.pigEnCartera4(true, true, dataFinalDia));
                    decimal valorTotal = prods2.Sum(s => s.valorEnCartera(dataFinalDia));
                    decimal variacioImport = valorTotalAnt == 0 ? 0 : (valorTotal - valorTotalAnt);
                    decimal variacioPercentatge = valorTotalAnt == 0 ? 0 : (valorTotal / valorTotalAnt - 1);

                    if (moviments.Any(w => w.Data.Date == data.Date) && valorTotalAnt != 0)
                    {
                        List<Moviment> movsData = moviments.Where(w => w.Data.Date == data.Date).ToList();

                        decimal impVendes = movsData.Where(w => w._EsVenda).Sum(s => s._ImportBrut);
                        decimal impCompres = movsData.Where(w => w._EsCompra).Sum(s => s._ImportBrut);

                        // Si hi ha hagut moviments en el dia, recalculo la variació del import.
                        variacioImport += impVendes - impCompres;
                        variacioPercentatge = variacioImport / valorTotalAnt;
                    }

                    //if (data >= new DateTime(2015, 3, 20) && pig > 0)
                    if (data >= dataH && pig != 0)
                    {
                        chart.Series[0].Points.AddXY(data.ToOADate(), pig);

                        if (maxVal < pig)
                            maxVal = Math.Ceiling(pig / 10) * 10;

                        if (minVal > pig)
                            minVal = Math.Floor(pig / 10) * 10;
                    }

                    llista.Add(new StrDgvValoracionsPerData(data, pig, variacioPercentatge, variacioImport, valorTotal));

                    valorTotalAnt = valorTotal;
                }

                if (chart.Series[0].Points.Count > 1)
                {
                    chart.ChartAreas[0].AxisY.Minimum = (double) minVal;
                    chart.ChartAreas[0].AxisY.Maximum = (double) maxVal;
                    chart.Update();
                }

                return llista;
            }

            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        #endregion

        private bool vEsNouValor;

        private Valoracio vValoracioSeleccionada;

        public ValoracionsTab()
        {
            InitializeComponent();

            chProd.GetToolTipText += chart1_GetToolTipText;

            dgvValoracions.AutoGenerateColumns = false;

            chProd.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0.00";
            chProd.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            chTotals.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        }


        internal override void carregaInicial()
        {
            base.carregaInicial();

            cData.Value = DateTime.Today.AddDays(-1);

            dtpDataIniciLlista.Value = DateTime.Now.AddMonths(-6);
            dtpDataIniciValoracions.Value = DateTime.Now.AddMonths(-6);

            //gestioProductesTabValoracions.refrescaDadesControl(true);
            gestioProductesTabValoracions.refrescaDadesControl(null);

            actualitzaPercentatges();
        }

        internal override void refresca()
        {
            base.refresca();

            if (dgvValoracionsPerData.Rows.Count > 0)
                actualitzaLlistaValoracionsTotal();

            //gestioProductesTabValoracions.refrescaDadesControl(_PendentCanviUsuari);
            gestioProductesTabValoracions.refrescaDadesControl();

            actualitzaPercentatges();

            modeConsulta();
        }

        internal override void obrePestanya(Producte prod)
        {
            gestioProductesTabValoracions.refrescaDadesControl(prod);
        }


        internal override void canviUsuari()
        {
            dgvValoracionsPerData.Rows.Clear();
            dgvValoracions.DataSource = null;
            pnEdicio.Visible = false;

            refresca();

            base.canviUsuari();
        }

        protected override void modeEdicio()
        {
            base.modeEdicio();

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

            acceptButton(btDesa);
            cancelButton(btCancela);
        }

        protected override void modeConsulta()
        {
            base.modeConsulta();

            btNouValor.Enabled = gestioProductesTabValoracions.productesSeleccionats().Any();
            btModifica.Enabled = dgvValoracions.SelectedCells.Count > 0;
            btEsborra.Enabled = dgvValoracions.SelectedCells.Count > 0;
            btCopiaValorsDelPaste.Enabled = true;
            btCancela.Enabled = false;
            btDesa.Enabled = false;
            dgvValoracions.Enabled = true;
            gestioProductesTabValoracions.Enabled = true;
            cData.Enabled = false;
            tbImport.Enabled = false;
            gbFiltreTipusProducte.Enabled = true;

            acceptButton(null);
            cancelButton(null);
        }

        private void posaValorsDeLaFilaSeleccionada()
        {
            if (vValoracioSeleccionada == null)
            {
                tbImport.Valor = 0;
            }
            else
            {
                cData.Value = vValoracioSeleccionada.Data;
                tbImport.Valor = vValoracioSeleccionada.PreuParticipacio;
            }
        }

        private void actualitzaLlistaValoracionsPerProducte()
        {
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                if (gestioProductesTabValoracions != null)
                {
                    var valoracionsProducteSelec = new List<Valoracio>();

                    if (gestioProductesTabValoracions._ProducteSeleccionat != null
                        && gestioProductesTabValoracions._ProducteSeleccionat.ValoracionsProducte != null)
                    {
                        valoracionsProducteSelec = gestioProductesTabValoracions._ProducteSeleccionat.ValoracionsProducte
                            .Where(val => val.Data >= dtpDataIniciValoracions.Value).ToList();
                    }

                    if (ckValsAmbParticipacions.Checked)
                        // * Elimina valoracions sense participacions o amb preu participacio = 0.
                        valoracionsProducteSelec = valoracionsProducteSelec.Where(val => val._NumParticipacions > 0 && val.PreuParticipacio > 0).ToList();

                    valoracionsProducteSelec = valoracionsProducteSelec.OrderBy(val => val.Data).ToList();

                    List<StrDgvValoracions> valoracionsProducteSelec2 = StrDgvValoracions.CarregaStruct(valoracionsProducteSelec);

                    dgvValoracions.SuspendLayout();

                    dgvValoracions.DataSource = valoracionsProducteSelec2;

                    // * Ajusta l'amplada de la taula.
                    Utilitats.AjustaAmpladaDataGridView(dgvValoracions);

                    int ultimaFila = dgvValoracions.Rows.GetLastRow(DataGridViewElementStates.Visible);
                    if (ultimaFila >= 0)
                    {
                        dgvValoracions.FirstDisplayedScrollingRowIndex = ultimaFila;
                    }

                    actualitzaPercentatges();

                    ompleGrafica1(valoracionsProducteSelec);
                }

                dgvValoracions.ResumeLayout();
            }
            finally
            {
                Cursor = cursor;
            }
        }

        /// <summary>
        ///     Assigna l'atribut Visible a tots els controls dins de TableLayoutPanel.
        /// </summary>
        /// <param name="indexColumn"></param>
        /// <param name="visible"></param>
        private void columnaVisible(int indexColumn, bool visible)
        {
            foreach (Control control in tlpPercents.Controls)
            {
                if (tlpPercents.GetColumn(control) == indexColumn)
                {
                    // * Canvia Visible de tots els controls dins de TableLayoutPanel
                    control.Visible = visible;
                }
            }
        }

        private void actualitzaPercentatges()
        {
            if (gestioProductesTabValoracions._ProducteSeleccionat == null)
            {
                columnaVisible(0, false);
                columnaVisible(1, false);
                columnaVisible(2, false);
                columnaVisible(3, false);
                columnaVisible(4, false);
                columnaVisible(5, false);

                return;
            }

            var dataIniciAny = new DateTime(DateTime.Today.Year, 1, 1);

            List<Valoracio> valoracionsProdSel = Valoracio.Tuples.Where(w => w.ProdId == gestioProductesTabValoracions._ProducteSeleccionat.Id)
                .OrderBy(o => o.Data).ToList();

            if (!valoracionsProdSel.Any())
                return;

            Valoracio valActual = valoracionsProdSel.Last();
            Valoracio val1M = valoracionsProdSel.FirstOrDefault(w => w.Data >= DateTime.Today.AddMonths(-1).AddDays(-1));
            Valoracio val3M = valoracionsProdSel.FirstOrDefault(w => w.Data >= DateTime.Today.AddMonths(-3).AddDays(-1));
            Valoracio val6M = valoracionsProdSel.FirstOrDefault(w => w.Data >= DateTime.Today.AddMonths(-6).AddDays(-1));
            Valoracio val1A = valoracionsProdSel.FirstOrDefault(w => w.Data >= DateTime.Today.AddMonths(-12).AddDays(-1));
            Valoracio valAny = valoracionsProdSel.FirstOrDefault(w => w.Data >= dataIniciAny);

            decimal percent;

            if (val1M == null || (valActual.Data - val1M.Data).Days < 25)
            {
                columnaVisible(0, false);
            }
            else
            {
                columnaVisible(0, true);

                percent = valActual.PreuParticipacio / val1M.PreuParticipacio - 1;
                ntbPercent1M.Valor = percent;
                ntbPercent1M12.Valor = percent * 12;
            }

            if (val3M == null || (valActual.Data - val3M.Data).Days < 85)
            {
                columnaVisible(1, false);
            }
            else
            {
                columnaVisible(1, true);

                percent = valActual.PreuParticipacio / val3M.PreuParticipacio - 1;
                ntbPercent3M.Valor = percent;
                ntbPercent3M12.Valor = percent * 4;
            }

            if (val6M == null || (valActual.Data - val6M.Data).Days < 175)
            {
                columnaVisible(2, false);
            }
            else
            {
                columnaVisible(2, true);

                percent = valActual.PreuParticipacio / val6M.PreuParticipacio - 1;
                ntbPercent6M.Valor = percent;
                ntbPercent6M12.Valor = percent * 2;
            }

            int diesDesDeIniciAny = (DateTime.Now - dataIniciAny).Days + 1;

            if (valAny == null || (valActual.Data - val1A.Data).Days < diesDesDeIniciAny)
            {
                columnaVisible(3, false);
            }
            else
            {
                columnaVisible(3, true);

                lbPercentAny.Text = "% " + dataIniciAny.Year;

                percent = valActual.PreuParticipacio / valAny.PreuParticipacio - 1;
                ntbPercentAny.Valor = percent;
            }

            if (val1A == null || (valActual.Data - val1A.Data).Days < 350)
            {
                columnaVisible(4, false);
            }
            else
            {
                columnaVisible(4, true);

                percent = valActual.PreuParticipacio / val1A.PreuParticipacio - 1;
                ntbPercent1A.Valor = percent;
            }
        }


        private void ompleGrafica1(List<Valoracio> valoracionsProducte)
        {
            if (valoracionsProducte == null || valoracionsProducte.Count <= 1)
            {
                chProd.Series[0].Points.Clear();
            }
            else
            {
                chProd.ChartAreas[0].AxisY.Minimum = (double) (valoracionsProducte.Min(m => m.PreuParticipacio)); // / 1.02M);
                chProd.ChartAreas[0].AxisY.Maximum = (double) (valoracionsProducte.Max(m => m.PreuParticipacio)); // * 1.02M);

                chProd.DataSource = valoracionsProducte;

                chProd.DataBind();
                chProd.Update();
            }
        }

        private void actualitzaLlistaValoracionsTotal()
        {
            byte resultat = 0;
            if (checkedComboBoxEdit1.Properties.Items[TipusProd.Accions].CheckState == CheckState.Checked) resultat |= 1 << 0; // Primer bit
            if (checkedComboBoxEdit1.Properties.Items[TipusProd.Criptos].CheckState == CheckState.Checked) resultat |= 1 << 1; // Segon bit
            if (checkedComboBoxEdit1.Properties.Items[TipusProd.RF].CheckState == CheckState.Checked) resultat |= 1 << 2; // Tercer bit
            if (checkedComboBoxEdit1.Properties.Items[TipusProd.RV].CheckState == CheckState.Checked) resultat |= 1 << 3; // Quart bit

            dgvValoracionsPerData.SuspendLayout();

            //dgvValoracionsPerData.CellFormatting += NumericCell.CellFormatting;

            dgvValoracionsPerData.DataSource = StrDgvValoracionsPerData
                .CarregaStruct(dtpDataIniciLlista.Value, resultat, chTotals).OrderBy(o => o._Data).ToList();

            //dgvValoracionsPerData.CellFormatting -= NumericCell.CellFormatting;

            int ultimaFilaX = dgvValoracionsPerData.Rows.GetLastRow(DataGridViewElementStates.Visible);
            if (ultimaFilaX >= 0)
                dgvValoracionsPerData.FirstDisplayedScrollingRowIndex = ultimaFilaX;

            dgvValoracionsPerData.ResumeLayout();
        }

        #region *** Events ***

        private Producte vProdAnt;

        private void btNouValor_Click(object sender, EventArgs e)
        {
            vEsNouValor = true;

            tbImport.Valor = 0;

            modeEdicio();

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
                        Utilitats.EscriuLog(ex2, Program.FitxerLog, Program.Versio);
                        //MessageBox.Show(ex2.InnerException.InnerException.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
                    catch (Exception ex)
                    {
                        Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                        //MessageBox.Show(ex.Message);
                        conn.UndoingChangesDbEntityPropertyLevel(vValoracioSeleccionada);
                    }
                }

                Valoracio.RefrescaTaula();
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
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            if (tbImport.Valor <= 0)
            {
                MessageBox.Show(ParentForm, "El valor no potser igual o inferior a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = new InversionsBDContext())
                {
                    {
                        try
                        {
                            if (vEsNouValor)
                            {
                                Valoracio.Nova(conn, gestioProductesTabValoracions._ProducteSeleccionat, cData.Value, tbImport._DecimalValue);
                                conn.SaveChanges();
                                Valoracio.RefrescaTaula();
                            }
                            else
                            {
                                vValoracioSeleccionada.modifica(conn, cData.Value, tbImport._DecimalValue);
                                conn.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            Exception xx = Utilitats.ExtreuInnerException(ex);

                            if (xx is SqlException && ((SqlException) xx).Number == 2627)
                                MessageBox.Show("Valoració ja existeix", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show(xx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (vValoracioSeleccionada != null)
                    Valoracio.Reload(vValoracioSeleccionada);

                //gestioProductesTabValoracions.refrescaDadesControl(false);
                gestioProductesTabValoracions.refrescaDadesControl();

                ActivaRefrescaEnTabs(this);

                modeConsulta();

                tbImport.Valor = 0;

                actualitzaLlistaValoracionsPerProducte();
            }
            finally
            {
                Cursor = cursor;
            }
        }

        private void gestioProductesTabValoracions_ProducteSeleccionat(object sender, EventArgs e)
        {
            bool hiHaUnProducteSeleccionat = sender != null;

            btNouValor.Enabled = hiHaUnProducteSeleccionat;
            btModifica.Enabled = false;
            btEsborra.Enabled = false;
            tbImport.Valor = 0;
            pnEdicio.Visible = hiHaUnProducteSeleccionat;

            var prodSelect = (Producte) sender;

            if (vProdAnt != prodSelect)
            {
                actualitzaLlistaValoracionsPerProducte();

                vProdAnt = prodSelect;
            }
        }

        private void cDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvValoracions.CurrentRow == null)
            {
                vValoracioSeleccionada = null;
            }
            else if (vValoracioSeleccionada != ((StrDgvValoracions) dgvValoracions.Rows[e.RowIndex].DataBoundItem)._Valoracio)
            {
                //vValoracioSeleccionada = (Valoracio)dgvValoracions.Rows[e.RowIndex].DataBoundItem;
                vValoracioSeleccionada = ((StrDgvValoracions) dgvValoracions.Rows[e.RowIndex].DataBoundItem)._Valoracio;
                posaValorsDeLaFilaSeleccionada();
                btModifica.Enabled = true;
                btEsborra.Enabled = true;
            }
        }

        private void btCopiaValorsDelPaste_Click(object sender, EventArgs e)
        {
            var pSelf = new PasteSelfBank();
            if (pSelf.ShowDialog(this) == DialogResult.OK)
            {
                ActivaRefrescaEnTabs(this);
                //gestioProductesTabValoracions.refrescaDadesControl(false);
                gestioProductesTabValoracions.refrescaDadesControl();
            }
        }

        private void checkedComboBoxEdit1_CloseUp(object sender, CloseUpEventArgs e)
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
                        DataPoint dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];

                        e.Text = string.Format("Import:\t{0}", dataPoint.YValues[0]);
                    }
                    break;
            }
        }


        private void tbImport_TextChanged(object sender, EventArgs e)
        {
            cancelButton(tbImport.Modified ? null : btCancela);
        }

        private void tbImport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tbImport.Modified)
                {
                    cancelButton(btCancela);
                }
            }
        }

        private void ckValsAmbParticipacions_CheckedChanged(object sender, EventArgs e)
        {
            actualitzaLlistaValoracionsPerProducte();
        }

        private void dtpDataIniciValoracions_Validating(object sender, CancelEventArgs e)
        {
            actualitzaLlistaValoracionsPerProducte();
        }

        private void dtpDataIniciValoracions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
                actualitzaLlistaValoracionsPerProducte();
        }

        #endregion *** Events ***

        private enum TipusProd
        {
            Accions,
            RF,
            RV,
            Criptos
        }
    }
}