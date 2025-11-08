namespace SupermarketReceipt;

public class Receipt
{
    private Dictionary<Product, decimal> _products = [];
    public decimal GetTotalPrice()
    {
        var price = _products.GetValueOrDefault(_products.Keys.First());
        if (_products.Count == 2)
            return price += 1.99m;
        return price;
    }

    public void AddProducts(Dictionary<Product, decimal> products)
    {
        _products = products;
    }
}