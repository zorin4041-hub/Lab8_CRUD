namespace Lab8_CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            labelName = new Label();
            textBoxName = new TextBox();
            textBoxGroup = new TextBox();
            labelAge = new Label();
            labelGroup = new Label();
            labelFGrade = new Label();
            numericAge = new NumericUpDown();
            numericGrade = new NumericUpDown();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            labelStatus = new Label();
            buttonExportCSV = new Button();
            buttonCancel = new Button();
            labelCounter = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(207, 30);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(429, 182);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(49, 269);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 1;
            labelName.Text = "ФИО:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(22, 324);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(406, 324);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(100, 23);
            textBoxGroup.TabIndex = 4;
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(234, 269);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(53, 15);
            labelAge.TabIndex = 3;
            labelAge.Text = "Возраст:";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(423, 269);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(49, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Группа:";
            // 
            // labelFGrade
            // 
            labelFGrade.AutoSize = true;
            labelFGrade.Location = new Point(601, 269);
            labelFGrade.Name = "labelFGrade";
            labelFGrade.Size = new Size(88, 15);
            labelFGrade.TabIndex = 6;
            labelFGrade.Text = "Средний балл:";
            // 
            // numericAge
            // 
            numericAge.Location = new Point(210, 324);
            numericAge.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            numericAge.Name = "numericAge";
            numericAge.Size = new Size(120, 23);
            numericAge.TabIndex = 7;
            numericAge.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // numericGrade
            // 
            numericGrade.DecimalPlaces = 2;
            numericGrade.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericGrade.Location = new Point(601, 324);
            numericGrade.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericGrade.Name = "numericGrade";
            numericGrade.Size = new Size(120, 23);
            numericGrade.TabIndex = 8;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(821, 106);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(821, 56);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(821, 157);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(821, 210);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 12;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(376, 477);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(45, 15);
            labelStatus.TabIndex = 13;
            labelStatus.Text = "Готово";
            // 
            // buttonExportCSV
            // 
            buttonExportCSV.Location = new Point(760, 477);
            buttonExportCSV.Name = "buttonExportCSV";
            buttonExportCSV.Size = new Size(98, 23);
            buttonExportCSV.TabIndex = 14;
            buttonExportCSV.Text = "Экспорт в CSV";
            buttonExportCSV.UseVisualStyleBackColor = true;
            buttonExportCSV.Click += buttonExportCSV_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(821, 269);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelCounter
            // 
            labelCounter.AutoSize = true;
            labelCounter.Location = new Point(66, 47);
            labelCounter.Name = "labelCounter";
            labelCounter.Size = new Size(107, 15);
            labelCounter.TabIndex = 16;
            labelCounter.Text = "Всего студентов: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 573);
            Controls.Add(labelCounter);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExportCSV);
            Controls.Add(labelStatus);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(numericGrade);
            Controls.Add(numericAge);
            Controls.Add(labelFGrade);
            Controls.Add(labelGroup);
            Controls.Add(textBoxGroup);
            Controls.Add(labelAge);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа №8 - CRUDDDD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Label labelName;
        private TextBox textBoxName;
        private TextBox textBoxGroup;
        private Label labelAge;
        private Label labelGroup;
        private Label labelFGrade;
        private NumericUpDown numericAge;
        private NumericUpDown numericGrade;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
        private Label labelStatus;
        private Button buttonExportCSV;
        private Button buttonCancel;
        private Label labelCounter;
    }
}
