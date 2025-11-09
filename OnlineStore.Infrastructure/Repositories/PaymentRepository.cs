using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly StoreDbContext _context;
    public PaymentRepository(StoreDbContext context) => _context = context;

    public async Task AddAsync(Payment payment)
        => await _context.Payments.AddAsync(payment);
}
