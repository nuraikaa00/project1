namespace sweet_shop.Forms
{
    partial class frmProdaja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.SaleOfProductIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOfProductProductColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOfProductAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOfProductSumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOfProductDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOfProductStaffColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 99);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(252, 45);
            this.button3.TabIndex = 10;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1Async);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 99);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 45);
            this.button2.TabIndex = 9;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_ClickAsync);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 99);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleOfProductIDColumn,
            this.SaleOfProductProductColumn,
            this.SaleOfProductAmountColumn,
            this.SaleOfProductSumColumn,
            this.SaleOfProductDateColumn,
            this.SaleOfProductStaffColumn});
            this.dataGridView1.Location = new System.Drawing.Point(16, 168);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1137, 573);
            this.dataGridView1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 62);
            this.label1.TabIndex = 6;
            this.label1.Text = "Продажа продукции";
            // 
            // SaleOfProductIDColumn
            // 
            this.SaleOfProductIDColumn.HeaderText = "ID";
            this.SaleOfProductIDColumn.MinimumWidth = 6;
            this.SaleOfProductIDColumn.Name = "SaleOfProductIDColumn";
            this.SaleOfProductIDColumn.Visible = false;
            this.SaleOfProductIDColumn.Width = 125;
            // 
            // SaleOfProductProductColumn
            // 
            this.SaleOfProductProductColumn.HeaderText = "Продукция";
            this.SaleOfProductProductColumn.MinimumWidth = 6;
            this.SaleOfProductProductColumn.Name = "SaleOfProductProductColumn";
            this.SaleOfProductProductColumn.Width = 125;
            // 
            // SaleOfProductAmountColumn
            // 
            this.SaleOfProductAmountColumn.HeaderText = "Количество";
            this.SaleOfProductAmountColumn.MinimumWidth = 6;
            this.SaleOfProductAmountColumn.Name = "SaleOfProductAmountColumn";
            this.SaleOfProductAmountColumn.Width = 125;
            // 
            // SaleOfProductSumColumn
            // 
            this.SaleOfProductSumColumn.HeaderText = "Сумма";
            this.SaleOfProductSumColumn.MinimumWidth = 6;
            this.SaleOfProductSumColumn.Name = "SaleOfProductSumColumn";
            this.SaleOfProductSumColumn.Width = 125;
            // 
            // SaleOfProductDateColumn
            // 
            this.SaleOfProductDateColumn.HeaderText = "Дата";
            this.SaleOfProductDateColumn.MinimumWidth = 6;
            this.SaleOfProductDateColumn.Name = "SaleOfProductDateColumn";
            this.SaleOfProductDateColumn.Width = 125;
            // 
            // SaleOfProductStaffColumn
            // 
            this.SaleOfProductStaffColumn.HeaderText = "Сотрудник";
            this.SaleOfProductStaffColumn.MinimumWidth = 6;
            this.SaleOfProductStaffColumn.Name = "SaleOfProductStaffColumn";
            this.SaleOfProductStaffColumn.Width = 125;
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 756);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form11";
            this.Text = "Лабораторные работы";
            this.Activated += new System.EventHandler(this.Form11_Activated);
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductProductColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductSumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOfProductStaffColumn;
    }
}