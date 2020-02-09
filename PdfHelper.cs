using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PDFWasher
{
    internal class PDFHelper
    {
        public static bool RemoveProtection(string srcFile, string dstFile)
        {
            using (var reader = new PdfReader(srcFile))
            {
                PdfReader.unethicalreading = true;
                // saving original bookmark
                var bookMark = SimpleBookmark.GetBookmark(reader);
                using (var fs = new FileStream(dstFile, FileMode.Create, FileAccess.Write))
                {
                    using (var doc = new Document())
                    {
                        using (var copy = new PdfCopy(doc, fs))
                        {
                            doc.Open();
                            for (var pageIndex = 1; pageIndex <= reader.NumberOfPages; pageIndex++)
                            {
                                copy.AddPage(copy.GetImportedPage(reader, pageIndex));
                            }
                            if (null != bookMark)
                            {
                                copy.Outlines = bookMark;
                            }
                        }

                    }
                }
            }

            return true;
        }

        //    public static void RemoveUriLinks(string srcFile, string dstFile)
        //    {
        //        using (var reader = new PdfReader(srcFile))
        //        {
        //            for (var pageIndex = 1; pageIndex <= reader.NumberOfPages; pageIndex++)
        //            {
        //                var annots = reader.GetPageN(pageIndex).GetAsArray(PdfName.ANNOTS);
        //                // 本页没有注释则跳到下一页
        //                if ((annots == null) || (annots.Length == 0))
        //                {
        //                    continue;
        //                }
        //                // 遍历当前页面所有注释
        //                for (var annotIndex = 0; annotIndex < annots.ArrayList.Count; annotIndex++)
        //                {
        //                    var annotDict = PdfReader.GetPdfObject(annots.ArrayList[annotIndex]) as PdfDictionary;
        //                    if (!HasAction(annotDict))
        //                    {
        //                        continue;
        //                    }
        //                    var annotActionObj = annotDict.Get(PdfName.A);
        //                    if (annotActionObj == null)
        //                    {
        //                        continue;
        //                    }
        //                    var annotAction =
        //                        (annotActionObj.IsIndirect()
        //                            ? PdfReader.GetPdfObject(annotActionObj)
        //                            : annotActionObj) as PdfDictionary;
        //                    if (annotAction == null)
        //                    {
        //                        continue;
        //                    }

        //                    annots.ArrayList.RemoveAt(annotIndex);
        //                }
        //            }
        //            SavePdf(reader, dstFile);
        //        }
        //    }

        //    /// <summary>
        //    /// 判断注释是不是链接
        //    /// </summary>
        //    /// <param name="annotDict"></param>
        //    /// <returns></returns>
        //    public static bool HasAction(PdfDictionary annotDict)
        //    {
        //        var subtype = annotDict.Get(PdfName.SUBTYPE);
        //        return subtype != null && subtype.Equals(PdfName.LINK);
        //    }

        //    /// <summary>
        //    /// 判断是不是URI链接
        //    /// </summary>
        //    /// <param name="annotAction"></param>
        //    /// <returns></returns>
        //    public static bool IsUriAction(PdfDictionary annotAction)
        //    {
        //        var uriObj = annotAction.Get(PdfName.S);
        //        return uriObj != null && uriObj.Equals(PdfName.URI);
        //    }

        //    public static bool IsUriLaunch(PdfDictionary annotAction)
        //    {
        //        var uriObj = annotAction.Get(PdfName.S);
        //        return uriObj != null && uriObj.Equals(PdfName.LAUNCH);
        //    }

        //    public static void SavePdf(PdfReader pdfReader, string filePath)
        //    {
        //        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //        using (var stamper = new PdfStamper(pdfReader, fileStream))
        //        {
        //            stamper.Close();
        //        }
        //    }
        //}
    }
}