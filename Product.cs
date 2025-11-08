namespace SupermarketReceipt;

public class Product(string name, decimal price, ProductUnit unit)
{
    private int _quantity;

    public decimal GetPrice()
    {
        return price;
    }

    public string GetName()
    {
        return name;
    }

    public void AddQuantity(int numberOfProducts)
    {
        _quantity = numberOfProducts;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public string GetUnit()
    {
        return unit.ToString();
    }
}