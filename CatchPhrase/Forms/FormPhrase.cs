using CatchPhrase.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CatchPhrase
{
    public partial class FormPhrase : Form
    {
        public FormPhrase()
        {
            InitializeComponent();
        }

        private void FormPhrase_Load(object sender, EventArgs e)
        {
            UpdateTable();
            filtrWhere.SelectedIndex = 0;
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
                string tableName = filtrWhere.SelectedIndex == 0 ? $" WHERE Value LIKE N'%{find.Text.Trim()}%'" : "";
                var adapter = new SqlDataAdapter("SELECT * FROM Phrase"+(find.Text!=""?tableName:""), con);
                var dat = new DataTable();
                // заполним таблицу данными
                adapter.Fill(dat);
                if (grid.DataSource == null)
                {
                    grid.Rows.Clear();
                    grid.Columns.Clear();
                }

                #region Сопоставление связей таблицы
                // временное хранилище словаря id:автор
                Dictionary<int,string> author = new Dictionary<int, string>();
                // получить всех авторов и их id
                var adapterauthor = new SqlDataAdapter("SELECT * FROM Author", con);
                var datauthor = new DataTable();
                // заполним таблицу данными
                adapterauthor.Fill(datauthor);
                // заполнение хранилища временными данными
                foreach (DataRow row in datauthor.Rows)
                    author.Add((int)row[0],(string)row[1]);
                // временное хранилище словаря id:типы
                Dictionary<int, string> types = new Dictionary<int, string>();
                var adaptertypes = new SqlDataAdapter("SELECT * FROM TypePhrase", con);
                var dattypes = new DataTable();
                // заполним таблицу данными
                adaptertypes.Fill(dattypes);
                // заполнение хранилища временными данными
                foreach (DataRow row in dattypes.Rows)
                    types.Add((int)row[0], (string)row[1]);
                // установим наименования заголовков gridView
                dat.Columns.Add(" Автор", typeof(string));
                dat.Columns.Add(" Тип", typeof(string));
                foreach (DataRow row in dat.Rows)
                {
                    if(row[1].ToString()!="" && author.ContainsKey((int)row[1]))
                        row[dat.Columns.Count-2] = author[(int)row[1]];

                    if (row[2].ToString() != "" && types.ContainsKey((int)row[2]))
                        row[dat.Columns.Count-1] = types[(int)row[2]];
                }

                #endregion
     
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
                // скрыть столбцы связей
                grid.Columns[1].Visible = false;// Автор
                grid.Columns[2].Visible = false;// Тип
                grid.Columns[3].HeaderText = @"Фраза";
                // Выровняем заголовки равномерно по ширине таблицы
                grid.Columns[grid.Columns.Count-2].AutoSizeMode = 
                grid.Columns[grid.Columns.Count-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grid.Columns[grid.Columns.Count - 1].DefaultCellStyle.Alignment = 
                grid.Columns[grid.Columns.Count - 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (filtrWhere.SelectedIndex != 0)
                    for(int i=dat.Rows.Count-1;i>=0;i--)
                    {
                        if (filtrWhere.SelectedIndex == 1)
                        {
                            // фильтр по автору
                            if(!dat.Rows[i][grid.Columns.Count - 2].ToString().Contains(find.Text))
                                dat.Rows.RemoveAt(i);
                        }
                        else
                        {
                            if (!dat.Rows[i][grid.Columns.Count - 1].ToString().Contains(find.Text))
                                dat.Rows.RemoveAt(i);
                        }
                    }
            }
            // если была выделена строка, восстановим выделение
            if (sel >= 0 && grid.Rows.Count>sel)
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
                new SqlCommand($"UPDATE Phrase SET {grid.Columns[e.ColumnIndex].Name}" +
                               $"=N'{grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}' " +
                               $"WHERE Id={grid.Rows[e.RowIndex].Cells[0].Value}", con)
                    .ExecuteNonQuery();
            }
        }

        /// <summary> Добавление новой пустой записи в базу данных </summary>
        private void insert_Click(object sender, EventArgs e)
        {
            // открыть окно редактирования записи для создания новой записи
            new FormPhraseEdit().ShowDialog();
            UpdateTable();// Обновим содержимое таблицы
        }

        /// <summary> Удаление выделенной записи </summary>
        private void remote_Click(object sender, EventArgs e)
        {
            // получить Id удаляемой записи
            int selId = (int)grid.CurrentRow.Cells[0].Value;
            // выйти если не выделена строка
            if (selId < 0) return;
            // спросить пользователя разрешение на даление записи
            if (MessageBox.Show($@"Удалить фразу : '{grid.CurrentRow?.Cells[3].Value}' ?",
                    @"Внимание...", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;
            // Создадим подключение к бд
            using (SqlConnection con = new SqlConnection(Settings.Default.ConnectionString))
            {
                con.Open();// Откроем соединение
                // Добавим пустую запись в таблицу Author
                new SqlCommand($"DELETE FROM Phrase WHERE Id={selId}", con).ExecuteNonQuery();
            }
            UpdateTable();// Обновим содержимое таблицы
        }

        private void change_Click(object sender, EventArgs e)
        {
            // получить Id выделенной записи
            if (grid?.SelectedCells == null) return;
            int id = (int)grid.SelectedCells[0].Value;
            if (id < 1) return;
            // открыть окно редактирования записи для правки
            new FormPhraseEdit(id).ShowDialog();
            // обновить содержимое таблицы
            UpdateTable();
        }

        private void back_Click(object sender, EventArgs e)
        {
            // Закрыть окно
            Close();
        }

        /// <summary> обновление содержимого таблицы в соответствии с содержимым поля поиска </summary>
        private void find_TextChanged(object sender, EventArgs e)
        {
            // обновить содержимое таблицы
            UpdateTable();
        }
    }


}
