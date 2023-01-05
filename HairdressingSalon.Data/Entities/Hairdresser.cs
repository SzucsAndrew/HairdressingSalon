namespace HairdressingSalon.Data.Entities
{
    public class Hairdresser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Fired { get; set; }
        public string ImageName { get; set; }
        public string? IntroduceHtml { get; set; }
        public byte[] RowVersion { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
