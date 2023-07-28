using System.Globalization;

namespace Soat.CleanCode.VideoStore.Original;

public class RentalReporter
{
    private int FrequentRenterPoints { get; set; }
    private decimal TotalAmount { get; set; }
    private readonly List<Rental> _rentals = new();
    private string CustomerName { get; }

    public RentalReporter(string customerName)
    {
        ClearTotals();
        CustomerName = customerName;
    }

    private void ClearTotals()
    {
        FrequentRenterPoints = 0;
        TotalAmount = 0m;
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string Generate() => MakeHeader() + MakeDetails() + MakeTotal();

    private string MakeHeader() => "Rental Record for " + CustomerName + "\n";

    private string MakeDetails() =>
        _rentals.Aggregate(string.Empty, (current, rental) => current + MakeRentalLine(rental));

    private string MakeRentalLine(Rental rental)
    {
        var amount = rental.DetermineAmount();

        FrequentRenterPoints += rental.CalculateFrequentRenterPoints();
        TotalAmount += amount;

        return FormatRentalLine(rental.Movie.Title, amount);
    }

    private string MakeTotal() =>
        $"You owed {TotalAmount.ToString("0.0", CultureInfo.InvariantCulture)}\n" +
        $"You earned {FrequentRenterPoints} frequent renter points \n";

    private static string FormatRentalLine(string rentalTitle, decimal amount) =>
        $"\t{rentalTitle}\t{amount.ToString("0.0", CultureInfo.InvariantCulture)}\n";
}