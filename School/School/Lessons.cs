using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class Lessons : Form
    {
        public Lessons()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.LessonTableAdapter les = new DataSet1TableAdapters.LessonTableAdapter();
        private void Lessons_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = les.LessonList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =les.LessonList(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            les.LessonAdd(textBox2.Text);
            MessageBox.Show("the lesson added!");
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            les.LessonUpdate(textBox2.Text,byte.Parse(textBox1.Text));
            MessageBox.Show("the lesson updated!");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            les.LessonDelete(byte.Parse(textBox1.Text));
            MessageBox.Show("the lesson deleted!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
