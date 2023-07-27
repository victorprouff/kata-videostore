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
    
    public decimal DetermineAmount()
    {
        decimal thisAmount = 0;
        switch (Movie.PriceCode)
        {
            case Movie.REGULAR:
                thisAmount = Movie.CalculateAmountByDaysRented(DaysRented);
                break;
            case Movie.NEW_RELEASE:
                thisAmount = Movie.CalculateAmountByDaysRented(DaysRented);
                break;
            case Movie.CHILDREN:
                thisAmount = Movie.CalculateAmountByDaysRented(DaysRented);

                break;
        }

        return thisAmount;
    }
    
    public int CalculateFrequentRenterPoints()
    {
        var frequentRenterPoints = 1;

        if (Movie.PriceCode == Movie.NEW_RELEASE && DaysRented > 1)
        {
            frequentRenterPoints++;
        }

        return frequentRenterPoints;
    }
}