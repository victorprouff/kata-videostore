namespace Soat.CleanCode.VideoStore.Original;

public abstract class Movie
{
    public const int REGULAR     = 0;
    public const int NEW_RELEASE = 1;
    public const int CHILDREN    = 2;

    public int PriceCode { get; }
    public decimal BaseAmount { get; }
    public string Title { get; }

    protected Movie(string title, int priceCode, decimal baseAmount)
    {
        Title     = title;
        PriceCode = priceCode;
        BaseAmount = baseAmount;
    }

    public abstract decimal CalculateAmountByDaysRented(int daysRented);
}

public class RegularMovie : Movie
{
    public RegularMovie(string title)
        : base(title, 0, 2)
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

public class NewReleaseMovie : Movie
{
    public NewReleaseMovie(string title)
        : base(title, 1, 3)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        throw new NotImplementedException();
    }
}

public class ChildrenMovie : Movie
{
    public ChildrenMovie(string title) : base(title, 2, 1.5m)
    {
    }

    public override decimal CalculateAmountByDaysRented(int daysRented)
    {
        throw new NotImplementedException();
    }
}