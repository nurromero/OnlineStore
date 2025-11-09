using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
}
