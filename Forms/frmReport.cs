using sweet_shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace sweet_shop.Forms
{
  
    public partial class frmReport : Form
    {
        ReportManager reportManager = new ReportManager();
        DatabaseManager dbManager=new DatabaseManager();
        public frmReport()
        {
            reportViewer1 = new ReportViewer();
            dbManager = new DatabaseManager();
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DataTable dt = dbManager.ExecuteQuery("Select * From View_SupplyR");
            reportManager.LoadReport(dt, "Report1", reportViewer1);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DataTable dt = dbManager.ExecuteQuery("Select * From View_SupplyR");
            reportManager.LoadReport(dt, "Report1", reportViewer1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DataTable dt = dbManager.ExecuteQuery("Select* From View_ProdajaR");
            reportManager.LoadReport(dt, "Report2", reportViewer1);
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            DataTable dt = dbManager.ExecuteQuery("Select* From View_ProdajaR");
            reportManager.LoadReport(dt, "Report2", reportViewer1);
        }
    }
}
