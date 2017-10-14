using System.Collections.Generic;
using System.Linq;
using KD.CurrencyConverterComparator.Models;
using Newtonsoft.Json.Linq;

namespace KD.CurrencyConverterComparator
{
    /// <summary>
    /// Currency downloader for fixer.io
    /// </summary>
    public class CurrencyDownloaderFixerIO : AbstractCurrencyDownloader
    {
        /// <summary>
        /// WebSite prefix
        /// </summary>
        string Prefix
        {
            get
            {
                return "https://api.fixer.io/latest?base=";
            }
        }
        /// <summary>
        /// Suffix which should be added after each currency.
        /// </summary>
        string Suffix
        {
            get
            {
                return "&symbols=PLN";
            }
        }

        public CurrencyDownloaderFixerIO() :
            base("fixer.io", "https://api.fixer.io/latest?base=")
        {
        }

        public override List<ModelCurrency> DownloadCurrencies()
        {
            // Get all possible currencies
            var all = this.GetParsedResponse("PLN");
            // Parse and get available currencies
            var currencies = this.GetAvailableCurrencies(all);

            List<ModelCurrency> returnCurrencies = new List<ModelCurrency>();

            // Get response for each currency converted to PLN
            foreach (var currency in currencies)
            {
                // Response for each Currency
                var response = this.GetParsedResponse(currency.ShortName + Suffix);

                // if something went wrong with this request
                if (response.Equals(""))
                {
                    break;
                }

                var parsedToPln = this.GetAvailableCurrencies(response);

                // Trick to get actual value
                var value = parsedToPln[0].Value;

                // Add right conversion to list
                returnCurrencies.Add(new ModelCurrency(null, currency.ShortName, value));
            }

            returnCurrencies = returnCurrencies.OrderBy(selector => selector.ShortName).ToList();
            return returnCurrencies;
        }

        private List<ModelCurrency> GetAvailableCurrencies(string all)
        {
            if (all.Equals(""))
            {
                return new List<ModelCurrency>();
            }

            var plnResponseJSON = JObject.Parse(all);
            var properties = plnResponseJSON.Children();

            List<ModelCurrency> currencies = new List<ModelCurrency>();
            // JSON Properties
            foreach (JToken property in properties)
            {
                if (property.Path.Equals("rates"))
                {
                    // Actual rates
                    var rates = property.First.Children();
                    foreach (JToken rate in rates)
                    {
                        var code = this.ParseJsonPathToCurrencyName(rate.Path);
                        var value = rate.First.Value<string>();
                        currencies.Add(new ModelCurrency(null, code, value));
                    }
                }
            }

            return currencies;
        }

        private string ParseJsonPathToCurrencyName(string path)
        {
            var parts = path.Split('.');
            return parts[1];
        }

        private string GetParsedResponse(string baseAndSuffix)
        {
            return this.GetParsedResponse(this.Prefix + baseAndSuffix, "json");
        }
    }
}