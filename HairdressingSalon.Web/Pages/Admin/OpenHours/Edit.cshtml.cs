using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.OpeningHours;
using AutoMapper;
using HairdressingSalon.Data.Entities;

namespace HairdressingSalon.Web.Pages.Admin.OpenHours
{
    public class EditModel : PageModel
    {
        private readonly OpeningHourService _openingHourService;
        private readonly IMapper _mapper;

        public EditModel(OpeningHourService openingHourService, IMapper mapper)
        {
            _openingHourService = openingHourService;
            _mapper = mapper;
        }

        [BindProperty]
        public OpeningHourEditModel OpeningHour { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openinghour =  await _openingHourService.GetById(id.Value);
            if (openinghour == null)
            {
                return NotFound();
            }
            OpeningHour = _mapper.Map<OpeningHourEditModel>(openinghour);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var openinghour = await _openingHourService.GetById(OpeningHour.Id);
            if (openinghour == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                OpeningHour = _mapper.Map<OpeningHourEditModel>(openinghour);
                return Page();
            }

            await _openingHourService.Update(_mapper.Map<OpeningHour>(OpeningHour));

            return RedirectToPage("./Index");
        }
    }
}
