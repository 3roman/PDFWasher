using System.IO;
using System.Windows.Forms;

namespace PDFWasher
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Text = string.Format("PDFWasher V{0}", Application.ProductVersion);
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            // 设置拖入文件时鼠标效果
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (Path.GetExtension(file).ToLower().Contains(".pdf"))
                    {
                        txtPrompt.Text = "[-]操作失败";
                        if (ManiplatePDF(file))
                        {
                            txtPrompt.Text = "[+]操作成功";
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[-]{file}\r非法PDF文件", "报错信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ManiplatePDF(string pdfFile)
        {
            var succeed = false;

            var tmpFile = Path.GetTempPath() + Path.GetFileName(pdfFile);
            // 移除编辑限制
            File.Copy(pdfFile, tmpFile, true);
            succeed = PDFHelper.RemoveProtection(tmpFile, pdfFile);
            // 移除水印链接
            //File.Copy(pdfFile, tmpFile, true);
            //File.Delete(pdfFile);
            //PDFHelper.RemoveUriLinks(tmpFile, pdfFile);

            return succeed;
        }
    }
}