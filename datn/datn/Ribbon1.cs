﻿using Microsoft.Office.Tools.Ribbon;
using System.Text;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using static datn.FormContentControl;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.Linq;
using System;

namespace datn
{
    public partial class Ribbon1
    {
        private static readonly string[] ChuSo = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bẩy", "tám", "chín" };
        private static readonly string[] Tien = new string[6] { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ" };

        private static readonly string[] NumberInText = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] Money = new string[6] { "", " thousand", " million", " billion", "trillion", " quadrillion" };

        private static readonly long BiggestNumber = 8999999999999999;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            synthesizer = new SpeechSynthesizer();

        }

        private void readNumberVnBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

            if (document.Application.Selection != null && document.Application.Selection.Start != document.Application.Selection.End)
            {
                /// Văn bản được chọn
                string selectedText = document.Application.Selection.Text;
                //double numberInput = Double.Parse(selectedText);
                long number;
                bool isNumeric = long.TryParse(selectedText, out number);

                if (isNumeric)
                {
                    string numberToText = DocTienBangChu(number);
                    numberToText = " ( " + numberToText + " )";
                    document.Application.Selection.InsertAfter(numberToText);
                }
                else
                {
                    MessageBox.Show("Đầu vào không phải là một số nguyên.");
                }

            }
        }

        private void readNumberEnBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

            if (document.Application.Selection != null && document.Application.Selection.Start != document.Application.Selection.End)
            {

                /// Văn bản được chọn
                string selectedText = document.Application.Selection.Text;
                ///double numberInput = Double.Parse(selectedText);
                long number;
                bool isNumeric = long.TryParse(selectedText, out number);

                if (isNumeric)
                {
                    string numberToText = ReadMoneyInText(number);
                    numberToText = " ( " + numberToText + " )";
                    document.Application.Selection.InsertAfter(numberToText);
                }
                else
                {
                    MessageBox.Show("Input is not an integer.");
                }

            }
        }

        private static string DocTienBangChu(long SoTien)
        {
            int lan, i;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien == 0) return "không";

            /// Giá trị tuyệt đối của Số Tiền            
            long so = (SoTien > 0) ? SoTien : -SoTien;
            ///Kiểm tra số quá lớn
            if (SoTien > BiggestNumber)
            {
                ///SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so -= long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so -= long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so -= long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            /// Tìm đến hàng đầu tiên có giá trị khác 0
            for (lan = 5; lan >= 0; lan--)
            {
                if (ViTri[lan] != 0) break;
            }
            /// Bắt đầu từ vị trí hàng khác 0 --> chuyển đổi 
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i], (i == lan));
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += (" " + Tien[i] + " ");
                //if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim();
            if (SoTien < 0)
            {
                KetQua = "âm " + KetQua;
            }
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }

        static private string DocSo3ChuSo(int baso, bool IsMSB)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            bool IsMot = false;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";

            {/// Hàng trăm

                if ((tram != 0) || (tram == 0 && !IsMSB))
                {
                    KetQua += ChuSo[tram] + " trăm ";
                }
            }

            {/// Hàng chục
                if (chuc > 1)
                {
                    KetQua += ChuSo[chuc] + " mươi ";
                    IsMot = true;
                }
                else
                {
                    if (chuc == 1)
                    {
                        KetQua += "mười ";
                    }
                    else if ((tram != 0) && (donvi != 0) || (tram == 0) && !IsMSB)
                    {
                        KetQua += "linh ";
                    }
                }
            }
            {/// Hàng đơn vị
                if (IsMot && donvi == 1)
                {
                    KetQua += "mốt";
                }
                else
                {
                    if (donvi == 5 && chuc != 0)
                    {
                        KetQua += "lăm";
                    }
                    else if (donvi > 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else if ((chuc == 0) && (donvi == 0))
                    {
                        KetQua = KetQua.TrimEnd(' ');
                    }
                }
            }
            return KetQua;
        }

        private static string ReadMoneyInText(long Amount)
        {
            int times, i;
            long number;
            string Result = "", tmp;
            int[] Place = new int[6];
            if (Amount == 0) return "";
            if (Amount > 0)
            {
                number = Amount;
            }
            else
            {
                number = -Amount;
            }
            /// Check if the number is too big
            if (Amount > BiggestNumber)
            {
                ///Amount = 0;
                return "";
            }
            Place[5] = (int)(number / 1000000000000000);
            number -= long.Parse(Place[5].ToString()) * 1000000000000000;
            Place[4] = (int)(number / 1000000000000);
            number -= long.Parse(Place[4].ToString()) * +1000000000000;
            Place[3] = (int)(number / 1000000000);
            number -= long.Parse(Place[3].ToString()) * 1000000000;
            Place[2] = (int)(number / 1000000);
            Place[1] = (int)((number % 1000000) / 1000);
            Place[0] = (int)(number % 1000);
            if (Place[5] > 0)
            {
                times = 5;
            }
            else if (Place[4] > 0)
            {
                times = 4;
            }
            else if (Place[3] > 0)
            {
                times = 3;
            }
            else if (Place[2] > 0)
            {
                times = 2;
            }
            else if (Place[1] > 0)
            {
                times = 1;
            }
            else
            {
                times = 0;
            }
            for (i = times; i >= 0; i--)
            {
                tmp = Read3DigitNumber(Place[i]);
                Result += tmp;
                if (Place[i] != 0) Result += Money[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) Result += ", ";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (Result.Substring(Result.Length - 2, 2) == ", ") Result = Result.Substring(0, Result.Length - 2);
            Result = Result.Trim();
            if (Amount < 0)
            {
                Result = "Negative " + Result;
            }
            return Result.Substring(0, 1).ToUpper() + Result.Substring(1);
        }


        static private string Read3DigitNumber(int threeDigit)
        {
            int hundreds, tens, ones;
            string Result = "";
            hundreds = (int)(threeDigit / 100);
            tens = (int)((threeDigit % 100) / 10);
            ones = threeDigit % 10;
            if ((hundreds == 0) && (tens == 0) && (ones == 0)) return "";
            if (hundreds != 0)
            {
                Result += NumberInText[hundreds] + " hundred";
                //if ((tens == 0) && (ones != 0)) Result += ""
            }
            if ((tens == 0) && (ones != 0))
            {
                Result += " " + NumberInText[ones];
            }
            else if ((tens == 0) && (ones == 0))
            {

            }
            else
            {
                if (tens == 1)
                {
                    switch (ones)
                    {
                        case 0: Result += " ten"; break;
                        case 1: Result += " eleven"; break;
                        case 2: Result += " twelve"; break;
                        case 3: Result += " thirteen"; break;
                        case 4: Result += " fourteen"; break;
                        case 5: Result += " fifteen"; break;
                        case 6: Result += " sixteen"; break;
                        case 7: Result += " seventeen"; break;
                        case 8: Result += " eighteen"; break;
                        case 9: Result += " nineteen"; break;
                        default: break;
                    }
                }
                else
                {
                    switch (tens)
                    {
                        case 2: Result += " twenty"; break;
                        case 3: Result += " thirty"; break;
                        case 4: Result += " forty"; break;
                        case 5: Result += " fifty"; break;
                        case 6: Result += " sixty"; break;
                        case 7: Result += " seventy"; break;
                        case 8: Result += " eighty"; break;
                        case 9: Result += " ninety"; break;
                        default: break;
                    }
                    Result += "-" + NumberInText[ones];
                }
            }

            return Result;

        }
        ///tieng anh

        private SpeechSynthesizer synthesizer;
        private bool isPaused;
        private void textToSpeechEn_Click(object sender, RibbonControlEventArgs e)
        {
            //string selectedText = Globals.ThisAddIn.Application.Selection.Text;

            //using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            //{
            //    synthesizer.Speak(selectedText);
            //}

            if (Globals.ThisAddIn.Application.Selection != null && !isPaused)
            {
                /// Lấy văn bản đã chọn
                string selectedText = Globals.ThisAddIn.Application.Selection.Text;

                if (!string.IsNullOrWhiteSpace(selectedText))
                {
                    /// Bắt đầu đọc văn bản
                    synthesizer.SpeakAsync(selectedText);
                }
            }

        }

        private void playOrPause_Click(object sender, RibbonControlEventArgs e)
        {
            if (synthesizer.State == SynthesizerState.Speaking)
            {
                /// Tạm dừng đọc
                synthesizer.Pause();
                isPaused = true;
                return;
            }

            else if (isPaused)
            {
                /// Tiếp tục đọc nếu đã tạm dừng
                synthesizer.Resume();
                isPaused = false;
            }
        }

        private void stopSpeech_Click(object sender, RibbonControlEventArgs e)
        {
            if (synthesizer.State == SynthesizerState.Speaking || isPaused)
            {
                /// Dừng đọc
                synthesizer.SpeakAsyncCancelAll();
                isPaused = false;
            }
        }

        private void aboutBtn_Click(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("Author: Nguyễn Văn Đại IT E6 04");
        }

        private void button6_Click(object sender, RibbonControlEventArgs e)
        {
            FormContentControl formControl = new FormContentControl();
            formControl.ShowDialog();
        }

        private void btnAddQrCode_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string selectedText = currentDocument.Application.Selection.Text;
            if (selectedText == " " || selectedText == "" || selectedText == null || selectedText == "\t")
            {
                MessageBox.Show("no text selected");
                return;
            }
            else
            {
                FormAddQrCode form = new FormAddQrCode();
                form.ShowDialog();
            }

        }

        public Shape addQrCode(String textContentQr)
        {
            Word.Shape square = createSquare();
            if(square != null)
            {
                square.Fill.UserPicture(GetQRCodeWebAPI(textContentQr));
                square.AlternativeText = textContentQr;
                return square;
            } 
            return null;
           
        }

        private Word.Shape createSquare()
        {
            try
            {
                /// Lấy văn bản đang hoạt động trong tài liệu hiện tại
                Word.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;

                Word.Selection currentSelection = currentDocument.Application.Selection;

                /// Tạo một đối tượng Shape
                Word.Shape square = currentDocument.Shapes.AddShape(
                    Type: (int)Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle,
                    Left: currentSelection.get_Information(Word.WdInformation.wdHorizontalPositionRelativeToPage),
                    Top: currentSelection.get_Information(Word.WdInformation.wdVerticalPositionRelativeToPage),
                    Width: 100,
                    Height: 100
                );

                square.Line.Weight = 1;

                return square;
            }
            catch (Exception E )
            {
                MessageBox.Show(E.Message);
                return null;
            }
          
        }

        static string GetQRCodeWebAPI(string Text, int ImageSize = 500, CorrectionLevel Correction = CorrectionLevel.High, int Margin = 0)
        {
            StringBuilder sURL = new StringBuilder();
            sURL.AppendFormat("https://chart.googleapis.com/chart?cht=qr&chs={0}x{0}&chld={1}|{2}&chl={3}", ImageSize, Correction, Margin, Text);
            return sURL.ToString();
        }


        private Dictionary<string, string> listQrCode()
        {
            /// Lấy tài liệu Word hiện tại
            Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
            Dictionary<string, string> qrCodeList = new Dictionary<string, string>();

            try
            {
                /// Liệt kê tất cả các shape trong tài liệu Word hiện tại
                foreach (Word.Shape shape in document.Shapes)
                {
                    string name = shape.Name;
                    if (name.Contains("qr_"))
                    {
                        string value = shape.Name;
                        qrCodeList.Add(name, value);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return qrCodeList;
        }

        private void createQRForm_Click(object sender, RibbonControlEventArgs e)
        {
            CreateQRForm formQR = new CreateQRForm();
            formQR.ShowDialog();
        }

        private void qr_showListContentControl_Click(object sender, RibbonControlEventArgs e)
        {
            FormCreateQRFromCC form = new FormCreateQRFromCC();
            form.ShowDialog();
        }

        private void listQR_Click(object sender, RibbonControlEventArgs e)
        {
            FormListQR formListQR = new FormListQR();
            formListQR.ShowDialog();
        }
    }
}
