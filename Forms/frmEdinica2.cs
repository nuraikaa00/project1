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
    public partial class frmEdinica2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmEdinica2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Measurement> measurments = _context.Measurement.ToList();
            for (int i = 0; i < measurments.Count; i++)
            {
                dataGridView1.Rows.Add(measurments[i].Id, measurments[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEdinica form = new frmEdinica(_context);
            frmEdinica.insertOrUpdate = true;
            form.Show();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
           
        }

        private void Form5_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var measurement = await _context.Measurement.FindAsync(id);
                    frmEdinica form = new frmEdinica(_context);
                    frmEdinica.insertOrUpdate = false;
                    frmEdinica.measurement = measurement;
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
            frmEdinica form = new frmEdinica(_context);
            frmEdinica.insertOrUpdate = true;
            form.ShowDialog();
            updateDGV();
        }

        private async void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var measurment = await _context.Measurement.FindAsync(id);
                    if (measurment != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Measurement.Remove(measurment);
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
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddControls(new frmProduct2(_context), this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmPurchase2(_context), this);
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
