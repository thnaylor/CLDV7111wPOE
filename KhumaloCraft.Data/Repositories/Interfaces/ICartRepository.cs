using KhumaloCraft.Data.Entities;

namespace KhumaloCraft.Business.Interfaces;

public interface ICartRepository
{
  Cart GetCartById(string cartId);
  void SaveCart(Cart cart);
  void UpdateCartUserId(string cartId, string userId);
  void DeleteCart(string cartId);
  IEnumerable<Cart> GetCartsOlderThan(DateTime expirationDate);
}

