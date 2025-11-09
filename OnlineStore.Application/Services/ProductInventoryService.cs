using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Services;

public class ProductInventoryService
{
    private readonly IProductRepository _productRepository;

    public ProductInventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> GetInventoryCountAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        return product?.Stock ?? 0;
    }

    public async Task UpdateInventoryAsync(int productId, int newCount)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null) throw new Exception("Product not found.");

        product.Stock = newCount;
        await _productRepository.UpdateAsync(product);
    }
}
