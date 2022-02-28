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
    public partial class FRM_ADD_PRODUCT : Form
    {
        public string state = "add";
        BL.CLS_PROUDCTS prd = new BL.CLS_PROUDCTS();
        public FRM_ADD_PRODUCT()
        {
            InitializeComponent();
            cmbCategories.DataSource = prd.GET_ALL_CATEGORTES();
            cmbCategories.DisplayMember = "Description";
            cmbCategories.ValueMember = "ID";


        }

      

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ////////
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream(); // memory to storage image 
                pbox.Image.Save(ms, pbox.Image.RawFormat);// image storaage to ====> ms , rawformat return typefile image 
                byte[] byteImage = ms.ToArray();// storage memory in array as like 0 and 1
                prd.ADD_PROUDCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text, txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);
                MessageBox.Show("تمت الاضافه بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MemoryStream ms = new MemoryStream(); // memory to storage image 
                pbox.Image.Save(ms, pbox.Image.RawFormat);// image storaage to ====> ms , rawformat return typefile image 
                byte[] byteImage = ms.ToArray();// storage memory in array as like 0 and 1
                prd.UPDATE_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text, txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);
                MessageBox.Show("تمت التعديل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FRM_PRODUCTS.getMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            }
            FRM_PRODUCTS.getMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        }
     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "ملفات الصور|*.JPG;*.PNG;*.GIF";
            if (OFD.ShowDialog() == DialogResult.OK)
            {

                pbox.Image = Image.FromFile(OFD.FileName);
            }
        }

        private void txtRef_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable Dt = new DataTable();
                Dt = prd.verifyProductID(txtRef.Text);
                if (Dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا المعرف موجود مسبقا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();// to select text 
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;
                }
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDes_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
