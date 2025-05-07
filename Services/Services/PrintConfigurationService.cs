using Microsoft.Extensions.Configuration;
using Services.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;


namespace Services.Services
{
    public class PrintConfigurationService: IPrintConfigurationService
    {
        private readonly IConfiguration _configuration;
        private PrintTagConfiguration _cachedConfig;

        public PrintConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PrintTagConfiguration GetPrintTagConfiguration()
        {
            if (_cachedConfig != null)
                return _cachedConfig;

            // Try to bind from appsettings.json first
            var config = new PrintTagConfiguration();
            _configuration.GetSection("PrintTagConfiguration").Bind(config);

            // If we have an external config file path specified
            string externalConfigPath = _configuration["PrintTagConfigurationPath"];
            if (!string.IsNullOrEmpty(externalConfigPath) && File.Exists(externalConfigPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(externalConfigPath);
                    config = JsonSerializer.Deserialize<PrintTagConfiguration>(jsonContent);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error reading print tag configuration file: {ex.Message}", ex);
                }
            }

            // Set default values if not specified
            SetDefaultValues(config);

            _cachedConfig = config;
            return config;
        }

        private void SetDefaultValues(PrintTagConfiguration config)
        {
            // Font defaults
            if (config.TitleFont == null)
            {
                config.TitleFont = new PrintTagConfiguration.FontConfig
                {
                    FontFamily = "Arial",
                    Size = 10,
                    Style = FontStyle.Bold
                };
            }

            if (config.NormalFont == null)
            {
                config.NormalFont = new PrintTagConfiguration.FontConfig
                {
                    FontFamily = "Arial",
                    Size = 8,
                    Style = FontStyle.Regular
                };
            }

            if (config.PriceFont == null)
            {
                config.PriceFont = new PrintTagConfiguration.FontConfig
                {
                    FontFamily = "Arial",
                    Size = 12,
                    Style = FontStyle.Bold
                };
            }

            // Layout defaults
            if (config.StartX <= 0)
                config.StartX = 10;

            if (config.StartY <= 0)
                config.StartY = 10;

            if (config.LineHeight <= 0)
                config.LineHeight = 15;

            if (config.TitleBottomMargin <= 0)
                config.TitleBottomMargin = 5;
        }
    }
}
