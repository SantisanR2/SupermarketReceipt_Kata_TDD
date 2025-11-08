namespace SupermarketReceipt;

public class Supermarket
{
    private Dictionary<Product, int> _productsInCart = [];

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
            products.Add(product.Key, product.Key.GetPrice() * product.Value);
        }
        
        receipt.AddProducts(products);
        return receipt;
    }

    public void ApplyDiscount(string toothbrushes)
    {
        throw new NotImplementedException();
    }
}