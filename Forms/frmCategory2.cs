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
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace sweet_shop.Forms
{
    public partial class frmCategory2 : Form
    {
        private readonly SecondModuleContext _context;
        public static Category category;
        public static bool insertOrUpdate; // true - вставка
        public frmCategory2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            category = new Category();
            insertOrUpdate = true;
        }
        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public void inputForm()
        {
            textBox1.Text = category.Id.ToString(); 
            textBox2.Text = category.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCategory2_Load(object sender, EventArgs e)
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
            if (textBox2.Text != "")
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        category.Name = textBox2.Text;
                        _context.Add(category);
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
                        category.Name = textBox2.Text;
                        _context.Update(category);
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
