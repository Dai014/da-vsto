﻿namespace datn
{
    partial class FormCreateQRFromCC
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
            this.checkedListCC = new System.Windows.Forms.CheckedListBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCreatQRFromCC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNameQr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListCC
            // 
            this.checkedListCC.FormattingEnabled = true;
            this.checkedListCC.Location = new System.Drawing.Point(22, 50);
            this.checkedListCC.Margin = new System.Windows.Forms.Padding(5);
            this.checkedListCC.Name = "checkedListCC";
            this.checkedListCC.Size = new System.Drawing.Size(904, 188);
            this.checkedListCC.TabIndex = 0;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.ItemHeight = 20;
            this.comboBoxFormat.Items.AddRange(new object[] {
            ", ",
            "- ",
            "\t",
            "; ",
            "new line"});
            this.comboBoxFormat.Location = new System.Drawing.Point(22, 280);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(220, 28);
            this.comboBoxFormat.TabIndex = 1;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(18, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "format";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(22, 356);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(900, 131);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "select the content control";
            // 
            // BtnCreatQRFromCC
            // 
            this.BtnCreatQRFromCC.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCreatQRFromCC.Location = new System.Drawing.Point(383, 493);
            this.BtnCreatQRFromCC.Name = "BtnCreatQRFromCC";
            this.BtnCreatQRFromCC.Size = new System.Drawing.Size(114, 48);
            this.BtnCreatQRFromCC.TabIndex = 5;
            this.BtnCreatQRFromCC.Text = "OKE";
            this.BtnCreatQRFromCC.UseVisualStyleBackColor = false;
            this.BtnCreatQRFromCC.Click += new System.EventHandler(this.BtnCreatQRFromCC_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(22, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result";
            // 
            // textBoxNameQr
            // 
            this.textBoxNameQr.Location = new System.Drawing.Point(419, 282);
            this.textBoxNameQr.Name = "textBoxNameQr";
            this.textBoxNameQr.Size = new System.Drawing.Size(270, 26);
            this.textBoxNameQr.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(419, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "name QR code";
            // 
            // FormCreateQRFromCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 553);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNameQr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCreatQRFromCC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.checkedListCC);
            this.Name = "FormCreateQRFromCC";
            this.Text = "FormCreateQRFromCC";
            this.Load += new System.EventHandler(this.FormCreateQRFromCC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListCC;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCreatQRFromCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNameQr;
        private System.Windows.Forms.Label label4;
    }
}