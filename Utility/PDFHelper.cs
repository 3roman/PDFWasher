using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace PDFWasher.Utility
{
    class PDFHelper
    {
        public static bool RemoveEditRestriction(string srcFile, string dstFile)
        {
            PdfReader.unethicalreading = true;
            PdfReader reader = new PdfReader(srcFile);
            using Stream fs = new FileStream(dstFile, FileMode.Create);
            Document doc = new Document();
            PdfCopy copy = new PdfCopy(doc, fs);
            doc.Open();
            copy.AddDocument(reader);
            var originalBookMark = SimpleBookmark.GetBookmark(reader);
            if (null != originalBookMark)
            {
                copy.Outlines = originalBookMark;
            }
            copy.Close();
            reader.Close();

            return true;
        }

        public static bool RemoveLinks(string srcFile, string dstFile)
        {
            PdfReader reader = new PdfReader(srcFile);
            using PdfStamper stamper = new PdfStamper(reader, new FileStream(dstFile, FileMode.Create));
            // TODO How to remove xobjects?
            

            return true;
        }
    }
}
