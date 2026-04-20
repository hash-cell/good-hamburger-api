using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.DTOs;

public class OrderResponse
{
    public Guid Id { get; set; }
    public decimal Subtotal { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal Total { get; set; }

    public static OrderResponse FromEntity(Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            Subtotal = order.Subtotal,
            DiscountPercentage = order.DiscountPercentage,
            DiscountValue = order.DiscountValue,
            Total = order.Total
        };
    }
}