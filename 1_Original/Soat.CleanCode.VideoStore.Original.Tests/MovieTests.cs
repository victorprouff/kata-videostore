using FluentAssertions;

namespace Soat.CleanCode.VideoStore.Original.Tests;

public class MovieTests
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(5, 6.5)]
    public void TestCalculateAmountByDaysRentedOfRegularMovie(int daysRentals, decimal expectedAmount)
    {
        var movie = new RegularMovie("Lord Of the rings");

        var result = movie.CalculateAmountByDaysRented(daysRentals);
        
        result.Should().Be(expectedAmount);
    }
}