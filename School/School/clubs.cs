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
    public partial class clubs : Form
    {
        public clubs()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=EVREM_ANKA;Initial Catalog=school;Integrated Security=True");
        public void List()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Clubs ",con);
            DataTable dt = new DataTable(); 
            da.Fill(dt);    
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Clubs set ClubName=@c1 where ClubId=@c2",con);
            cmd.Parameters.AddWithValue("@c2", textBox1.Text);
            cmd.Parameters.AddWithValue("@c1",textBox2.Text);
            cmd.ExecuteNonQuery();  
            List();
            con.Close();
            MessageBox.Show("the club updated!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Clubs (ClubName) values (@c1)",con);
            cmd.Parameters.AddWithValue("@c1",textBox2.Text);
            cmd.ExecuteNonQuery();
            List();
            con.Close();
            MessageBox.Show("the club added!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Clubs where ClubId = @c",con);
            cmd.Parameters.AddWithValue("@c",textBox1.Text);
            cmd.ExecuteNonQuery();  
            List(); 
            con.Close();
            MessageBox.Show("the club deleted!"); ;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.LightBlue;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor= Color.Transparent;    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

    }
}
