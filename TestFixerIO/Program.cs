using KD.CurrencyConverterComparator;
using System;
using System.Linq;

namespace TestFixerIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var downloader = new CurrencyDownloaderFixerIO();
            var result = downloader.DownloadCurrencies();

            result.ToList().ForEach(model =>
            {
                Console.WriteLine($"ShortName = { model.ShortName }");
                Console.WriteLine($"Value = { model.Value }");
                Console.WriteLine("=======================================");
            });

            Console.ReadKey();
        }
    }
}
