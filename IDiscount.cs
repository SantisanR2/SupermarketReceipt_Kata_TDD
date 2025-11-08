namespace SupermarketReceipt;

public interface IDiscount
{
    decimal CalculatePrice(int numberOfProducts);
}

public class AppleDiscount(Product apple) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return numberOfProducts * apple.GetPrice() * 0.8m;
    }
}

public class TomatoesDiscount(Product tomatoes) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 2m) * 0.99m + (numberOfProducts % 2) * tomatoes.GetPrice();
    }
}

public class ToothpasteDiscount(Product toothpaste) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 5m) * 7.49m + (numberOfProducts % 5) * toothpaste.GetPrice();
    }
}

public class RiceDiscount(Product rice) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return numberOfProducts * rice.GetPrice() * 0.9m;
    }
}

public class ToothbrushDiscount(Product toothbrush) : IDiscount
{
    public decimal CalculatePrice(int numberOfProducts)
    {
        return Math.Truncate(numberOfProducts / 2m) * toothbrush.GetPrice() + (numberOfProducts % 2) * toothbrush.GetPrice();
    }
}