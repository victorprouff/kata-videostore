namespace Soat.CleanCode.VideoStore.Original;

public abstract class Movie
{
    public string Title { get; }

    protected Movie(string title)
    {
        Title = title;
    }

    public abstract decimal CalculateAmountByDaysRented(int daysRented);
}