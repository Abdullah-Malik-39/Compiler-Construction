using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace CC_Lab2
{
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("TWords", "Words Starting with T");
            dataGridView1.Columns.Add("MWords", "Words Starting with M");
            Button loadPdfButton = new Button { Text = "Load PDF", Dock = DockStyle.Top };
            loadPdfButton.Click += LoadPdfButton_Click;
            this.Controls.Add(loadPdfButton);
        }

        private void LoadPdfButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string extractedText = ExtractTextFromPdf(filePath);
                    FindAndDisplayWords(extractedText);
                }
            }
        }

        private string ExtractTextFromPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader pdfReader = new PdfReader(filePath))
            using (PdfDocument pdfDoc = new PdfDocument(pdfReader))
            {
                for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page)));
                }
            }
            return text.ToString();
        }
        private void FindAndDisplayWords(string text)
        {
            string tPattern = @"\b[tT]\w*\b";
            string mPattern = @"\b[mM]\w*\b";
            MatchCollection tMatches = Regex.Matches(text, tPattern);
            MatchCollection mMatches = Regex.Matches(text, mPattern);
            dataGridView1.Rows.Clear();
            int maxRows = Math.Max(tMatches.Count, mMatches.Count);
            for (int i = 0; i < maxRows; i++)
            {
                string tWord = i < tMatches.Count ? tMatches[i].Value : string.Empty;
                string mWord = i < mMatches.Count ? mMatches[i].Value : string.Empty;
                dataGridView1.Rows.Add(tWord, mWord);
            }
        }
    }
}
