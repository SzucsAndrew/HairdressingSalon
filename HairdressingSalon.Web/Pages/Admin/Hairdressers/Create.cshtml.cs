using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using HairdressingSalon.Web.Services;
using HairdressingSalon.Data.Entities;
using Ganss.Xss;
using HairdressingSalon.Web.Helper;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationUserRegisterHelper _applicationUserRegisterHelper;
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly FileService _fileService;

        public CreateModel(
            HairdresserService hairdresserService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            FileService fileService,
            ApplicationUserRegisterHelper applicationUserRegisterHelper)
        {
            _hairdresserService = hairdresserService;
            _mapper = mapper;
            _webHostEnviroment = webHostEnvironment;
            _fileService = fileService;
            _applicationUserRegisterHelper = applicationUserRegisterHelper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HairdresserCreateModel Hairdresser { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (Hairdresser.IntroduceHtml != null)
            {
                Hairdresser.IntroduceHtml = new HtmlSanitizer().Sanitize(Hairdresser.IntroduceHtml);
            }

            var applicationUser = await _applicationUserRegisterHelper.GenerateHairdresser(Hairdresser.Name);

            var hairdresser = _mapper.Map<Hairdresser>(Hairdresser);
            hairdresser.ApplicationUserId = applicationUser.Id;
            SavePhoto(hairdresser);

            await _hairdresserService.AddOrUpdateHairdresserAsync(hairdresser);

            return RedirectToPage("./Index");
        }

        private void SavePhoto(Hairdresser hairdresser)
        {
            string uploadsFolder = Path.Combine(_webHostEnviroment.WebRootPath, "images", "profiles");
            hairdresser.ImageName = _fileService.SaveImage(uploadsFolder, Photo);
        }
    }
}
