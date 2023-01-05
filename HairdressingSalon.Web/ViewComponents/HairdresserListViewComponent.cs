using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalon.Web.ViewComponents
{
    public class HairdresserListViewComponent : ViewComponent
    {
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;
        public HairdresserListViewComponent(HairdresserService hairdresserService, IMapper mapper)
        {
            _hairdresserService = hairdresserService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hairdressers = _mapper.Map<IList<HairdresserViewModel>>(await _hairdresserService.GetAllHairdresserAsync());
            return View(hairdressers);
        }
    }
}
