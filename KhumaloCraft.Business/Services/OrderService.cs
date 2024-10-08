using KhumaloCraft.Business.Interfaces;
using KhumaloCraft.Data.Entities;
using KhumaloCraft.Data.Repositories.Interfaces;
using KhumaloCraft.Shared.DTOs;

namespace KhumaloCraft.Business.Services;

public class OrderService : IOrderService
{
  private readonly IOrderRepository _orderRepository;

  public OrderService(IOrderRepository orderRepository)
  {
    _orderRepository = orderRepository;
  }

  public async Task<List<OrderDisplayDTO>> GetOrdersByUserIdAsync(string userId)
  {
    var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

    return orders.Select(order => new OrderDisplayDTO
    {
      OrderId = order.OrderId.ToString(),
      OrderDate = order.OrderDate,
      StatusId = order.StatusId,
      StatusName = order.Status?.StatusName,
      Items = order.OrderItems.Select(item => new OrderItemDTO
      {
        ProductName = item.Product.Name,
        Quantity = item.Quantity,
        Price = item.Product.Price
      }).ToList()
    }).ToList();
  }

  public async Task<List<OrderDisplayDTO>> GetAllOrders()
  {
    var orders = await _orderRepository.GetAllOrdersAsync();

    var orderDTOs = orders.Select(order => new OrderDisplayDTO
    {
      OrderId = order.OrderId.ToString(),
      UserId = order.UserId,
      OrderDate = order.OrderDate,
      StatusId = order.StatusId,
      StatusName = order.Status?.StatusName,
      User = new UserDTO
      {
        UserId = order.User.Id,
        UserName = order.User.UserName,
        FirstName = order.User.FirstName,
        LastName = order.User.LastName
      },
      Items = order.OrderItems.Select(item => new OrderItemDTO
      {
        OrderItemId = item.OrderItemId,
        ProductId = item.ProductId,
        ProductName = item.Product?.Name,
        Price = item.Product?.Price ?? 0,
        Quantity = item.Quantity
      }).ToList()
    }).ToList();

    return orderDTOs;
  }

  public async Task<OrderDisplayDTO?> GetOrderById(int orderId)
  {
    var order = await _orderRepository.GetOrderByIdAsync(orderId);
    if (order == null) return null;

    return new OrderDisplayDTO();
  }

  public async Task AddOrder(OrderDTO orderDTO)
  {
    var order = new Order
    {
      UserId = orderDTO.UserId,
      OrderDate = DateTime.Now,
      StatusId = 1,
    };

    foreach (var itemDTO in orderDTO.Items)
    {
      var orderItem = new OrderItem
      {
        ProductId = itemDTO.ProductId,
        Quantity = itemDTO.Quantity,
      };

      order.OrderItems.Add(orderItem);
    }

    await _orderRepository.AddOrderAsync(order);
    await _orderRepository.SaveChangesAsync();
  }

  public async Task UpdateOrderStatusAsync(int orderId, int statusId)
  {
    // Retrieve the order by orderId
    var order = await _orderRepository.GetOrderByIdAsync(orderId);

    if (order == null)
    {
      throw new KeyNotFoundException($"Order with ID {orderId} not found.");
    }

    // Check if the statusId exists in the Status table
    var statusExists = await _orderRepository.StatusExistsAsync(statusId);
    if (!statusExists)
    {
      throw new InvalidOperationException($"Invalid StatusId {statusId}. No matching status found in the Status table.");
    }

    // Update the order's StatusId
    order.StatusId = statusId;

    // Save the changes
    await _orderRepository.SaveChangesAsync();
  }

  public async Task CancelOrder(int orderId)
  {
    var order = await _orderRepository.GetOrderByIdAsync(orderId);
    if (order == null) return;

    await _orderRepository.CancelOrderAsync(order);
    await _orderRepository.SaveChangesAsync();
  }
}
