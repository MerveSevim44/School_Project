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
using System.Data.SqlClient;
using System.Xml.Linq;


namespace School
{
    public partial class Exams : Form
    {
        public Exams()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=EVREM_ANKA;Initial Catalog=school;Integrated Security=True");

        DataSet1TableAdapters.NotesTableAdapter ds = new DataSet1TableAdapters.NotesTableAdapter();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentNotes(byte.Parse(txtLessonId.Text),byte.Parse(txtId.Text));
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void Exams_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Lesson", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbLesson.ValueMember = txtLessonId.Text;
            cmbLesson.DisplayMember = "ClassName";
            cmbLesson.DataSource = dt;
       
            con.Close();
        }
   
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {  txtNoteId.Text  = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAvr.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtOcc.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
             cmbLesson.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); 
            
        }
        int exam1, exam2,project;
        double average;
        private void btnCal_Click(object sender, EventArgs e)
        {// How do I turn average into double
             exam1= Convert.ToInt32(txtExam1.Text);  
             exam2 = Convert.ToInt32(txtExam2.Text); 
             project= Convert.ToInt32(txtProject.Text);
             average = (exam1 + exam2 + project)/3;
           
            txtAvr.Text = average.ToString();

           
            if(average > 50)
            {
                txtOcc.Text = "True";
            }

            else
            {
                txtOcc.Text= "False";   
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.LessonUpdate(int.Parse(cmbLesson.SelectedValue.ToString()), int.Parse(txtId.Text),byte.Parse(txtExam1.Text), byte.Parse(txtExam2.Text), byte.Parse(txtProject.Text), decimal.Parse(txtAvr.Text), bool.Parse(txtOcc.Text),int.Parse(txtNoteId.Text ));
            
        }
    }
}
