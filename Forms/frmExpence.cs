using Microsoft.EntityFrameworkCore;
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
    public partial class frmExpence : Form
    {
        private readonly SecondModuleContext _context;
        public frmExpence(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Expence> expence = _context.Expence.Include(p => p.Category).ToList();
            for (int i = 0; i < expence.Count; i++)
            {
                dataGridView1.Rows.Add(expence[i].Id, expence[i].Name, expence[i].Category.Name, expence[i].Summ, expence[i].Comment, expence[i].Date);
            }
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmExpence2 form = new frmExpence2(_context);
            frmExpence2.insertOrUpdate = true;
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
                    var expence = await _context.Expence.FindAsync(id);
                    frmExpence2 form = new frmExpence2(_context);
                    frmExpence2.insertOrUpdate = false;
                    frmExpence2.expence = expence;
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
                    var expence = await _context.Expence.FindAsync(id);
                    if (expence != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Expence.Remove(expence);
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

        private void frmExpence_Load(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmBudjet2(_context), this);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
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
    }
}
