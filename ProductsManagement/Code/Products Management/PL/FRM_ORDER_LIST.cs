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
    public partial class FRM_ORDER_LIST : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        public FRM_ORDER_LIST()
        {
            InitializeComponent();
            this.dgvOrder.DataSource = order.SearchOrders("");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            try {

                this.dgvOrder.DataSource = order.SearchOrders(txtSearchOrder.Text);

            }
            catch {
                return;
            }
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dgvOrder.CurrentRow.Cells[0].Value);
            RPT.rpt_Orders report = new RPT.rpt_Orders();
            RPT.FRM_RPT_PROUDUCT frm = new RPT.FRM_RPT_PROUDUCT();
            report.SetDataSource(order.GETORDERDETILS(order_id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
