using System;
using System.IO;
using System.Windows.Forms;

namespace PDFWasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = string.Format("PDFWasher V{0}", Application.ProductVersion);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Multiselect = false,
                RestoreDirectory = true,
                Filter = "PDF文件|*.pdf",
                FilterIndex = 1
            };
            if (DialogResult.OK == ofd.ShowDialog())
            {
                txtFielPath.Text = ofd.FileName;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // 文件类型则获取拖拽信息
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var date = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!date.ToLower().Contains(".pdf"))
            {
                MessageBox.Show("请拖入正确的文件!");
                return;
            }
            txtFielPath.Text = date;
        }

        private void btnWash_Click(object sender, EventArgs e)
        {
            var oldFile = txtFielPath.Text;
            var tmpFile = Path.GetTempPath() + "ratel";
            var newFile = oldFile.ToLower().Replace(".pdf", "_washed.pdf");

            if (chkRemoveRestrictions.Checked)
            {
                PdfHelper.RemoveRestrictions(oldFile, newFile);
            }

            if (chkRemoveUriLinks.Checked)
            {
                PdfHelper.RemoveRestrictions(oldFile, tmpFile);
                PdfHelper.RemoveUriLinks(tmpFile, newFile);
            }
        }
    }
}
