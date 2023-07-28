namespace Soat.CleanCode.VideoStore.Original.Movies;

public abstract class Movie
{
    protected const int BaseFrequentRenterPoints = 1;
    public string Title { get; }

    protected Movie(string title)
    {
        Title = title;
    }

    public abstract decimal CalculateAmountByDaysRented(int daysRented);
    public abstract int CalculateFrequentRenterPoints(int daysRented);
}