using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Business.Interfaces;

public interface IOrderService
{
  Task<List<OrderDisplayDTO>> GetAllOrders();
  Task<OrderDTO?> GetOrderById(int orderId);
  Task<List<OrderDTO>> GetOrdersByUserIdAsync(string userId);
  Task AddOrder(OrderDTO orderDTO);
  Task CancelOrder(int orderId);
}
