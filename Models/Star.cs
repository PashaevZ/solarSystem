namespace solarsystem.Models
{
    public class Star
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public List<Planet>? Planets {get; set; }
        public List<DwarfPlanet>? DworfPlanets {get; set; }
        public List<Asteroid>? Asteroids {get; set; }
        public List<Comet>? Comets {get; set; }
    }
}