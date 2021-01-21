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

        public FormPhraseEdit(int id=-1)
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
                if (Id > 0)
                {
                    adapter = new SqlDataAdapter("SELECT * FROM Phrase WHERE Id=" + Id, con);
                    var dat = new DataTable();
                    adapter.Fill(dat);
                    if (dat.Rows.Count == 0)
                    {
                        if (Id == -1) Id = 1;
                        var ret = new SqlCommand($"INSERT INTO Phrase(Author_Id,TypePhrase_Id,Value) VALUES(NULL,NULL,NULL)", con)
                            .ExecuteScalar();
                        authors.SelectedIndex = types.SelectedIndex = -1;
                        Value.Text = "";
                    }
                    else
                    {
                        int id = -1;
                        if (!string.IsNullOrEmpty(dat.Rows[0].ItemArray[1].ToString()))
                            id = int.Parse(dat.Rows[0].ItemArray[1].ToString());
                        authors.SelectedIndex = id;
                        if (!string.IsNullOrEmpty(dat.Rows[0].ItemArray[2].ToString()))
                            id = int.Parse(dat.Rows[0].ItemArray[2].ToString());
                        types.SelectedIndex = id;
                        Value.Text = dat.Rows[0]["Value"].ToString();
                    }
                }
                else
                {
                    Value.Text = "";
                    authors.SelectedIndex = types.SelectedIndex = -1;
                }
            }
        }

        /// <summary> Обновление содержимого таблицы данными из бд </summary>
        //private void UpdateTable()
        //{ 
        //    // Создадим подключение к бд
        //    using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
        //    {
        //        con.Open();// Откроем соединение
        //        // Добавим пустую запись в таблицу Author
        //        // new SqlCommand($"INSERT INTO Phrase(Id,Name,Country) VALUES({grid.Rows.Count + 1},' ',' ')", con).ExecuteNonQuery();
        //    }
        //}

        private void save_Click(object sender, EventArgs e)
        {
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение

                int id_author = authors.SelectedIndex >= 0 ? (int)((DataRowView)authors.Items[authors.SelectedIndex])[0]:-1;
                int id_type = types.SelectedIndex >= 0 ? (int)((DataRowView)types.Items[types.SelectedIndex])[0]:-1;
                if (Id < 1)
                {
                    // Добавим пустую запись в таблицу Phrase
                    new SqlCommand($"INSERT INTO Phrase({(id_author>0?"Author_Id,":"")}{(id_type>0?"TypePhrase_Id,":"")}Value) " +
                                   $"VALUES({(id_author>0?$"{id_author},":null)}{(id_type>0?$"{id_type},":null)}N'{Value.Text.Trim()}')", con).ExecuteNonQuery();
                }
                else
                {
                    new SqlCommand($"UPDATE Phrase SET " +
                        $"{(id_author>0?"Author_Id="+id_author+",":"")}" +
                        $"{(id_type>0?"TypePhrase_Id="+id_type+",":"")}" +
                        $"Value=N'{Value.Text.Trim()}' WHERE Id={Id}", con)
                        .ExecuteNonQuery();
                }
            }
            Close();
        }
    }
}
