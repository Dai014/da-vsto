using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace datn
{

    public partial class CreateQRForm : Form
    {

        private Word.Document currentDocument;
        private List<Word.ContentControl> contentControls;


        public CreateQRForm()
        {
            InitializeComponent();

        }

        private void CreateQrForm_Load(object sender, EventArgs e)
        {

        }
 
        private void btnSaveQR_Click(object sender, EventArgs e)
        {
            string nameQRCode = nameQR.Text;
            if (nameQRCode.Length == 0)
            {
                this.Close();
                MessageBox.Show("invalid name");
                return;
            }
            string contentText = richTextBoxContentQR.Text;
            Ribbon1 ribbon1 = new Ribbon1();
            Shape qrCode = ribbon1.addQrCode(contentText);
            if (qrCode != null)
            {
                qrCode.Name = "QR_" + nameQRCode;
                // Hiển thị
                qrCode.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            }
            else
            {
                MessageBox.Show("Error !");

                this.Close();
                return;
            }

            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}
