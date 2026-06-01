using NUnit.Framework;
using System;
using System.Collections.Generic;
using TaxiRouting.Core;

namespace TaxiRouting.Tests
{
    [TestFixture]
    public class BruteForceSearchTests
    {
        [Test]
        public void FindFiveNearest_ShouldReturnExactlyFiveDrivers_WhenMoreThanFiveExist()
        {
            
            var algorithm = new BruteForceSearch();
            var order = new Order { X = 0, Y = 0 }; 

            var drivers = new List<Driver>();
            
            for (int i = 1; i <= 10; i++)
            {
                drivers.Add(new Driver { Id = Guid.NewGuid(), X = i, Y = i });
            }

            
            var result = algorithm.FindFiveNearest(drivers, order);

            
            Assert.That(result.Count, Is.EqualTo(5), "Алгоритм должен вернуть ровно 5 водителей");
        }

        [Test]
        public void FindFiveNearest_ShouldReturnClosestDriversFirst()
        {
            
            var algorithm = new BruteForceSearch();
            var order = new Order { X = 0, Y = 0 };

            
            var closestDriver = new Driver { Id = Guid.NewGuid(), X = 1, Y = 1 }; 
            var mediumDriver = new Driver { Id = Guid.NewGuid(), X = 5, Y = 5 };  
            var farDriver = new Driver { Id = Guid.NewGuid(), X = 10, Y = 10 };   

            var drivers = new List<Driver> { farDriver, closestDriver, mediumDriver };

            
            var result = algorithm.FindFiveNearest(drivers, order);

            
            Assert.That(result[0].Id, Is.EqualTo(closestDriver.Id), "Первым должен быть самый близкий водитель");
        }
    }

    [TestFixture]
    public class PriorityQueueSearchTests
    {
        [Test]
        public void PriorityQueue_ShouldFindClosestDriver()
        {
            var algorithm = new PriorityQueueSearch();
            var order = new Order { X = 0, Y = 0 };
            var closestDriver = new Driver { Id = Guid.NewGuid(), X = 1, Y = 1 };
            var farDriver = new Driver { Id = Guid.NewGuid(), X = 50, Y = 50 };

            var result = algorithm.FindFiveNearest(new List<Driver> { farDriver, closestDriver }, order);

            Assert.That(result[0].Id, Is.EqualTo(closestDriver.Id));
        }
    }

    [TestFixture]
    public class RadiusSearchTests
    {
        [Test]
        public void RadiusSearch_ShouldFindClosestDriver()
        {
            var algorithm = new RadiusSearch();
            var order = new Order { X = 0, Y = 0 };
            var closestDriver = new Driver { Id = Guid.NewGuid(), X = 2, Y = 2 };
            var farDriver = new Driver { Id = Guid.NewGuid(), X = 500, Y = 500 };

            var result = algorithm.FindFiveNearest(new List<Driver> { farDriver, closestDriver }, order);

            Assert.That(result[0].Id, Is.EqualTo(closestDriver.Id));
        }
    }
}
