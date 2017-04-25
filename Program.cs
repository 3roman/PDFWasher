using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace UnlockPDF
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("本程序支持批量解除PDF编辑限制，处理完自动覆盖原文件。");
            Console.WriteLine("Tips:由于嵌入了dll资源，360可能会报毒，请忽略之!");
            Console.WriteLine("『C0de by 工艺系统室-热工组-hangch Ver1.1』\n");

            var ofd = new OpenFileDialog()
            {
                Multiselect = true,
                RestoreDirectory = true,
                Filter = "PDF文件|*.pdf",
                FilterIndex = 1
            };
            var pdfFiles = new List<string>();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                pdfFiles = new List<string>(ofd.FileNames);
            }

            AppDomain.CurrentDomain.AssemblyResolve += LoadManagedDllResource;

            var exceptionMessage = string.Empty;
            foreach (var pdfFile in pdfFiles)
            {
                if (DecryptPDF(pdfFile, ref exceptionMessage))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+]Succeed --> " + Path.GetFileName(pdfFile));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[-]Failed  --> " + Path.GetFileName(pdfFile) + " >>>> Exception: " + exceptionMessage);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[!]All Done");

            Console.ReadKey();
        }

        private static bool DecryptPDF(string pdfFile, ref string exceptionMessage)
        {
            try
            {
                var tmpFile = Path.GetTempPath() + "tmp.pdf";

                var reader = new PdfReader(pdfFile);
                PdfReader.unethicalreading = true;

                var document = new Document(reader.GetPageSize(1), 50, 50, 50, 50);
                // 创建该文档
                var writer = PdfWriter.GetInstance(document, new FileStream(tmpFile, FileMode.Create));
                // 打开文档
                document.Open();
                // 写入内容
                var cb = writer.DirectContent;
                var pageIndex = 0;
                while (pageIndex < reader.NumberOfPages)
                {
                    document.NewPage();
                    pageIndex++;
                    var newPage = writer.GetImportedPage(reader, pageIndex);
                    cb.AddTemplate(newPage, 1f, 0, 0, 1f, 0, 0);
                }
                document.Close();
                reader.Close();
                File.Copy(tmpFile, pdfFile, true);
            }
            catch (Exception ex)
            {
                exceptionMessage = ex.Message;
                return false;
            }

            return true;
        }

        private static Assembly LoadManagedDllResource(object sender, ResolveEventArgs args)
        {
            var dllName = MethodBase.GetCurrentMethod().DeclaringType.Namespace +
                "." +
                new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dllName))
            {
                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return Assembly.Load(buffer);
            }
        }
    }
}