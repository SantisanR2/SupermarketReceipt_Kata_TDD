using AwesomeAssertions;

namespace SupermarketReceipt;

public class SupermarketReceiptTest
{
    private readonly Product _toothbrush = new ("Toothbrush", 0.99m, ProductUnit.Unit);
    private readonly Product _toothpaste = new ("Toothpaste", 1.79m, ProductUnit.Unit);
    private readonly Product _tomatoes = new ("Cherry tomatoes", 0.69m, ProductUnit.Box);
    private readonly Product _apples = new ("Apple", 1.99m, ProductUnit.Kilo);
    private readonly Product _rice = new ("Rice", 2.49m, ProductUnit.Bag);
    
    [Fact]
    public void Cuando_ComproUnCepilloDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(_toothbrush, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }

    [Fact]
    public void Cuando_ComproUnKiloDeManzanaAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_1_99()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(_apples, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.99m);
    }
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_1_98()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(_toothbrush, 2);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesYUnKiloDeManzanasAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_3_97()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(_toothbrush, 2);
        supermarket.AddToCart(_apples, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.97m);
    }
    
    [Fact]
    public void Cuando_ComproUnaBolsaDeTomatesCherryUnKiloDeManzanasYUnCepilloDeDientesAPrecioNormal_ElPrecioTotalDelRecibo_Debe_SerDe_3_67()
    {
        var supermarket = new Supermarket();
        
        supermarket.AddToCart(_toothbrush, 1);
        supermarket.AddToCart(_apples, 1);
        supermarket.AddToCart(_tomatoes, 1);
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.67m);
    }
    
    [Fact]
    public void Cuando_ComproDosCepillosDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothbrush, 2);
        var discount = new ToothbrushDiscount(_toothbrush);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }
    
    [Fact]
    public void Cuando_ComproTresCepillosDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_1_98()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothbrush, 3);
        var discount = new ToothbrushDiscount(_toothbrush);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.98m);
    }
    
    [Fact]
    public void Cuando_ComproUnKiloDeManzanasConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_1_592()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 1);
        var discount = new AppleDiscount(_apples);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.592m);
    }
    
    [Fact]
    public void Cuando_ComproDosKilosDeManzanasConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_3_184()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 2);
        var discount = new AppleDiscount(_apples);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(3.184m);
    }
    
    [Fact]
    public void Cuando_ComproUnaBolsaDeArrozConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_2_241()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_rice, 1);
        var discount = new RiceDiscount(_rice);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(2.241m);
    }
    
    [Fact]
    public void Cuando_ComproDosBolsasDeArrozConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_4_482()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_rice, 2);
        var discount = new RiceDiscount(_rice);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(4.482m);
    }
    
    [Fact]
    public void Cuando_ComproCincoTubosDePastaDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_7_49()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothpaste, 5);
        var discount = new ToothpasteDiscount(_toothpaste);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(7.49m);
    }
    
    [Fact]
    public void Cuando_ComproSeisTubosDePastaDeDientesConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_9_28()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothpaste, 6);
        var discount = new ToothpasteDiscount(_toothpaste);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(9.28m);
    }
    
    [Fact]
    public void Cuando_ComproDosCajasDeTomatesCherryConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_0_99()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_tomatoes, 2);
        var discount = new TomatoesDiscount(_tomatoes);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(0.99m);
    }
    
    [Fact]
    public void Cuando_ComproTresCajasDeTomatesCherryConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_1_68()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_tomatoes, 3);
        var discount = new TomatoesDiscount(_tomatoes);
        supermarket.ApplyDiscount(discount);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(1.68m);
    }
    
    [Fact]
    public void Cuando_ComproSeisTubosDePastaDeDientes_UnKiloDeManzanas_DosCepillosDeDientes_UnaBolsaDeArroz_Y_TresCajasDeTomatesCherryConDescuento_ElPrecioTotalDelRecibo_Debe_SerDe_15_783()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothpaste, 6);
        supermarket.AddToCart(_tomatoes, 3);
        supermarket.AddToCart(_apples, 1);
        supermarket.AddToCart(_rice, 1);
        supermarket.AddToCart(_toothbrush, 2);
        var discountToothpaste = new ToothpasteDiscount(_toothpaste);
        var discountTomatoes = new TomatoesDiscount(_tomatoes);
        var discountApples = new AppleDiscount(_apples);
        var discountRice = new RiceDiscount(_rice);
        var discountToothbrush = new ToothbrushDiscount(_toothbrush);
        supermarket.ApplyDiscount(discountToothpaste);
        supermarket.ApplyDiscount(discountTomatoes);
        supermarket.ApplyDiscount(discountApples);
        supermarket.ApplyDiscount(discountRice);
        supermarket.ApplyDiscount(discountToothbrush);
        
        var receipt = supermarket.Checkout();
        
        receipt.GetTotalPrice().Should().Be(15.783m);
    }

    [Fact]
    public void Cuando_ComproUnKiloDeManzanas_LosDetallesDeLaCompraDelRecibo_Debe_DecirUnKiloDeManzana()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 1);

        var receipt = supermarket.Checkout();

        receipt.GetItemDetails().Should().Be("Apple 1 Kilo");
    }
    
    [Fact]
    public void Cuando_ComproDosKilosDeManzanas_LosDetallesDeLaCompraDelRecibo_Debe_DecirDosKilosDeManzana()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 2);

        var receipt = supermarket.Checkout();

        receipt.GetItemDetails().Should().Be("Apple 2 Kilo");
    }
    
    [Fact]
    public void Cuando_ComproDosKilosDeManzanas_Y_UnaCajaDeTomatesCherry_LosDetallesDeLaCompraDelRecibo_Debe_DecirDosKilosDeManzana_Y_UnaCajaDeTomatesCherry()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 2);
        supermarket.AddToCart(_tomatoes, 1);

        var receipt = supermarket.Checkout();

        receipt.GetItemDetails().Should().Be("Apple 2 Kilo\nCherry tomatoes 1 Box");
    }
    
    [Fact]
    public void Cuando_ComproUnaPastaDeDientes_DosBolsasDeArroz_Y_UnaCajaDeTomatesCherry_LosDetallesDeLaCompraDelRecibo_Debe_DecirUnaPastaDeDientes_DosBolsasDeArroz_Y_UnaCajaDeTomatesCherry()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_toothpaste, 1);
        supermarket.AddToCart(_rice, 2);
        supermarket.AddToCart(_tomatoes, 1);

        var receipt = supermarket.Checkout();

        receipt.GetItemDetails().Should().Be("Toothpaste 1 Unit\nRice 2 Bag\nCherry tomatoes 1 Box");
    }

    [Fact]
    public void CuandoComproUnKiloDeManzanasConDescuento_EnLosDescuentosAplicadosEnElRecibo_Debe_DecirDescuentoDeManzanasAplicado()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 1);
        var discountApples = new AppleDiscount(_apples);
        supermarket.ApplyDiscount(discountApples);

        var receipt = supermarket.Checkout();

        receipt.GetAppliedDiscounts().Should().Be("Apple Discount Applied");
    }
    
    [Fact]
    public void CuandoComproUnKiloDeManzanas_Y_UnaBolsaDeArrozConDescuento_EnLosDescuentosAplicadosEnElRecibo_Debe_DecirDescuentoDeManzanasAplicado_DescuentoDeArrozAplicado()
    {
        var supermarket = new Supermarket();
        supermarket.AddToCart(_apples, 1);
        supermarket.AddToCart(_rice, 1);
        var discountApples = new AppleDiscount(_apples);
        var discountRice = new RiceDiscount(_rice);
        supermarket.ApplyDiscount(discountApples);
        supermarket.ApplyDiscount(discountRice);

        var receipt = supermarket.Checkout();

        receipt.GetAppliedDiscounts().Should().Be("Apple Discount Applied\nRice Discount Applied");
    }
}