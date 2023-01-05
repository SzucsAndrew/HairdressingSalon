namespace HairdressingSalon.Web.ViewModels.Customers
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
