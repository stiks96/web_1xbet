namespace Web1xbet.Entities
{
    public class Bet : IEntityBase
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public User User { get; set;}
        public double Summa { get; set; }
        public int Result { get; set; }
    }
}
