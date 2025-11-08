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
        var details = "";
        
        foreach (var (product, price) in _products)
        {
            details += $"{product.GetName()} {product.GetQuantity()} {product.getUnit()}\n";
        }
        
        return details.TrimEnd('\n');
    }
}