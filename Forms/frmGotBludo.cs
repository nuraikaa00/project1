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
    public partial class frmGotBludo : Form
    {
        private readonly SecondModuleContext _context;
        public static Product product;
        public static List<Measurement> measurements;
        public static bool insertOrUpdate; //true - insert

        public frmGotBludo(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            product = new Product();
            measurements = new List<Measurement>();
            insertOrUpdate = true;
        }

        public void getMeasurements()
        {
            measurements = _context.Measurement.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = measurements;
            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            getMeasurements();
            comboBox1.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = product.Id + "";
            textBox2.Text = product.Name;
            textBox3.Text = product.Amount + "";
            textBox4.Text = product.Sum + "";
            getMeasurements();
            comboBox1.SelectedItem = product.Measurement;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form19_Load(object sender, EventArgs e)
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

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        product.Amount = Convert.ToDecimal(textBox3.Text);
                        product.Sum = Convert.ToDecimal(textBox4.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        product.Name = textBox2.Text;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        product.MeasurementId = m.Id;
                        _context.Add(product);
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
                        product.Amount = Convert.ToDecimal(textBox3.Text);
                        product.Sum = Convert.ToDecimal(textBox4.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        product.Name = textBox2.Text;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        product.MeasurementId = m.Id;
                        _context.Update(product);
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
