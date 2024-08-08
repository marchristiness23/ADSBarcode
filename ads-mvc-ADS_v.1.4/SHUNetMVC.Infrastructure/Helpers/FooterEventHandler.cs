using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.Helpers
{
    public class FooterEventHandler : IEventHandler
    {
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            int pageNumber = pdfDoc.GetPageNumber(page);

            // Create a footer with page number
            Paragraph footer = new Paragraph().Add("Page " + pageNumber)
                                              .SetFontColor(iText.Kernel.Colors.ColorConstants.GRAY)
                                              .SetFontSize(8)
                                              .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);

            // Get PdfCanvas object to write to page content
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            Rectangle pageSize = page.GetPageSize();

            // Add footer to the page
            new Canvas(pdfCanvas, pageSize)
                .ShowTextAligned(footer, pageSize.GetWidth() / 2, 30, pageNumber, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);

            // Release canvas
            pdfCanvas.Release();
        }
    }
}
