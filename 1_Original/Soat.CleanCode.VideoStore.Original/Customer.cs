using System.Globalization;

namespace Soat.CleanCode.VideoStore.Original;

public class Customer
{
    private readonly List<Rental> _rentals = new List<Rental>();
    public string Name { get; }

    public Customer(string name)
    {
        Name = name;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string Statement()
    {
        var frequentRenterPoints = 0;
        var totalAmount = 0m;
        var result = "Rental Record for " + Name + "\n";
        foreach (var rental in _rentals)
        {
            var thisAmount = 0m;

            //dtermines the amount for each line
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                    {
                        thisAmount += (rental.DaysRented - 2) * 1.5m;
                    }

                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5m;
                    if (rental.DaysRented > 3)
                    {
                        thisAmount += (rental.DaysRented - 3) * 1.5m;
                    }

                    break;
            }

            frequentRenterPoints++;

            if (rental.Movie.PriceCode == Movie.NEW_RELEASE
                && rental.DaysRented > 1)
            {
                frequentRenterPoints++;
            }

            result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            totalAmount += thisAmount;
        }

        result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
        result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points \n";

        return result;
    }
}