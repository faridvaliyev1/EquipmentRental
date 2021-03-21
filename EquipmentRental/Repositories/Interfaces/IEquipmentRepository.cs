using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
       public Task<IEnumerable<Equipment>> GetEquipments();

        public Task<Equipment> GetEquipmentDetail(int id);
    }
}
