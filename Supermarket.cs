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

        foreach (var keyValuePair in _productsInCart)
        {
            var product = keyValuePair.Key;
            var numberOfProducts = keyValuePair.Value;
            
            if (_discounts.Any(d => d is AppleDiscount) && product.GetName() is "Apple")
            {
                var appleDiscount = new AppleDiscount(product);
                products.Add(product, appleDiscount.CalculatePrice(numberOfProducts));
            }
            else if (_discounts.Any(d => d is TomatoesDiscount) && product.GetName() is "Cherry tomatoes")
            {
                var tomatoesDiscount = new TomatoesDiscount(product);
                products.Add(product, tomatoesDiscount.CalculatePrice(numberOfProducts));
            }
            else if (_discounts.Any(d => d is ToothpasteDiscount) && product.GetName() is "Toothpaste")
            {
                var toothpasteDiscount = new ToothpasteDiscount(product);
                products.Add(product, toothpasteDiscount.CalculatePrice(numberOfProducts));
            }
            else if (_discounts.Any(d => d is RiceDiscount) && product.GetName() is "Rice")
            {
                var riceDiscount = new RiceDiscount(product);
                products.Add(product, riceDiscount.CalculatePrice(numberOfProducts));
            }
            else if (_discounts.Any(d => d is ToothbrushDiscount) && product.GetName() is "Toothbrush")
            {
                var toothbrushDiscount = new ToothbrushDiscount(product);
                products.Add(product, toothbrushDiscount.CalculatePrice(numberOfProducts));
            }
            else
            {
                products.Add(product, product.GetPrice() * numberOfProducts);
            }
        }
        
        receipt.AddProducts(products);
        return receipt;
    }

    public void ApplyDiscount(IDiscount discount)
    {
        _discounts.Add(discount);
    }
}