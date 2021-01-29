using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CatchPhrase.Properties;

namespace CatchPhrase
{
    public partial class FormTypePhraseEdit : Form
    {
        public int Id { get; private set; }
        public FormTypePhraseEdit(int id = -1)
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
                con.Open(); // Откроем соединение
                var adapter = new SqlDataAdapter($"SELECT * FROM TypePhrase WHERE Id={Id}", con);
                // заполним таблицу данными
                var dat = new DataTable();
                adapter.Fill(dat);
                // если данные есть, заполним поля
                if(dat.Rows.Count>0)
                    type.Text = dat.Rows[0][1].ToString();
            }
            else type.Text = "";
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(type.Text))
            {
                MessageBox.Show("Поле 'Тип' имеет недопустимое значение", "Недопустимое значение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                if (Id < 1)
                    // Добавим новую запись в таблицу TypePhrase
                    new SqlCommand($"INSERT INTO TypePhrase(Name) VALUES(N'{type.Text.Trim()}')", con)
                        .ExecuteNonQuery();
                else
                    // Обновим значение отредактированной ячейки
                    new SqlCommand($"UPDATE TypePhrase SET Name=N'{type.Text.Trim()}' WHERE Id={Id}", con)
                        .ExecuteNonQuery();
            }
            Close();
        }
    }
}
