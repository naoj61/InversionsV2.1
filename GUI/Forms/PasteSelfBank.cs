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

namespace Inversions.GUI
{
    public partial class PasteSelfBank : Form
    {
        public PasteSelfBank()
        {
            InitializeComponent();

            dateTimePicker1.Value = DateTime.Now;
        }

        private void btCapturaValors_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var text1 = textBox1.Text.Replace(Environment.NewLine, "\t");
            var items = text1.Split(new char[]{'\t', }, StringSplitOptions.RemoveEmptyEntries);
            ProdFons prod = null;
            int conta = 0;
            string valor;
            foreach (var item in items)
            {
                if (conta == 0)
                {
                    prod = Program.Sessio.ProdFons.SingleOrDefault(w => w.ISIN == item);
                    if (prod != null)
                        conta++;
                }
                else if (conta < 4)
                {
                    conta ++;
                }
                else
                {
                    conta = 0;

                    dataGridView1.Rows.Add(new object[] {prod, Convert.ToDouble(item.Replace("€", ""))});

                }
            }

            btDesa.Enabled = dataGridView1.Rows.Count > 0;
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            using (var connexio = new InversionsBDContext())
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Valoracio val = new Valoracio();
                        val.PreuParticipacio = (double) row.Cells[1].Value;
                        val.ProdId = ((ProdFons) row.Cells[0].Value).Id;
                        val.Data = dateTimePicker1.Value;
                        connexio.Valoracions.Add(val);
                    }

                    connexio.SaveChanges();

                    btDesa.Enabled = false;

                    MessageBox.Show("Fet!");
                }
                catch (Exception ex)
                {
                    Utilitats.EscriuLog(ex, null);
                }
            }
        }
    }
}
