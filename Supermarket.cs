namespace SupermarketReceipt;

public class Supermarket
{
    private List<Product> _productsInCart = [];

    public void AddToCart(Product product, int quantity)
    {
        _productsInCart.Add(product);
    }

    public Receipt Checkout()
    {
        var receipt = new Receipt();
        var products = new Dictionary<Product, decimal>();
        products.Add(_productsInCart[0], _productsInCart[0].GetPrice());
        receipt.AddProducts(products);
        return receipt;
    }
}