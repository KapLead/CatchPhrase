using CatchPhrase.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Windows.Forms;

namespace CatchPhrase
{
    public partial class FormAuthors : Form
    {
        public FormAuthors()
        {
            InitializeComponent();
        }

        /// <summary> Вернуться в форму главного меню (закрытие текущей формы) </summary>
        private void back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAuthors_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /// <summary> Обновление содержимого таблицы данными из бд </summary>
        private void UpdateTable()
        {
            // отписаться от события изменения содержимого редактируемой ячейки
            grid.CellEndEdit -= GridOnCellEndEdit;
            // Получим индекс текущей выделенной строки (если выделено)
            int sel = grid.CurrentRow?.Index ?? -1;
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open(); // Откроем соединение
                // Считаем требуемую таблицу
                var adapter = new SqlDataAdapter("SELECT * FROM Author", con);
                var dat = new DataTable();
                // заполним таблицу данными
                adapter.Fill(dat);
                if (grid.DataSource == null)
                {
                    grid.Rows.Clear();
                    grid.Columns.Clear();
                }
                // установим таблицу ресурсом данных для DataGridView
                grid.DataSource = dat;
                // если надо отобразим поле Id записи
                if (Settings.Default.ShowIdTables)
                {
                    // Установим факсированную длину столбца
                    grid.Columns[0].Width = 25;
                    // Поле Id - только чтение
                    grid.Columns[0].ReadOnly = true;
                }
                else // иначе спрячем колонку с id
                    grid.Columns[0].Visible = false;
                // установим наименования заголовков gridView
                grid.Columns[1].HeaderText = @"Автор";
                grid.Columns[2].HeaderText = @"Страна";
                // Выровняем заголовки равномерно по ширине таблицы
                grid.Columns[1].AutoSizeMode =
                    grid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            // если была выделена строка, восстановим выделение
            if (sel >= 0 && grid.Rows.Count>0)
                grid.Rows[sel].Selected = true;
            // подпишимся заново на событие изменения содержимого редактируемой ячейки
            grid.CellEndEdit += GridOnCellEndEdit;
        }

        /// <summary> Изменение содержимого редактируемой ячейки, изменение содержимого в бд </summary>
        private void GridOnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open(); // Откроем соединение
                // Обновим значение отредактированной ячейки
                new SqlCommand($"UPDATE Author SET {grid.Columns[e.ColumnIndex].Name}" +
                               $"=N'{grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}' " +
                               $"WHERE Id={grid.Rows[e.RowIndex].Cells[0].Value}", con)
                    .ExecuteNonQuery();
            }
        }

        /// <summary> Добавление новой пустой записи в базу данных </summary>
        private void insert_Click(object sender, EventArgs e)
        {
            new FormAuthorEdit().ShowDialog();
            UpdateTable();
            // Создадим подключение к бд
            //using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            //{
            //    con.Open();// Откроем соединение
            //    // Добавим пустую запись в таблицу Author
            //    new SqlCommand($"INSERT INTO Author(Id,Name,Country) VALUES({grid.Rows.Count + 1},' ',' ')", con).ExecuteNonQuery();
            //}
            //UpdateTable();// Обновим содержимое таблицы
            //// Выделим последнюю строку таблицы (новая созданная запись)
            //grid.Rows[grid.RowCount - 1].Selected = true;
        }

        /// <summary> Удаление выделенной записи </summary>
        private void remote_Click(object sender, EventArgs e)
        {

        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)
        {
            if (grid?.SelectedCells == null) return;
            int id = (int) grid.SelectedCells[0].Value;
            if (id < 1) return;
            new FormAuthorEdit(id).ShowDialog();
            UpdateTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (grid?.SelectedCells == null) return;
            int id = (int)grid.SelectedCells[0].Value;
            if (id < 1) return;
            if (MessageBox.Show($@"Вы хотите удалить автора: '{grid.SelectedCells[1].Value}'",
                    @"Внимание", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open(); // Откроем соединение
                // Удалить запись из таблицы Author
                new SqlCommand($"DELETE FROM Author WHERE Id={id}", con).ExecuteNonQuery();
            }
            UpdateTable(); // Обновим содержимое таблицы
        }
    }
}
