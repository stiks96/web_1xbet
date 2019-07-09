namespace Web1xbet.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public StatusType Status { get; set; }
        public int? StatusId { get; set; } = null;
    }
}
