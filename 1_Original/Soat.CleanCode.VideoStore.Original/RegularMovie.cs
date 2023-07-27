namespace Soat.CleanCode.VideoStore.Original;

public class RegularMovie : Movie
{
    private const decimal BaseAmount = 2;

    public RegularMovie(string title)
        : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        var amount = BaseAmount;
        if (daysRented > 2)
        {
            amount += (daysRented - 2) * 1.5m;
        }

        return amount;
    }
}