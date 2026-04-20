using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.DTOs;

public class CreateOrderRequest
{
    public List<OrderItem> Items { get; set; } = new();
}