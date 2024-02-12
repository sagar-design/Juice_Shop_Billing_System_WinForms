using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Juice_Shop_Billing_System
{
    public partial class Main_MDI : Form
    {
        public Main_MDI()
        {
            InitializeComponent();
        }


       
        private void addJuicePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_juice_price a = new add_juice_price();
            a.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_employee a1 = new add_employee();
            a1.Show();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_customer a2 = new add_customer();
            a2.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orders a3 = new orders();
            a3.Show();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_orders a4 = new view_orders();
            a4.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_MDI_Load(object sender, EventArgs e)
        {

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //by mistake
        }
    }
}
