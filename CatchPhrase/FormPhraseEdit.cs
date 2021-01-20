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
                comboBox1.DataSource = datauthor;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                // Считаем требуемую таблицу
                adapter = new SqlDataAdapter("SELECT * FROM TypePhrase", con);
                var dattype = new DataTable();
                // заполним таблицу данными
                adapter.Fill(dattype);
                comboBox1.DataSource = dattype;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                // установим таблицу ресурсом данных для DataGridView
            }
        }
    }
}
