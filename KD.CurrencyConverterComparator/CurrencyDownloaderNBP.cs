using System.Collections.Generic;
using KD.CurrencyConverterComparator.Models;
using System.Linq;
using System.Xml;

namespace KD.CurrencyConverterComparator
{
    /// <summary>
    /// Currency downloader for NBP.
    /// </summary>
    public class CurrencyDownloaderNBP : AbstractCurrencyDownloader
    {
        public CurrencyDownloaderNBP() :
            base("Narodowy Bank Polski", "http://api.nbp.pl/api/exchangerates/tables/A/") // NBP XML with currencies Purchases / Sales
        {
        }

        public override List<ModelCurrency> DownloadCurrencies()
        {
            // Get Response from NBP and parse it to XmlReader
            var response = this.GetParsedResponse(this.WebPage, "xml");

            // Divide to separate Rates
            var document = new XmlDocument();
            // Parse XML to Document
            document.LoadXml(response);

            // Get childrens
            var rates = document.GetElementsByTagName("Rate");

            List<ModelCurrency> models = new List<ModelCurrency>();

            // Parse Rates to list
            foreach (XmlNode rate in rates)
            {
                // Properties
                var values = rate.ChildNodes;

                // Get properties for Model
                var fullName = values[0].InnerText;
                var code = values[1].InnerText;
                var value = values[2].InnerText;

                // Add new Model to list
                models.Add(new ModelCurrency(fullName, code, value));
            }

            models = models.OrderBy(selector => selector.ShortName).ToList();
            return models;
        }
    }
}