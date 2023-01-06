using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using HairdressingSalon.Web.Services;
using Ganss.Xss;
using HairdressingSalon.Web.Helper;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationUserRegisterHelper _applicationUserRegisterHelper;
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly FileService _fileService;

        public EditModel(
            ApplicationUserRegisterHelper applicationUserRegisterHelper,
            HairdresserService hairdresserService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            FileService fileService)
        {
            _applicationUserRegisterHelper = applicationUserRegisterHelper;
            _hairdresserService = hairdresserService;
            _mapper = mapper;
            _webHostEnviroment = webHostEnvironment;
            _fileService = fileService;
        }

        [BindProperty]
        public HairdresserEditModel Hairdresser { get; set; } = default!;

        [BindProperty]
        public IFormFile? Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairdresser =  await _hairdresserService.GetByIdAsync(id.Value);
            if (hairdresser == null)
            {
                return NotFound();
            }
            Hairdresser = _mapper.Map<HairdresserEditModel>(hairdresser);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var hairdresser = await _hairdresserService.GetByIdAsync(Hairdresser.Id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Hairdresser.IntroduceHtml != null)
            {
                Hairdresser.IntroduceHtml = new HtmlSanitizer().Sanitize(Hairdresser.IntroduceHtml);
            }
            SavePhoto(hairdresser);
            await _hairdresserService.AddOrUpdateHairdresserAsync(_mapper.Map<Hairdresser>(Hairdresser));

            if (Hairdresser.Fired)
            {
                await _applicationUserRegisterHelper.LockoutTheUser(hairdresser.ApplicationUserId);
            }
            else
            {
                await _applicationUserRegisterHelper.UnLockoutTheUser(hairdresser.ApplicationUserId);
            }

            return RedirectToPage("./Index");
        }

        private void SavePhoto(Hairdresser hairdresser)
        {
            if (Photo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnviroment.WebRootPath, "images", "profiles");

                RemoveOldPhoto(hairdresser, uploadsFolder);

                hairdresser.ImageName = _fileService.SaveImage(uploadsFolder, Photo);
            }
        }

        private void RemoveOldPhoto(Hairdresser hairdresser, string uploadsFolder)
        {
            if (!string.IsNullOrWhiteSpace(hairdresser.ImageName))
            {
                var oldFilePath = Path.Combine(uploadsFolder, hairdresser.ImageName);
                _fileService.RemoveImage(oldFilePath);
            }
        }
    }
}
