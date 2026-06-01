using System.Collections.Generic;

namespace TaxiRouting.Core
{
    public interface IDriverSearchAlgorithm
    {
        List<Driver> FindFiveNearest(List<Driver> allDrivers, Order order);
    }
}
