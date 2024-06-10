using Microsoft.EntityFrameworkCore;
using sweet_shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sweet_shop.Forms
{
    public partial class frmExpence2 : Form
    {
        private readonly SecondModuleContext _context;
        public static Expence expence;
        public static List<Category> category;
        public static bool insertOrUpdate; //true - insert
        private bool isTextBox4Changed = false;
        public frmExpence2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            expence = new Expence();
            category = new List<Category>();
            insertOrUpdate = true;
            textBox4.TextChanged += textBox4_TextChanged_1;
        }
        public void getCategory()
        {
            category = _context.Сategory.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = category;
            comboBox2.DataSource = bindingSource1.DataSource;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "name";
        }
        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            getCategory();
            textBox4.Text = "";
            comboBox2.Text = "";
           
        }

        public void inputForm()
        {
            textBox1.Text = expence.Id + "";
            textBox2.Text = expence.Name + "";
            comboBox2.SelectedItem = expence.CategoryId;
            textBox4.Text = expence.Summ + "";
            textBox3.Text = expence.Comment + "";
            getCategory();


        }
       
        //private void textBox4_TextChanged(object sender, EventArgs e)
        //{
            
        //}
        private  void button1_Click(object sender, EventArgs e)
        {

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void frmExpence2_Load(object sender, EventArgs e)
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

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            isTextBox4Changed = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "" && textBox4.Text != "" && comboBox2.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {

                        expence.Summ = Convert.ToDecimal(textBox4.Text);
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

                        if (budget.SumOfBudget < expence.Summ)
                        {
                            MessageBox.Show("Сумма расхода превышает общий бюджет! У вас не достаточно денег!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            expence.Date = DateTime.Now;
                            Category category = (Category)comboBox2.SelectedItem;
                            expence.CategoryId = category.Id;
                            expence.Name = textBox2.Text;
                            expence.Comment = textBox3.Text;

                            _context.Add(expence);
                            await _context.SaveChangesAsync();

                            budget.SumOfBudget -= expence.Summ;
                            _context.Update(budget);
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
                        expence.Summ = Convert.ToDecimal(textBox4.Text);
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

                        if (budget.SumOfBudget < expence.Summ)
                        {
                            MessageBox.Show("Сумма расхода превышает общий бюджет! У вас не достаточно денег!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            expence.Date = DateTime.Now;
                            Category category = (Category)comboBox2.SelectedItem;
                            expence.CategoryId = category.Id;
                            expence.Name = textBox2.Text;
                            expence.Comment = textBox3.Text;

                            if (isTextBox4Changed)
                            {
                                budget.SumOfBudget -= expence.Summ;
                                _context.Update(budget);
                            }
                            else
                            {
                                await _context.SaveChangesAsync();
                                _context.Update(expence);
                                await _context.SaveChangesAsync();
                            }


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
