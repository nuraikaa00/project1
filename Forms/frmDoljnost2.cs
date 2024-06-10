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
    public partial class frmDoljnost2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmDoljnost2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            updateDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void updateDGV()
        {
            dataGridView1.Rows.Clear();
            List<Position> positions = _context.Position.ToList();
            for (int i = 0; i < positions.Count; i++)
            {
                dataGridView1.Rows.Add(positions[i].Id, positions[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
           
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmDoljnost form = new frmDoljnost(_context);
            frmDoljnost.insertOrUpdate = true;
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
                    var position = await _context.Position.FindAsync(id);
                    frmDoljnost form = new frmDoljnost(_context);
                    frmDoljnost.insertOrUpdate = false;
                    frmDoljnost.position = position;
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
                    var position = await _context.Position.FindAsync(id);
                    if (position != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Position.Remove(position);
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
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            AddControls(new frmSotrudniki2(_context), this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AddControls(new frmSotrudniki2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
