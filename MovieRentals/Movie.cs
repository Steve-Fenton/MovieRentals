using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentals
{
    public class Movie
    {
        public const string CHILDRENS = "CHILDRENS";
        public const string NEW_RELEASE = "NEW_RELEASE";
        public const string REGULAR = "REGULAR";

        private string title;
        private string priceCode;

        public Movie(string title, string priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public string GetPriceCode()
        {
            return priceCode;
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
