using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatchPhrase.Properties;

namespace CatchPhrase
{
    public partial class FormAuthors : Form
    {
        public FormAuthors()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAuthors_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();
                var adapter = new SqlDataAdapter("SELECT * FROM Author",con);
                var dat = new DataTable();
                adapter.Fill(dat);
                if (dataGridView1.DataSource == null)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                }
                dataGridView1.DataSource = dat;
                dataGridView1.Columns[0].Width = 25;// Visible = false;
                dataGridView1.Columns[1].HeaderText = @"Автор";
                dataGridView1.Columns[2].HeaderText = @"Страна";
                dataGridView1.Columns[1].AutoSizeMode =
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();
                new SqlCommand($"INSERT INTO Author(Id,Name,Country) VALUES({dataGridView1.Rows.Count+1},' ',' ')",con).ExecuteNonQuery();
            }
            UpdateTable();
            dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
        }
    }
}
