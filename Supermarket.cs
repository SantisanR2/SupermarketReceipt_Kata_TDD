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
            if (_discounts.Contains("toothbrush"))
            {
                products.Add(product.Key, 0.99m);
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