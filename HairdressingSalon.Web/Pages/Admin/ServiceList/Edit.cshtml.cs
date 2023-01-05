using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Data.Entities;
using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.Services;

namespace HairdressingSalon.Web.Pages.Admin.ServiceList
{
    public class EditModel : PageModel
    {
        private readonly ServiceListService _serviceListService;
        private readonly IMapper _mapper;

        public EditModel(
            ServiceListService serviceListService,
            IMapper mapper)
        {
            _serviceListService = serviceListService;
            _mapper = mapper;
        }

        [BindProperty]
        public ServiceEditModel Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service =  await _serviceListService.GetServiceAsync(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            Service = _mapper.Map<ServiceEditModel>(service);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var service = await _serviceListService.GetServiceAsync(Service.Id);
            if (service == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                Service = _mapper.Map<ServiceEditModel>(service);
                return Page();
            }

            await _serviceListService.CreateAndUpdateAsync(_mapper.Map<Service>(Service));

            return RedirectToPage("./Index");
        }
    }
}
