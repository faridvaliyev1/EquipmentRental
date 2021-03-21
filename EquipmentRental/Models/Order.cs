using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentRental.Models
{
    public class Order
    {
       [Key]
       public int Id { get; set; }

       [MaxLength(450)]
       public string UserId { get; set; }
       
       public User User { get; set; }

       public int EquipmentId { get; set; }

       public Equipment Equipment { get; set; }

       public DateTime Create_date { get; set; }

       public int Days { get; set; }

       public int Price { get; set; }
    }
}
