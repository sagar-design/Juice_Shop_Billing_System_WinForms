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
    public partial class orders : Form
    {
        static string s = "server=SAGAR-SS;database=profound15_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public orders()
        {
            InitializeComponent();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            autoincrement();
            bindcustomername();
            bindjuicename();
        }
        public void autoincrement()
        {
            int r;
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(oid) from orders", con);
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
        public void bindcustomername()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select name from add_customer", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.Show();
        }

        public void bindjuicename()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select juice_name from add_juice_price", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            comboBox2.DataSource = ds.Tables[0];
            comboBox2.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { // select customer name fetch mob no and date
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from add_customer where name='" + comboBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[3].ToString();
            }
            dr.Close();
            con.Close();
            textBox3.Text = DateTime.Now.ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { // fetch rate
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from add_juice_price where juice_name='" + comboBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr[2].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            int r, q, t;
            r = Convert.ToInt16(textBox4.Text);
            q = Convert.ToInt16(textBox5.Text);
            t = r * q;
            textBox6.Text = t.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {  // add listbox item
            listBox1.Items.Add(comboBox2.Text);
            listBox2.Items.Add(textBox4.Text);
            listBox3.Items.Add(textBox5.Text);
            listBox4.Items.Add(textBox6.Text);
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            // sum of listbox
            int sum=0;           
            for (int i = 0; i < listBox4.Items.Count; i++)
            {
                sum += Convert.ToInt16(listBox4.Items[i].ToString());
            }
            textBox7.Text = sum.ToString();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            int a, b, c;
            a = Convert.ToInt16(textBox7.Text);
            b = Convert.ToInt16(textBox8.Text);
            c = a - b;
            textBox9.Text = c.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {  // insert orders
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into orders values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p3", textBox2.Text);
            cmd.Parameters.AddWithValue("@p4", textBox3.Text);
            cmd.Parameters.AddWithValue("@p5", textBox7.Text);
            cmd.Parameters.AddWithValue("@p6", textBox8.Text);
            cmd.Parameters.AddWithValue("@p7", textBox9.Text);
            DialogResult res = MessageBox.Show("Do you want Add New Orders ", "Added Orders", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        { // clearbtn
            textBox1.Clear();
            comboBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            autoincrement();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("only number are allow");
                textBox5.Focus();
            }   
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("only number are allow");
                textBox8.Focus();
            }   
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
