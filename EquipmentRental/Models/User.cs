using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EquipmentRental.Models
{
    public class User:IdentityUser
    {
       public int LoyaltyBalance { get; set; }

       public virtual IEnumerable<Order> Orders { get; set; }


    }
}
