using System.Collections.Generic;

namespace KD.CurrencyConverterComparator.Models
{
    /// <summary>
    /// Model which is used to collect all various data about single row in main table.
    /// </summary>
    public class ModelRow
    {
        /// <summary>
        /// All Currencies with the same name in single table row.
        /// </summary>
        public List<ModelCurrency> ConnectedCurrencies { get; set; }

        public ModelRow()
        {
            this.ConnectedCurrencies = new List<ModelCurrency>();
        }
    }
}