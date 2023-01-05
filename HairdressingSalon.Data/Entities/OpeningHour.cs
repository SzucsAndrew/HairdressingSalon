namespace HairdressingSalon.Data.Entities
{
    public class OpeningHour
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public bool IsClosed { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
