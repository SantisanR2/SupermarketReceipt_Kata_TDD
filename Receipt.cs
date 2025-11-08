namespace SupermarketReceipt;

public class Receipt
{
    private Dictionary<Product, decimal> _products = [];
    private List<string> _appliedDiscounts = [];
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
            details += $"{product.GetName()} {product.GetQuantity()} {product.GetUnit()}\n";
        }
        
        return details.TrimEnd('\n');
    }

    public string GetAppliedDiscounts()
    {
        var discounts = "";

        foreach (var discount in _appliedDiscounts)
        {
            discounts += $"{discount} Applied\n";
        }

        return discounts.TrimEnd('\n');
    }

    public void AddAppliedDiscounts(List<string> discounts)
    {
        _appliedDiscounts = discounts;
    }
}