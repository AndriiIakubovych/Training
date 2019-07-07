using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BooksSearch
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter da;
        DataTable books;
        DataSet ds;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataTable authors = new DataTable();
            DataTable press = new DataTable();
            SqlCommand command = new SqlCommand();
            try
            {
                books = new DataTable();
                ds = new DataSet();
                connection = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = Catalog; Integrated Security = True");
                da = new SqlDataAdapter();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Authors ORDER BY Author_name";
                da.SelectCommand = command;
                da.Fill(authors);
                ds.Tables.Add(authors);
                authorChoice.DataSource = ds.Tables[0];
                authorChoice.DisplayMember = "Author_name";
                command.CommandText = "SELECT * FROM Press ORDER BY Press_name";
                da.SelectCommand = command;
                da.Fill(press);
                ds.Tables.Add(press);
                pressChoice.DataSource = ds.Tables[1];
                pressChoice.DisplayMember = "Press_name";
                command.CommandText = "SELECT Book_id, Book_name, Pages_count, Books.Author_id, Author_name, Books.Press_id, Press_name, Press_year FROM Books, Authors, Press WHERE Books.Author_id = Authors.Author_id AND Books.Press_id = Press.Press_id";
                da.SelectCommand = command;
                da.Fill(books);
                ds.Tables.Add(books);
                booksView.DataSource = ds.Tables[2];
                booksView.Columns[0].Visible = false;
                booksView.Columns[1].HeaderText = "Название книги";
                booksView.Columns[1].Width = 293;
                booksView.Columns[2].HeaderText = "Количество страниц";
                booksView.Columns[2].Width = 135;
                booksView.Columns[3].Visible = false;
                booksView.Columns[4].HeaderText = "Автор";
                booksView.Columns[4].Width = 150;
                booksView.Columns[5].Visible = false;
                booksView.Columns[6].HeaderText = "Издательство";
                booksView.Columns[6].Width = 200;
                booksView.Columns[7].HeaderText = "Год издания";
                booksView.Columns[7].Width = 95;
                booksView.RowHeadersVisible = booksView.ColumnHeadersVisible = booksView.Rows[0].Cells[1].Selected = booksView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void authorSearch_CheckedChanged(object sender, EventArgs e)
        {
            authorChoice.Enabled = authorSearch.Checked;
        }

        private void pressSearch_CheckedChanged(object sender, EventArgs e)
        {
            pressChoice.Enabled = pressSearch.Checked;
        }

        private void find_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            try
            {
                command.Connection = connection;
                command.CommandText = "SELECT Book_id, Book_name, Pages_count, Books.Author_id, Author_name, Books.Press_id, Press_name, Press_year FROM Books, Authors, Press WHERE Books.Author_id = Authors.Author_id AND Books.Press_id = Press.Press_id";
                if (authorSearch.Checked)
                    command.CommandText += " AND Author_name = @authorName";
                if (pressSearch.Checked)
                    command.CommandText += " AND Press_name = @pressName";
                command.Parameters.Add("@authorName", SqlDbType.VarChar).Value = authorChoice.Text;
                command.Parameters.Add("@pressName", SqlDbType.VarChar).Value = pressChoice.Text;
                da.SelectCommand = command;
                books.Clear();
                da.Fill(books);
                booksView.DataSource = ds.Tables[2];
                booksView.RowHeadersVisible = booksView.ColumnHeadersVisible = booksView.Rows.Count > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка доступа к данным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}