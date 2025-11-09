using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly StoreDbContext _context;
    public OrderRepository(StoreDbContext context) => _context = context;

    public async Task AddAsync(Order order)
        => await _context.Orders.AddAsync(order);
}
