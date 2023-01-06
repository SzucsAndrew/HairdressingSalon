using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.Hairdressers;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class IndexModel : PageModel
    {
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;

        public IndexModel(HairdresserService hairdresserService, IMapper mapper)
        {
            _hairdresserService = hairdresserService;
            _mapper = mapper;
        }

        public IList<HairdresserViewModel> Hairdresser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Hairdresser = _mapper.Map<IList<HairdresserViewModel>>(await _hairdresserService.GetAllHairdresserAsync());
        }
    }
}
