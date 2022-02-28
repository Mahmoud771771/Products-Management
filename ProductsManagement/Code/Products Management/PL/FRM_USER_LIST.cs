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
    public partial class FRM_USER_LIST : Form
    {
        BL.CLSLOGIN login = new BL.CLSLOGIN();
        public FRM_USER_LIST()
        {
            InitializeComponent();

            this.dgvUser.DataSource = login.SearchUser("");
        }

       

       

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.btnSave.Text = "حفظ الستخدم";
            frm.ShowDialog();
            this.dgvUser.DataSource = login.SearchUser("");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.txtID.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            frm.txtfullName.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
            frm.txtPWD.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            frm.txtPWDConfirm.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            frm.cmbType.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
            frm.btnSave.Text = "تعديل الستخدم";
            frm.ShowDialog();
            this.dgvUser.DataSource = login.SearchUser("");

        }


        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            this.dgvUser.DataSource = login.SearchUser(txtSearchUSER.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف المستخدم", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                login.DELETE_USER(dgvUser.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تم الحذ بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvUser.DataSource = login.SearchUser(txtSearchUSER.Text);

            }
        }
    }
}
