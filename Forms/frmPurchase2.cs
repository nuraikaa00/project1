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
    public partial class frmPurchase2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmPurchase2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var purchaseOfSupply = await _context.PurchaseOfSupply.FindAsync(id);
                    if (purchaseOfSupply != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.PurchaseOfSupply.Remove(purchaseOfSupply);
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

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<PurchaseOfSupply> purchaseOfSupplies = _context.PurchaseOfSupply.Include(p => p.Staff).Include(p => p.Supply).ToList();
            for (int i = 0; i < purchaseOfSupplies.Count; i++)
            {
                dataGridView1.Rows.Add(purchaseOfSupplies[i].Id, purchaseOfSupplies[i].Supply.Name, purchaseOfSupplies[i].Amount, purchaseOfSupplies[i].Sum, purchaseOfSupplies[i].Date, purchaseOfSupplies[i].Staff.Fio);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form8_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmPurchase form = new frmPurchase(_context);
            frmPurchase.insertOrUpdate = true;
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
                    var purchaseOfSupply = await _context.PurchaseOfSupply.FindAsync(id);
                    frmPurchase form = new frmPurchase(_context);
                    frmPurchase.insertOrUpdate = false;
                    frmPurchase.purchaseOfSupply = purchaseOfSupply;
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
                    var purchaseOfSupply = await _context.PurchaseOfSupply.FindAsync(id);
                    if (purchaseOfSupply != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.PurchaseOfSupply.Remove(purchaseOfSupply);
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
        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
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
            AddControls(new frmInventory2(_context), this);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddControls(new frmInventory2(_context), this);
        }
    }
}
