using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Services;

namespace HairdressingSalon.Web.Pages.Admin.ServiceList
{
    public class DetailsModel : PageModel
    {
        private readonly ServiceListService _serviceListService;
        private readonly IMapper _mapper;

        public DetailsModel(
            ServiceListService serviceListService,
            IMapper mapper)
        {
            _serviceListService = serviceListService;
            _mapper = mapper;
        }

        public ServiceViewModel Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _serviceListService.GetServiceAsync(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            else 
            {
                Service = _mapper.Map<ServiceViewModel>(service);
            }
            return Page();
        }
    }
}
