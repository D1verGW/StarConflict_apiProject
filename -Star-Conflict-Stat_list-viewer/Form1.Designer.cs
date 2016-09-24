namespace _Star_Conflict_Stat_list_viewer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.new_pilots = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.Button();
            this.load_to_datagridview_table = new System.Windows.Forms.Button();
            this.load_to_exel_button = new System.Windows.Forms.Button();
            this.load_to_csv_button = new System.Windows.Forms.Button();
            this.load_to_xml_button = new System.Windows.Forms.Button();
            this.clean_flot_realization = new System.Windows.Forms.Button();
            this.find_file = new System.Windows.Forms.Button();
            this.clean_flot_initialize = new System.Windows.Forms.Button();
            this.flot_add = new System.Windows.Forms.TextBox();
            this.flot_have = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clean_data = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(349, 1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(920, 396);
            this.dataGridView1.TabIndex = 0;
            // 
            // new_pilots
            // 
            this.new_pilots.Location = new System.Drawing.Point(11, 116);
            this.new_pilots.Margin = new System.Windows.Forms.Padding(2);
            this.new_pilots.Name = "new_pilots";
            this.new_pilots.Size = new System.Drawing.Size(133, 53);
            this.new_pilots.TabIndex = 1;
            this.new_pilots.Text = "Добавить пилотов\r\nв космофлот";
            this.new_pilots.UseVisualStyleBackColor = true;
            this.new_pilots.Click += new System.EventHandler(this.new_pilots_Click);
            // 
            // open_file
            // 
            this.open_file.Location = new System.Drawing.Point(148, 58);
            this.open_file.Margin = new System.Windows.Forms.Padding(2);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(194, 53);
            this.open_file.TabIndex = 2;
            this.open_file.Text = "Открыть готовый список";
            this.open_file.UseVisualStyleBackColor = true;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // load_to_datagridview_table
            // 
            this.load_to_datagridview_table.Location = new System.Drawing.Point(148, 115);
            this.load_to_datagridview_table.Margin = new System.Windows.Forms.Padding(2);
            this.load_to_datagridview_table.Name = "load_to_datagridview_table";
            this.load_to_datagridview_table.Size = new System.Drawing.Size(194, 83);
            this.load_to_datagridview_table.TabIndex = 3;
            this.load_to_datagridview_table.Text = "Загрузить данные в таблицу";
            this.load_to_datagridview_table.UseVisualStyleBackColor = true;
            this.load_to_datagridview_table.Click += new System.EventHandler(this.load_to_datagridview_table_Click);
            // 
            // load_to_exel_button
            // 
            this.load_to_exel_button.Location = new System.Drawing.Point(268, 202);
            this.load_to_exel_button.Margin = new System.Windows.Forms.Padding(2);
            this.load_to_exel_button.Name = "load_to_exel_button";
            this.load_to_exel_button.Size = new System.Drawing.Size(74, 56);
            this.load_to_exel_button.TabIndex = 4;
            this.load_to_exel_button.Text = "Загрузить таблицу в Exel";
            this.load_to_exel_button.UseVisualStyleBackColor = true;
            this.load_to_exel_button.Click += new System.EventHandler(this.load_to_exel_button_Click);
            // 
            // load_to_csv_button
            // 
            this.load_to_csv_button.Location = new System.Drawing.Point(268, 262);
            this.load_to_csv_button.Margin = new System.Windows.Forms.Padding(2);
            this.load_to_csv_button.Name = "load_to_csv_button";
            this.load_to_csv_button.Size = new System.Drawing.Size(74, 66);
            this.load_to_csv_button.TabIndex = 5;
            this.load_to_csv_button.Text = "Загрузить таблицу в .csv ";
            this.load_to_csv_button.UseVisualStyleBackColor = true;
            this.load_to_csv_button.Click += new System.EventHandler(this.load_to_csv_button_Click);
            // 
            // load_to_xml_button
            // 
            this.load_to_xml_button.Location = new System.Drawing.Point(268, 332);
            this.load_to_xml_button.Margin = new System.Windows.Forms.Padding(2);
            this.load_to_xml_button.Name = "load_to_xml_button";
            this.load_to_xml_button.Size = new System.Drawing.Size(74, 65);
            this.load_to_xml_button.TabIndex = 6;
            this.load_to_xml_button.Text = "Загрузить таблицу в  .xml";
            this.load_to_xml_button.UseVisualStyleBackColor = true;
            this.load_to_xml_button.Click += new System.EventHandler(this.load_to_xml_button_Click);
            // 
            // clean_flot_realization
            // 
            this.clean_flot_realization.Location = new System.Drawing.Point(148, 332);
            this.clean_flot_realization.Margin = new System.Windows.Forms.Padding(2);
            this.clean_flot_realization.Name = "clean_flot_realization";
            this.clean_flot_realization.Size = new System.Drawing.Size(116, 65);
            this.clean_flot_realization.TabIndex = 7;
            this.clean_flot_realization.Text = "Очистить состав флота\r\n(необратимо!)";
            this.clean_flot_realization.UseVisualStyleBackColor = true;
            this.clean_flot_realization.Click += new System.EventHandler(this.clean_flot_realization_Click);
            // 
            // find_file
            // 
            this.find_file.Location = new System.Drawing.Point(11, 332);
            this.find_file.Margin = new System.Windows.Forms.Padding(2);
            this.find_file.Name = "find_file";
            this.find_file.Size = new System.Drawing.Size(133, 65);
            this.find_file.TabIndex = 8;
            this.find_file.Text = "Где находится текущий состав флота?";
            this.find_file.UseVisualStyleBackColor = true;
            this.find_file.Click += new System.EventHandler(this.find_file_Click);
            // 
            // clean_flot_initialize
            // 
            this.clean_flot_initialize.Location = new System.Drawing.Point(148, 262);
            this.clean_flot_initialize.Margin = new System.Windows.Forms.Padding(2);
            this.clean_flot_initialize.Name = "clean_flot_initialize";
            this.clean_flot_initialize.Size = new System.Drawing.Size(116, 66);
            this.clean_flot_initialize.TabIndex = 9;
            this.clean_flot_initialize.Text = "Инициация очищения флота";
            this.clean_flot_initialize.UseVisualStyleBackColor = true;
            this.clean_flot_initialize.Click += new System.EventHandler(this.clean_flot_initialize_Click);
            // 
            // flot_add
            // 
            this.flot_add.Location = new System.Drawing.Point(11, 58);
            this.flot_add.Margin = new System.Windows.Forms.Padding(2);
            this.flot_add.Multiline = true;
            this.flot_add.Name = "flot_add";
            this.flot_add.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.flot_add.Size = new System.Drawing.Size(133, 53);
            this.flot_add.TabIndex = 10;
            // 
            // flot_have
            // 
            this.flot_have.Location = new System.Drawing.Point(11, 200);
            this.flot_have.Margin = new System.Windows.Forms.Padding(2);
            this.flot_have.Multiline = true;
            this.flot_have.Name = "flot_have";
            this.flot_have.ReadOnly = true;
            this.flot_have.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.flot_have.Size = new System.Drawing.Size(133, 128);
            this.flot_have.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 48);
            this.label2.TabIndex = 13;
            this.label2.Text = "Введите никнеймы \r\n(через Enter) \r\nи нажмите кнопку";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 48);
            this.label3.TabIndex = 14;
            this.label3.Text = "Или выберите существующий \r\nфайл (.txt) c составом флота\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Состав флота:";
            // 
            // clean_data
            // 
            this.clean_data.Location = new System.Drawing.Point(148, 202);
            this.clean_data.Margin = new System.Windows.Forms.Padding(2);
            this.clean_data.Name = "clean_data";
            this.clean_data.Size = new System.Drawing.Size(116, 56);
            this.clean_data.TabIndex = 16;
            this.clean_data.Text = "Очистить таблицу";
            this.clean_data.UseVisualStyleBackColor = true;
            this.clean_data.Click += new System.EventHandler(this.clean_data_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 408);
            this.Controls.Add(this.clean_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flot_have);
            this.Controls.Add(this.flot_add);
            this.Controls.Add(this.clean_flot_initialize);
            this.Controls.Add(this.find_file);
            this.Controls.Add(this.clean_flot_realization);
            this.Controls.Add(this.load_to_xml_button);
            this.Controls.Add(this.load_to_csv_button);
            this.Controls.Add(this.load_to_exel_button);
            this.Controls.Add(this.load_to_datagridview_table);
            this.Controls.Add(this.open_file);
            this.Controls.Add(this.new_pilots);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Star Conflict] Статистика флотилии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button new_pilots;
        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.Button load_to_datagridview_table;
        private System.Windows.Forms.Button load_to_exel_button;
        private System.Windows.Forms.Button load_to_csv_button;
        private System.Windows.Forms.Button load_to_xml_button;
        private System.Windows.Forms.Button clean_flot_realization;
        private System.Windows.Forms.Button find_file;
        private System.Windows.Forms.Button clean_flot_initialize;
        private System.Windows.Forms.TextBox flot_add;
        private System.Windows.Forms.TextBox flot_have;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clean_data;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

