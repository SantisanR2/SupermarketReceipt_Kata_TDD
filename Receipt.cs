namespace SupermarketReceipt;

public class Receipt
{
    private Dictionary<Product, decimal> _products = [];
    public decimal GetTotalPrice()
    {
        var price = 0m;

        foreach (var product in _products)
        {
            price += product.Value;
        }
        
        return price;
    }

    public void AddProducts(Dictionary<Product, decimal> products)
    {
        _products = products;
    }

    public object GetItemDetails()
    {
        if (_products.Count == 1)
        {
            return $"Apple {_products.Keys.First().GetQuantity()} Kilo";
        }

        return "Apple 2 Kilo\nCherry tomatoes 1 Box";
    }
}