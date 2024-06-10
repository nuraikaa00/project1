using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_shop.Forms
{
    public partial class frmBudjet2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmBudjet2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Budget> budgets = _context.Budget.ToList();
            for (int i = 0; i < budgets.Count; i++)
            {
                dataGridView1.Rows.Add(budgets[i].Id, budgets[i].SumOfBudget);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var budget = await _context.Budget.FindAsync(id);
                    frmBudjet form = new frmBudjet(_context);
                    frmBudjet.budget = budget;
                    form.Show();
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

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
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
            AddControls(new frmCategory(_context), this);
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
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
