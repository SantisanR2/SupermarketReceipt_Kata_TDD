namespace SupermarketReceipt;

public class Product
{
    private decimal _price;
    public Product(string name, decimal price, ProductUnit unit)
    {
        _price = price;
    }

    public decimal GetPrice()
    {
        return _price;
    }
}