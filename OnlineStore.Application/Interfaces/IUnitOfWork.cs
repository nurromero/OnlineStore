namespace OnlineStore.Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IPaymentRepository Payments { get; }
    Task<int> SaveChangesAsync();
}
