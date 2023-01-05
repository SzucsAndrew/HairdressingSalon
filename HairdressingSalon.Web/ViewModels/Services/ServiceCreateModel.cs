namespace HairdressingSalon.Web.ViewModels.Services
{
    public class ServiceCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
