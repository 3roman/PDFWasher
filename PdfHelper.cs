using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFWasher
{
    class PdfHelper
    {
        public static void RemoveRestrictions(string oldFile, string newFile)
        {
            using (var reader = new PdfReader(oldFile))
            {
                PdfReader.unethicalreading = true;
                // saving original bookmark
                var bookerMark = SimpleBookmark.GetBookmark(reader);
                using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
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
                            if (null != bookerMark)
                            {
                                copy.Outlines = bookerMark;
                            }
                        }

                    }
                }
            }
        }

        public static void RemoveUriLinks(string oldFile, string newFile)
        {
            using (var reader = new PdfReader(oldFile))
            {
                // 遍历所有页面
                for (var pageIndex = 1; pageIndex <= reader.NumberOfPages; pageIndex++)
                {
                    var annots = reader.GetPageN(pageIndex).GetAsArray(PdfName.ANNOTS);
                    // 本页没有注释则跳到下一页
                    if ((annots == null) || (annots.Length == 0))
                    {
                        continue;
                    }
                    // 遍历当前页面所有注释
                    for (var annotIndex = 0; annotIndex < annots.ArrayList.Count; annotIndex++)
                    {
                        var annotDict = PdfReader.GetPdfObject(annots.ArrayList[annotIndex]) as PdfDictionary;
                        if (!HasAction(annotDict))
                        {
                            continue;
                        }
                        var annotActionObj = annotDict.Get(PdfName.A);
                        if (annotActionObj == null)
                        {
                            continue;
                        }
                        var annotAction =
                            (annotActionObj.IsIndirect()
                                ? PdfReader.GetPdfObject(annotActionObj)
                                : annotActionObj) as PdfDictionary;
                        if (annotAction == null)
                        {
                            continue;
                        }

                        annots.ArrayList.RemoveAt(annotIndex);
                    }
                }
                SavePdf(reader, newFile);
            }
        }

        /// <summary>
        /// 判断注释是不是链接
        /// </summary>
        /// <param name="annotDict"></param>
        /// <returns></returns>
        public static bool HasAction(PdfDictionary annotDict)
        {
            var subtype = annotDict.Get(PdfName.SUBTYPE);
            return subtype != null && subtype.Equals(PdfName.LINK);
        }

        /// <summary>
        /// 判断是不是URI链接
        /// </summary>
        /// <param name="annotAction"></param>
        /// <returns></returns>
        public static bool IsUriAction(PdfDictionary annotAction)
        {
            var uriObj = annotAction.Get(PdfName.S);
            return uriObj != null && uriObj.Equals(PdfName.URI);
        }

        public static bool IsUriLaunch(PdfDictionary annotAction)
        {
            var uriObj = annotAction.Get(PdfName.S);
            return uriObj != null && uriObj.Equals(PdfName.LAUNCH);
        }

        public static void SavePdf(PdfReader pdfReader, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (var stamper = new PdfStamper(pdfReader, fileStream))
            {
                stamper.Close();
            }
        }
    }
}
