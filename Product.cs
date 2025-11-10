// csharp
using System;

namespace SupermarketReceipt;

public class Product
{
    private readonly string _name;
    private readonly decimal _price;
    private readonly ProductUnit _unit;
    private int _quantity;

    public Product(string name, decimal price, ProductUnit unit)
    {
        if (price < 0) throw new ArgumentException("El precio no puede ser negativo.");
        _name = name;
        _price = price;
        _unit = unit;
    }

    public decimal GetPrice() => _price;

    public string GetName() => _name;

    public void AddQuantity(int numberOfProducts) => _quantity = numberOfProducts;

    public int GetQuantity() => _quantity;

    public string GetUnit() => _unit.ToString();
}