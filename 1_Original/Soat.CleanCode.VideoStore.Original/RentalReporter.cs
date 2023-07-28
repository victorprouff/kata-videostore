using System.Globalization;

namespace Soat.CleanCode.VideoStore.Original;

public class RentalReporter
{
    private readonly List<Rental> _rentals = new();
    private string CustomerName { get; }

    public RentalReporter(string customerName)
    {
        CustomerName = customerName;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string Generate()
    {
        var frequentRenterPoints = 0;
        var totalAmount = 0m;
        var result = Header();

        foreach (var rental in _rentals)
        {
            var rentalAmount = rental.DetermineAmount();

            frequentRenterPoints += rental.CalculateFrequentRenterPoints();

            result += FormatRentalLine(rental.Movie.Title, rentalAmount);
            totalAmount += rentalAmount;
        }

        result += Totals(totalAmount, frequentRenterPoints);

        return result;
    }

    private string Header() => "Rental Record for " + CustomerName + "\n";

    private string Totals(decimal totalAmount, int frequentRenterPoints)
    {
        var result = "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points \n";
        
        return result;
    }

    private static string FormatRentalLine(string rentalTitle, decimal amount) =>
        $"\t{rentalTitle}\t{amount.ToString("0.0", CultureInfo.InvariantCulture)}\n";
}