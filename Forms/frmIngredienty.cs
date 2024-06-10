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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sweet_shop.Forms
{
    public partial class frmIngredienty : Form
    {
        private readonly SecondModuleContext _context;
        public static Ingredient ingredient;
        public static List<Supply> supplies;
        public static bool insertOrUpdate; //true - insert
        public Product productSelected;
        private frmIngredienty2 form6;

        public frmIngredienty(SecondModuleContext context, Product product, frmIngredienty2 form6)
        {
            InitializeComponent();
            _context = context;
            ingredient = new Ingredient();
            insertOrUpdate = true;
            supplies = new List<Supply>();
            productSelected = product;
            this.form6 = form6;
        }

        public void getProductsAndSupplies()
        {
            var bindingSource1 = new BindingSource();

            supplies = _context.Supply.ToList();
            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = supplies;
            comboBox2.DataSource = bindingSource2.DataSource;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Name";
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            getProductsAndSupplies();
            comboBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = ingredient.Id + "";
            textBox2.Text = ingredient.Amount + "";
            getProductsAndSupplies();
            comboBox2.SelectedItem = ingredient.Supply;
            textBox2.Text = ingredient.Amount + "";
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            //// Задаем начальное положение формы
            //this.StartPosition = FormStartPosition.Manual;

            //// Получаем размеры рабочей области экрана
            //int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            //int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            //// Вычисляем координаты для размещения формы
            //int formWidth = this.Width;
            //int formHeight = this.Height;

            //// Вычисляем смещения
            //int topOffset = 10; // смещение от верхнего края на 10 мм
            //int rightOffset = (int)(screenWidth * 0.3); // смещение от правого края на 15% от ширины экрана
            //int bottomOffset = 10; // смещение вниз на 10 мм

            //// Вычисляем координаты формы
            //int formLeft = screenWidth - formWidth - rightOffset;
            //int formTop = (screenHeight - formHeight) / 2 + topOffset + bottomOffset;

            //// Устанавливаем координаты формы
            //this.Left = formLeft;
            //this.Top = formTop;
            if (insertOrUpdate)
            {
                clearForm();
            }
            else
            {
                inputForm();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    Supply s = (Supply)comboBox2.SelectedItem;
                    if (form6.ingredients.FindLast(i => i.Supply.Id == s.Id) != null)
                    {
                        MessageBox.Show(
                            "Такой ингредиент уже существует!",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                        return;
                    }
                    try
                    {
                        ingredient.Amount = Convert.ToDecimal(textBox2.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        Product p = productSelected;
                        s = (Supply)comboBox2.SelectedItem;
                        ingredient.ProductId = p.Id;
                        ingredient.SupplyId = s.Id;
                        _context.Add(ingredient);
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
                        ingredient.Amount = Convert.ToDecimal(textBox2.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        Product p = productSelected;
                        Supply s = (Supply)comboBox2.SelectedItem;
                        ingredient.ProductId = p.Id;
                        ingredient.SupplyId = s.Id;
                        _context.Update(ingredient);
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
