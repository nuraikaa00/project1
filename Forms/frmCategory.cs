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
    public partial class frmCategory : Form
    {
        private readonly SecondModuleContext _context;
        public frmCategory(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Category> сategory = _context.Сategory.ToList();
            for (int i = 0; i < сategory.Count; i++)
            {
                dataGridView1.Rows.Add(сategory[i].Id, сategory[i].Name);
            }
        }
        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmCategory2 form = new frmCategory2(_context);
            frmCategory2.insertOrUpdate = true;
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
        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var category = await _context.Сategory.FindAsync(id);
                    frmCategory2 form = new frmCategory2(_context);
                    frmCategory2.insertOrUpdate = false;
                    frmCategory2.category = category;
                    form.ShowDialog();
                    updateDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста, повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var category = await _context.Сategory.FindAsync(id);
                    if (category != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Сategory.Remove(category);
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

        private void Category_Load(object sender, EventArgs e)
        {
            updateDGV();
        }
        
        private void label4_Click(object sender, EventArgs e)
        {
            AddControls(new frmBludo(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmBludo(_context), this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context), this);
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context), this);
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
