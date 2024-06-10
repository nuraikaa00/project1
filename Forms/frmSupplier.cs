using Microsoft.EntityFrameworkCore;
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
    public partial class frmSupplier : Form
    {
        private readonly SecondModuleContext _context;
        public frmSupplier(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        public void updateDGV()
        {
            dataGrid.Rows.Clear();
            List<Supplier> suppliers = _context.Supplier.ToList();
            foreach (var supplier in suppliers)
            {
                dataGrid.Rows.Add(supplier.id, supplier.organization, supplier.name, supplier.number);
            }
        }
        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmSupplier2 form = new frmSupplier2(_context);
            frmSupplier2.insertOrUpdate = true;
            form.ShowDialog();
            updateDGV();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGrid.SelectedCells[0].Value);
                    var Supplier = await _context.Supplier.FindAsync(id);
                    frmSupplier2 form = new frmSupplier2(_context);
                    frmSupplier2.insertOrUpdate = false;
                    frmSupplier2.Supplier= Supplier;
                    form.ShowDialog(); 
                    updateDGV();


                }

                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста, повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updateDGV();
            }
            else
            {
                MessageBox.Show("Выберите запись, которую хотите редактировать!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGrid.SelectedCells[0].Value);
                    var Supplier = await _context.Supplier.FindAsync(id);
                    if (Supplier != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Supplier.Remove(Supplier);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updateDGV(); // Возможно, это опечатка и должно быть updateDGV()
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
    }
}
