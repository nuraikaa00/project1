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
    public partial class frmProdaja2 : Form
    {
        private readonly SecondModuleContext _context;
        public static SaleOfProduct saleOfProduct;
        public static List<Product> products;
        public static List<Staff> staff;
        public static bool insertOrUpdate; //true - insert

        public frmProdaja2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            saleOfProduct = new SaleOfProduct();
            products = new List<Product>();
            staff = new List<Staff>();
            insertOrUpdate = true;
        }

        public void getProductsAndStaff()
        {
            products = _context.Product.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = products;
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
            getProductsAndStaff();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = saleOfProduct.Id + "";
            textBox2.Text = saleOfProduct.Amount + "";
            getProductsAndStaff();
            comboBox1.SelectedItem = saleOfProduct.Product;
            comboBox2.SelectedItem = saleOfProduct.Staff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();       
        }

        private void Form21_Load(object sender, EventArgs e)
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

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        saleOfProduct.Amount = Convert.ToDecimal(textBox2.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        saleOfProduct.Date = DateTime.Now;
                        Product product = comboBox1.SelectedItem as Product;
                        saleOfProduct.ProductId = product.Id;
                        Staff staff = comboBox2.SelectedItem as Staff;
                        saleOfProduct.StaffId = staff.Id;

                        var budget = await _context.Budget
                            .FirstOrDefaultAsync(m => m.Id == 1);
                        if (budget == null)
                        {
                            MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (saleOfProduct.Amount > product.Amount)
                        {
                            MessageBox.Show("Недостаточно продукции на складе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            decimal averageSumOfProduct = (decimal)(product.Sum / product.Amount);
                            product.Amount -= saleOfProduct.Amount;
                            product.Sum -= averageSumOfProduct * saleOfProduct.Amount;
                            _context.Update(product);
                            await _context.SaveChangesAsync();

                            saleOfProduct.Sum = averageSumOfProduct * saleOfProduct.Amount;

                            budget.SumOfBudget += saleOfProduct.Sum + (saleOfProduct.Sum);
                            _context.Update(budget);
                            await _context.SaveChangesAsync();
                        }

                        _context.Add(saleOfProduct);
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
                        saleOfProduct.Amount = Convert.ToDecimal(textBox2.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        saleOfProduct.Date = DateTime.Now;
                        Product product = comboBox1.SelectedItem as Product;
                        saleOfProduct.ProductId = product.Id;
                        Staff staff = comboBox1.SelectedItem as Staff;
                        saleOfProduct.ProductId = staff.Id;

                        var budget = await _context.Budget
                            .FirstOrDefaultAsync(m => m.Id == 1);
                        if (budget == null)
                        {
                            MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (saleOfProduct.Amount > product.Amount)
                        {
                            MessageBox.Show("Недостаточно продукции на складе!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            decimal averageSumOfProduct = (decimal)(product.Sum / product.Amount);
                            product.Amount -= saleOfProduct.Amount;
                            product.Sum -= averageSumOfProduct * saleOfProduct.Amount;
                            _context.Update(product);
                            await _context.SaveChangesAsync();

                            saleOfProduct.Sum = averageSumOfProduct * saleOfProduct.Amount;

                            budget.SumOfBudget += saleOfProduct.Sum + (saleOfProduct.Sum);
                            _context.Update(budget);
                            await _context.SaveChangesAsync();
                        }

                        _context.Add(saleOfProduct);
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
