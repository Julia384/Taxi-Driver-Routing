using System;
using System.Collections.Generic;
using System.Linq;

namespace TaxiRouting.Core
{
    public class RadiusSearch : IDriverSearchAlgorithm
    {
        public List<Driver> FindFiveNearest(List<Driver> allDrivers, Order order)
        {
            int currentRadius = 10; 
            List<Driver> nearbyDrivers = new List<Driver>();

            
            while (nearbyDrivers.Count < 5 && currentRadius <= 1000)
            {
                nearbyDrivers = allDrivers.Where(d =>
                    Math.Abs(d.X - order.X) <= currentRadius &&
                    Math.Abs(d.Y - order.Y) <= currentRadius
                ).ToList();

                currentRadius *= 2; 
            }

            
            return nearbyDrivers
                .OrderBy(driver => (driver.X - order.X) * (driver.X - order.X) +
                                   (driver.Y - order.Y) * (driver.Y - order.Y))
                .Take(5)
                .ToList();
        }
    }
}

