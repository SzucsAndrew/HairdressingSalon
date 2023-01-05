using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.OpeningHours;
using AutoMapper;

namespace HairdressingSalon.Web.Pages.Admin.OpenHours
{
    public class IndexModel : PageModel
    {
        private readonly OpeningHourService _openingHourService;
        private readonly IMapper _mapper;

        public IndexModel(OpeningHourService openingHourService, IMapper mapper)
        {
            _openingHourService = openingHourService;
            _mapper = mapper;
        }

        public IList<OpeningHourViewModel> OpeningHours { get;set; }

        public async Task OnGetAsync()
        {
            OpeningHours = _mapper.Map<IList<OpeningHourViewModel>>(await _openingHourService.GetAllOpeningHours());
        }
    }
}
