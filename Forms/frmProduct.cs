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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sweet_shop.Forms
{
    public partial class frmProduct : Form
    {
        private readonly SecondModuleContext _context;
        public static Supply supply;
        public static List<Measurement> measurements;
        public static List<Supplier> supplier;
        public static bool insertOrUpdate; //true - insert

        public frmProduct(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            supply = new Supply();
            insertOrUpdate = true;
            measurements = new List<Measurement>();
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
        public void GetSupplier() 
        {
            supplier = _context.Supplier.ToList(); 
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = supplier;
            comboBox2.DataSource = bindingSource1.DataSource;
            comboBox2.DisplayMember = "organization";
            comboBox2.ValueMember = "organization";
        }

        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           
            getMeasurements();
            comboBox1.Text = "";
            GetSupplier();
            comboBox2.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = supply.Id + "";
            textBox2.Text = supply.Name;
            textBox3.Text = supply.Amount + "";
            getMeasurements();
            comboBox1.SelectedItem = supply.Measurement;
            GetSupplier();
            comboBox2.SelectedItem = supply.Supplier;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form17_Load(object sender, EventArgs e)
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        supply.Amount = Convert.ToDecimal(textBox3.Text);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        supply.Name = textBox2.Text;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        supply.MeasurementId = m.Id;
                        Supplier s = (Supplier)comboBox2.SelectedItem;
                        supply.SupplierID = s.id;
                        _context.Add(supply);
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
                    supply.Amount = Convert.ToDecimal(textBox3.Text);

                    try
                    {
                        supply.Amount = Convert.ToDecimal(textBox3.Text);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        supply.Name = textBox2.Text;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        supply.MeasurementId = m.Id;
                        Supplier s = (Supplier)comboBox2.SelectedItem;
                        supply.SupplierID = s.id;
                        _context.Update(supply);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
