using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using PdfSharper.Pdf;
using PdfSharper.Pdf.IO;
using System.IO;

namespace PDFSharper.UnitTests
{
    [TestClass]
    public class CompressionTests
    {
        [TestMethod]
        public void SaveReducedSize_NoModifications()
        {
            byte[] reducedPdf = GetReducedSizePdfData();

            using (MemoryStream ms = new MemoryStream(reducedPdf))
            {
                PdfDocument doc = PdfReader.Open(ms);
                var b = doc.AcroForm;
                var x = b.Fields;
            }
        }

        private static byte[] GetReducedSizePdfData()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            using (var pdfStream = executingAssembly.GetManifestResourceStream("PDFSharper.UnitTests.ReducedSizePdf.pdf"))
            {

                byte[] result = new byte[pdfStream.Length];
                pdfStream.Read(result, 0, result.Length);
                return result;
            }
        }
    }
}
