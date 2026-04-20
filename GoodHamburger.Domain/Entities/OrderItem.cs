using GoodHamburger.Domain.Enums;

namespace GoodHamburger.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public ProductType Type { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    private OrderItem() { } // EF

    public OrderItem(ProductType type, string name, decimal price)
    {
        Type = type;
        Name = name;
        Price = price;
    }
}