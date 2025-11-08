namespace SupermarketReceipt;

public class Supermarket
{
    private Dictionary<Product, int> _productsInCart = [];
    private List<string> _discounts = [];

    public void AddToCart(Product product, int quantity)
    {
        _productsInCart.Add(product, quantity);
    }

    public Receipt Checkout()
    {
        var receipt = new Receipt();
        var products = new Dictionary<Product, decimal>();

        foreach (var product in _productsInCart)
        {
            if (_discounts.Contains("toothbrush") && product.Key.GetName().Equals("Toothbrush"))
            {
                products.Add(product.Key, Math.Truncate(product.Value/2m) * product.Key.GetPrice() + (product.Value % 2) * product.Key.GetPrice());
            }
            else if (_discounts.Contains("apple") && product.Key.GetName().Equals("Apple"))
            {
                products.Add(product.Key, product.Value * product.Key.GetPrice() * 0.8m);
            }
            else if (_discounts.Contains("rice") && product.Key.GetName().Equals("Rice"))
            {
                products.Add(product.Key, product.Value * product.Key.GetPrice() * 0.9m);
            }
            else if (_discounts.Contains("toothpaste") && product.Key.GetName().Equals("Toothpaste"))
            {
                products.Add(product.Key, Math.Truncate(product.Value/5m) * 7.49m + (product.Value % 5) * product.Key.GetPrice());
            }
            else if (_discounts.Contains("tomatoes") && product.Key.GetName().Equals("Cherry tomatoes"))
            {
                products.Add(product.Key, Math.Truncate(product.Value/2m) * 0.99m + (product.Value % 2) * product.Key.GetPrice());
            }
            else
            {
                products.Add(product.Key, product.Key.GetPrice() * product.Value);
            }
        }
        
        receipt.AddProducts(products);
        return receipt;
    }

    public void ApplyDiscount(string discount)
    {
        _discounts.Add(discount);
    }
}