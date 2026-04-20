using Microsoft.EntityFrameworkCore;
using GoodHamburger.Application.Interfaces;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Data;

namespace GoodHamburger.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAll()
    {
        return await _context.Orders.Include(o => o.Items).ToListAsync();
    }

    public async Task<Order?> GetById(Guid id)
    {
        return await _context.Orders.Include(o => o.Items)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Order order)
    {
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}