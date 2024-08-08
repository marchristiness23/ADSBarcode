using iText.IO.Image;
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
    public class HeaderEventHandler : IEventHandler
    {
        private string headerText;
        private Image headerImage;
        private float imageWidth;
        private float imageHeight;

        public HeaderEventHandler(string headerText, string imagePath)
        {
            this.headerText = headerText;
            this.headerImage = new Image(ImageDataFactory.Create(imagePath));
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();

            // Add header to each page
            Rectangle pageSize = page.GetPageSize();
            float x = pageSize.GetWidth() - 20; // Adjusted to position on the right
            float y = pageSize.GetTop() - 20;

            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            Canvas canvas = new Canvas(pdfCanvas, pageSize);
            headerImage.SetWidth(120);
            headerImage.SetHeight(40);
            // Add the image to the header
            float imageX = 460; // Adjust to position on the right
            float imageY = 785; // Adjust to position near the top
            headerImage.SetFixedPosition(imageX, imageY);
            canvas.Add(headerImage);

            // Add the header text
            canvas.ShowTextAligned(headerText, x, y, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
            canvas.Close();
        }

    }
}
