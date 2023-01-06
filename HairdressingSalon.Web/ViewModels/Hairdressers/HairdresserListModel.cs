namespace HairdressingSalon.Web.ViewModels.Hairdressers
{
    public class HairdresserListModel
    {
        public IList<HairdresserViewModel> Hairdressers { get; set; }
        public int? CustomerId { get; set; }
    }
}
