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
    public partial class frmProduct2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmProduct2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
           
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Supply> supplies = _context.Supply.Include(s => s.Measurement).Include(s => s.Supplier).ToList();
            for (int i = 0; i < supplies.Count; i++)
            {
                dataGridView1.Rows.Add(supplies[i].Id, supplies[i].Name, supplies[i].Measurement.Name, supplies[i].Amount, supplies[i].Supplier.organization);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProduct form = new frmProduct(_context);
            frmProduct.insertOrUpdate = true;
            form.Show();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form7_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var supply = await _context.Supply.FindAsync(id);
                    if (supply != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Supply.Remove(supply);
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

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var supply = await _context.Supply.FindAsync(id);
                    frmProduct form = new frmProduct(_context);
                    frmProduct.insertOrUpdate = false;
                    frmProduct.supply = supply;
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

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmProduct form = new frmProduct(_context);
            frmProduct.insertOrUpdate = true;
            form.ShowDialog();
            updateDGV();
        }
        public void AddControls(Form f, Form mainForm)
        {
            mainForm.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            mainForm.Controls.Add(f);
            f.Show();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            AddControls(new frmEdinica2(_context), this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddControls(new frmEdinica2(_context), this);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            AddControls(new frmInventory2(_context), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddControls(new frmInventory2(_context), this);
        }
    }
}
