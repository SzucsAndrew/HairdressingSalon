using HairdressingSalon.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HairdressingSalon.Web.ViewModels.Hairdressers
{
    public class HairdresserEditModel
    {
        public int Id { get; set; }
        [MaxLength(HairdresserConstant.MaxNameLength)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Fired { get; set; }
        [MaxLength(HairdresserConstant.MaxIntroduceLength)]
        public string? IntroduceHtml { get; set; }
        [MaxLength(HairdresserConstant.MaxImagePathLength)]
        public string? ImageName { get; set; }
    }
}
