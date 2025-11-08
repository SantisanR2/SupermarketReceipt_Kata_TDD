namespace SupermarketReceipt;

public interface IDiscount
{
    decimal CalculatePrice(int quantity);
    bool IsApplicableTo(Product product);
    string GetDiscountName();
}

public class AppleDiscount(Product apple) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return numberOfProducts * apple.GetPrice() * 0.8m;
    }
    
    public bool IsApplicableTo(Product product) => product.GetName() == apple.GetName();
    
    public string GetDiscountName() => "Apple Discount";
}

public class TomatoesDiscount(Product tomatoes) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 2m) * 0.99m + (numberOfProducts % 2) * tomatoes.GetPrice();
    }
    
    public bool IsApplicableTo(Product product) => product.GetName() == tomatoes.GetName();
    
    public string GetDiscountName() => "Cherry Tomatoes Discount";
}

public class ToothpasteDiscount(Product toothpaste) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 5m) * 7.49m + (numberOfProducts % 5) * toothpaste.GetPrice();
    }
    
    public bool IsApplicableTo(Product product) => product.GetName() == toothpaste.GetName();
    
    public string GetDiscountName() => "Toothpaste Discount";
}

public class RiceDiscount(Product rice) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return numberOfProducts * rice.GetPrice() * 0.9m;
    }
    
    public bool IsApplicableTo(Product product) => product.GetName() == rice.GetName();
    
    public string GetDiscountName() => "Rice Discount";
}

public class ToothbrushDiscount(Product toothbrush) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 2m) * toothbrush.GetPrice() + (numberOfProducts % 2) * toothbrush.GetPrice();
    }
    
    public bool IsApplicableTo(Product product) => product.GetName() == toothbrush.GetName();
    
    public string GetDiscountName() => "Toothbrush Discount";
}