using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task UpdateAsync(Product product);
}
