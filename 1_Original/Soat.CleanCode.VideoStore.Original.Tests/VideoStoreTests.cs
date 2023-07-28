using Soat.CleanCode.VideoStore.Original.Movies;

namespace Soat.CleanCode.VideoStore.Original.Tests;

public class VideoStoreTests
{
    private readonly Customer _customer;

    public VideoStoreTests()
    {
        _customer = new Customer("Fred");
    }

    [Fact]
    public void TestSingleNewReleaseStatement()
    {
        _customer.AddRental(new Rental(new NewReleaseMovie("The cell"), 3));
        Assert.Equal(
            "Rental Record for Fred\n\tThe cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points \n",
            _customer.Statement());
    }

    [Fact]
    public void TestDualNewReleaseStatement()
    {
        _customer.AddRental(new Rental(new NewReleaseMovie("The cell"), 3));
        _customer.AddRental(new Rental(new NewReleaseMovie("The Tigger Movie"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tThe cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points \n",
            _customer.Statement());
    }

    [Fact]
    public void TestSingleChildrensStatement()
    {
        _customer.AddRental(new Rental(new ChildrenMovie("The Tigger Movie"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points \n",
            _customer.Statement());
    }

    [Fact]
    public void TestMultipleRegularStatement()
    {
        _customer.AddRental(new Rental(new RegularMovie("Plan 9 from Outer Space"), 1));
        _customer.AddRental(new Rental(new RegularMovie("8 1/2"), 2));
        _customer.AddRental(new Rental(new RegularMovie("Eraserhead"), 3));

        Assert.Equal(
            "Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points \n",
            _customer.Statement());
    }
}