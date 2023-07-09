using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using PDFWasher.Utility;

namespace PDFWasher.ViewModel
{
    class MainViewModel
    {
        public void OnPreviewMouseMove(object sender, EventArgs e) 
        {
            if (e is DragEventArgs dragEvent)
            {
                dragEvent.Effects = dragEvent.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
            }
        }

        public void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string filePath in filePaths)
                {
                    if (string.Compare(Path.GetExtension(filePath), ".pdf") == 0)
                    {
                        string tmpFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(filePath));
                        //File.Copy(filePath, tmpFilePath, true);
                        //PDFHelper.RemoveEditRestriction(tmpFilePath, filePath);
                        File.Copy(filePath, tmpFilePath, true);
                        PDFHelper.RemoveLinks(tmpFilePath, filePath);
                    }
                }
            }
        }

        public void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Application.Current.Shutdown();
        }
    }
}
