using GoodHamburger.Application.DTOs;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrderResponse> Create(CreateOrderRequest request)
    {
        var order = new Order(request.Items);

        await _repository.Add(order);

        return OrderResponse.FromEntity(order);
    }

    public async Task<List<OrderResponse>> GetAll()
    {
        var orders = await _repository.GetAll();

        return orders.Select(OrderResponse.FromEntity).ToList();
    }

    public async Task<OrderResponse?> GetById(Guid id)
    {
        var order = await _repository.GetById(id);

        if (order == null)
            return null;

        return OrderResponse.FromEntity(order);
    }

    public async Task<OrderResponse?> Update(Guid id, CreateOrderRequest request)
    {
        var order = await _repository.GetById(id);

        if (order == null)
            return null;

        order.UpdateItems(request.Items);

        await _repository.Update(order);

        return OrderResponse.FromEntity(order);
    }

    public async Task<bool> Delete(Guid id)
    {
        var order = await _repository.GetById(id);

        if (order == null)
            return false;

        await _repository.Delete(order);

        return true;
    }
}