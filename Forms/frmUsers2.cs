using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sweet_shop.Forms
{
    
    public partial class frmUsers2 : Form
    {
        private readonly SecondModuleContext _context;
        public static Users users;
        public static bool insertOrUpdate; //true - insert
        public frmUsers2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            users = new Users();
            insertOrUpdate = true;
          
        }
        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        public void inputForm()
        {
            textBox1.Text = users.Id + "";
            textBox2.Text = users.Name;
            textBox3.Text = users.Pass + "";
            textBox4.Text = users.Role + "";
        }

        private void frmUsers2_Load(object sender, EventArgs e)
        {
            if (insertOrUpdate)
            {
                clearForm();
            }
            else
            {
                inputForm();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        users.Name = textBox2.Text;
                        users.Pass = textBox3.Text;
                        users.Role = textBox4.Text;

                        _context.Add(users);
                        await _context.SaveChangesAsync();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    
                    try
                    {
                        users.Name = textBox2.Text;
                        users.Pass = textBox3.Text;
                        users.Role = textBox4.Text;

                        _context.Update(users);
                        await _context.SaveChangesAsync();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля прежде чем сохранять!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    
}
