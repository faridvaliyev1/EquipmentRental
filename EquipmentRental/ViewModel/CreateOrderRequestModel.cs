using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.ViewModel
{
    public class CreateOrderRequestModel
    {
        public string UserId { get; set; }

        public int number_of_days { get; set; }

        public int EquipmentId { get; set; }

        public string EquipmentName { get; set; }
        public int Type_id { get; set; }

        
    }
}
