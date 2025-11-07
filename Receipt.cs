namespace SupermarketReceipt;

public class Receipt
{
    private Dictionary<Product, decimal> _products = [];
    public decimal GetTotalPrice()
    {
        return _products.GetValueOrDefault(_products.Keys.First());
    }

    public void AddProducts(Dictionary<Product, decimal> products)
    {
        _products = products;
    }
}