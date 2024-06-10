using sweet_shop.Models;
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
    public partial class frmSupplier2 : Form
    {
        private readonly SecondModuleContext _context;
        public static Supplier Supplier;
        public static bool insertOrUpdate; //true - insert

        public frmSupplier2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            Supplier = new Supplier();
            insertOrUpdate = true;
        }
        public void inputForm()
        {
            textBox1.Text = Supplier.id + "";
            textBox2.Text = Supplier.organization;
            textBox3.Text = Supplier.name;
            textBox5.Text = Supplier.number;
        }
        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private  void button1_Click(object sender, EventArgs e)
        {
                
            }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmSupplier2_Load(object sender, EventArgs e)
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

        private  void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                try
                {
                    Supplier.organization = textBox2.Text;
                    Supplier.name = textBox3.Text;
                    Supplier.number = textBox5.Text;

                    if (insertOrUpdate)
                    {
                        _context.Add(Supplier);
                    }
                    else
                    {
                        _context.Update(Supplier);
                    }

                    await _context.SaveChangesAsync();
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста, повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля прежде чем сохранять!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
