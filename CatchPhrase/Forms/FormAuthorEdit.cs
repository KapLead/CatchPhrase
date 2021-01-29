using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CatchPhrase.Properties;

namespace CatchPhrase
{
    public partial class FormAuthorEdit : Form
    {
        public int Id { get; private set; }
        public FormAuthorEdit(int id = -1)
        {
            Id = id;
            InitializeComponent();
        }

        private void FormAuthorEdit_Load(object sender, EventArgs e)
        {
            if(Id>0)
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                var adapter = new SqlDataAdapter($"SELECT * FROM Author WHERE Id={Id}", con);
                ;
                var dat = new DataTable();
                // заполним таблицу данными
                adapter.Fill(dat);       // var result = new SqlCommand($"SELECT * FROM Author WHERE Id={Id}", con).ExecuteReader();
                author.Text = dat.Rows[0][1].ToString();
                country.Text = dat.Rows[0][2].ToString();
                }
            else
            {
                author.Text = "";
                country.Text = "";
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(author.Text))
            {
                MessageBox.Show("Поле 'Автор' имеет недопустимые значения", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(country.Text))
            {
                MessageBox.Show("Поле 'страна' имеет недопустимые значения", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                // Добавим новую запись в таблицу Author
                if (Id < 1)
                {
                    new SqlCommand($"INSERT INTO Author(Name,Country) VALUES(N'{author.Text}',N'{country.Text}')", con)
                        .ExecuteNonQuery();
                }
                else
                // Обновим значение отредактированной ячейки
                new SqlCommand($"UPDATE Author SET Name=N'{author.Text.Trim()}', Country=N'{country.Text.Trim()}' WHERE Id={Id}", con)
                    .ExecuteNonQuery();
            }
            Close();
        }
    }
}
