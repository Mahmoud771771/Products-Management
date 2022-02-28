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
// To transaction filetybe

namespace Products_Management.PL
{
    public partial class FRM_CUSTOMER : Form
    {
        BL.CLS_CUSTOMER cust = new BL.CLS_CUSTOMER();
        int id ,Postion;
        public FRM_CUSTOMER()
        {

            InitializeComponent();
            this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }


        private void btnAdd_click_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Picture;
                if (pbox.Image == null)
                {
                    Picture = new byte[0];
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image");
                    MessageBox.Show("تمت الإضافة بنجاح ", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
                else
                {
                    // to stor picture  tybe biary
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);// to stor image on memoryStream
                    Picture = ms.ToArray();

                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image");
                    MessageBox.Show("تمت الإضافة بنجاح ", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();
                }
            }
            catch
            {

                return;
            }
            finally
            {
                btnAdd_click.Enabled = false;
                button1.Enabled = true;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("العميل المراد التعديل عليه غير موجود");
                    return;
                }

                byte[] Picture;
                if (pbox.Image == null)
                {
                    Picture = new byte[0];
                    cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image",id);
                    MessageBox.Show("تم التعديل بنجاح ", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

                }
                else
                {
                    // to stor picture  tybe biary
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);// to stor image on memoryStream
                    Picture = ms.ToArray();

                    cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image",id);
                    MessageBox.Show("تم التعديل بنجاح ", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();
                }
            }
            catch
            {

                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("العميل المراد حذفه غير موجود");
                return;
            }
            if (MessageBox.Show("هل تريد فعلا حذف هذا العميل ", "الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.Delete_Customer(id);
                MessageBox.Show("تم الحذف بنجاح ", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = cust.GET_ALL_CUSTOMERS();

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Postion == cust.GET_ALL_CUSTOMERS().Rows.Count-1)
            {
                MessageBox.Show("هذا هو أخر عميل");
                return;
            }
            Postion += 1;
            Navigate(Postion);
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "ملفات الصور|*.JPG;*.PNG;*.GIF";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            pbox.Image = null;
            txtFirstName.Focus();
            btnAdd_click.Enabled = true;
            button1.Enabled = false;
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_click.Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                pbox.Image = null;
                id= Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value);
                this.txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] Picture = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(Picture);
                pbox.Image = Image.FromStream(ms);//بجيب الصوره من ال stream
            }
            catch {

                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cust.Search_Customer(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10_Click(sender,e);
                
            }
        }

        void Navigate(int Indx) {
            try { 
            pbox.Image = null;
            DataTable Dt = cust.GET_ALL_CUSTOMERS();
            id = Convert.ToInt32(Dt.Rows[Indx][0]);
            txtFirstName.Text = Dt.Rows[Indx][1].ToString();
            txtLastName.Text = Dt.Rows[Indx][2].ToString();
            txtTel.Text = Dt.Rows[Indx][3].ToString();
            txtEmail.Text = Dt.Rows[Indx][4].ToString();

            byte[] Picture = (byte[])Dt.Rows[Indx][5];
            MemoryStream ms = new MemoryStream(Picture);
            pbox.Image = Image.FromStream(ms);//بجيب الصوره من ال stream
            }
            catch
            {
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Postion == 0)
            {
                MessageBox.Show("هذا هو أول عميل");
                return;
            }
            Postion -= 1;
            Navigate(Postion);
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            Postion = cust.GET_ALL_CUSTOMERS().Rows.Count - 1;
            Navigate(Postion); 
        }
    }
}
