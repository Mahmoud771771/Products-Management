using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Products_Management.PL
{
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        DataTable DT = new DataTable();

        void CalculateAmount()
        {
            if (txtPrice.Text != string.Empty && txtQty.Text != string.Empty)
            {
                double Amount = Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text);
                txtAmount.Text = Amount.ToString();
            }
        }

        void CalculateTotalAmount()
        {
            if (txtDiscount.Text != string.Empty&&txtAmount.Text!=string.Empty)
            {
                double Discount = Convert.ToDouble(txtDiscount.Text);
                double Amount = Convert.ToDouble(txtAmount.Text);
                double TotalAmount = Amount - (Amount * (Discount / 100));
                txtTotalAmount.Text = TotalAmount.ToString();
            }
        }

        void ClearBox() {
            txtIDProducts.Clear();
            txtNameProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtAmount.Clear();
            txtDiscount.Clear();
            txtTotalAmount.Clear();
            btnBrowse.Focus();

        }
        void ClearData() {

            txtOrderID.Clear();
            txtDesOrder.Clear();
            dtorder.ResetText();
          
            txtCustomersID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            ClearBox();
            txtSumTotal.Clear();
            pbox.Image = null;
            DT.Clear();
            dgvProducts.DataSource = null;
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnPrint.Enabled = true;


        }
        void CreateDataTable()
        {

            DT.Columns.Add("معرف المنتوج ");
            DT.Columns.Add("إسم  المنتوج ");
            DT.Columns.Add("الثمن ");
            DT.Columns.Add("الكميه ");
            DT.Columns.Add("المبلغ  ");
            DT.Columns.Add(" نسبه الخصم (%)");
            DT.Columns.Add("المبلغ الاجمالي ");

            dgvProducts.DataSource = DT;

            //// Add button to dataGridview
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "اختيار منتج ";
            //btn.Text = "البحث";
            //btn.UseColumnTextForButtonValue = true;
            //dgvProducts.Columns.Insert(0, btn);

        }

        void ResizeDGV()
        {
            this.dgvProducts.RowHeadersWidth = 100;
            //this.dgvProducts.Columns[0].Width = 99;
            //this.dgvProducts.Columns[1].Width = 198;
            //this.dgvProducts.Columns[2].Width = 119;
            //this.dgvProducts.Columns[3].Width = 113;
            //this.dgvProducts.Columns[4].Width = 113;
            //this.dgvProducts.Columns[5].Width = 99;
            //this.dgvProducts.Columns[6].Width = 120;


        }
        public FRM_ORDERS()
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtsalesman.Text = Program.Salesman;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            if (frm.dgvCustomer.CurrentRow.Cells[5].Value is DBNull)
            {
                MessageBox.Show("هذا العميل لا يحتوي علي صوره ");
                this.txtCustomersID.Text =frm.dgvCustomer.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomer.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomer.CurrentRow.Cells[4].Value.ToString();
                pbox.Image = null;
                return;
            }
            this.txtCustomersID.Text = frm.dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            this.txtFirstName.Text = frm.dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            this.txtLastName.Text = frm.dgvCustomer.CurrentRow.Cells[2].Value.ToString();
            this.txtTel.Text = frm.dgvCustomer.CurrentRow.Cells[3].Value.ToString();
            this.txtEmail.Text = frm.dgvCustomer.CurrentRow.Cells[4].Value.ToString();
            byte[] custPicture = (byte[])frm.dgvCustomer.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(custPicture);
            pbox.Image = Image.FromStream(ms);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearBox();

            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtIDProducts.Text = frm.dgvProductsList.CurrentRow.Cells[0].Value.ToString();
            txtNameProduct.Text = frm.dgvProductsList.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProductsList.CurrentRow.Cells[3].Value.ToString();
            txtQty.Focus();


        }



      

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPrice.Text != string.Empty)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtQty.Text != string.Empty)
            {
                txtDiscount.Focus();
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (order.VerifyQTy(txtOrderID.Text, Convert.ToInt32(txtQty.Text)).Rows.Count < 1)
                {
                    MessageBox.Show(" هذه الكميه غير متوفره ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < dgvProducts.Rows.Count - 1; i++) {

                    if (dgvProducts.Rows[i].Cells[0].Value.ToString() == txtIDProducts.Text) {

                        MessageBox.Show(" هذا المنتج تم اداخاله مسبقا ", "تنبيه ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                  

                }
                DataRow r = DT.NewRow();
                r[0] = txtIDProducts.Text;
                r[1] = txtNameProduct.Text;
                r[2] = txtPrice.Text;
                r[3] = txtQty.Text;
                r[4] = txtAmount.Text;
                r[5] = txtDiscount.Text;
                r[6] = txtTotalAmount.Text;
                DT.Rows.Add(r);
                dgvProducts.DataSource = DT;
                ClearBox();

                txtSumTotal.Text =
                    (from DataGridViewRow row in dgvProducts.Rows
                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIDProducts.Text = this.dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtNameProduct.Text = this.dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = this.dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQty.Text = this.dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtAmount.Text = this.dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtDiscount.Text = this.dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = this.dgvProducts.CurrentRow.Cells[6].Value.ToString();
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                txtQty.Focus();
            }
            catch {

                return;
            }

        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtSumTotal.Text =
                   (from DataGridViewRow row in dgvProducts.Rows
                    where row.Cells[6].FormattedValue.ToString() != string.Empty
                    select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }



        private void تعديلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dgvProducts_DoubleClick(sender, e);
        }

        private void حذفالسطرالحالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
        }

        private void حذفالكلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DT.Clear();
            dgvProducts.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
           if(txtOrderID.Text==string.Empty||txtCustomersID.Text==string.Empty||dgvProducts.Rows.Count<1||txtDesOrder.Text==string.Empty)
            {
                MessageBox.Show("ينبغي تسجيل المعلومات المهمه ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtorder.Value, Convert.ToInt32(txtCustomersID.Text), txtDesOrder.Text, txtsalesman.Text);
            // ضافه المنتجات المدخله

            for (int i = 0; i < dgvProducts.Rows.Count - 1; i++) {

                order.ADD_ORDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                    Convert.ToInt32(txtOrderID.Text),
                    Convert.ToInt32(dgvProducts.Rows[i].Cells[3].Value),
                    dgvProducts.Rows[i].Cells[2].Value.ToString(),
                    Convert.ToInt32(dgvProducts.Rows[i].Cells[5].Value),
                    dgvProducts.Rows[i].Cells[4].Value.ToString(),
                    dgvProducts.Rows[i].Cells[6].Value.ToString());
            }
            MessageBox.Show("تمت عمليه الحفظ بنجاح "," عملية الحفظ  ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ClearData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // get the last order 
            this.Cursor = Cursors.WaitCursor;
            int order_id =Convert.ToInt32( order.GET_LAST_ORDER_ID_forPrint().Rows[0][0]);
            RPT.rpt_Orders report = new RPT.rpt_Orders();
            RPT.FRM_RPT_PROUDUCT frm = new RPT.FRM_RPT_PROUDUCT();
            report.SetDataSource(order.GETORDERDETILS(order_id));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
