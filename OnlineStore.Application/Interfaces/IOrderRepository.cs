using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
}
