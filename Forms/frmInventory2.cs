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
    public partial class frmInventory2 : Form
    {
        private readonly SecondModuleContext _context;
        public frmInventory2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Inventory> inventories = _context.Inventory.Include(s => s.Measurement).Include(s => s.Supply).Include(s => s.Staff).ToList();
            for (int i = 0; i < inventories.Count; i++)
            {
                dataGridView1.Rows.Add(inventories[i].Id, inventories[i].Supply.Name, inventories[i].Measurement.Name, inventories[i].Amount, inventories[i].Amount_Supp, inventories[i].Diff,  inventories[i].Staff.Fio, inventories[i].Date);
            }
        }
        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            frmInventory form = new frmInventory(_context);
            frmInventory.insertOrUpdate = true;
            form.ShowDialog();
            updateDGV();
        }

        private void frmInventory2_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var inventory = await _context.Inventory.FindAsync(id);
                    frmInventory form = new frmInventory(_context);
                    frmInventory.insertOrUpdate = false;
                    frmInventory.inventory = inventory;
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
        public void AddControls(Form f, Form mainForm)
        {
            mainForm.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            mainForm.Controls.Add(f);
            f.Show();
        }
        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var inventory = await _context.Inventory.FindAsync(id);
                    if (inventory != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Inventory.Remove(inventory);
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

        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddControls(new frmEdinica2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            AddControls(new frmEdinica2(_context), this);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
        }
    }
}
