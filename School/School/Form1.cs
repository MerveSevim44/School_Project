using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StudentNotes notes = new StudentNotes();
            notes.number = textBox1.Text;
            notes.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProgressTeacher teach = new ProgressTeacher();   
            teach.Show();
            this.Hide();

        }
    }
}
