using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Services;

namespace HairdressingSalon.Web.Pages.Admin.ServiceList
{
    public class IndexModel : PageModel
    {
        private readonly ServiceListService _serviceListService;
        private readonly IMapper _mapper;

        public IndexModel(
            ServiceListService serviceListService,
            IMapper mapper)
        {
            _serviceListService = serviceListService;
            _mapper = mapper;
        }

        public IList<ServiceViewModel> Services { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Services = _mapper.Map<IList<ServiceViewModel>>(await _serviceListService.GetAllServiceAsync());
        }
    }
}
