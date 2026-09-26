using BusinessLogic;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DecanatPROForms
{
    public partial class Form1 : Form
    {
        private readonly Logic _logic = new Logic();

        public Form1()
        {
            
            InitializeComponent();
            SeedData();
            SetupGrid();
            SetupChart();
            SetupTexts();
            RefreshGrid();
            BuildHistogram();
        }

        void SeedData()
        {
            _logic.AddStudent("Иванов Иван Иванович", "ИВТ", "ИВТ-21-1");
            _logic.AddStudent("Петров Пётр Петрович", "ИВТ", "ИВТ-21-1");
            _logic.AddStudent("Сидоров Сидор Сидорович", "ПМИ", "ПМИ-21-2");
            _logic.AddStudent("Иванов Иван Иванович", "ИВТ", "ИВТ-21-1");
            _logic.AddStudent("Кузнецова Анна Сергеевна", "ИБ", "ИБ-21-3");
            _logic.AddStudent("Смирнов Алексей Олегович", "ПМИ", "ПМИ-21-2");
            _logic.AddStudent("Волкова Мария Дмитриевна", "ИБ", "ИБ-21-3");
            _logic.AddStudent("Иванов Иван Иванович", "ПМИ", "ПМИ-21-2");
        }

        void SetupTexts()
        {
            button1.Text = "Добавить";
            button2.Text = "Удалить";
            groupBox1.Text = "Список";
            
        }

        void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "ФИО"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSpec",
                HeaderText = "Специальность"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGroup",
                HeaderText = "Группа"
            });
        }

        void SetupChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();

            chart1.Titles.Add("Распределение студентов по специальностям");

            ChartArea area = new ChartArea("main");
            area.AxisX.Title = "Специальность";
            area.AxisY.Title = "Кол-во студентов";
            area.AxisX.Interval = 1;
            chart1.ChartAreas.Add(area);

            Series series = new Series("Students");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Color = Color.Pink;
            chart1.Series.Add(series);
        }

        void RefreshGrid()
        {
            dataGridView1.Rows.Clear();

            var students = _logic.GetStudentsForView();
            foreach (var s in students)
                dataGridView1.Rows.Add(s[0], s[1], s[2], s[3]);
        }

        void BuildHistogram()
        {
            chart1.Series["Students"].Points.Clear();

            var data = _logic.GetDistributionBySpeciality();
            foreach (var pair in data)
                chart1.Series["Students"].Points.AddXY(pair.Key, pair.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_logic);
            form2.ShowDialog();

            RefreshGrid();
            BuildHistogram();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента в таблице", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells["colId"].Value.ToString());

                _logic.DeleteStudent(id);
                RefreshGrid();
                BuildHistogram();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}