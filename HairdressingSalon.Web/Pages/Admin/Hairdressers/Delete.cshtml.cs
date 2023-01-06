using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using HairdressingSalon.Web.Helper;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationUserRegisterHelper _applicationUserRegisterHelper;
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;

        public DeleteModel(
            HairdresserService hairdresserService,
            IMapper mapper,
            ApplicationUserRegisterHelper applicationUserRegisterHelper)
        {
            _applicationUserRegisterHelper = applicationUserRegisterHelper;
            _hairdresserService = hairdresserService;
            _mapper = mapper;
        }

        [BindProperty]
        public HairdresserViewModel Hairdresser { get; set; }

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
                Hairdresser = _mapper.Map<HairdresserViewModel>(hairdresser);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hairdresser = await _hairdresserService.GetByIdAsync(id.Value);

            if (hairdresser != null)
            {
                await _hairdresserService.RemoveAsync(id.Value);
                await _applicationUserRegisterHelper.LockoutTheUser(hairdresser.ApplicationUserId);
            }

            return RedirectToPage("./Index");
        }
    }
}
