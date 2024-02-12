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
    public partial class view_orders : Form
    {
        static string s = "server=SAGAR-SS;database=profound15_juice_shop;integrated security=true";
        SqlConnection con = new SqlConnection(s);
        public view_orders()
        {
            InitializeComponent();
        }

        private void view_orders_Load(object sender, EventArgs e)
        {
            data();
        }
        public void data()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from orders ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
