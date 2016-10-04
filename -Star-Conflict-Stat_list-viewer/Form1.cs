using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Net.Http;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace _Star_Conflict_Stat_list_viewer
{
    
    public partial class MainForm : Form
    {
        public Excel.Application app;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Range excelcells;
        string pilots_list;
        public MainForm()
        {
            InitializeComponent();
            load_to_csv_button.Enabled = false;
            load_to_exel_button.Enabled = false;
            load_to_xml_button.Enabled = false;
            clean_flot_realization.Enabled = false;
            load_to_datagridview_table.Enabled = false;
            find_file.Enabled = false;
        }
        private void MainForm_Load(object sender, EventArgs e)                    // Обработка событий при загрузке приложения
        {
            pilots_list = "flot_list.txt";
            dataGridView1.Columns.Add("ID", "uID");
            dataGridView1.Columns.Add("Name", "Никнейм");
            
            dataGridView1.Columns.Add("Corp", "Корпорация");
            dataGridView1.Columns.Add("CorpTag", "Тэг");
            dataGridView1.Columns.Add("PlayBattle", "Сыграно битв");
            dataGridView1.Columns.Add("Winrate", "Винрейт");
            dataGridView1.Columns.Add("Kill", "Убийств");
            dataGridView1.Columns.Add("KillPerBattle", "Убийств за бой");
            dataGridView1.Columns.Add("KillDeath", "Убийств " + "/" + " Смертей");
            dataGridView1.Columns.Add("HelpPerBattle", "Помощи за бой");
            dataGridView1.Columns.Add("DmgPerBattle", "Урона за бой");
            dataGridView1.Columns.Add("HealPerBattle", "Лечения за бой");
            dataGridView1.Columns.Add("Karma", "Карма пилота");
            dataGridView1.Columns.Add("FullShipInAngar", "Мощь флота");
            
            if (!File.Exists(pilots_list))
            {
                FileStream file_create = File.Create(pilots_list);
                file_create.Close();
            }
            
            bool append = true;
            StreamReader new_stream = new StreamReader(pilots_list, append);      // создаем поток для считывания списка пилотов
            while (!new_stream.EndOfStream)                                       // пока не прочитаем весь файл
            {                                                                       
                flot_have.Text = flot_have.Text + new_stream.ReadLine() + Environment.NewLine; // добавляем пилотов текстбокс с составом флота
            }
            new_stream.Close();

            if (flot_have.Text != " " && flot_have.Text != "")
            {
                load_to_datagridview_table.Enabled = true;
            }
        }
        private void FocusFile(string file)                                       // Открываем проводник и устанавливаем курсор 
        {                                                                             // на файле с списком пилотов,
            System.Diagnostics.Process.Start("explorer.exe", @"/select, " + file);    // что используется в данный момент
        }
        public void open_file_dialog()                                            // Открываем диалог для выбора файла с списком пилотов
        {

            var dialog = new OpenFileDialog();
            dialog.Filter = "Файлы txt|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pilots_list = dialog.FileName;
                load_to_datagridview_table.Enabled = true;
            }
            StreamReader new_stream = new StreamReader(dialog.FileName);              // Создаем поток для считывания списка пилотов
            flot_have.Text = null;                                                     // Очищаем текстбокс с текущим списком пилотов
            while (!new_stream.EndOfStream)                                           // Читаем файл до конца
            {
                flot_have.Text = flot_have.Text + new_stream.ReadLine() + Environment.NewLine;    // Заполняем текстбокс с текущим списком пилотов
            }
            new_stream.Close();
            find_file.Enabled = true;
        }
        public void new_file_dialog()                                             // Создаем новый файл с списком пилотов (или дополняем текущий)
        {                                                                             // И заполняем его значениями из текстбокса
            string path = "flot_list.txt";
            if (pilots_list != "" || pilots_list != null || pilots_list != " ")
            {
                path = pilots_list;
            }
            string text = flot_add.Text;
            bool append = true;
            StreamWriter output = new StreamWriter(path, append);                     // Создаем поток для записи в файл
            if (!File.Exists(path)) File.Create(path);                                // Если файла не существует, создаем
            if (text != null || text != " ")                                          // Заполняем файл значениями из текстбокса 
            {
                output.WriteLine(text);
            }
            flot_add.Text = null;
            output.Close();
            pilots_list = path;
            if (text != null || text != " ")                                          // Добавляем значения в текстбокс с текущим списком пилотов
            { 
                flot_have.Text = flot_have.Text + text + Environment.NewLine; 
            }
            find_file.Enabled = true;
        }
        public async void load_data()                                             // Загружаем данные по текущему списку флота
        {
            StreamReader stream = new StreamReader(pilots_list); // создаем поток для считывания списка пилотов
            List<string> pilots = new List<string>();            // создаем список List, в котором будем хранить считанные данные
            while (!stream.EndOfStream)
            {
                // Читаем строку из файла во временную переменную.
                string temp = stream.ReadLine();
                // Если достигнут конец файла, прерываем считывание.
                if (temp == null) break;
                if (temp == " ") continue;
                // Пишем считанную строку в итоговую переменную.
                pilots.Add(temp);
            }
            stream.Close();

            for (int i = 0; i < pilots.Count; i++)
            {
                if (pilots.ElementAt(i) == " " || pilots.ElementAt(i) == null) i++;
                string urn = ("http://gmt.star-conflict.com/pubapi/v1/userinfo.php?nickname=" + pilots.ElementAt(i)); // Формируем запрос
                var uri = new Uri(urn);
                var client = new HttpClient(); // Add: using System.Net.Http;       // Создаем клиента для запроса
                var response = await client.GetAsync(uri);                          // Совершаем запрос
                string results = await response.Content.ReadAsStringAsync();        // Получаем в переменную результат запроса
                dynamic root = JObject.Parse(results);                              // Парсим результат запроса как JSon строку

                dataGridView1.Rows.Add();                                           // Добавляем строку
                if (root.code == 0)                                                 // Если никнейм существует - составляем строку из элементов root.* 
                {
                    double game_played_d = root.data.pvp.gamePlayed;
                    double gameWin_d = 0;
                    double winrate_d = 0;
                    if (root.data.pvp.gameWin >= 2)
                    {
                        gameWin_d = root.data.pvp.gameWin;
                        winrate_d = Math.Round((gameWin_d / (game_played_d - gameWin_d)), 2);
                    }
                    double kill_d = root.data.pvp.totalKill;
                    double m_kill_d = Math.Round(Math.Round((kill_d / game_played_d), 3), 2);
                    double totalDeath_d = root.data.pvp.totalDeath;
                    double kill_death_d = Math.Round(Math.Round((kill_d / totalDeath_d), 3), 2);
                    double totalAssists_d = root.data.pvp.totalAssists;
                    double m_assists_d = Math.Round(Math.Round((totalAssists_d / game_played_d), 3), 2);
                    double totalDmgDone_d = root.data.pvp.totalDmgDone;
                    double m_dmg_d = Math.Round(Math.Round((totalDmgDone_d / game_played_d), 3), 2);
                    double totalHealDone_d = root.data.pvp.totalHealingDone;
                    double m_heal_d = Math.Round(Math.Round((totalHealDone_d / game_played_d), 3), 2);
                    double pr_bonus_d = 0;
                    if (root.data.prestigeBonus != null) { pr_bonus_d = root.data.prestigeBonus; }      // Костыль для заброшенных старых аккаунтов
                    double fleet_power_d = (pr_bonus_d * 100);
                    dataGridView1.Rows[i].HeaderCell.Value = pilots.ElementAt(i);
                    dataGridView1.Rows[i].Cells[1].Value = pilots.ElementAt(i);
                    dataGridView1.Rows[i].Cells[0].Value = root.data.uid;
                    dataGridView1.Rows[i].Cells[2].Value = "Без корпорации";
                    dataGridView1.Rows[i].Cells[3].Value = null;
                    if (root.data.clan != null && root.data.clan.name != null && root.data.clan.tag != null)
                    {
                        dataGridView1.Rows[i].Cells[2].Value = root.data.clan.name;
                        dataGridView1.Rows[i].Cells[3].Value = ("[" + root.data.clan.tag + "]");
                    }
                    dataGridView1.Rows[i].Cells[4].Value = root.data.pvp.gamePlayed;
                    dataGridView1.Rows[i].Cells[5].Value = winrate_d;
                    dataGridView1.Rows[i].Cells[6].Value = root.data.pvp.totalKill;
                    dataGridView1.Rows[i].Cells[7].Value = m_kill_d;
                    dataGridView1.Rows[i].Cells[8].Value = kill_death_d;
                    dataGridView1.Rows[i].Cells[9].Value = m_assists_d;
                    dataGridView1.Rows[i].Cells[10].Value = m_dmg_d;
                    dataGridView1.Rows[i].Cells[11].Value = m_heal_d;
                    dataGridView1.Rows[i].Cells[12].Value = root.data.karma;
                    dataGridView1.Rows[i].Cells[13].Value = fleet_power_d;
                }
                else if (root.code == 1 || pilots.ElementAt(i) == null || pilots.ElementAt(i) == " ")  // Если никнейм не существует
                {
                    dataGridView1.Rows[i].HeaderCell.Value = "[Error]";
                    dataGridView1.Rows[i].Cells[0].Value = "[Not found] " + pilots.ElementAt(i);
                    for (int j = 1; j <= 13; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                    }
                }
                if (dataGridView1.Rows[i].Cells[10] == null)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }
            dataGridView1.AutoResizeColumns();                                                                    // Выравнивание колонок по содержимому
            dataGridView1.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders); // Выравнивание заголовков строк по содержимому
            DataGridViewColumn Name = dataGridView1.SortedColumn;
            load_to_csv_button.Enabled = true;
            load_to_exel_button.Enabled = true;
            load_to_xml_button.Enabled = true;
            find_file.Enabled = true;
        }
        public void clean_flot()                                                  // Очищаем список флота
        {
            flot_have.Text = null;                                                     // Очищаем текущий список пилотов
            File.Delete(pilots_list);                                                 // Удаляем текущий файл с списком
            clear_data();
            load_to_csv_button.Enabled = false;
            load_to_exel_button.Enabled = false;
            load_to_xml_button.Enabled = false;
            find_file.Enabled = false;                                                           // Запускаем функцию очистки таблицы dgv
        }
        private void FinishExcel(Excel.Application XL)                            // Завершаем процесс эксель
        {
            if (XL != null)
            {
                XL.ScreenUpdating = true;
                if (!XL.Interactive) XL.Interactive = true;
                XL.UserControl = true;
                if (XL.Workbooks.Count == 0)
                {
                    XL.Quit();
                }
                else
                {
                    if (!XL.Visible) XL.Visible = true;
                    XL.ActiveWorkbook.Saved = true;
                }
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(XL);
                XL = null;
                GC.GetTotalMemory(true); // вызов сборщика мусора
                                         // Пока не закрыть приложение EXCEL.EXE будет висеть в процессах
            }
        }
        public void export_to_exel()                                              // Экспорт данных в Эксель 
        {


            app = new Excel.Application();
            app.Visible = false;

            //app.SheetsInNewWorkbook = 1;//обязательно до создания новой книги
            //var workbook = app.Workbooks.Add(1);
            string path = Environment.CurrentDirectory + "\\flot_list.xlsx";
            string sheet_name_d = DateTime.Now.ToString();
            var temp_time = new Regex(":");
            Excel.Workbook workbook;
            Excel.Worksheet worksheets;
            sheet_name_d = temp_time.Replace(sheet_name_d, ".");
            if(File.Exists(path) == false)
            {
                workbook = app.Workbooks.Add(Environment.CurrentDirectory + "\\flot_list_template");
                workbook.SaveAs(Environment.CurrentDirectory + "\\flot_list.xlsx");
            }
            workbook = app.Workbooks.Open(path);
            worksheets = app.Worksheets.Add();
            worksheets.Name = sheet_name_d;
            app.Columns.ColumnWidth = 17;
            app.Cells[1, 2] = "Никнейм";                                           // Стартовые значения заголовков таблицы
            app.Cells[1, 1] = "uID";
            app.Cells[1, 3] = "Корпорация";
            app.Cells[1, 4] = "Тэг";
            app.Cells[1, 5] = "Сыграно битв [x1000]";
            app.Cells[1, 6] = "Винрейт";
            app.Cells[1, 7] = "Убийств [x100000]";
            app.Cells[1, 8] = "Убийств за бой";
            app.Cells[1, 9] = "Убийств" + " / " + "Сметрей";
            app.Cells[1, 10] = "Помощи за бой";
            app.Cells[1, 11] = "Урона за бой [x100000]";
            app.Cells[1, 12] = "Лечения за бой [x100000]";
            app.Cells[1, 13] = "Карма пилота [x100000]";
            app.Cells[1, 14] = "Мощь флота [x10]";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    app.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    
                    app.Cells[i + 2, 5]  =    double.Parse (dataGridView1.Rows[i].Cells[4].Value.ToString()) / 1000;
                    app.Cells[i + 2, 7] =     double.Parse (dataGridView1.Rows[i].Cells[6].Value.ToString()) / 100000;
                    app.Cells[i + 2, 11] =    double.Parse (dataGridView1.Rows[i].Cells[10].Value.ToString()) / 100000;
                    app.Cells[i + 2, 12] =    double.Parse (dataGridView1.Rows[i].Cells[11].Value.ToString()) / 100000;
                    app.Cells[i + 2, 13] =    double.Parse (dataGridView1.Rows[i].Cells[12].Value.ToString()) / 100000;
                    app.Cells[i + 2, 14] =    double.Parse (dataGridView1.Rows[i].Cells[13].Value.ToString()) / 10;
                }
            }
            
            int z = dataGridView1.Rows.Count + 1;
            //Если бы мы открыли несколько книг, то получили ссылку так
            //excelappworkbook=excelappworkbooks[1];
            //Получаем массив ссылок на листы выбранной книги
            excelsheets = workbook.Worksheets;
            //Получаем ссылку на лист 1
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            //Выделяем ячейки с данными  в таблице
            excelcells = excelworksheet.get_Range("b1", "n" + z);
            //И выбираем их
            excelcells.Select();
            //Создаем объект Excel.Chart диаграмму по умолчанию
            Excel.Chart excelchart = (Excel.Chart)app.Charts.Add();
            //Выбираем диграмму - отображаем лист с диаграммой
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            //Изменяем тип диаграммы
            app.ActiveChart.ChartType = Excel.XlChartType.xlLine;
            //Создаем надпись - Заглавие диаграммы
            app.ActiveChart.HasTitle = true;
            app.ActiveChart.ChartTitle.Text = "Cтатистика космофлота";



            app.Visible = true;
            app.UserControl = true;
            FinishExcel(app);
        }
        public void export_to_xml()                                               // Экспорт данных в .xml файл
        {
            DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
            System.Data.DataTable dt = new System.Data.DataTable(); // создаем пока что пустую таблицу данных
            dt.TableName = "pilot"; // название таблицы
            // название колонок
            dt.Columns.Add("Никнейм");
            dt.Columns.Add("uID");
            dt.Columns.Add("Корпорация");
            dt.Columns.Add("Тэг");
            dt.Columns.Add("Сыграно битв");
            dt.Columns.Add("Винрейт");
            dt.Columns.Add("Убийств");
            dt.Columns.Add("Убийств за бой");
            dt.Columns.Add("Убийств Смертей");
            dt.Columns.Add("Помощи за бой");
            dt.Columns.Add("Урона за бой");
            dt.Columns.Add("Лечения за бой");
            dt.Columns.Add("Карма пилота");
            dt.Columns.Add("Мощь флота");
            ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

            foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
            {
                DataRow row = ds.Tables["pilot"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                row["Никнейм"] = r.Cells[1].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                row["uID"] = r.Cells[0].Value;
                row["Корпорация"] = r.Cells[2].Value;
                row["Тэг"] = r.Cells[3].Value;
                row["Сыграно битв"] = r.Cells[4].Value;
                row["Винрейт"] = r.Cells[5].Value;
                row["Убийств"] = r.Cells[6].Value;
                row["Убийств за бой"] = r.Cells[7].Value;
                row["Убийств Смертей"] = r.Cells[8].Value;
                row["Помощи за бой"] = r.Cells[9].Value;
                row["Урона за бой"] = r.Cells[10].Value;
                row["Лечения за бой"] = r.Cells[11].Value;
                row["Карма пилота"] = r.Cells[12].Value;
                row["Мощь флота"] = r.Cells[13].Value;
                ds.Tables["pilot"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
            }
            ds.WriteXml("fleet_data.xml");
        }                                             
        public void export_to_csv()                                               // Экспорт данных в .csv файл
        {
            string fileCSV = "";
            saveFileDialog1.Filter = "Файлы csv|*.csv";
            saveFileDialog1.ShowDialog();
            for (int f = 0; f < dataGridView1.ColumnCount; f++)
            {
                fileCSV += (dataGridView1.Columns[f].HeaderText + ";");

            }
            fileCSV += "\t\n"; //тут была загвоздка
            for (int i = 0; i < dataGridView1.RowCount ; i++)
            {

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {

                    fileCSV += (dataGridView1[j, i].Value).ToString() + ";";
                }

                fileCSV += "\t\n";
            }
            StreamWriter wr = new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.GetEncoding("windows-1251"));
            wr.Write(fileCSV);
            wr.Close();
        }
        public void clear_data()                                                  // Функция очистки таблицы с данными
        {
            dataGridView1.Rows.Clear();
            load_to_csv_button.Enabled = false;
            load_to_exel_button.Enabled = false;
            load_to_xml_button.Enabled = false;
        }
        public void read_log_for_gamelist()                                       // Функция считывания логфайла для получения списка игр, и списка пилотов в играх
        {
            this.comboBox1.ResetText();
            this.comboBox1.Items.Clear();
            List <string> game = new List<string>();
             
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "combat.log | combat.log"; // открываем файл
            string dir = Application.StartupPath + "\\player_for_game";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            string startgame = "Start gameplay";                  // так же элемент для проверки
            string player_example = "Spawn SpaceShip for player"; // элемент для проверки
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fs1 = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                StreamReader read = new StreamReader(fs1, Encoding.UTF8);
                while (true)
                {
                    string strings = read.ReadLine();
                    if (strings == null)
                    {
                        break;
                    }

                    else
                        if (strings.Contains(startgame))
                    {
                        game.Add(strings);
                    }
                    else
                        continue;
                }
                read.Close();
                fs1.Close();
                FileStream fs2 = new FileStream(open.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                using (StreamReader reader = new StreamReader(fs2, Encoding.UTF8))
                    for (int i = 0; i < game.Count; i++)
                    {
                        List<string> players = new List<string>();
                        while (true)
                        {
                            string player = reader.ReadLine();
                            if (player == null)
                            {
                                break;
                            }
                            if (player.Contains("Start PVE mission"))
                            {
                                break;
                            }
                            if (player.Contains(game.ElementAt(i)))
                            {
                                continue;
                            }
                            if (player.Contains(game.ElementAt(game.Count - 1)))
                            {
                                break;
                            }
                            if (i < game.Count - 1)
                            {
                                if (player.Contains(game.ElementAt(i + 1)))
                                {
                                    break;
                                }
                            }

                            if (player.Contains(player_example))
                            {
                                string q = player.Substring(player.IndexOf('(') + 1);
                                q = q.Remove(q.IndexOf(','));
                                if (players.Contains(q))
                                {
                                    continue;
                                }
                                else players.Add(q);
                            }

                        }
                        string g = game.ElementAt(i).Substring(46);
                        string times = game.ElementAt(i);
                        times = times.Remove(times.IndexOf(' '), times.Length - times.IndexOf(' '));
                        times = times.Replace(':', '.');
                        var gg = g.Remove(g.IndexOf(','), g.Length - g.IndexOf(','));

                        string path = dir + "\\" + times + " [" + gg + "].txt";
                        bool append = false;                                                       // Если нужно перезаписывать файл
                        StreamWriter outputs = new StreamWriter(path, append);                     // Создаем поток для записи в файл

                        if (!File.Exists(path))
                        {
                            File.Create(path);                                 // Если файла не существует, создаем
                        }

                        for (int j = 0; j < players.Count; j++)
                        {
                            outputs.WriteLine(players.ElementAt(j));
                        }
                        outputs.Close();
                        this.comboBox1.Items.Add(new SelectData(path, times + " [" + gg + "]"));
                    }
                fs2.Close();
            }

        }

        private void new_pilots_Click(object sender, EventArgs e)
        {
            clear_data();
            new_file_dialog();
            load_to_datagridview_table.Enabled = true;
        }

        private void find_file_Click(object sender, EventArgs e)
        {
            FocusFile(pilots_list);
        }

        private void open_file_Click(object sender, EventArgs e)
        {
            open_file_dialog();
        }

        private void load_to_datagridview_table_Click(object sender, EventArgs e)
        {
            clear_data();
            load_data();
        }

        private void clean_data_Click(object sender, EventArgs e)
        {
            clear_data();
        }

        private void clean_flot_initialize_Click(object sender, EventArgs e)
        {
            clean_flot_realization.Enabled = true;
        }

        private void clean_flot_realization_Click(object sender, EventArgs e)
        {
            clean_flot();
        }

        private void load_to_exel_button_Click(object sender, EventArgs e)
        {
            export_to_exel();
        }

        private void load_to_xml_button_Click(object sender, EventArgs e)
        {
            export_to_xml();
            DialogResult result = MessageBox.Show("Таблица экспортирована \nОткрыть расположение таблицы?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                System.Diagnostics.Process.Start("explorer.exe", @"/select, " + "fleet_data.xml");
            }
        }

        private void load_to_csv_button_Click(object sender, EventArgs e)
        {
            export_to_csv();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinishExcel(app);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FinishExcel(app);
        }

        private void read_log_button_Click(object sender, EventArgs e)
        {
            
        }

        private void work_button_Click(object sender, EventArgs e)
        {
            read_log_for_gamelist();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_to_datagridview_table.Enabled = true;
            
            pilots_list = ((SelectData)this.comboBox1.SelectedItem).Value;
            flot_have.Text = null;
            StreamReader new_stream_combo = new StreamReader(pilots_list);      // создаем поток для считывания списка пилотов
            while (!new_stream_combo.EndOfStream)                                       // пока не прочитаем весь файл
            {
                flot_have.Text = flot_have.Text + new_stream_combo.ReadLine() + Environment.NewLine; // добавляем пилотов текстбокс с составом флота
            }
            new_stream_combo.Close();
        }
    }
    class SelectData
    {
        public readonly string Value;
        public readonly string Text;
        public SelectData(string Value, string Text)
        {
            this.Value = Value;
            this.Text = Text;
        }
        public override string ToString()
        {
            return this.Text;
        }
    }
}
