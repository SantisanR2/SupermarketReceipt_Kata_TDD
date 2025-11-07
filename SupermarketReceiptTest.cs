using AwesomeAssertions;

namespace SupermarketReceipt;

public class SupermarketReceiptTest
{
    [Fact]
    public void Cuando_ComproUnaCremaDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var catalog = new Catalog();
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        catalog.AddProduct(toothbrush);
        var supermarket = new Supermarket(catalog);
        
        supermarket.AddToCart(toothbrush, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }

    [Fact]
    public void Cuando_ComproUnKiloDeManzanaAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_1_99()
    {
        var catalog = new Catalog();
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        catalog.AddProduct(apples);
        var supermarket = new Supermarket(catalog);
        
        supermarket.AddToCart(apples, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.99m);
    }
}