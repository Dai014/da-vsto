using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace datn
{
    public partial class FormAddQrCode : Form
    {
        public FormAddQrCode()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void saveNameQrCodeBtn_Click(object sender, EventArgs e)
        {
            Word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string selectedText = currentDocument.Application.Selection.Text;
            string nameQrCode = nameQrInput.Text;
            if(nameQrCode.Length != 0)
            {
                nameQrCode = "QR_" + nameQrCode;

                Ribbon1 ribbon1 = new Ribbon1();
                Shape qrCode = ribbon1.addQrCode(selectedText);
                if(qrCode != null )
                {
                    qrCode.Name = nameQrCode;
                    /// Hiển thị hình vuông
                    qrCode.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                }
                else
                {
                    this.Close();
                    return;
                }
               
                
            }
            else
            {
                MessageBox.Show("Invalid name! ");
            }
            
            this.Close();
        }
    }
}
