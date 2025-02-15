namespace library
{
    partial class frmBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooks));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWriter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPulish_year = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubjectid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.writer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publish_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditRow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeleteRow = new System.Windows.Forms.DataGridViewImageColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(703, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کتاب";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(665, 84);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(101, 31);
            this.txtName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 70);
            this.button1.TabIndex = 6;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtWriter
            // 
            this.txtWriter.Location = new System.Drawing.Point(549, 85);
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWriter.Size = new System.Drawing.Size(101, 31);
            this.txtWriter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام نویسنده";
            // 
            // txtPulish_year
            // 
            this.txtPulish_year.Location = new System.Drawing.Point(336, 88);
            this.txtPulish_year.Name = "txtPulish_year";
            this.txtPulish_year.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPulish_year.Size = new System.Drawing.Size(101, 31);
            this.txtPulish_year.TabIndex = 4;
            this.txtPulish_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPulish_year_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "سال چاپ";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(217, 88);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(101, 31);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "قیمت";
            // 
            // cmbSubjectid
            // 
            this.cmbSubjectid.DisplayMember = "name";
            this.cmbSubjectid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubjectid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSubjectid.FormattingEnabled = true;
            this.cmbSubjectid.Location = new System.Drawing.Point(442, 85);
            this.cmbSubjectid.Name = "cmbSubjectid";
            this.cmbSubjectid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSubjectid.Size = new System.Drawing.Size(101, 34);
            this.cmbSubjectid.TabIndex = 3;
            this.cmbSubjectid.ValueMember = "id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "موضوع";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.writer,
            this.subject_name,
            this.subject_id,
            this.publish_year,
            this.price,
            this.btnEditRow,
            this.btnDeleteRow});
            this.dataGridView1.Location = new System.Drawing.Point(1, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(776, 276);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "کد کتاب";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 86;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "نام کتاب";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 88;
            // 
            // writer
            // 
            this.writer.DataPropertyName = "writer";
            this.writer.HeaderText = "نویسنده";
            this.writer.Name = "writer";
            this.writer.ReadOnly = true;
            this.writer.Width = 86;
            // 
            // subject_name
            // 
            this.subject_name.DataPropertyName = "name:1";
            this.subject_name.HeaderText = "موضوع";
            this.subject_name.Name = "subject_name";
            this.subject_name.ReadOnly = true;
            this.subject_name.Width = 81;
            // 
            // subject_id
            // 
            this.subject_id.DataPropertyName = "subject_id";
            this.subject_id.HeaderText = "کد موضوع";
            this.subject_id.Name = "subject_id";
            this.subject_id.ReadOnly = true;
            this.subject_id.Visible = false;
            this.subject_id.Width = 80;
            // 
            // publish_year
            // 
            this.publish_year.DataPropertyName = "publish_year";
            this.publish_year.HeaderText = "سال چاپ";
            this.publish_year.Name = "publish_year";
            this.publish_year.ReadOnly = true;
            this.publish_year.Width = 94;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "قیمت";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 72;
            // 
            // btnEditRow
            // 
            this.btnEditRow.HeaderText = "ویرایش";
            this.btnEditRow.Image = global::library.Properties.Resources.Untitled_521;
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.ReadOnly = true;
            this.btnEditRow.Width = 62;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.HeaderText = "حذف";
            this.btnDeleteRow.Image = global::library.Properties.Resources.images__1_1;
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.ReadOnly = true;
            this.btnDeleteRow.Width = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "جستجو در تمام ستون ها";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(562, 167);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(203, 31);
            this.txtSearch.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Image = global::library.Properties.Resources.Untitled_18;
            this.button3.Location = new System.Drawing.Point(481, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 27);
            this.button3.TabIndex = 16;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "ویرایش";
            this.dataGridViewImageColumn1.Image = global::library.Properties.Resources.Untitled_521;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 44;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "حذف";
            this.dataGridViewImageColumn2.Image = global::library.Properties.Resources.images__1_1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 34;
            // 
            // button2
            // 
            this.button2.Image = global::library.Properties.Resources.Untitled_19;
            this.button2.Location = new System.Drawing.Point(515, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 27);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::library.Properties.Resources.Untitled_101;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 56);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 494);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSubjectid);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPulish_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWriter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Vazirmatn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "frmBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کتابها";
            this.Load += new System.EventHandler(this.frmBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWriter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPulish_year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSubjectid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn writer;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn publish_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewImageColumn btnEditRow;
        private System.Windows.Forms.DataGridViewImageColumn btnDeleteRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}