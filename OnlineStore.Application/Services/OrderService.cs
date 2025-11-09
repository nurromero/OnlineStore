using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Application.Services;

public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StoreDbContext _context;

    public OrderService(IUnitOfWork unitOfWork, StoreDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<bool> PlaceOrderAsync(int productId, int quantity, decimal paymentAmount)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Get product
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null || product.Stock < quantity)
                throw new Exception("Not enough stock available.");

            // 2Reduce stock
            product.Stock -= quantity;
            await _unitOfWork.Products.UpdateAsync(product);

            // Create order
            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = paymentAmount
            };
            await _unitOfWork.Orders.AddAsync(order);

            //  Record payment
            var payment = new Payment
            {
                OrderId = order.Id,
                Amount = paymentAmount,
                Status = "Completed"
            };
            await _unitOfWork.Payments.AddAsync(payment);

            //  Save & commit
            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}
