using Microsoft.EntityFrameworkCore;
using GoodHamburger.Domain.Entities;

namespace GoodHamburger.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
}