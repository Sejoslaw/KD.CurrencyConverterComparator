using KD.CurrencyConverterComparator.Models;
using System.Collections.Generic;

namespace KD.CurrencyConverterComparator
{
    /// <summary>
    /// Used to download Currency values from single WebPage.
    /// </summary>
    public interface ICurrencyDownloader
    {
        /// <summary>
        /// Title for this Downloader.
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Name of the used WebPage.
        /// </summary>
        string WebPage { get; }

        /// <summary>
        /// Method used to download currencies from current WebPage.
        /// </summary>
        IEnumerable<ModelCurrency> DownloadCurrencies();
    }
}