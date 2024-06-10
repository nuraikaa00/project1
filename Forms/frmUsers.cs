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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace sweet_shop.Forms
{
    public partial class frmUsers : Form
    {
        private readonly SecondModuleContext _context;
        public frmUsers(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
        }
        public void updageDGV()
        {
            dataGridView1.Rows.Clear();
            List<Users> user = _context.Users.ToList();
            for (int i = 0; i < user.Count; i++)
            {
                dataGridView1.Rows.Add(user[i].Id, user[i].Name, user[i].Pass,user[i].Role);
            }
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmUsers2 form = new frmUsers2(_context);
            frmUsers2.insertOrUpdate = true;
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
                    var users = await _context.Users.FindAsync(id);
                    frmUsers2 form = new frmUsers2(_context);
                    frmUsers2.insertOrUpdate = false;
                    frmUsers2.users = users;
                    form.ShowDialog();
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
                    var users = await _context.Users.FindAsync(id);
                    if (users != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Users.Remove(users);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updageDGV(); 
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

        private void frmUsers_Load(object sender, EventArgs e)
        {
            updageDGV();
        }
    }
}
