using EquipmentRental.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquipmentRentalTest
{
    [TestClass]
    public class PricingTests
    {
        [TestMethod]
        public void Heavy_pricing_one_day()
        {
            int Result = Helper.Calculate(1, 3);

            Assert.AreEqual(160, Result);
        }

        [TestMethod]
        public void Heavy_pricing_2days()
        {
            int Result = Helper.Calculate(2, 3);

            Assert.AreEqual(220, Result);
        }

        [TestMethod]
        public void Regular_pricing_till_2_days()
        {
            int Result = Helper.Calculate(2, 2);

            Assert.AreEqual(220, Result);
        } 

        [TestMethod]
        public void Regular_pricng_more_than_2_days()
        {
            int Result = Helper.Calculate(3, 2);

            Assert.AreEqual(260, Result);
        }

        [TestMethod]
        public void Specialized_pricing_less_than_3_days()
        {
            int Result = Helper.Calculate(3, 1);

            Assert.AreEqual(180, Result);
        }

        [TestMethod]
        public void Specialized_pricing_more_than_3_days()
        {
            int Result = Helper.Calculate(4, 1);

            Assert.AreEqual(220, Result);
        }
    }
}
