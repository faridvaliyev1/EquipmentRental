using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.Methods
{
    public static class Pricing
    {
        private static int one_time = 100;

        private static int premium = 60;

        private static int regular = 40;

        public static int Calculate(int number_of_days,int Type_id)
        {
           int total = 0;

           switch(Type_id)
            {
                case 1:
                    total += number_of_days > 3 ? (3 * premium) + (number_of_days - 3) * regular : number_of_days * premium;
                    break;
                case 2:
                    total += number_of_days > 2 ? one_time + 2 * premium + (number_of_days - 2) * regular : one_time + number_of_days * premium;
                    break;
                case 3:
                    total += one_time + premium * number_of_days;
                    break;
                    
            }

            return total;
        }
    }
}
