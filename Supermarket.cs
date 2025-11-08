namespace SupermarketReceipt;

public class Supermarket
{
    private Dictionary<Product, int> _productsInCart = [];
    private List<IDiscount> _discounts = [];

    public void AddToCart(Product product, int quantity)
    {
        _productsInCart.Add(product, quantity);
    }

    public Receipt Checkout()
    {
        var receipt = new Receipt();
        var products = new Dictionary<Product, decimal>();

        foreach (var (product, numberOfProducts) in _productsInCart)
        {
            decimal price;
            var applicableDiscount = _discounts.FirstOrDefault(d => d.IsApplicableTo(product));
            
            if (applicableDiscount != null)
                price = applicableDiscount.CalculatePrice(numberOfProducts);
            else
                price = product.GetPrice() * numberOfProducts;
                
            products.Add(product, price);
        }
        
        receipt.AddProducts(products);
        return receipt;
    }

    public void ApplyDiscount(IDiscount discount)
    {
        _discounts.Add(discount);
    }
}