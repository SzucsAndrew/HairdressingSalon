using HairdressingSalon.Data.Enums;

namespace HairdressingSalon.Web.ViewModels.Appointments
{
    public class AppointmentCreateModel
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
