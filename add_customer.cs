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
    public partial class add_customer : Form
    {
        static string s = "server=SAGAR-SS;database=profound15_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public add_customer()
        {
            InitializeComponent();
        }

        private void add_customer_Load(object sender, EventArgs e)
        {
            autoincrement();
        }
        public void autoincrement()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(cid) from add_customer", con);
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
        public void cleardata()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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
            cmd.CommandText = "insert into add_customer values(@p1,@p2,@p3,@p4)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", gender);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);         
            DialogResult res = MessageBox.Show("Do you want to Add New Customer ", "Added Customer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();
            cleardata();
            autoincrement();           
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
                MessageBox.Show("Entre the 10 Digit Mobile Num ");
                textBox3.Focus();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {//not in use
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
