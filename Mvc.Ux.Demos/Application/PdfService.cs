///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Drawing;
using SelectPdf;

namespace Mvc.Ux.Demos.Application
{
    public class PdfService
    {
        public static void Create(string html, string filename, string baseUrl = "", string title = "")
        {
            var converter = new HtmlToPdf();
            converter.Options.DrawBackground = true;
            converter.Options.KeepImagesTogether = true;
            converter.Options.EmbedFonts = true;
            converter.Options.MarginTop = 50;
            converter.Options.MarginBottom = 50;
            converter.Options.MarginLeft = 80;
            converter.Options.MarginRight = 80;
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1024;
            converter.Options.WebPageHeight = 0;
            converter.Options.CssMediaType = HtmlToPdfCssMediaType.Screen;
            converter.Options.DisplayFooter = true;

            var footer = new PdfTextSection(0, 10, "{page_number} / {total_pages}", new Font("Arial", 8))
            {
                HorizontalAlign = PdfTextHorizontalAlign.Right
            };
            converter.Footer.Add(footer);

            // Save PDF document
            var doc = converter.ConvertHtmlString(html, baseUrl);
            doc.DocumentInformation.Title = title;
            doc.DocumentInformation.Author = "UI Best Practices Playbook for ASP.NET MVC";
            doc.DocumentInformation.Subject = title;
            doc.DocumentInformation.CreationDate = DateTime.Now;
            
            doc.Save(filename);
            doc.Close();
        }
    }
}