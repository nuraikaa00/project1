using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_shop.Forms
{
    public partial class frmDoljnost : Form
    {
        private readonly SecondModuleContext _context;
        public static Position position;
        public static bool insertOrUpdate; //true - insert

        public frmDoljnost(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            position = new Position();
            insertOrUpdate = true;
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = position.Id + "";
            textBox2.Text = position.Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form13_Load(object sender, EventArgs e)
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
                        position.Name = textBox2.Text;
                        _context.Add(position);
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
                        position.Name = textBox2.Text;
                        _context.Update(position);
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
