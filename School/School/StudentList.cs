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
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=EVREM_ANKA;Initial Catalog=school;Integrated Security=True");

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        public void List()
        {

            dataGridView1.DataSource = ds.StudentsList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Clubs", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbName.ValueMember = "ClubId";
            cmbName.DisplayMember = "ClubName";
            cmbName.DataSource = dt;
            con.Close();
        }
        private void StudentList_Load(object sender, EventArgs e)
        {
            List(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.StudentAdd(txtName.Text, txtLastName.Text, byte.Parse (cmbName.SelectedValue.ToString()));
            MessageBox.Show("the student added!");
            List();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            ds.StudentDelete(byte.Parse(txtId.Text));
            MessageBox.Show("student Deleted");
            List(); 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {// this part was not complete! you should look at part again!
            txtId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {// I cannot update I don't know Why
            try
            {
                // Validate and parse cmbName.SelectedValue
                if (cmbName.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid name.");
                    return;
                }

                if (!byte.TryParse(cmbName.SelectedValue.ToString(), out byte selectedValue))
                {
                    MessageBox.Show("The selected value is not in a valid format.");
                    return;
                }

                // Validate and parse txtId.Text
                if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out int studentId))
                {
                    MessageBox.Show("Please enter a valid student ID.");
                    return;
                }

                // Call the update method
                ds.StudentUpdate(txtName.Text, txtLastName.Text,byte.Parse( cmbName.SelectedValue.ToString()),int.Parse(txtId.Text));

                MessageBox.Show("Student updated!");

                // Refresh the list
                List();
            }
            catch (Exception ex)
            {
                // Log the exception or show a generic error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



    }
}
