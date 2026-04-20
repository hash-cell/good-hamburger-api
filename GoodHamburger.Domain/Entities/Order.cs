using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public List<OrderItem> Items { get; private set; } = new();

    public decimal Subtotal { get; private set; }
    public decimal DiscountPercentage { get; private set; }
    public decimal DiscountValue { get; private set; }
    public decimal Total { get; private set; }

    private Order() { } // EF

    public Order(List<OrderItem> items)
    {
        SetItems(items);
    }

    public void UpdateItems(List<OrderItem> items)
    {
        SetItems(items);
    }

    private void SetItems(List<OrderItem> items)
    {
        Validate(items);
        Items = items;
        Calculate();
    }

    private void Validate(List<OrderItem> items)
    {
        if (!items.Any(i => i.Type == ProductType.Sandwich))
            throw new Exception("Order must contain a sandwich");

        if (items.Count(i => i.Type == ProductType.Sandwich) > 1 ||
            items.Count(i => i.Type == ProductType.Fries) > 1 ||
            items.Count(i => i.Type == ProductType.Drink) > 1)
            throw new Exception("Duplicate items are not allowed");
    }

    private void Calculate()
    {
        Subtotal = Items.Sum(i => i.Price);

        bool hasFries = Items.Any(i => i.Type == ProductType.Fries);
        bool hasDrink = Items.Any(i => i.Type == ProductType.Drink);

        if (hasFries && hasDrink)
            DiscountPercentage = 0.20m;
        else if (hasDrink)
            DiscountPercentage = 0.15m;
        else if (hasFries)
            DiscountPercentage = 0.10m;
        else
            DiscountPercentage = 0;

        DiscountValue = Subtotal * DiscountPercentage;
        Total = Subtotal - DiscountValue;
    }
}