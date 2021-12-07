using System;

namespace solarsystem.Models
{
    public class Satellite
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int PlanetID { get; set; }
        
        public Planet? Planet { get; set; }
        public string? Description { get; set; }
    }
}