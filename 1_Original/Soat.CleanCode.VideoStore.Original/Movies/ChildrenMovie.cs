namespace Soat.CleanCode.VideoStore.Original.Movies;

public class ChildrenMovie : Movie
{
    private const decimal BaseAmount = 1.5m;

    public ChildrenMovie(string title) : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        if (daysRented > 3)
        {
            return BaseAmount + (daysRented - 3) * 1.5m;
        }

        return BaseAmount;
    }
}