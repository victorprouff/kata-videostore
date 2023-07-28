using Soat.CleanCode.VideoStore.Original.Movies;

namespace Soat.CleanCode.VideoStore.Original.Tests;

public class VideoStoreTests
{
    private readonly RentalReporter _rentalReporter;

    public VideoStoreTests()
    {
        _rentalReporter = new RentalReporter("Fred");
    }

    [Fact]
    public void TestSingleNewReleaseStatement()
    {
        _rentalReporter.AddRental(new Rental(new NewReleaseMovie("The cell"), 3));
        Assert.Equal(
            "Rental Record for Fred\n\tThe cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points \n",
            _rentalReporter.Generate());
    }

    [Fact]
    public void TestDualNewReleaseStatement()
    {
        _rentalReporter.AddRental(new Rental(new NewReleaseMovie("The cell"), 3));
        _rentalReporter.AddRental(new Rental(new NewReleaseMovie("The Tigger Movie"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tThe cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points \n",
            _rentalReporter.Generate());
    }

    [Fact]
    public void TestSingleChildrensStatement()
    {
        _rentalReporter.AddRental(new Rental(new ChildrenMovie("The Tigger Movie"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points \n",
            _rentalReporter.Generate());
    }

    [Fact]
    public void TestMultipleRegularStatement()
    {
        _rentalReporter.AddRental(new Rental(new RegularMovie("Plan 9 from Outer Space"), 1));
        _rentalReporter.AddRental(new Rental(new RegularMovie("8 1/2"), 2));
        _rentalReporter.AddRental(new Rental(new RegularMovie("Eraserhead"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points \n",
            _rentalReporter.Generate());
    }
}