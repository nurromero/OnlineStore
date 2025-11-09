using OnlineStore.Application.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreDbContext _context;
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }
    public IPaymentRepository Payments { get; }

    public UnitOfWork(StoreDbContext context,
                      IProductRepository products,
                      IOrderRepository orders,
                      IPaymentRepository payments)
    {
        _context = context;
        Products = products;
        Orders = orders;
        Payments = payments;
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
