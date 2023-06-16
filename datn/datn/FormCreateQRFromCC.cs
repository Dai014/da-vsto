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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;

namespace datn
{
    public partial class FormCreateQRFromCC : Form
    {
        Word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;
        List<String> checkedItems = new List<String>();

        public FormCreateQRFromCC()
        {
            InitializeComponent();
            
            checkedListCC.SelectedIndexChanged += (sender, e) =>
            {
                addTextToTextBoxContentQR();
            };
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            addTextToTextBoxContentQR();

        }

        private void addTextToTextBoxContentQR()
        {
            checkedItems.Clear();
            foreach (String item in checkedListCC.CheckedItems)
            {
                checkedItems.Add(item);
            }
            String formatQr = comboBoxFormat.Text;
            string resultContentQr;
            if (formatQr == "new line")
            {
                resultContentQr = string.Join("\n", checkedItems);
            }
            else
            {
                resultContentQr = string.Join(formatQr, checkedItems);
            }
            richTextBox1.Text = resultContentQr;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormCreateQRFromCC_Load(object sender, EventArgs e)
        {
            comboBoxFormat.SelectedIndexChanged += comboBoxFormat_SelectedIndexChanged;

            FormContentControl formContentControl = new FormContentControl();
            List<Word.ContentControl> listContentControl = formContentControl.GetAllContentControls(currentDocument);
            List<String> listItemCC = new List<String>();
            foreach(Word.ContentControl item in listContentControl)
            {
                String cc = item.Title + " : " + item.Range.Text;
                listItemCC.Add(cc);
            }

            comboBoxFormat.SelectedIndex = 0;
            int itemSpacing = 15;
            checkedListCC.DataSource = listItemCC;
            //checkedListCC.Format += (formatSender, formatEvent) =>
            //{
            //    if (formatEvent.ListItem != null)
            //    {
            //        ContentControl contentControl = (ContentControl)formatEvent.ListItem;
            //        formatEvent.Value = $"{contentControl.Title} : {contentControl.Range.Text}";
            //    }
            //};

            // Đặt Padding cho mỗi mục (tạo khoảng cách giữa các mục)
            checkedListCC.Padding = new Padding(0, itemSpacing, 0, itemSpacing);

           
        }

        private void BtnCreatQRFromCC_Click(object sender, EventArgs e)
        {
            string nameQrCode = textBoxNameQr.Text;
            string contentQr = richTextBox1.Text;
            nameQrCode = "QR_" + nameQrCode;

            Ribbon1 ribbon1 = new Ribbon1();
            Shape qrCode = ribbon1.addQrCode(contentQr);
            if (qrCode != null)
            {
                qrCode.Name = nameQrCode;
                // Hiển thị hình vuông
                qrCode.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            }
            else
            {
                this.Close();
                return;
            }

            this.Close();
        }
    }
}
