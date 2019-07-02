using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesViewing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableChoice.SelectedIndex = 0;
        }

        private void tableChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Sales; Integrated Security = True");
            string query = null;
            if (tableChoice.SelectedIndex == 0)
                query = "SELECT * FROM Buyers";
            if (tableChoice.SelectedIndex == 1)
                query = "SELECT * FROM Sellers";
            if (tableChoice.SelectedIndex == 2)
                query = "SELECT * FROM Sales";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                da.Fill(dt);
                dataGridView.DataSource = dt;
                if (dataGridView.Rows.Count > 0)
                {
                    if (tableChoice.SelectedIndex == 0)
                    {
                        dataGridView.Columns[0].HeaderText = "Идентификатор";
                        dataGridView.Columns[0].Width = 180;
                        dataGridView.Columns[1].HeaderText = "Имя";
                        dataGridView.Columns[1].Width = 265;
                        dataGridView.Columns[2].HeaderText = "Фамилия";
                        dataGridView.Columns[2].Width = 274;
                    }
                    if (tableChoice.SelectedIndex == 1)
                    {
                        dataGridView.Columns[0].HeaderText = "Идентификатор";
                        dataGridView.Columns[0].Width = 180;
                        dataGridView.Columns[1].HeaderText = "Имя";
                        dataGridView.Columns[1].Width = 265;
                        dataGridView.Columns[2].HeaderText = "Фамилия";
                        dataGridView.Columns[2].Width = 274;
                    }
                    if (tableChoice.SelectedIndex == 2)
                    {
                        dataGridView.Columns[0].HeaderText = "Идентификатор сделки";
                        dataGridView.Columns[0].Width = 151;
                        dataGridView.Columns[1].HeaderText = "Идентификатор покупателя";
                        dataGridView.Columns[1].Width = 173;
                        dataGridView.Columns[2].HeaderText = "Идентификатор продавца";
                        dataGridView.Columns[2].Width = 163;
                        dataGridView.Columns[3].HeaderText = "Сумма сделки (грн.)";
                        dataGridView.Columns[3].Width = 132;
                        dataGridView.Columns[4].HeaderText = "Дата сделки";
                    }
                }
                else
                    dataGridView.RowHeadersVisible = dataGridView.ColumnHeadersVisible = false;
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения к БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}