namespace HairdressingSalon.Web.ViewModels.Hairdressers
{
    public class HairdresserEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Fired { get; set; }
        public string? IntroduceHtml { get; set; }
        public string? ImageName { get; set; }
    }
}
