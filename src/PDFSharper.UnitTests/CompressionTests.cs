using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace PDFSharper.UnitTests
{
    [TestClass]
    public class CompressionTests
    {
        [TestMethod]
        public void SaveReducedSize_NoModifications()
        {
            byte[] reducedPdf = GetReducedSizePdfData();
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
