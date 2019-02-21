using System;
using System.Collections.Generic;
using System.Text;

namespace Whats_New_CSharp_6
{
    public class Money
    {
        public Money(decimal amount, string currency)
        {
            Currency = currency;
            Amount = amount;
        }

        public static Money Parse(string input)
        {
            var parts = input.Split(' ');
            var currency = parts[1];
            if (decimal.TryParse(parts[0], out var amount))
            {
                return new Money(amount, currency);
            }
            // m suffix means to treat this literal as a decimal value
            return new Money(0m, currency);
        }

        public static Money operator +(Money m1, Money m2)
        {
            if (string.Compare(m1.Currency, m2.Currency,
                StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                var template = "Cannot add currency {0} to currency {1}";
                var message = string.Format(template, m1.Currency, m2.Currency);
                throw new InvalidOperationException(message);
            }
            return new Money(m1.Amount + m2.Amount, m1.Currency);
        }


        public string Currency { get; private set; }
        public decimal Amount { get; private set; }
    }
}
