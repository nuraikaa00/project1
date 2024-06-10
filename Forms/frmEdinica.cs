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
    public partial class frmEdinica : Form
    {
        private readonly SecondModuleContext _context;
        public static Measurement measurement;
        public static bool insertOrUpdate; //true - insert

        public frmEdinica(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            measurement = new Measurement();
            insertOrUpdate = true;
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = measurement.Id + "";
            textBox2.Text = measurement.Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form15_Load(object sender, EventArgs e)
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

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            
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
                        measurement.Name = textBox2.Text;
                        _context.Add(measurement);
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
                        measurement.Name = textBox2.Text;
                        _context.Update(measurement);
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
