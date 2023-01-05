namespace HairdressingSalon.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsActive { get; set; }
    }
}
