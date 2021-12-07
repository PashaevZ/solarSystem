namespace solarsystem.Models
{
    public class DwarfPlanet
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int StarID { get; set; }
        
        public Star? Star { get; set; }

    }
}