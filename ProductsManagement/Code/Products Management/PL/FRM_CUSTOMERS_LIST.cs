using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management.PL
{
    public partial class FRM_CUSTOMERS_LIST : Form
    {
        BL.CLS_CUSTOMER cust = new BL.CLS_CUSTOMER();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();
            this.dgvCustomer.DataSource = cust.GET_ALL_CUSTOMERS();
            this.dgvCustomer.Columns[0].Visible = false;
            this.dgvCustomer.Columns[5].Visible = false;


        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
