using System.IO;
using System.Windows.Forms;

namespace PDFWasher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            // 设置拖入文件时鼠标效果
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (FileAttributes.Directory == File.GetAttributes(files[0]))
                {
                    files = Directory.GetFiles(files[0], "*.pdf", searchOption:SearchOption.AllDirectories);
                }

                var count = 0;
                foreach (var file in files)
                {
                    if (Path.GetExtension(file).ToLower().Contains(".pdf"))
                    {

                        if (ManiplatePDF(file))
                        {
                            count++;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"[-]{file}\r非法PDF文件", "警告",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                label1.Text = $"成功处理{count}/{files.Length}个文件";
            }
        }


        private bool ManiplatePDF(string pdfFile)
        {
            var tmpFile = Path.GetTempPath() + Path.GetFileName(pdfFile);
            // 移除编辑限制
            File.Copy(pdfFile, tmpFile, true);
            var succeed = PDFHelper.RemoveProtection(tmpFile, pdfFile);
            //TODO 移除水印

            return succeed;
        }
    }
}