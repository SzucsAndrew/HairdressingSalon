using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Services;

namespace HairdressingSalon.Web.Pages.Admin.ServiceList
{
    public class CreateModel : PageModel
    {
        private readonly ServiceListService _serviceListService;
        private readonly IMapper _mapper;

        public CreateModel(
            ServiceListService serviceListService,
            IMapper mapper)
        {
            _serviceListService = serviceListService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceCreateModel Service { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _serviceListService.CreateAndUpdateAsync(_mapper.Map<Service>(Service));

            return RedirectToPage("./Index");
        }
    }
}
