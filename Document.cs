using iText.Kernel.Pdf;
using System;

namespace HotelManagementSystem
{
    internal class Document
    {
        private PdfDocument pdf;

        public Document(PdfDocument pdf)
        {
            this.pdf = pdf;
        }

        internal void Add(Paragraph paragraph)
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}