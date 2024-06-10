using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_shop.Forms
{
    public partial class frmFinance : Form
    {
        private readonly SecondModuleContext _context;
        public frmFinance(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
