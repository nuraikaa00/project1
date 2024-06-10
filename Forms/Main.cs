using Guna.UI2.WinForms;
using sweet_shop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace sweet_shop
{
    public partial class Main : Form
    {
        private readonly SecondModuleContext _context;
        private string _userRole;

        public Main(SecondModuleContext context, string userRole)
        {
            InitializeComponent();
            _context = context;
            _userRole = userRole;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Логика инициализации для основной формы, если необходимо
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        public void AddControls(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEdinica2 form = new frmEdinica2(_context);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmIngredienty2 form = new frmIngredienty2(_context);
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmProduct2 form = new frmProduct2(_context);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPurchase2 form = new frmPurchase2(_context);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBludo form = new frmBludo(_context);
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form = new Main(_context, _userRole); // Передача роли пользователя
            form.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new frmSotrudniki2(_context));
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddControls(new frmGotBludo2(_context));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            // Ваша логика
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context));
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddControls(new frmSupplier(_context));
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin form = new frmLogin(_context);
            form.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (_userRole == "admin")
            {
                // Открываем форму для администратора
                AddControls(new frmUsers(_context));
            }
            else
            {
                // Выводим сообщение, что пользователь не является администратором
                MessageBox.Show("Вы вошли как пользователь. Административные функции недоступны.", "Доступ ограничен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            AddControls(new frmReport());
        }
    }

}
