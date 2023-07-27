using FluentAssertions;

namespace Soat.CleanCode.VideoStore.Original.Tests;

public class RentalTests
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(5, 6.5)]
    public void TestDetermineAmountWithRegularMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new RegularMovie("Lord Of the rings"), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 6)]
    [InlineData(5, 15)]
    public void TestDetermineAmountWithNewReleaseMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new NewReleaseMovie("Lord Of the rings"), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }
    
    [Theory]
    [InlineData(2, 1.5)]
    [InlineData(5, 4.5)]
    public void TestDetermineAmountWithChildrenMovie(int daysRentals, decimal expectedAmount)
    {
        var rental = new Rental(new ChildrenMovie("Lord Of the rings"), daysRentals);

        var result = rental.DetermineAmount();
        
        result.Should().Be(expectedAmount);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 1)]
    public void TestCalculateFrequentRenterPointsForRegularMovie(int daysRentals, int points)
    {
        var rental = new Rental(new RegularMovie("Lord Of the rings"), daysRentals);

        var result = rental.CalculateFrequentRenterPoints();
        
        result.Should().Be(points);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 2)]
    public void TestCalculateFrequentRenterPointsForNewReleaseMovie(int daysRentals, int points)
    {
        var rental = new Rental(new NewReleaseMovie("Lord Of the rings"), daysRentals);

        var result = rental.CalculateFrequentRenterPoints();
        
        result.Should().Be(points);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 1)]
    public void TestCalculateFrequentRenterPointsForChildrenMovie(int daysRentals, int points)
    {
        var rental = new Rental(new ChildrenMovie("Lord Of the rings"), daysRentals);

        var result = rental.CalculateFrequentRenterPoints();
        
        result.Should().Be(points);
    }
}