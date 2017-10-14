using System.Collections.Generic;
using KD.CurrencyConverterComparator.Models;
using System.Net;
using System.IO;
using System.Text;
using System;

namespace KD.CurrencyConverterComparator
{
    /// <summary>
    /// Abstract currency downloader.
    /// </summary>
    public abstract class AbstractCurrencyDownloader : ICurrencyDownloader
    {
        public string Title { get; private set; }
        public string WebPage { get; private set; }

        public AbstractCurrencyDownloader(string title, string webPage)
        {
            this.Title = title;
            this.WebPage = webPage;
        }

        /// <summary>
        /// Returns the response for given WebPage.
        /// </summary>
        protected string GetParsedResponse(string webPage, string type)
        {
            var request = WebRequest.CreateHttp(webPage);
            request.Method = "GET";
            request.ContentType = $"application/{ type }";
            request.Timeout = int.MaxValue;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            return readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        public abstract List<ModelCurrency> DownloadCurrencies();
    }
}