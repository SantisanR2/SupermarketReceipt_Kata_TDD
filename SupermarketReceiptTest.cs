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
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesYUnKiloDeManzanasAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_3_97()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(toothbrush, 2);
        supermarket.AddToCart(apples, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.97m);
    }
    
    [Fact]
    public void Cuando_ComproUnaBolsaDeTomatesCherryUnKiloDeManzanasYUnCepilloDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_3_67()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        var tomatoes = new Product("Cherry tomatoes", 0.69m, ProductUnit.Box);
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(toothbrush, 1);
        supermarket.AddToCart(apples, 1);
        supermarket.AddToCart(tomatoes, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.67m);
    }
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        supermarket.AddToCart(toothbrush, 2);
        supermarket.ApplyDiscount("toothbrushes");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }
}