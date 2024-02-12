using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Juice_Shop_Billing_System
{
    public partial class add_employee : Form
    {
        static string s = "server=SAGAR-SS;database=profound15_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public add_employee()
        {
            InitializeComponent();
        }

        private void add_employee_Load(object sender, EventArgs e)
        {
            autoincrement();
            data();
        }
        public void autoincrement()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(eid) from add_employee", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string d = dr[0].ToString();
                if (d == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    r = Convert.ToInt16(dr[0].ToString());
                    r = r + 1;
                    textBox1.Text = r.ToString();
                }
            }
            dr.Close();
            con.Close();
        }
        public void data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from add_employee", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }
        public void cleardata()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {  // insert
            string gender;
            if (radioButton1.Checked == true)
                gender = "Male";
            else if (radioButton2.Checked == true)
                gender = "Female";
            else
                gender = "Other";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into add_employee values(@p1,@p2,@p3,@p4,@p5,@p6)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", gender);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@p6", textBox4.Text);
            DialogResult res = MessageBox.Show("Do you want to Add New Employee ", "Added Employee", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "Male")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                textBox3.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { // update
            string gender;
            if (radioButton1.Checked == true)
                gender = "Male";
            else if (radioButton2.Checked == true)
                gender = "Female";
            else
                gender = "Other";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update add_employee set name=@p2,gender=@p3,mob=@p4,doj=@p5,salary=@p6 where eid=@p1";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", gender);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@p6", textBox4.Text);
            DialogResult res = MessageBox.Show("Do you want to Update Employee ", "Updated Employee", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            data();
        }

        private void button3_Click(object sender, EventArgs e)
        {  // delete
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from add_employee where eid=@p1";
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);          
            DialogResult res = MessageBox.Show("Do you want to Delete Employee ", "Deleted Employee", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();
            data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("only number are allow");
                textBox3.Focus();
            }   
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 10)
            {
            }
            else
            {
                MessageBox.Show("Enter the 10 Digit Mobile Num ");
                textBox3.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("only number are allow");
                textBox4.Focus();
            }   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
