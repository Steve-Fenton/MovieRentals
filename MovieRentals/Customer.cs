using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentals
{
    public class Customer
    {
        private string name;
        private ArrayList rentals = new ArrayList();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;

            string result = "Rental record for " + name + "\n";
            for (int i = 0; i < rentals.Count; i++)
            {
                Rental each = (Rental)rentals[i];
                double
                thisAmount = 0;

                switch
                (each.GetMovie().GetPriceCode())
                {
                    case
                    Movie.REGULAR:
                        thisAmount += 2;
                        if (each.GetDaysRented() > 2)
                        {
                            thisAmount += (each.GetDaysRented() - 2) * 1.5;
                        }
                        break;
                    case
                    Movie.NEW_RELEASE:
                        thisAmount += each.GetDaysRented() * 3;
                        break;
                    case
                    Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.GetDaysRented() > 3)
                        {
                            thisAmount += (each.GetDaysRented() - 3) * 1.5;
                        }
                        break;
                }
                frequentRenterPoints++;
                if ((each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && (each.GetDaysRented() > 1))
                {
                    frequentRenterPoints++;
                }
                result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount.ToString() + "\n"; totalAmount += thisAmount;
            }
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString()
                + " frequent renter points.";
            return result;
        }
    }
}
