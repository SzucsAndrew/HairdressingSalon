namespace HairdressingSalon.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] RowVersion { get; set; }
        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
