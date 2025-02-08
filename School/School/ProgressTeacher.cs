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


namespace School
{
    public partial class ProgressTeacher : Form
    {
        public ProgressTeacher()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clubs club = new clubs();
            club.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lessons lesson = new Lessons();
            lesson.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentList students = new StudentList();   
            students.Show();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exams exam = new Exams();   
            exam.Show();
        }
    }
}
