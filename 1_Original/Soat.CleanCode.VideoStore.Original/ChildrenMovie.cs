namespace Soat.CleanCode.VideoStore.Original;

public class ChildrenMovie : Movie
{
    private const decimal BaseAmount = 1.5m;

    public ChildrenMovie(string title) : base(title)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        var amount = BaseAmount;
        if (daysRented > 3)
        {
            amount += (daysRented - 3) * 1.5m;
        }

        return amount;
    }
}