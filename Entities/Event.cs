namespace Web1xbet.Entities
{
    public class Event : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public EventType Type { get; set; } 
    }
}
