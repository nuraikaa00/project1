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
    public partial class frmProdaja : Form
    {
        private readonly SecondModuleContext _context;

        public frmProdaja(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<SaleOfProduct> saleOfProducts = _context.SaleOfProduct.Include(s => s.Product).Include(s => s.Staff).ToList();
            for (int i = 0; i < saleOfProducts.Count; i++)
            {
                dataGridView1.Rows.Add(saleOfProducts[i].Id, saleOfProducts[i].Product.Name, saleOfProducts[i].Amount, saleOfProducts[i].Sum, saleOfProducts[i].Date, saleOfProducts[i].Staff.Fio);
            }
        }

        private async void button3_Click_1Async(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var saleOfProduct = await _context.SaleOfProduct.FindAsync(id);
                    if (saleOfProduct != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.SaleOfProduct.Remove(saleOfProduct);
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmProdaja2 form = new frmProdaja2(_context);
            frmProdaja2.insertOrUpdate = true;
            form.Show();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var saleOfProduct = await _context.SaleOfProduct.FindAsync(id);
                    frmProdaja2 form = new frmProdaja2(_context);
                    frmProdaja2.insertOrUpdate = false;
                    frmProdaja2.saleOfProduct = saleOfProduct;
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

        private void Form11_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }
    }
}
