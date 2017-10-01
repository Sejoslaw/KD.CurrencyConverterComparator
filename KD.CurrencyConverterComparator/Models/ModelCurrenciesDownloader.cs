using System.Collections.Generic;

namespace KD.CurrencyConverterComparator.Models
{
    /// <summary>
    /// Model which contains all currently registered Downloaders.
    /// </summary>
    public class ModelCurrenciesDownloader
    {
        public IEnumerable<ICurrencyDownloader> Downloaders { get; private set; }

        public ModelCurrenciesDownloader()
        {
            this.Downloaders = new List<ICurrencyDownloader>()
            {
                new CurrencyDownloaderNBP(),
                new CurrencyDownloaderFixerIO()
            };
        }
    }
}