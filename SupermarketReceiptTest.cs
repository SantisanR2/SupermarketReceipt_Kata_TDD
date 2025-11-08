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
        supermarket.ApplyDiscount("toothbrush");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }
    
    [Fact]
    public void Cuando_ComproTresCepillosDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_1_98()
    {
        var toothbrush = new Product("Toothbrush", 0.99m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        supermarket.AddToCart(toothbrush, 3);
        supermarket.ApplyDiscount("toothbrush");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Cuando_ComproUnKiloDeManzanasConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_1_592()
    {
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        var supermarket = new Supermarket();
        supermarket.AddToCart(apples, 1);
        supermarket.ApplyDiscount("apple");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.592m);
    }
    
    [Fact]
    public void Cuando_ComproDosKilosDeManzanasConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_3_184()
    {
        var apples = new Product("Apple", 1.99m, ProductUnit.Kilo);
        var supermarket = new Supermarket();
        supermarket.AddToCart(apples, 2);
        supermarket.ApplyDiscount("apple");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.184m);
    }
    
    [Fact]
    public void Cuando_ComproUnaBolsaDeArrozConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_2_241()
    {
        var rice = new Product("Rice", 2.49m, ProductUnit.Bag);
        var supermarket = new Supermarket();
        supermarket.AddToCart(rice, 1);
        supermarket.ApplyDiscount("rice");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(2.241m);
    }
    
    [Fact]
    public void Cuando_ComproDosBolsasDeArrozConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_4_482()
    {
        var rice = new Product("Rice", 2.49m, ProductUnit.Bag);
        var supermarket = new Supermarket();
        supermarket.AddToCart(rice, 2);
        supermarket.ApplyDiscount("rice");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(4.482m);
    }
    
    [Fact]
    public void Cuando_ComproCincoTubosDePastaDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_7_49()
    {
        var toothpaste = new Product("Toothpaste", 1.79m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        supermarket.AddToCart(toothpaste, 5);
        supermarket.ApplyDiscount("toothpaste");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(7.49m);
    }
    
    [Fact]
    public void Cuando_ComproSeisTubosDePastaDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_9_28()
    {
        var toothpaste = new Product("Toothpaste", 1.79m, ProductUnit.Unit);
        var supermarket = new Supermarket();
        supermarket.AddToCart(toothpaste, 6);
        supermarket.ApplyDiscount("toothpaste");
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(9.28m);
    }
}