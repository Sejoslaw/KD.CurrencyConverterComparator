using KD.CurrencyConverterComparator;
using System;
using System.Linq;

namespace TestNBP
{
    class Program
    {
        static void Main(string[] args)
        {
            var downloaderNBP = new CurrencyDownloaderNBP();
            var downloaded = downloaderNBP.DownloadCurrencies();

            downloaded.ToList().ForEach(model =>
            {
                Console.WriteLine($"ShortName = { model.ShortName }");
                Console.WriteLine($"Value = { model.Value }");
                Console.WriteLine("=======================================");
            });

            Console.ReadKey();
        }
    }
}
