using System;

namespace TaxiRouting.Core
{
    public struct Driver
    {
        public Guid Id { get; set; } 
        public int X { get; set; }   
        public int Y { get; set; }   
    }
    
    public struct Order
    {
        public int X { get; set; }  
        public int Y { get; set; }   
    }
}

