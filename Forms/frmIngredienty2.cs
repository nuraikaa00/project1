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
    public partial class frmIngredienty2 : Form
    {
        private readonly SecondModuleContext _context;
        public static List<Product> products;
        public List<Ingredient> ingredients;
        public Product productSelected;

        public frmIngredienty2(SecondModuleContext context)
        {
            InitializeComponent();
            _context = context;
            products = new List<Product>();
            getProducts();
        }

        public void getProducts()
        {
            products = _context.Product.ToList();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = products;
            comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            updateDGV();
            //comboBox1.Text = "";
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
        }

        public void updateDGV()
        {
            dataGridView1.Rows.Clear();
            ingredients = _context.Ingredient.Include(i => i.Product).Include(i => i.Supply).ToList();
            ingredients = ingredients.Where(i => i.Product.Id == productSelected.Id).ToList();
            for (int i = 0; i < ingredients.Count; i++)
            {
                dataGridView1.Rows.Add(ingredients[i].Id, ingredients[i].Product.Name, ingredients[i].Supply.Name, ingredients[i].Amount);
            }

            comboBox1.SelectedItem = productSelected;
        }

        private void Form6_Activated(object sender, EventArgs e)
        {
            updateDGV();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                dataGridView1.Rows.Clear();
                Product product = comboBox1.SelectedItem as Product;
                productSelected = product;
                ingredients = _context.Ingredient.Include(i => i.Product).Include(i => i.Supply).ToList();
                ingredients = ingredients.Where(i => i.Product.Id == product.Id).ToList();
                for (int i = 0; i < ingredients.Count; i++)
                {
                    dataGridView1.Rows.Add(ingredients[i].Id, ingredients[i].Product.Name, ingredients[i].Supply.Name, ingredients[i].Amount);
                }
            }
            else
            {
                updateDGV();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            frmIngredienty form = new frmIngredienty(_context, productSelected, this);
            frmIngredienty.insertOrUpdate = true;
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
                    var ingredient = await _context.Ingredient.FindAsync(id);
                    frmIngredienty form = new frmIngredienty(_context, productSelected, this);
                    frmIngredienty.insertOrUpdate = false;
                    frmIngredienty.ingredient = ingredient;
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
                    var ingredient = await _context.Ingredient.FindAsync(id);
                    if (ingredient != null)
                    {
                        DialogResult dialogResult =
                            MessageBox.Show("Вы уверены?", "Диалоговое окно", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            _context.Ingredient.Remove(ingredient);
                        }
                    }

                    await _context.SaveChangesAsync();
                    updateDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Пожалуйста повторите позже!", "Ошибка!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись, которую хотите удалить!", "Ошибка!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
        private void label1_Click(object sender, EventArgs e)
        {
            AddControls(new frmGotBludo2(_context), this);
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            AddControls(new frmGotBludo2(_context), this);
        }
    }
}
