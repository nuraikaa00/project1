using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    public partial class frmBludo2 : Form
    {
        private readonly SecondModuleContext _context;
        public static ProductionOfProduct productionOfProduct;
        public static List<Product> products;
        public static List<Staff> staff;
        public static bool insertOrUpdate; //true - insert

        public frmBludo2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            productionOfProduct = new ProductionOfProduct();
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
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            getProductsAndStaff();
            comboBox1.Text = "";
            comboBox2.Text = "";
            
        }

        public void inputForm()
        {
            textBox1.Text = productionOfProduct.Id + "";
            textBox2.Text = productionOfProduct.Amount + "";
            textBox3.Text = productionOfProduct.Prize + " ";
            getProductsAndStaff();
            comboBox1.SelectedItem = productionOfProduct.Product;
            comboBox2.SelectedItem = productionOfProduct.Staff;
            
        }

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form20_Load(object sender, EventArgs e)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Product selectedProduct = comboBox1.SelectedItem as Product;
                textBox3.Text = selectedProduct.Sum.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        productionOfProduct.Amount = Convert.ToDecimal(textBox2.Text);
                        productionOfProduct.Prize = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        productionOfProduct.Date = DateTime.Now;
                        Product product = comboBox1.SelectedItem as Product;
                        productionOfProduct.ProductId = product.Id;
                        Staff staff = comboBox2.SelectedItem as Staff;

                        productionOfProduct.StaffId = staff.Id;


                        var supplies = _context.Supply.Include(s => s.Measurement);
                        List<Ingredient> ingredients = _context.Ingredient.Include(i => i.Product).Include(i => i.Supply).Where(i => i.ProductId == productionOfProduct.ProductId).ToList();
                        var budget = await _context.Budget
                            .FirstOrDefaultAsync(m => m.Id == 1);
                        bool check = true;
                        foreach (Ingredient ingredient in ingredients)
                        {
                            decimal temp = (decimal)(ingredient.Amount * productionOfProduct.Amount);
                            var supply = _context.Supply.FirstOrDefault(m => m.Id == ingredient.SupplyId);
                            if (temp > supply.Amount)
                            {
                                check = false;
                            }
                        }


                        decimal sums = 0;
                        foreach (Ingredient ingredient in ingredients)
                        {
                            decimal temp = (decimal)(ingredient.Amount * productionOfProduct.Amount);
                            var supply = _context.Supply.FirstOrDefault(m => m.Id == ingredient.SupplyId);

                            sums += (decimal)(productionOfProduct.Amount * ingredient.Amount);
                            supply.Amount -= temp;
                            _context.Update(supply);
                            await _context.SaveChangesAsync();
                        }
                        budget.SumOfBudget += productionOfProduct.Amount * (productionOfProduct.Prize);
                        _context.Update(budget);
                        await _context.SaveChangesAsync();


                        _context.Add(productionOfProduct);
                        await _context.SaveChangesAsync();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        productionOfProduct.Amount = Convert.ToDecimal(textBox2.Text);
                        productionOfProduct.Prize = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        productionOfProduct.Date = DateTime.Now;
                        Product product = comboBox1.SelectedItem as Product;
                        productionOfProduct.ProductId = product.Id;
                        Staff staff = comboBox2.SelectedItem as Staff;
                        productionOfProduct.StaffId = staff.Id;
                        var budget = await _context.Budget
                           .FirstOrDefaultAsync(m => m.Id == 1);
                        var supplies = _context.Supply.Include(s => s.Measurement);
                        List<Ingredient> ingredients = _context.Ingredient.Include(i => i.Product).Include(i => i.Supply).Where(i => i.ProductId == productionOfProduct.ProductId).ToList();

                        bool check = true;
                        foreach (Ingredient ingredient in ingredients)
                        {
                            decimal temp = (decimal)(ingredient.Amount * productionOfProduct.Amount);
                            var supply = _context.Supply.FirstOrDefault(m => m.Id == ingredient.SupplyId);
                            if (temp > supply.Amount)
                            {
                                check = false;
                            }
                        }


                        foreach (Ingredient ingredient in ingredients)
                        {
                            decimal temp = (decimal)(ingredient.Amount * productionOfProduct.Amount);
                            var supply = _context.Supply.FirstOrDefault(m => m.Id == ingredient.SupplyId);
                            supply.Amount -= temp;
                            _context.Update(supply);
                            await _context.SaveChangesAsync();
                        }
                        budget.SumOfBudget += productionOfProduct.Amount * (productionOfProduct.Prize);
                        _context.Update(budget);
                        await _context.SaveChangesAsync();


                        _context.Add(productionOfProduct);
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

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

