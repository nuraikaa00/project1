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
    public partial class frmSotrudniki : Form
    {
        private readonly SecondModuleContext _context;
        public static Staff staff;
        public static List<Position> positions;
        public static bool insertOrUpdate; //true - insert

        public frmSotrudniki(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            staff = new Staff();
            insertOrUpdate = true;
            positions = new List<Position>();
        }

        public void getPositions()
        {
            positions = _context.Position.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = positions;
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
            textBox5.Text = "";
            getPositions();
            comboBox1.Text = "";
        }

        public void inputForm()
        {
            textBox1.Text = staff.Id + "";
            textBox2.Text = staff.Fio;
            textBox3.Text = staff.Salary + "";
            textBox4.Text = staff.Address;
            textBox5.Text = staff.PhoneNumber;
            getPositions();
            comboBox1.SelectedItem = staff.Position;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form14_Load(object sender, EventArgs e)
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
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.SelectedItem != null)
            {
                if (insertOrUpdate)
                {
                    try
                    {
                        staff.Salary = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        staff.Fio = textBox2.Text;
                        staff.Address = textBox4.Text;
                        staff.PhoneNumber = textBox5.Text;
                        Position p = (Position)comboBox1.SelectedItem;
                        staff.PositionId = p.Id;
                        _context.Add(staff);
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
                        staff.Salary = Convert.ToDecimal(textBox3.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверный тип данных! Введите правильно и повторите попытку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    try
                    {
                        staff.Fio = textBox2.Text;
                        staff.Address = textBox4.Text;
                        staff.PhoneNumber = textBox5.Text;
                        Position p = (Position)comboBox1.SelectedItem;
                        staff.PositionId = p.Id;
                        _context.Update(staff);
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
