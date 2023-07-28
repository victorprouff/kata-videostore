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

    public string Generate()
    {
        var result = MakeHeader();

        MakeDetails(ref result);

        result += MakeTotal();

        return result;
    }

    private void MakeDetails(ref string result)
    {
        foreach (var rental in _rentals)
        {
            var rentalAmount = rental.DetermineAmount();

            FrequentRenterPoints += rental.CalculateFrequentRenterPoints();

            result += FormatRentalLine(rental.Movie.Title, rentalAmount);
            TotalAmount += rentalAmount;
        }
    }

    private string MakeHeader() => "Rental Record for " + CustomerName + "\n";

    private string MakeTotal()
    {
        var result = "You owed " + TotalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
        result += "You earned " + FrequentRenterPoints + " frequent renter points \n";
        
        return result;
    }

    private static string FormatRentalLine(string rentalTitle, decimal amount) =>
        $"\t{rentalTitle}\t{amount.ToString("0.0", CultureInfo.InvariantCulture)}\n";
}