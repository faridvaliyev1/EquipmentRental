using Microsoft.AspNetCore.Identity;

namespace EquipmentRental.Models
{
    public class User:IdentityUser
    {
       public int LoyaltyBalance { get; set; }
    }
}
