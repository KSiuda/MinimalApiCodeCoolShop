using Domain;
using System.Collections.Generic;

namespace MinimalApiCodeCoolShop.Services.Orders
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        List<Domain.Order> GetAllOrders();
        void SaveOrderToJson(Order order);
    }
}