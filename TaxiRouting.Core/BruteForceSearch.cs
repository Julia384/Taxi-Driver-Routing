using System.Collections.Generic;
using System.Linq;

namespace TaxiRouting.Core
{
    public class BruteForceSearch : IDriverSearchAlgorithm
    {
        public List<Driver> FindFiveNearest(List<Driver> allDrivers, Order order)
        {
         
            return allDrivers
                .OrderBy(driver => (driver.X - order.X) * (driver.X - order.X) +
                                   (driver.Y - order.Y) * (driver.Y - order.Y))
                .Take(5) 
                .ToList();
        }
    }
}

