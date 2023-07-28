namespace Soat.CleanCode.VideoStore.Original.Movies;

public class RegularMovie : Movie
{
    private const decimal BaseAmount = 2;

    public RegularMovie(string title)
        : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        if (daysRented > 2)
        {
            return BaseAmount + (daysRented - 2) * 1.5m;
        }

        return BaseAmount;
    }

    public override int CalculateFrequentRenterPoints(int daysRented) => BaseFrequentRenterPoints;
}