namespace library
{
    partial class frmBorrowBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrowBook));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTaken = new System.Windows.Forms.ComboBox();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrow_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtsBorrowDate = new Atf.UI.DateTimeSelector();
            this.dtsBackDate = new Atf.UI.DateTimeSelector();
            this.lblMember = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditRow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeleteRow = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(555, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "تاریخ امانت";
            // 
            // cmbTaken
            // 
            this.cmbTaken.DisplayMember = "name";
            this.cmbTaken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTaken.FormattingEnabled = true;
            this.cmbTaken.Items.AddRange(new object[] {
            "خیر",
            "بله"});
            this.cmbTaken.Location = new System.Drawing.Point(247, 55);
            this.cmbTaken.Name = "cmbTaken";
            this.cmbTaken.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTaken.Size = new System.Drawing.Size(136, 34);
            this.cmbTaken.TabIndex = 5;
            this.cmbTaken.ValueMember = "id";
            // 
            // txtBookId
            // 
            this.txtBookId.Location = new System.Drawing.Point(648, 56);
            this.txtBookId.Name = "txtBookId";
            this.txtBookId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBookId.Size = new System.Drawing.Size(120, 31);
            this.txtBookId.TabIndex = 2;
            this.txtBookId.TextChanged += new System.EventHandler(this.txtBookId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(707, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "کد کتاب";
            // 
            // txtMemberId
            // 
            this.txtMemberId.Location = new System.Drawing.Point(774, 55);
            this.txtMemberId.Name = "txtMemberId";
            this.txtMemberId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMemberId.Size = new System.Drawing.Size(120, 31);
            this.txtMemberId.TabIndex = 1;
            this.txtMemberId.TextChanged += new System.EventHandler(this.txtMemberId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(816, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "کد عضویت";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "وضعیت تحویل";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "تاریخ بازگشت";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.book_id,
            this.member_id,
            this.borrow_date,
            this.back_date,
            this.taken,
            this.user_id,
            this.member_name,
            this.book_name,
            this.user_name,
            this.btnEditRow,
            this.btnDeleteRow});
            this.dataGridView1.Location = new System.Drawing.Point(-2, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(922, 276);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "کد";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 44;
            // 
            // book_id
            // 
            this.book_id.DataPropertyName = "book_id";
            this.book_id.HeaderText = "کدکتاب";
            this.book_id.Name = "book_id";
            this.book_id.ReadOnly = true;
            this.book_id.Visible = false;
            this.book_id.Width = 67;
            // 
            // member_id
            // 
            this.member_id.DataPropertyName = "member_id";
            this.member_id.HeaderText = "کد عضو";
            this.member_id.Name = "member_id";
            this.member_id.ReadOnly = true;
            this.member_id.Visible = false;
            this.member_id.Width = 69;
            // 
            // borrow_date
            // 
            this.borrow_date.DataPropertyName = "borrow_date";
            this.borrow_date.HeaderText = "تاریخ امانت";
            this.borrow_date.Name = "borrow_date";
            this.borrow_date.ReadOnly = true;
            this.borrow_date.Width = 103;
            // 
            // back_date
            // 
            this.back_date.DataPropertyName = "back_date";
            this.back_date.HeaderText = "تاریخ برگشت";
            this.back_date.Name = "back_date";
            this.back_date.ReadOnly = true;
            this.back_date.Width = 113;
            // 
            // taken
            // 
            this.taken.DataPropertyName = "taken";
            this.taken.HeaderText = "وضعیت تحویل";
            this.taken.Name = "taken";
            this.taken.ReadOnly = true;
            this.taken.Width = 126;
            // 
            // user_id
            // 
            this.user_id.DataPropertyName = "user_id";
            this.user_id.HeaderText = "کد کاربر";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Visible = false;
            this.user_id.Width = 72;
            // 
            // member_name
            // 
            this.member_name.DataPropertyName = "member_name";
            this.member_name.HeaderText = "نام عضو";
            this.member_name.Name = "member_name";
            this.member_name.ReadOnly = true;
            this.member_name.Width = 86;
            // 
            // book_name
            // 
            this.book_name.DataPropertyName = "book_name";
            this.book_name.HeaderText = "نام کتاب";
            this.book_name.Name = "book_name";
            this.book_name.ReadOnly = true;
            this.book_name.Width = 88;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            this.user_name.HeaderText = "نام کاربر";
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            this.user_name.Width = 84;
            // 
            // dtsBorrowDate
            // 
            this.dtsBorrowDate.CustomFormat = "dd/MM/yyyy";
            this.dtsBorrowDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dtsBorrowDate.Location = new System.Drawing.Point(525, 54);
            this.dtsBorrowDate.Name = "dtsBorrowDate";
            this.dtsBorrowDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtsBorrowDate.Size = new System.Drawing.Size(108, 32);
            this.dtsBorrowDate.TabIndex = 3;
            this.dtsBorrowDate.UsePersianFormat = true;
            // 
            // dtsBackDate
            // 
            this.dtsBackDate.CustomFormat = "dd/MM/yyyy";
            this.dtsBackDate.Format = Atf.UI.DateTimeSelectorFormat.Custom;
            this.dtsBackDate.Location = new System.Drawing.Point(398, 55);
            this.dtsBackDate.Name = "dtsBackDate";
            this.dtsBackDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtsBackDate.Size = new System.Drawing.Size(108, 32);
            this.dtsBackDate.TabIndex = 4;
            this.dtsBackDate.UsePersianFormat = true;
            // 
            // lblMember
            // 
            this.lblMember.Location = new System.Drawing.Point(774, 103);
            this.lblMember.Name = "lblMember";
            this.lblMember.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMember.Size = new System.Drawing.Size(120, 76);
            this.lblMember.TabIndex = 22;
            // 
            // lblBook
            // 
            this.lblBook.Location = new System.Drawing.Point(525, 103);
            this.lblBook.Name = "lblBook";
            this.lblBook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBook.Size = new System.Drawing.Size(238, 45);
            this.lblBook.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(860, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 26);
            this.label8.TabIndex = 25;
            this.label8.Text = "جستجو";
            this.label8.UseWaitCursor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(637, 155);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(215, 37);
            this.txtSearch.TabIndex = 24;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(247, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 35);
            this.button4.TabIndex = 28;
            this.button4.Text = "کتاب های تحویل داده نشده";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "ویرایش";
            this.dataGridViewImageColumn1.Image = global::library.Properties.Resources.Untitled_521;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 44;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "حذف";
            this.dataGridViewImageColumn2.Image = global::library.Properties.Resources.images__1_1;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 34;
            // 
            // button5
            // 
            this.button5.Image = global::library.Properties.Resources.Untitled_166;
            this.button5.Location = new System.Drawing.Point(487, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 35);
            this.button5.TabIndex = 29;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Image = global::library.Properties.Resources.Untitled_181;
            this.button3.Location = new System.Drawing.Point(539, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 35);
            this.button3.TabIndex = 27;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::library.Properties.Resources.Untitled_192;
            this.button2.Location = new System.Drawing.Point(582, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 35);
            this.button2.TabIndex = 26;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::library.Properties.Resources.U2;
            this.pictureBox1.Location = new System.Drawing.Point(21, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 56);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditRow
            // 
            this.btnEditRow.HeaderText = "ویرایش";
            this.btnEditRow.Image = global::library.Properties.Resources.Untitled_524;
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
            // frmBorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 477);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.dtsBackDate);
            this.Controls.Add(this.dtsBorrowDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTaken);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Vazirmatn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmBorrowBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "کتاب های امانت داده شده";
            this.Load += new System.EventHandler(this.frmBorrowBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTaken;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Atf.UI.DateTimeSelector dtsBorrowDate;
        private Atf.UI.DateTimeSelector dtsBackDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrow_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn back_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn taken;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn member_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewImageColumn btnEditRow;
        private System.Windows.Forms.DataGridViewImageColumn btnDeleteRow;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}