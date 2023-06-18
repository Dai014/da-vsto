using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;
using Word = Microsoft.Office.Interop.Word;


namespace datn
{
    public partial class FormListQR : Form
    {
        Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
        List<Word.Shape> shapeList = new List<Word.Shape>();
        public FormListQR()
        {
            InitializeComponent();

            // Thiết lập số cột, số hàng
            dataGridView1.ColumnCount = 2;
            // Đặt tên cho các cột
            dataGridView1.Columns[0].Name = "Name QR CODE";
            dataGridView1.Columns[1].Name = "Value";

            DisableDataGridViewSorting();
        }

        private void DisableDataGridViewSorting()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void FormListQR_Load(object sender, EventArgs e)
        {
            refreshBtn_Click(null, null);
        }

        private List<Word.Shape> getAllQRCode()
        {
            shapeList.Clear();
            foreach (Word.Shape shape in document.Shapes)
            {
                if (shape.Name.Contains("QR_")) {
                    shapeList.Add(shape);
                }
            }
            return shapeList;
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

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            List<Word.Shape> shapes = getAllQRCode();
            int shapesLength = shapes.Count;

            dataGridView1.RowCount = shapesLength;

            // Điền dữ liệu vào bảng
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                dataGridView1[0, row].Value = shapes.ElementAt(row).Name;
                dataGridView1[1, row].Value = shapes.ElementAt(row).AlternativeText;

            }
            // dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            int desiredWidth = (int)(0.8 * this.Width);
            // int desiredHeight = (int)(0.7 * this.Height);
            dataGridView1.Width = desiredWidth;
        }

        private void saveListQR_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < dataGridView1.RowCount; row++)
            {
                if (dataGridView1.Rows[row].Cells[0].Value != null && dataGridView1.Rows[row].Cells[0].Value != null)
                {
                    String cellName = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    String cellValue = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    shapeList.ElementAt(row).Select();
                    shapeList.ElementAt(row).Delete();
                    Ribbon1 ribbon1 = new Ribbon1();
                    Shape qrCode = ribbon1.addQrCode(cellValue);
                    qrCode.Name = cellName;
                    shapeList.Add(qrCode);
                }
            }
            this.Close();

        }
    }
}
