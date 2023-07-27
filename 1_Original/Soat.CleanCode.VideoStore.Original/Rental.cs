namespace Soat.CleanCode.VideoStore.Original;

public class Rental
{
    private int DaysRented { get; }
    public virtual Movie Movie { get; }

    public Rental(Movie movie, int daysRented)
    {
        Movie      = movie;
        DaysRented = daysRented;
    }
    
    public decimal DetermineAmount() => Movie.CalculateAmountByDaysRented(DaysRented);

    public int CalculateFrequentRenterPoints()
    {
        var frequentRenterPoints = 1;
        
        if (Movie is NewReleaseMovie && DaysRented > 1)
        {
            frequentRenterPoints++;
        }

        return frequentRenterPoints;
    }
}