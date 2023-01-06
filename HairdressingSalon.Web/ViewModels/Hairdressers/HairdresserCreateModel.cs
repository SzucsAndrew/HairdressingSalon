using HairdressingSalon.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HairdressingSalon.Web.ViewModels.Hairdressers
{
    public class HairdresserCreateModel
    {
        [MaxLength(HairdresserConstant.MaxNameLength)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(HairdresserConstant.MaxIntroduceLength)]
        public string? IntroduceHtml { get; set; }
    }
}
