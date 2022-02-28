using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace Products_Management.PL
{
    public partial class FRM_CATEGORIES : Form
    {
        SqlConnection sqlcon = new SqlConnection("Server=.;Database=ProductDB;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt=new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select ID as 'المعرف',Description as 'الصنف' from Categories", sqlcon);
            da.Fill(dt);
            dgList.DataSource = dt;
            txtID.DataBindings.Add("text", dt, "المعرف");
            txtDES.DataBindings.Add("text", dt, "الصنف");
            bmb = this.BindingContext[dt];
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count; 
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnadd.Enabled = true;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0])+1;//last opject and add 1 
            txtID.Text = id.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnadd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Deleted Successfuly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_categories rpt = new RPT.rpt_all_categories();
            RPT.FRM_RPT_PROUDUCT frm = new RPT.FRM_RPT_PROUDUCT();
            rpt.Refresh();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

       

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {
            RPT.rpt_Single_Categories rpt = new RPT.rpt_Single_Categories();
            RPT.FRM_RPT_PROUDUCT frm = new RPT.FRM_RPT_PROUDUCT();
            rpt.SetParameterValue("@id", Convert.ToInt32(txtID.Text));
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void exportToPdfAll_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_categories MyReport = new RPT.rpt_all_categories();
            // create Export Option
            ExportOptions export = new ExportOptions();
            // Create Object For destination
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            PdfFormatOptions PDFFormat = new PdfFormatOptions();
            // set the Path Destination
            dfoption.DiskFileName = @"E:/CategoriesList.pdf";
           export = MyReport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            //set the type of Document
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            //formate the PDF Document
            export.ExportFormatOptions = PDFFormat;
            export.ExportDestinationOptions = dfoption;
            MyReport.Refresh();
            MyReport.Export();
            MessageBox.Show("LIst   Exported successfuly!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void exportToPdfCurrent_Click(object sender, EventArgs e)
        {

            RPT.rpt_Single_Categories MyReport = new RPT.rpt_Single_Categories();
            // create Export Option
            ExportOptions export = new ExportOptions();
            // Create Object For destination
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            PdfFormatOptions PDFFormat = new PdfFormatOptions();
            // set the Path Destination
            dfoption.DiskFileName = @"E:/CategoryDetails.pdf";
            export = MyReport.ExportOptions;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            //set the type of Document
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            //formate the PDF Document
            export.ExportFormatOptions = PDFFormat;
            export.ExportDestinationOptions = dfoption;
            MyReport.SetParameterValue("@id", Convert.ToInt32(txtID.Text));
            MyReport.Export();
            MessageBox.Show("LIst   Exported successfuly!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
