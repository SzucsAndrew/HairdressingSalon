using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Hairdressers;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class DetailsModel : PageModel
    {
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;

        public DetailsModel(HairdresserService hairdresserService, IMapper mapper)
        {
            _hairdresserService = hairdresserService;
            _mapper = mapper;
        }

        public HairdresserDetailsModel Hairdresser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairdresser = await _hairdresserService.GetByIdAsync(id.Value);
            if (hairdresser == null)
            {
                return NotFound();
            }
            else 
            {
                Hairdresser = _mapper.Map<HairdresserDetailsModel>(hairdresser);
            }
            return Page();
        }
    }
}
