using sweet_shop.Models;
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

namespace sweet_shop.Forms
{
    public partial class frmInventory : Form
    {
        private readonly SecondModuleContext _context;
        public static List<Supply> supply;
        public static Inventory inventory;
        public static List<Measurement> measurements;
        public static List<Staff> staff;
        public static bool insertOrUpdate; //true - insert
        public frmInventory(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            supply = new List<Supply>();
            insertOrUpdate = true;
            measurements = new List<Measurement>();
            staff = new List<Staff>();
            inventory = new Inventory();
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
        public void GetStaff()
        {
            staff = _context.Staff.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = staff;
            comboBox2.DataSource = bindingSource1.DataSource;
            comboBox2.DisplayMember = "fio";
            comboBox2.ValueMember = "fio";
        }
        public void GetSupply()
        {
            supply = _context.Supply.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = supply;
            comboBox3.DataSource = bindingSource1.DataSource;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "name";
        }
        public void clearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
      

            getMeasurements();
            comboBox1.Text = "";
            GetSupply();
            GetStaff();
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = inventory.Id + "";
            comboBox1.SelectedItem = inventory.Name;
            GetSupply();
            getMeasurements();
            comboBox1.SelectedItem = inventory.Measurement;
            textBox3.Text = inventory.Amount + "";
            GetStaff();
            comboBox2.SelectedItem = inventory.Staff;
            textBox2.Text = inventory.Amount_Supp + "";
         

        }

        private void frmInventory_Load(object sender, EventArgs e)
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.SelectedItem != null && textBox3.Text != "" && comboBox1.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        inventory.Amount = Convert.ToDecimal(textBox3.Text);
                        inventory.Amount_Supp = Convert.ToDecimal(textBox2.Text);
                    

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        inventory.Date = DateTime.Now;
                        Supply s = (Supply)comboBox3.SelectedItem;
                        inventory.Name = s.Id;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        inventory.Measurement_id = m.Id;
                        Staff c = (Staff)comboBox2.SelectedItem;
                        inventory.Staff_id = c.Id;
                        inventory.Diff = inventory.Amount_Supp - inventory.Amount;
                        _context.Add(inventory);
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
                    inventory.Amount = Convert.ToDecimal(textBox3.Text);
                    inventory.Amount_Supp = Convert.ToDecimal(textBox2.Text);
                 


                    try
                    {
                        inventory.Amount = Convert.ToDecimal(textBox3.Text);
                        inventory.Amount_Supp = Convert.ToDecimal(textBox2.Text);
                   


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        inventory.Date = DateTime.Now;
                        Supply s = (Supply)comboBox3.SelectedItem;
                        inventory.Name = s.Id;
                        Measurement m = (Measurement)comboBox1.SelectedItem;
                        inventory.Measurement_id = m.Id;
                        Staff c = (Staff)comboBox2.SelectedItem;
                        inventory.Staff_id = c.Id;
                        inventory.Diff = inventory.Amount_Supp - inventory.Amount;
                        _context.Update(inventory);
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                Supply selectedSupply = comboBox3.SelectedItem as Supply;
                textBox2.Text = selectedSupply.Amount.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
       
            
        }
    }
}
