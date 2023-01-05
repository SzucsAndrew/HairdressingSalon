using HairdressingSalon.Data.Enums;

namespace HairdressingSalon.Web.ViewModels.Appointments
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public string HairdresserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceName { get; set; }
        public TimeSpan ServiceDuration { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
