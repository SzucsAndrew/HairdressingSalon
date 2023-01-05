using HairdressingSalon.Data.Enums;

namespace HairdressingSalon.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
