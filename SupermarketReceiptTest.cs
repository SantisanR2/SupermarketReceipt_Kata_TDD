using AwesomeAssertions;

namespace SupermarketReceipt;

public class SupermarketReceiptTest
{
    [Fact]
    public void Cuando_ComproUnCepilloDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(toothbrush, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }

    [Fact]
    public void Cuando_ComproUnKiloDeManzanaAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_1_99()
    {
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(apples, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.99m);
    }
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_1_98()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(toothbrush, 2);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
}