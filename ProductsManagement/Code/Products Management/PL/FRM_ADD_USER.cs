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
    public partial class FRM_ADD_USER : Form
    {
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtPWD.Text == string.Empty || txtfullName.Text == string.Empty || txtPWDConfirm.Text == string.Empty) {

                MessageBox.Show(" لم يتم اضافه المستخدم بنجاح ", "إضافة مستخدم جديد ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show(" كلمة السر غير مطابقه  ", "تنبيه  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSave.Text == "حفظ المستخدم")
            {
                BL.CLSLOGIN user = new BL.CLSLOGIN();
                user.ADD_USER(txtID.Text, txtfullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تمت اضافه المستخدم بنجاح ", "إضافة مستخدم جديد ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnSave.Text == "تعديل الستخدم") {

                BL.CLSLOGIN user = new BL.CLSLOGIN();
                user.EDIT_USER(txtID.Text, txtfullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تمت تعديل المستخدم بنجاح ", "تعديل مستخدم  ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }


            txtID.Clear();
            txtPWD.Clear();
            txtfullName.Clear();
            txtPWDConfirm.Clear();
            txtID.Focus();

        }

        private void txtPWDConfirm_Validated(object sender, EventArgs e)
        {
            if (txtPWD.Text!=txtPWDConfirm.Text) {
                MessageBox.Show(" كلمة السر غير مطابقه  ", "تنبيه  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

       
    }
}
