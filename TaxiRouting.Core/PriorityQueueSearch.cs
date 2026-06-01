using System.Collections.Generic;
using TaxiRouting.Core;

namespace TaxiRouting.Core
{
    public class PriorityQueueSearch : IDriverSearchAlgorithm
    {
        public List<Driver> FindFiveNearest(List<Driver> allDrivers, Order order)
        {
            
            var queue = new PriorityQueue<Driver, int>();

            foreach (var driver in allDrivers)
            {
                int distanceSquared = (driver.X - order.X) * (driver.X - order.X) +
                                     (driver.Y - order.Y) * (driver.Y - order.Y);

                queue.Enqueue(driver, distanceSquared);
            }

            var result = new List<Driver>();
            
            while (queue.Count > 0 && result.Count < 5)
            {
                result.Add(queue.Dequeue());
            }

            return result;
        }
    }
}
