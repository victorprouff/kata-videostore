using System.Globalization;

namespace Soat.CleanCode.VideoStore.Original;

public class Customer
{
    private readonly List<Rental> _rentals = new();
    private string Name { get; }

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
            var thisAmount = rental.DetermineAmount();

            frequentRenterPoints = rental.CalculateFrequentRenterPoints();

            result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            totalAmount += thisAmount;
        }

        result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points \n";

        return result;
    }
}