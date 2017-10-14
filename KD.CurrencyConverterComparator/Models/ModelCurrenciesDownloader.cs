using System.Collections.Generic;

namespace KD.CurrencyConverterComparator.Models
{
    /// <summary>
    /// Model which contains all currently registered Downloaders.
    /// </summary>
    public class ModelCurrenciesDownloader
    {
        public List<ICurrencyDownloader> Downloaders { get; private set; }

        public ModelCurrenciesDownloader()
        {
            this.Downloaders = new List<ICurrencyDownloader>()
            {
                new CurrencyDownloaderNBP(), // Used as index on HTML page
                new CurrencyDownloaderFixerIO()
            };
        }
    }
}