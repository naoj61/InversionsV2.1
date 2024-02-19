using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    public partial class EdicioTaulesTab : TabX
    {
        private static readonly string StringConexio = Program.Sessio.Database.Connection.ConnectionString;

        public EdicioTaulesTab()
        {
            InitializeComponent();
        }

        private void carregaTaula(string taula)
        {
            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                // Consulta SQL para seleccionar todos los registros de la tabla
                string query = "SELECT * FROM " + taula;

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                adapter.Fill(table);

                // Asignar la tabla como origen de datos del DataGridView
                dataGridView.DataSource = table;
            }
        }

        private void desaTaula(string taula)
        {
            // Guardar cambios en la base de datos al hacer clic en el botón "Guardar"
            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Crear comandos SQL para actualizar los cambios en la base de datos
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.SelectCommand = new SqlCommand("SELECT * FROM " + taula, connection);
                connection.Open();

                // Actualizar los cambios en la base de datos
                var files = (DataTable)dataGridView.DataSource;

                adapter.Update(files);

                connection.Close();
            }
        }

        #region *** Events ***

        private void edicioTaulesTab_Load(object sender, EventArgs e)
        {
            // Obté una llista de les taules disponibles a la base de dades
            var tables = Program.Sessio.Database
                .SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'").ToList();

            // Omple un desplegable amb les taules
            comboBoxTables.DataSource = tables;
            comboBoxTables.SelectedItem = null;

            comboBoxTables.SelectedIndexChanged -= comboBoxTables_SelectedIndexChanged;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregaTaula(comboBoxTables.SelectedItem.ToString());
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            desaTaula(comboBoxTables.SelectedItem.ToString());

        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();

            carregaTaula(selectedTable);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if (grid.Columns[e.ColumnIndex].Name == "RowVersion")
            {
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        #endregion *** Events ***
    }
}
