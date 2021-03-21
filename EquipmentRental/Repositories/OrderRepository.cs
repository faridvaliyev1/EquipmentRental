using EquipmentRental.Data;
using EquipmentRental.Methods;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;


        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(CreateOrderRequestModel model)
        {
            var order = new Order()
            {
                UserId = model.UserId,
                Create_date = DateTime.Now,
                Days = model.number_of_days,
                EquipmentId = model.EquipmentId,
                Price = Helper.Calculate(model.number_of_days, model.Type_id)
            };

           await _context.AddAsync(order);

            _context.SaveChanges();

           return order;
        }

        public async Task<List<Order>> GetOrders(string UserId)
        {
            return await _context.Orders.Where(c=>c.UserId==UserId).Include(x=>x.Equipment).ToListAsync();
        }
    }
}
