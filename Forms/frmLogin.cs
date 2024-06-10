using Guna.UI2.WinForms;
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
    public partial class frmLogin : Form
    {
        private readonly SecondModuleContext _context;
        public frmLogin(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (!Login.IsValidUser(txtUser.Text, txtPass.Text, out string role))
            {
                guna2MessageDialog1.Show("Неверный логин или пароль!");
                return;
            }

            // Открываем основную форму для всех пользователей и передаем роль
            this.Hide();
            Main mainForm = new Main(_context, role);
            mainForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
