namespace Soat.CleanCode.VideoStore.Original;

public class Movie
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
}

public class RegularMovie : Movie
{
    public RegularMovie(string title)
        : base(title, 0, 2)
    {
    }
}

public class NewReleaseMovie : Movie
{
    public NewReleaseMovie(string title)
        : base(title, 1, 3)
    {
    }
}

public class ChildrenMovie : Movie
{
    public ChildrenMovie(string title) : base(title, 2, 1.5m)
    {
    }
}