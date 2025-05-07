using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace Services.Services
{
    public class PrintService : IPrintService
    {
        private readonly IProductService _productService;
        private readonly IPrintConfigurationService _configService;

        public PrintService(IProductService productService, IPrintConfigurationService configService)
        {
            _productService = productService;
            _configService = configService;
        }

        public async Task PrintProductTagAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            // Ensure product has all relations loaded
            if (product.Supplier == null || product.Size == null)
            {
                product = await _productService.GetWithAllRelationsAsync(product.Id);
            }

            // Create a new print document
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = GetConfiguredPrinterName();
            pd.PrintPage += (sender, e) => PrintTagPage(sender, e, product);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error printing tag: {ex.Message}", ex);
            }
        }

        private string GetConfiguredPrinterName()
        {
            var config = _configService.GetPrintTagConfiguration();
            string printerNameContains = config.PrinterNameContains ?? "Brother QL-800";

            // Get all installed printers
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                // Look for the configured printer
                if (printer.Contains(printerNameContains))
                {
                    return printer;
                }
            }

            // If printer not found, throw exception
            throw new Exception($"{printerNameContains} printer not found. Please make sure it's properly installed.");
        }

        private void PrintTagPage(object sender, PrintPageEventArgs e, Product product)
        {
            // Get configuration
            var config = _configService.GetPrintTagConfiguration();

            // Set up graphics
            Graphics g = e.Graphics;

            // Create fonts from configuration
            Font titleFont = config.TitleFont.CreateFont();
            Font normalFont = config.NormalFont.CreateFont();
            Font priceFont = config.PriceFont.CreateFont();

            // Get layout settings from configuration
            int startX = config.StartX;
            int startY = config.StartY;
            int lineHeight = config.LineHeight;
            int titleBottomMargin = config.TitleBottomMargin;

            // Draw product name
            g.DrawString(product.Name, titleFont, Brushes.Black, startX, startY);
            startY += lineHeight + titleBottomMargin;

            // Draw SKU
            g.DrawString($"SKU: {product.SKU}", normalFont, Brushes.Black, startX, startY);
            startY += lineHeight;

            // Draw size
            g.DrawString($"Talla: {product.Size?.Name ?? "N/A"}", normalFont, Brushes.Black, startX, startY);
            startY += lineHeight;

            // Draw colors
            string colors = string.Join(", ", product.ProductColors.Select(pc => pc.Color.Name));
            g.DrawString($"Color(es): {colors}", normalFont, Brushes.Black, startX, startY);
            startY += lineHeight;

            // Draw price (emphasize this)
            g.DrawString($"Precio: ${product.RoundedPrice:N0}", priceFont, Brushes.Black, startX, startY);

            // No more pages to print
            e.HasMorePages = false;
        }
    }
}
