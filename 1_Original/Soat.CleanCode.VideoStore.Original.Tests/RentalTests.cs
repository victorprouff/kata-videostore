using FluentAssertions;

namespace Soat.CleanCode.VideoStore.Original.Tests;

public class RentalTests
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(5, 6.5)]
    public void TestDetermineAmountWithRegularMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new Movie("Lord Of the rings", Movie.REGULAR), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 6)]
    [InlineData(5, 15)]
    public void TestDetermineAmountWithNewReleaseMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new Movie("Lord Of the rings", Movie.NEW_RELEASE), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 1.5)]
    [InlineData(5, 4.5)]
    public void TestDetermineAmountWithChildrenMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new Movie("Lord Of the rings", Movie.CHILDREN), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 0)]
    [InlineData(5, 0)]
    public void TestDetermineAmountWithOtherPriceCodeMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new Movie("Lord Of the rings", 42), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
}