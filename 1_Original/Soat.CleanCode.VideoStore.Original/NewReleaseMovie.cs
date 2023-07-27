namespace Soat.CleanCode.VideoStore.Original;

public class NewReleaseMovie : Movie
{
    private const decimal BaseAmount = 3;

    public NewReleaseMovie(string title)
        : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented) => daysRented * BaseAmount;
}