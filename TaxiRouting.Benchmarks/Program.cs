using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using TaxiRouting.Core;

namespace TaxiRouting.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            BenchmarkRunner.Run<DriverSearchBenchmark>();
        }
    }

    [MemoryDiagnoser] 
    public class DriverSearchBenchmark
    {
        private List<Driver> _drivers;
        private Order _order;

        private BruteForceSearch _bruteForce;
        private PriorityQueueSearch _priorityQueue;
        private RadiusSearch _radiusSearch;

        [GlobalSetup]
        public void Setup()
        {
            
            var rand = new Random(42);
            _drivers = new List<Driver>();

            
            for (int i = 0; i < 20000; i++)
            {
                _drivers.Add(new Driver
                {
                    Id = Guid.NewGuid(),
                    X = rand.Next(0, 1000),
                    Y = rand.Next(0, 1000)
                });
            }

            
            _order = new Order { X = 500, Y = 500 };

            
            _bruteForce = new BruteForceSearch();
            _priorityQueue = new PriorityQueueSearch();
            _radiusSearch = new RadiusSearch();
        }

        [Benchmark]
        public void Test_BruteForce()
        {
            _bruteForce.FindFiveNearest(_drivers, _order);
        }

        [Benchmark]
        public void Test_PriorityQueue()
        {
            _priorityQueue.FindFiveNearest(_drivers, _order);
        }

        [Benchmark]
        public void Test_RadiusSearch()
        {
            _radiusSearch.FindFiveNearest(_drivers, _order);
        }
    }
}

