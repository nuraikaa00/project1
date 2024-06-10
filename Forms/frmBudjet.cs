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
    public partial class frmBudjet : Form
    {
        private readonly SecondModuleContext _context;
        public static Budget budget;

        public frmBudjet(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
          
            textBox1.Text = budget.Id.ToString();
            textBox2.Text = budget.SumOfBudget.ToString();
          
        }

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    budget.SumOfBudget = Convert.ToDecimal(textBox2.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                try
                {
                    _context.Update(budget);
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
                MessageBox.Show("Заполните все поля прежде чем сохранять!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
