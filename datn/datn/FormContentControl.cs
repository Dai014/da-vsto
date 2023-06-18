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
using Xceed.Document.NET;
using Word = Microsoft.Office.Interop.Word;

namespace datn
{
    public partial class FormContentControl : Form
    {
        List<Word.ContentControl> contentControls = new List<Word.ContentControl>();
        Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;


        public FormContentControl()
        {
            InitializeComponent();


            /// Thiết lập số cột, số hàng

            dataGridView1.ColumnCount = 2;
            /// Đặt tên cho các cột
            dataGridView1.Columns[0].Name = "Control Name";
            dataGridView1.Columns[1].Name = "Value";

            DisableDataGridViewSorting();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DisableDataGridViewSorting()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        /// <summary>
        ///     Tự động dò tìm các conten control và shape khi vừa mở form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            /// dò tìm các conten control và shape khi vừa mở form
            buttonRefresh_Click(null, null);
        }


        /// <summary>
        ///       Mức độ hiệu chỉnh lỗi của mã QRCode
        /// </summary>
        public enum CorrectionLevel
        {
            /// <summary> Cho phép hỏng 7% ảnh barcode  </summary>
            Low = 'L',
            /// <summary> Cho phép hỏng 15% ảnh barcode  </summary>
            Medium = 'M',
            /// <summary> Cho phép hỏng 25% ảnh barcode  </summary>
            Quad = 'Q',
            /// <summary> Cho phép hỏng 30% ảnh barcode  </summary>
            High = 'H'
        }

        /// <summary>
        ///         Trả về link ảnh từ dịch vụ QRCode của Google
        /// </summary>
        /// <param name="Text">Văn bản cần sinh mã QR</param>
        /// <param name="ImageSize">Kích thước của ảnh QR. Tối đa là 500 px</param>
        /// <param name="Correction">Mức độ chịu lỗi</param>
        /// <param name="Margin">Số điểm ảnh trắng để làm biên </param>
        /// <returns></returns>
        static string GetQRCodeWebAPI(string Text, int ImageSize = 500, CorrectionLevel Correction = CorrectionLevel.High, int Margin = 0)
        {
            StringBuilder sURL = new StringBuilder();
            sURL.AppendFormat("https://chart.googleapis.com/chart?cht=qr&chs={0}x{0}&chld={1}|{2}&chl={3}", ImageSize, Correction, Margin, Text);
            return sURL.ToString();
        }

        /// <summary>
        ///     Lấy danh sách tất cả các content control và các Shape đang có trong document hiện thời 
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> ListContentControlsInCurrentDocument()
        {
            /// Lấy tài liệu Word hiện tại
            Dictionary<string, string> controlList = new Dictionary<string, string>();

            try
            {
                /// Liệt kê tất cả các content control trong tài liệu Word hiện tại
                foreach (Word.ContentControl contentControl in document.ContentControls)
                {
                    /// Xử lý content control
                    /// Ví dụ: truy cập thuộc tính, giá trị, kiểu content control, vv.
                    string title = contentControl.Title;
                    string value = contentControl.Range.Text;
                    // Word.WdContentControlType type = contentControl.Type;
                    if (title == null || value == null) continue;
                    controlList.Add(title, value);
                }
                // Tao mot BindingList: du lieu nguon, control dich
                //Dictionary<string, string> BindingList = new Dictionary<string, string>();
                //BindingList.Add("name", "QRCodeArea");
                //Duyet tat ca cac contentcontrol co title la "name" de lay duoc thong tin roi update cac Shape co ten la "QRCodeArea"

                // Them 1 shape moi
                //document.Shapes.AddShape((int)Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, 10, 10, 10, 10);
                // Doc va sua cac shape da co
                foreach (Word.Shape shape in document.Shapes)
                {
                    controlList.Add(shape.Name, shape.Name);
                    //if (shape.Name == "QRCodeArea")
                    //{
                    //    shape.Fill.UserPicture(GetQRCodeWebAPI("Ta la dai"));
                    //}
                }

                // Doc thong tin metadata. Tham khao https://learn.microsoft.com/en-us/office/vba/api/office.documentproperties.add
                //document.CustomDocumentProperties.Add("Thong tin nay");

                //foreach (Word.CustomProperty prop in document.CustomDocumentProperties)
                //{
                //    controlList.Add(prop.Name, prop.Value);
                //}
            }
            finally
            {
            }
            return controlList;
        }

        public List<Word.ContentControl> GetAllContentControls(Word.Document document)
        {
            contentControls.Clear();
            foreach (Word.ContentControl control in document.ContentControls)
            {
                if (control.Title != null && control != null) {
                    contentControls.Add(control);
                }
            }

            return contentControls;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                dataGridView1.BeginEdit(true);
            }
        }

     
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView1.EndEdit();
            }
        }
        /// <summary>
        ///    dò tìm các conten control và shape 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> controlList = new Dictionary<string, string>();
            //controlList = ListContentControlsInCurrentDocument();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            List<Word.ContentControl> controlList = GetAllContentControls(document);
            int controlListLength = controlList.Count;

            dataGridView1.RowCount = controlListLength;

        

            // Điền dữ liệu vào bảng
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {

                dataGridView1[0, row].Value = controlList.ElementAt(row).Title;
                dataGridView1[1, row].Value = controlList.ElementAt(row).Range.Text;

            }
            // dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            int desiredWidth = (int)(0.8 * this.Width);
            // int desiredHeight = (int)(0.7 * this.Height);
            dataGridView1.Width = desiredWidth;
        }

        /// <summary>
        /// Đặt title cho content control
        /// </summary>
        /// <param name="contentControl"></param>
        /// <param name="title"></param>
        public void SetContentControlTitle(ContentControl contentControl, string title)
        {
            contentControl.Title = title;
        }

        /// <summary>
        /// Đặt text cho range của content control
        /// </summary>
        /// <param name="contentControl"></param>
        /// <param name="text"></param>
        public void SetContentControlText(ContentControl contentControl, string text)
        {
            contentControl.Range.Text = text;
        }

        private void saveContentControl_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                if(dataGridView1.Rows[row].Cells[0].Value != null && dataGridView1.Rows[row].Cells[0].Value != null)
                {
                    String cellTitle = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    String cellValue = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    contentControls.ElementAt(row).Title = cellTitle;
                    contentControls.ElementAt(row).Range.Text = cellValue;
                }
            }
            this.Close();


        }
    }
}
