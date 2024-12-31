using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchAndCQRS.Domain.ValueObjects
{
    public record Localization(string city, string country)
    {
        public static Localization Create(string value)
        {
            var splitLocalization = value.Split(',');
            return new Localization(splitLocalization.First(), splitLocalization.Last());
        }

        public override string ToString()
            => $"{city},{country}";
    }
}
