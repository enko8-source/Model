using BusinessLogic;
using System;
using System.Windows.Forms;

namespace DecanatPROForms
{
    public partial class Form2 : Form
    {
        private readonly Logic _logic;

        public Form2(Logic logic)
        {
            InitializeComponent();
            _logic = logic;
            SetupTexts();
        }

        void SetupTexts()
        {
            this.Text = "Добавление студента";
            label1.Text = "ФИО:";
            label2.Text = "Специальность:";
            label3.Text = "Группа:";
            button1.Text = "Добавить";
            groupBox2.Text = "Управление списком";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}