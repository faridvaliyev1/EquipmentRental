using EquipmentRental.Models;
using EquipmentRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(CreateOrderRequestModel model);
        public Task<List<Order>> GetOrders(string UserId);
    }
}
