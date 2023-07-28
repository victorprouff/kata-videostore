namespace Soat.CleanCode.VideoStore.Original.Movies;

public class NewReleaseMovie : Movie
{
    private const decimal BaseAmount = 3;

    public NewReleaseMovie(string title)
        : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented) => daysRented * BaseAmount;
    public override int CalculateFrequentRenterPoints(int daysRented)
    {
        if (daysRented > 1)
        {
            return BaseFrequentRenterPoints + 1;
        }

        return BaseFrequentRenterPoints;
    }
}