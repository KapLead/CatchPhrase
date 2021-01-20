using System;
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
            if(Id<1)
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                // Добавим пустую запись в таблицу Author
                new SqlCommand($"INSERT INTO Author(Id,Name,Country) VALUES({Id},' ',' ')", con).ExecuteNonQuery();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                // Добавим пустую запись в таблицу Author
                
                // Обновим значение отредактированной ячейки
                new SqlCommand($"UPDATE Author SET Name=N'{author.Text.Trim()}', Country=N'{country.Text.Trim()}' WHERE Id={Id}", con)
                    .ExecuteNonQuery();
            }
        }
    }
}
