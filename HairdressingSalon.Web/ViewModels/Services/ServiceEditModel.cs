using HairdressingSalon.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace HairdressingSalon.Web.ViewModels.Services
{
    public class ServiceEditModel
    {
        public int Id { get; set; }
        [MaxLength(ServiceConstant.MaxNameLength)]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
