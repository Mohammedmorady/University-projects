namespace Votes
{
    partial class VotingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTopics = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOption1 = new System.Windows.Forms.RadioButton();
            this.radioOption3 = new System.Windows.Forms.RadioButton();
            this.radioOption2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "کاندیدای مورد نظر خود را اانتخاب کنید";
            // 
            // comboBoxTopics
            // 
            this.comboBoxTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTopics.FormattingEnabled = true;
            this.comboBoxTopics.Items.AddRange(new object[] {
            "شورای دانش آموزی"});
            this.comboBoxTopics.Location = new System.Drawing.Point(290, 144);
            this.comboBoxTopics.Name = "comboBoxTopics";
            this.comboBoxTopics.Size = new System.Drawing.Size(263, 34);
            this.comboBoxTopics.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioOption2);
            this.groupBox1.Controls.Add(this.radioOption3);
            this.groupBox1.Controls.Add(this.radioOption1);
            this.groupBox1.Location = new System.Drawing.Point(150, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 136);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "یکی از گزینه های زیر را انتخاب کنید";
            // 
            // radioOption1
            // 
            this.radioOption1.AutoSize = true;
            this.radioOption1.Location = new System.Drawing.Point(413, 20);
            this.radioOption1.Name = "radioOption1";
            this.radioOption1.Size = new System.Drawing.Size(107, 30);
            this.radioOption1.TabIndex = 0;
            this.radioOption1.TabStop = true;
            this.radioOption1.Text = "علی معتمدی";
            this.radioOption1.UseVisualStyleBackColor = true;
            // 
            // radioOption3
            // 
            this.radioOption3.AutoSize = true;
            this.radioOption3.Location = new System.Drawing.Point(413, 92);
            this.radioOption3.Name = "radioOption3";
            this.radioOption3.Size = new System.Drawing.Size(122, 30);
            this.radioOption3.TabIndex = 1;
            this.radioOption3.TabStop = true;
            this.radioOption3.Text = "محمد اله مرادی";
            this.radioOption3.UseVisualStyleBackColor = true;
            // 
            // radioOption2
            // 
            this.radioOption2.AutoSize = true;
            this.radioOption2.Location = new System.Drawing.Point(413, 56);
            this.radioOption2.Name = "radioOption2";
            this.radioOption2.Size = new System.Drawing.Size(98, 30);
            this.radioOption2.TabIndex = 2;
            this.radioOption2.TabStop = true;
            this.radioOption2.Text = "صائب تیمار";
            this.radioOption2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "ثبت رای";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxTopics);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Vazirmatn", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "VotingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VotingForm";
            this.Load += new System.EventHandler(this.VotingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTopics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioOption2;
        private System.Windows.Forms.RadioButton radioOption3;
        private System.Windows.Forms.RadioButton radioOption1;
        private System.Windows.Forms.Button button1;
    }
}