using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CatchPhrase.Properties;

namespace CatchPhrase
{
    public partial class FormPhraseEdit : Form
    {
        public int Id { get; private set; }

        public FormPhraseEdit(int id)
        {
            Id = id;
            InitializeComponent();
        }

        private void FormPhraseEdit_Load(object sender, EventArgs e)
        {
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open(); // Откроем соединение
                // Считаем требуемую таблицу
                var adapter = new SqlDataAdapter("SELECT * FROM Author", con);
                var datauthor = new DataTable();
                // заполним таблицу данными
                adapter.Fill(datauthor);
                authors.DataSource = datauthor;
                authors.DisplayMember = "Name";
                authors.ValueMember = "Id";
                // Считаем требуемую таблицу
                adapter = new SqlDataAdapter("SELECT * FROM TypePhrase", con);
                var dattype = new DataTable();
                // заполним таблицу данными
                adapter.Fill(dattype);
                types.DataSource = dattype;
                types.DisplayMember = "Name";
                types.ValueMember = "Id";
                // установим таблицу ресурсом данных для DataGridView
                adapter = new SqlDataAdapter("SELECT * FROM Phrase WHERE Id="+Id, con);
                var dat = new DataTable();
                adapter.Fill(dat);
                if (dat.Rows.Count == 0)
                {
                    if (Id==-1) Id=1;
                    new SqlCommand($"INSERT INTO Phrase(Id,Author_Id,TypePhrase_Id,Value) VALUES({Id},0,0,' ')", con)
                        .ExecuteNonQuery();
                    authors.SelectedIndex = types.SelectedIndex = -1;
                    Value.Text = "";
                }
                else
                {

                }
            }
        }

        /// <summary> Обновление содержимого таблицы данными из бд </summary>
        private void UpdateTable()
        { 
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                // Добавим пустую запись в таблицу Author
                // new SqlCommand($"INSERT INTO Phrase(Id,Name,Country) VALUES({grid.Rows.Count + 1},' ',' ')", con).ExecuteNonQuery();
            }
            UpdateTable();// Обновим содержимое таблицы
            // Выделим последнюю строку таблицы (новая созданная запись)
           // grid.Rows[grid.RowCount - 1].Selected = true;
        }
    }
}
