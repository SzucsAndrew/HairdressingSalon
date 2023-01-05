namespace HairdressingSalon.Web.ViewModels.OpeningHours
{
    public class OpeningHourViewModel
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsClosed { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

    }
}
