using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab8_CRUD
{
    public partial class Form1 : Form
    {
        private string connectionString =
            @"Server=.\SQLEXPRESS;Database=StudentDB;Integrated Security=True;";

        private DataTable studentsTable;
        private int? selectedId = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadStudents()
        {
            try
            {
                string sql = "SELECT Id, FullName, Age, GroupName, AverageGrade FROM Students ORDER BY Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    studentsTable = new DataTable();
                    adapter.Fill(studentsTable);
                }

                dataGridViewStudents.DataSource = studentsTable;
                UpdateCounter();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCounter()
        {
            int count = studentsTable?.Rows.Count ?? 0;
            labelCounter.Text = $"Всего студентов: {count}";
        }

        private void ClearFields()
        {
            textBoxName.Text = "";
            numericAge.Value = 15;
            textBoxGroup.Text = "";
            numericGrade.Value = 0;
            selectedId = null;
            dataGridViewStudents.ClearSelection();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите ФИО студента.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxGroup.Text))
            {
                MessageBox.Show("Введите название группы.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool StudentExists(string fullName, int? excludeId = null)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Students WHERE FullName = @name";
                if (excludeId.HasValue)
                    sql += " AND Id <> @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", fullName);
                    if (excludeId.HasValue)
                        command.Parameters.AddWithValue("@id", excludeId.Value);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
            labelStatus.Text = "Данные загружены";
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null) return;
            if (dataGridViewStudents.CurrentRow.DataBoundItem == null) return;

            DataRowView row = (DataRowView)dataGridViewStudents.CurrentRow.DataBoundItem;

            selectedId = Convert.ToInt32(row["Id"]);
            textBoxName.Text = row["FullName"].ToString();
            numericAge.Value = Convert.ToDecimal(row["Age"]);
            textBoxGroup.Text = row["GroupName"].ToString();
            numericGrade.Value = Convert.ToDecimal(row["AverageGrade"]);

            labelStatus.Text = $"Выбран Id = {selectedId}";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (StudentExists(textBoxName.Text.Trim()))
            {
                MessageBox.Show("Студент с таким ФИО уже существует.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"INSERT INTO Students (FullName, Age, GroupName, AverageGrade)
                               VALUES (@name, @age, @group, @grade)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    command.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    command.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                    command.Parameters.AddWithValue("@grade", (double)numericGrade.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                labelStatus.Text = "Студент добавлен";
                LoadStudents();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Выберите студента в таблице.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            if (StudentExists(textBoxName.Text.Trim(), selectedId))
            {
                MessageBox.Show("Другой студент с таким ФИО уже существует.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"UPDATE Students
                               SET FullName = @name, Age = @age, GroupName = @group, AverageGrade = @grade
                               WHERE Id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", textBoxName.Text.Trim());
                    command.Parameters.AddWithValue("@age", (int)numericAge.Value);
                    command.Parameters.AddWithValue("@group", textBoxGroup.Text.Trim());
                    command.Parameters.AddWithValue("@grade", (double)numericGrade.Value);
                    command.Parameters.AddWithValue("@id", selectedId.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                labelStatus.Text = "Данные обновлены";
                LoadStudents();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Выберите студента в таблице.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Удалить студента \"{textBoxName.Text}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                string sql = "DELETE FROM Students WHERE Id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", selectedId.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                labelStatus.Text = "Студент удалён";
                LoadStudents();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Ошибка БД: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            labelStatus.Text = "Поля очищены";
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            if (studentsTable == null || studentsTable.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV-файл (*.csv)|*.csv";
                dialog.FileName = "students.csv";

                if (dialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Id;FullName;Age;GroupName;AverageGrade");

                    foreach (DataRow row in studentsTable.Rows)
                    {
                        sb.AppendLine($"{row["Id"]};{row["FullName"]};{row["Age"]};{row["GroupName"]};{row["AverageGrade"]}");
                    }

                    File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
                    labelStatus.Text = $"Экспортировано в {dialog.FileName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            LoadStudents();
            ClearFields();
            labelStatus.Text = "Изменения отменены, данные перезагружены";
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}