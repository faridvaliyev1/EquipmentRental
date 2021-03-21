using EquipmentRental.Data;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Equipment> GetEquipmentDetail(int id)
        {
            return await _context.Equipments.FindAsync(id);
        }

        public async Task<IEnumerable<Equipment>> GetEquipments()
        {
            return await _context.Equipments.ToListAsync();
        }
    }
}
