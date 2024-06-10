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
    public partial class frmBludo : Form
    {
        private readonly SecondModuleContext _context;

        public frmBludo(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<ProductionOfProduct> productionOfProducts = _context.ProductionOfProduct.Include(p => p.Product).Include(p => p.Staff).ToList();
            for (int i = 0; i < productionOfProducts.Count; i++)
            {
                dataGridView1.Rows.Add(productionOfProducts[i].Id, productionOfProducts[i].Product.Name, productionOfProducts[i].Amount, productionOfProducts[i].Date, productionOfProducts[i].Prize, productionOfProducts[i].Staff.Fio);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form10_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmBludo2 form = new frmBludo2(_context);
            frmBludo2.insertOrUpdate = true;
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
                    var productionOfProduct = await _context.ProductionOfProduct.FindAsync(id);
                    frmBludo2 form = new frmBludo2(_context);
                    frmBludo2.insertOrUpdate = false;
                    frmBludo2.productionOfProduct = productionOfProduct;
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
                    var productionOfProduct = await _context.ProductionOfProduct.FindAsync(id);
                    if (productionOfProduct != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.ProductionOfProduct.Remove(productionOfProduct);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updateDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
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
        private void label4_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context), this);
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategory(_context), this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategory(_context), this);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            AddControls(new frmExpence(_context), this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmExpence(_context), this);
        }
    }
}
