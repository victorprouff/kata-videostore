namespace Soat.CleanCode.VideoStore.Original;

public class Rental
{
    public int DaysRented { get; }
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
                thisAmount += 2;
                if (DaysRented > 2)
                {
                    thisAmount += (DaysRented - 2) * 1.5m;
                }

                break;
            case Movie.NEW_RELEASE:
                thisAmount += DaysRented * 3;
                break;
            case Movie.CHILDREN:
                thisAmount += 1.5m;
                if (DaysRented > 3)
                {
                    thisAmount += (DaysRented - 3) * 1.5m;
                }

                break;
        }

        return thisAmount;
    }
}