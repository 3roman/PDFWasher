using System;
using System.IO;
using System.Windows.Forms;

namespace PDFWasher
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Text = string.Format("PDFWasher V{0}", Application.ProductVersion);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            var date = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!date.ToLower().Contains(".pdf"))
            {
                txtFielPath.Text = "非pdf文件!!!";
                return;
            }
            txtFielPath.Text = date;

            var tmpFile = Path.GetTempPath() + Path.GetFileName(date);
            // 移除编辑限制
            File.Copy(date, tmpFile, true);
            File.Delete(date);
            PdfHelper.RemoveRestrictions(tmpFile, date);
            // 移除水印链接
            File.Copy(date, tmpFile, true);
            File.Delete(date);
            PdfHelper.RemoveUriLinks(tmpFile, date);
        }
    }
}
