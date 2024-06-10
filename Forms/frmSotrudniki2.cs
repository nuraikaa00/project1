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
    public partial class frmSotrudniki2 : Form
    {
        private readonly SecondModuleContext _context;

        public frmSotrudniki2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        public void AddControls(Form f, Form mainForm)
        {
            mainForm.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            mainForm.Controls.Add(f);
            f.Show();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            updageDGV();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
           
        }

        public void updageDGV()
        {
            dataGridView1.Rows.Clear();
            List<Staff> staff = _context.Staff.Include(s => s.Position).ToList();
            for (int i = 0; i < staff.Count; i++)
            {
                dataGridView1.Rows.Add(staff[i].Id, staff[i].Fio, staff[i].Salary, staff[i].Address, staff[i].PhoneNumber, staff[i].Position.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSotrudniki form = new frmSotrudniki(_context);
            frmSotrudniki.insertOrUpdate = true;
            form.ShowDialog();
            updageDGV();
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void Form4_Activated(object sender, EventArgs e)
        {
            updageDGV();
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmSotrudniki form = new frmSotrudniki(_context);
            frmSotrudniki.insertOrUpdate = true;
            form.ShowDialog();
            updageDGV();
        }

        private async void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt16(dataGridView1.SelectedCells[0].Value);
                    var staff = await _context.Staff.FindAsync(id);
                    frmSotrudniki form = new frmSotrudniki(_context);
                    frmSotrudniki.insertOrUpdate = false;
                    frmSotrudniki.staff = staff;
                    form.ShowDialog(); // Используем ShowDialog() для блокировки основной формы до закрытия дочерней
                    updageDGV();


                }

                catch (Exception ex)
                {
                    MessageBox.Show("Пожалуйста, повторите позже!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updageDGV();
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
                    var staff = await _context.Staff.FindAsync(id);
                    if (staff != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Staff.Remove(staff);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updageDGV(); // Возможно, это опечатка и должно быть updateDGV()
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

        private void label2_Click(object sender, EventArgs e)
        {
            AddControls(new frmDoljnost2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
