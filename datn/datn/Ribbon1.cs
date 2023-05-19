using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace datn
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            // Globals.ThisAddIn.Application.ActiveDocument.ContentControls["HoTen"].
            Microsoft.Office.Interop.Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;

            if (document.Application.Selection != null && document.Application.Selection.Start != document.Application.Selection.End)
            {
                // Văn bản được chọn
                string selectedText = document.Application.Selection.Text;

                Console.WriteLine(selectedText);

                int number = Int32.Parse(selectedText);
                string numberToText = ConvertNumberToText(number);

                document.Application.Selection.InsertAfter(numberToText);

            }
        }

        public string ConvertNumberToText(int number)
        {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
            {
                return units[number];
            }
            else if (number < 100)
            {
                return tens[number / 10] + " " + units[number % 10];
            }
            else
            {
                return units[number / 100] + " hundred " + ConvertNumberToText(number % 100);
            }
        }
    }
}
