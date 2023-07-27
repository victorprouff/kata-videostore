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
    
    [Theory]
    [InlineData(2, 6)]
    [InlineData(5, 15)]
    public void TestCalculateAmountByDaysRentedOfNewReleaseMovie(int daysRentals, decimal expectedAmount)
    {
        var movie = new NewReleaseMovie("Lord Of the rings");

        var result = movie.CalculateAmountByDaysRented(daysRentals);
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 1.5)]
    [InlineData(5, 4.5)]
    public void TestCalculateAmountByDaysRentedOfChildrenMovie(int daysRentals, decimal expectedAmount)
    {
        var movie = new ChildrenMovie("Lord Of the rings");

        var result = movie.CalculateAmountByDaysRented(daysRentals);
        
        result.Should().Be(expectedAmount);
    }
}