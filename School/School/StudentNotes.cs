using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School
{
    public partial class StudentNotes : Form
    {
        public StudentNotes()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=EVREM_ANKA;Initial Catalog=school;Integrated Security=True");
        public string number;
        private void StudentNotes_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select Lesson.ClassName,Exam1,Exam2,Project,Average from Notes inner join Lesson on Lesson.ClassId = Notes.ClassId where StudentId=@s1 ", con);
            cmd.Parameters.AddWithValue("@s1",number);
            this.Text = number;
            SqlDataAdapter da= new SqlDataAdapter(cmd); 
            DataTable dt = new DataTable();
            da.Fill(dt);   
            dataGridView1.DataSource = dt;  
        }
    }
}
