using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.OpeningHours;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalon.Web.ViewComponents
{
    public class OpeningHoursViewComponent : ViewComponent
    {
        private readonly OpeningHourService _openingHourService;
        private readonly IMapper _mapper;

        public OpeningHoursViewComponent(
            IMapper mapper,
            OpeningHourService openingHourService)
        {
            _openingHourService = openingHourService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var openingHours = await _openingHourService.GetAllOpeningHours();
            return View(_mapper.Map<IList<OpeningHourViewModel>>(openingHours));
        }
    }
}
