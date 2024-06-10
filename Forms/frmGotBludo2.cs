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

namespace sweet_shop.Forms
{
    public partial class frmGotBludo2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmGotBludo2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Product> products = _context.Product.Include(p => p.Measurement).ToList();
            for (int i = 0; i < products.Count; i++)
            {
                dataGridView1.Rows.Add(products[i].Id, products[i].Name, products[i].Measurement.Name, products[i].Amount, products[i].Sum);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var product = await _context.Product.FindAsync(id);
                    frmGotBludo form = new frmGotBludo(_context);
                    frmGotBludo.insertOrUpdate = false;
                    frmGotBludo.product = product;
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись, которую хотите редактировать!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form9_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmGotBludo form = new frmGotBludo(_context);
            frmGotBludo.insertOrUpdate = true;
            form.ShowDialog();
            updateDGV();
        }

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var product = await _context.Product.FindAsync(id);
                    frmGotBludo form = new frmGotBludo(_context);
                    frmGotBludo.insertOrUpdate = false;
                    frmGotBludo.product = product;
                    form.ShowDialog();
                    updateDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись, которую хотите редактировать!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var product = await _context.Product.FindAsync(id);
                    if (product != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Product.Remove(product);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updateDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись, которую хотите удалить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddControls(Form f, Form mainForm)
        {
            mainForm.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            mainForm.Controls.Add(f);
            f.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            AddControls(new frmIngredienty2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            AddControls(new frmIngredienty2(_context), this);
        }
    }
}
