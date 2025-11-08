namespace SupermarketReceipt;

public class Product
{
    private decimal _price;
    private string _name;
    private int _quantity;
    private ProductUnit _unit;
    public Product(string name, decimal price, ProductUnit unit)
    {
        _name = name;
        _price = price;
        _unit = unit;
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

    public string getUnit()
    {
        return _unit.ToString();
    }
}