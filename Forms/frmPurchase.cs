using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sweet_shop.Forms
{
    public partial class frmPurchase : Form
    {
        private readonly SecondModuleContext _context;
        public static PurchaseOfSupply purchaseOfSupply;
        public static List<Supply> supplies;
        public static List<Staff> staff;
        public static bool insertOrUpdate; //true - insert

        public frmPurchase(SecondModuleContext context)
        {
            InitializeComponent();
            _context= context;
            purchaseOfSupply = new PurchaseOfSupply();
            supplies = new List<Supply>();
            staff = new List<Staff>();
            insertOrUpdate = true;
        }

        public void getSuppliesAndStaff()
        {
            supplies = _context.Supply.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = supplies;
            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";

            staff = _context.Staff.ToList();
            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = staff;
            comboBox2.DataSource = bindingSource2.DataSource;
            comboBox2.DisplayMember = "Fio";
            comboBox2.ValueMember = "Fio";
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            getSuppliesAndStaff();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = purchaseOfSupply.Id + "";
            textBox2.Text = purchaseOfSupply.Amount + "";
            textBox3.Text = purchaseOfSupply.Sum + "";
            getSuppliesAndStaff();
            comboBox1.SelectedItem = purchaseOfSupply.Supply;
            comboBox2.SelectedItem = purchaseOfSupply.Staff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void Form18_Load(object sender, EventArgs e)
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
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        purchaseOfSupply.Amount = Convert.ToDecimal(textBox2.Text);
                        purchaseOfSupply.Sum = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        var budget = await _context.Budget.FirstOrDefaultAsync(m => m.Id == 1);
                        if (budget == null)
                        {
                            MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (budget.SumOfBudget < purchaseOfSupply.Sum)
                        {
                            MessageBox.Show("Сумма сырья превышает общий бюджет! У вас не достаточно денег!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            purchaseOfSupply.Date = DateTime.Now;
                            Supply supply = (Supply)comboBox1.SelectedItem;
                            purchaseOfSupply.SupplyId = supply.Id;
                            Staff staff = (Staff)comboBox2.SelectedItem;
                            purchaseOfSupply.StaffId = staff.Id;

                            _context.Add(purchaseOfSupply);
                            await _context.SaveChangesAsync();

                            budget.SumOfBudget -= purchaseOfSupply.Sum;
                            _context.Update(budget);
                            await _context.SaveChangesAsync();

                            supply.Amount += purchaseOfSupply.Amount;


                            _context.Update(supply);
                            await _context.SaveChangesAsync();

                            this.Close();
                        }
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
                        purchaseOfSupply.Amount = Convert.ToDecimal(textBox2.Text);
                        purchaseOfSupply.Sum = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        var budget = await _context.Budget
                            .FirstOrDefaultAsync(m => m.Id == 1);
                        if (budget == null)
                        {
                            MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (budget.SumOfBudget < purchaseOfSupply.Sum)
                        {
                            MessageBox.Show("Сумма сырья превышает общий бюджет! У вас не достаточно денег!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            purchaseOfSupply.Date = new DateTime();
                            Supply supply = (Supply)comboBox1.SelectedItem;
                            purchaseOfSupply.SupplyId = supply.Id;
                            Staff staff = (Staff)comboBox2.SelectedItem;
                            purchaseOfSupply.StaffId = staff.Id;

                            budget.SumOfBudget -= purchaseOfSupply.Sum;
                            _context.Update(budget);
                            await _context.SaveChangesAsync();

                            supply.Amount += purchaseOfSupply.Amount;


                            _context.Update(supply);
                            await _context.SaveChangesAsync();

                            _context.Update(purchaseOfSupply);
                            await _context.SaveChangesAsync();

                            this.Close();
                        }
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
