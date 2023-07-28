using System.Globalization;

namespace Soat.CleanCode.VideoStore.Original;

public class RentalReporter
{
    private int FrequentRenterPoints { get; set; }
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
    }

    public void AddRental(Rental rental)
    {
        _rentals.Add(rental);
    }

    public string Generate()
    {
        var totalAmount = 0m;
        var result = Header();

        MakeDetails(ref result, ref totalAmount);

        result += Totals(totalAmount, FrequentRenterPoints);

        return result;
    }

    private int MakeDetails(ref string result, ref decimal totalAmount)
    {
        foreach (var rental in _rentals)
        {
            var rentalAmount = rental.DetermineAmount();

            FrequentRenterPoints += rental.CalculateFrequentRenterPoints();

            result += FormatRentalLine(rental.Movie.Title, rentalAmount);
            totalAmount += rentalAmount;
        }

        return FrequentRenterPoints;
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