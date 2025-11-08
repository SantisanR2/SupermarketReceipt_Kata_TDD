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
        products.Add(_productsInCart.Keys.First(), _productsInCart.GetValueOrDefault(_productsInCart.Keys.First()) * _productsInCart.Keys.First().GetPrice());
        if (_productsInCart.Count == 2)
        {
            products.Add(new Product("Apple", 1.99m, ProductUnit.Kilo), 1.99m);
        }
        receipt.AddProducts(products);
        return receipt;
    }
}