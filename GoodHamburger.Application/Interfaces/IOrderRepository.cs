using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Application.Interfaces;

public interface IOrderRepository
{
    Task Add(Order order);
    Task<List<Order>> GetAll();
    Task<Order?> GetById(Guid id);
    Task Update(Order order);
    Task Delete(Order order);
}