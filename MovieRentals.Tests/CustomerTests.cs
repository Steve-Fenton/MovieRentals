using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRentals.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void StatementNewReleaseOneNight()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Dawn of the Dead", Movie.NEW_RELEASE), 1));

            string result = customer.Statement();

            Assert.AreEqual("Rental record for John Smith\n" +
                "\tDawn of the Dead\t3\n" +
                "Amount owed is 3\n" +
                "You earned 1 frequent renter points.", result);
        }

        [TestMethod]
        public void StatementNewReleaseFourNights()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Evan Almighty", Movie.NEW_RELEASE), 4));

            string result = customer.Statement();

            Assert.AreEqual("Rental record for John Smith\n" +
                "\tEvan Almighty\t12\n" +
                "Amount owed is 12\n" +
                "You earned 2 frequent renter points.", result);
        }

        [TestMethod]
        public void StatementNewReleaseSixNights()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Yes Man", Movie.NEW_RELEASE), 6));

            string result = customer.Statement();

            Assert.AreEqual("Rental record for John Smith\n" +
                "\tYes Man\t18\n" +
                "Amount owed is 18\n" +
                "You earned 2 frequent renter points.", result);
        }

        [TestMethod]
        public void StatementMultipleRentals()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Yes Man", Movie.NEW_RELEASE), 2));
            customer.AddRental(new Rental(new Movie("Bedtime Stories", Movie.CHILDRENS), 2));
            customer.AddRental(new Rental(new Movie("Mickey Mouse", Movie.CHILDRENS), 6));
            customer.AddRental(new Rental(new Movie("Back To The Future", Movie.REGULAR), 6));

            string result = customer.Statement();

            Assert.AreEqual("Rental record for John Smith\n" +
                "\tYes Man\t6\n" +
                "\tBedtime Stories\t1.5\n" +
                "\tMickey Mouse\t6\n" +
                "\tBack To The Future\t8\n" +
                "Amount owed is 21.5\n" +
                "You earned 5 frequent renter points.", result);
        }

        [TestMethod]
        public void StatementMultipleRentals2()
        {
            Customer customer = new Customer("John Smith");

            customer.AddRental(new Rental(new Movie("Jaws XIV", Movie.NEW_RELEASE), 2));
            customer.AddRental(new Rental(new Movie("Bedtime Stories", Movie.CHILDRENS), 5));
            customer.AddRental(new Rental(new Movie("Back To The Future", Movie.REGULAR), 3));
            customer.AddRental(new Rental(new Movie("Back To The Future 2", Movie.REGULAR), 4));

            string result = customer.Statement();

            Assert.AreEqual("Rental record for John Smith\n" +
                "\tJaws XIV\t6\n" +
                "\tBedtime Stories\t4.5\n" +
                "\tBack To The Future\t3.5\n" +
                "\tBack To The Future 2\t5\n" +
                "Amount owed is 19\n" +
                "You earned 5 frequent renter points.", result);
        }
    }
}
