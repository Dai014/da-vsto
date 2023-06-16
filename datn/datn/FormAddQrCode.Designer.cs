namespace datn
{
    partial class FormAddQrCode
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
            this.nameQrInput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveNameQrCodeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameQrInput
            // 
            this.nameQrInput.Location = new System.Drawing.Point(45, 59);
            this.nameQrInput.Name = "nameQrInput";
            this.nameQrInput.Size = new System.Drawing.Size(381, 64);
            this.nameQrInput.TabIndex = 0;
            this.nameQrInput.Text = "";
            this.nameQrInput.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Location = new System.Drawing.Point(170, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name QR Code";
            // 
            // saveNameQrCodeBtn
            // 
            this.saveNameQrCodeBtn.Location = new System.Drawing.Point(186, 129);
            this.saveNameQrCodeBtn.Name = "saveNameQrCodeBtn";
            this.saveNameQrCodeBtn.Size = new System.Drawing.Size(75, 34);
            this.saveNameQrCodeBtn.TabIndex = 2;
            this.saveNameQrCodeBtn.Text = "Save";
            this.saveNameQrCodeBtn.UseVisualStyleBackColor = true;
            this.saveNameQrCodeBtn.Click += new System.EventHandler(this.saveNameQrCodeBtn_Click);
            // 
            // FormAddQrCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 175);
            this.Controls.Add(this.saveNameQrCodeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameQrInput);
            this.Name = "FormAddQrCode";
            this.Text = "FormAddQrCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox nameQrInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveNameQrCodeBtn;
    }
}