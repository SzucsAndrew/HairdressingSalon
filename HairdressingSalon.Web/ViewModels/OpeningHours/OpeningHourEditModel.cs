namespace HairdressingSalon.Web.ViewModels.OpeningHours
{
    public class OpeningHourEditModel
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public bool IsClosed { get; set; }
    }
}
