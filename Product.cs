namespace SupermarketReceipt;

public class Product
{
    private decimal _price;
    private string _name;
    private int _quantity;
    public Product(string name, decimal price, ProductUnit unit)
    {
        _name = name;
        _price = price;
    }

    public decimal GetPrice()
    {
        return _price;
    }

    public string GetName()
    {
        return _name;
    }

    public void AddQuantity(int numberOfProducts)
    {
        _quantity = numberOfProducts;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}