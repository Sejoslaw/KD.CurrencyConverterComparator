using System;

namespace KD.CurrencyConverterComparator.Models
{
    /// <summary>
    /// Describes single currency.
    /// </summary>
    public class ModelCurrency
    {
        /// <summary>
        /// Full name of the currency.
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// Short name of this currency.
        /// </summary>
        public string ShortName { get; private set; }
        /// <summary>
        /// Value of this currency.
        /// </summary>
        public string Value { get; private set; }

        public ModelCurrency(string fullName, string shortName, string value)
        {
            this.FullName = fullName;
            this.ShortName = shortName;
            this.Value = value;
        }

        /// <summary>
        /// Converts current Value to double.
        /// </summary>
        public double GetDouble()
        {
            return Convert.ToDouble(this.Value.Replace(".", ","));
        }
    }
}