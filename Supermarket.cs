namespace SupermarketReceipt;

public class Supermarket
{
    private readonly Dictionary<Product, int> _productsInCart = [];
    private readonly List<IDiscount> _discounts = [];

    public void AddToCart(Product product, int quantity)
    {
        _productsInCart.Add(product, quantity);
    }

    public Receipt Checkout()
    {
        var receipt = new Receipt();
        var products = new Dictionary<Product, decimal>();
        var appliedDiscounts = new List<string>();

        foreach (var (product, numberOfProducts) in _productsInCart)
        {
            decimal price;
            var applicableDiscount = _discounts.FirstOrDefault(d => d.IsApplicableTo(product));
            
            if (applicableDiscount != null)
            {
                price = applicableDiscount.CalculatePrice(numberOfProducts);
                appliedDiscounts.Add(applicableDiscount.GetDiscountName());
            }
            else
                price = product.GetPrice() * numberOfProducts;
                
            products.Add(product, price);
            product.AddQuantity(numberOfProducts);
        }
        
        receipt.AddProducts(products);
        receipt.AddAppliedDiscounts(appliedDiscounts);
        return receipt;
    }

    public void ApplyDiscount(IDiscount discount)
    {
        _discounts.Add(discount);
    }
}