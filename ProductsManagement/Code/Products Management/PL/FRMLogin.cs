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
    public partial class FRMLogin : Form
    {
        BL.CLSLOGIN log = new BL.CLSLOGIN();
        public FRMLogin()
        {
            InitializeComponent();
        }

        private void FRMLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][2].ToString() == "مدير")
                {
                    FRM_main.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;

                    FRM_main.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_main.getMainForm.المستخدمونToolStripMenuItem.Enabled = true;
                    FRM_main.getMainForm.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_main.getMainForm.إستعادةنسخةمحفوظةToolStripMenuItem.Enabled = true;
                    Program.Salesman = Dt.Rows[0]["FullName"].ToString();

                    this.Close();

                }

                else if (Dt.Rows[0][2].ToString() == "عادي")
                {
                    FRM_main.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;

                    FRM_main.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_main.getMainForm.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_main.getMainForm.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_main.getMainForm.إستعادةنسخةمحفوظةToolStripMenuItem.Enabled = true;
                    Program.Salesman = Dt.Rows[0]["FullName"].ToString();

                    this.Close();

                }
            }
            else {
                MessageBox.Show("Login Failed");
            }
        }
    }
}
