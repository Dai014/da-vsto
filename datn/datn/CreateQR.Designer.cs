namespace datn
{
    partial class CreateQRForm
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
            this.btnSaveQR = new System.Windows.Forms.Button();
            this.richTextBoxContentQR = new System.Windows.Forms.RichTextBox();
            this.nameQR = new System.Windows.Forms.TextBox();
            this.N = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSaveQR.Location = new System.Drawing.Point(440, 343);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(75, 38);
            this.btnSaveQR.TabIndex = 3;
            this.btnSaveQR.Text = "Save";
            this.btnSaveQR.UseVisualStyleBackColor = false;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // richTextBoxContentQR
            // 
            this.richTextBoxContentQR.Location = new System.Drawing.Point(23, 142);
            this.richTextBoxContentQR.Name = "richTextBoxContentQR";
            this.richTextBoxContentQR.Size = new System.Drawing.Size(906, 157);
            this.richTextBoxContentQR.TabIndex = 4;
            this.richTextBoxContentQR.Text = "";
            // 
            // nameQR
            // 
            this.nameQR.Location = new System.Drawing.Point(23, 46);
            this.nameQR.Name = "nameQR";
            this.nameQR.Size = new System.Drawing.Size(411, 26);
            this.nameQR.TabIndex = 5;
            // 
            // N
            // 
            this.N.AutoSize = true;
            this.N.BackColor = System.Drawing.SystemColors.Info;
            this.N.Location = new System.Drawing.Point(23, 13);
            this.N.Name = "N";
            this.N.Size = new System.Drawing.Size(121, 20);
            this.N.TabIndex = 6;
            this.N.Text = "Name QR Code";
            this.N.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(23, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "ContentQrCode";
            // 
            // CreateQRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(958, 423);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.N);
            this.Controls.Add(this.nameQR);
            this.Controls.Add(this.richTextBoxContentQR);
            this.Controls.Add(this.btnSaveQR);
            this.Name = "CreateQRForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Create QR ";
            this.Load += new System.EventHandler(this.CreateQrForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.RichTextBox richTextBoxContentQR;
        private System.Windows.Forms.TextBox nameQR;
        private System.Windows.Forms.Label N;
        private System.Windows.Forms.Label label2;
    }
}