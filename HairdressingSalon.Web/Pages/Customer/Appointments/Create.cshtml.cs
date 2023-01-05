using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairdressingSalon.Data.Entities;
using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Web.ViewModels.Services;
using HairdressingSalon.Web.ViewModels.Customers;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using HairdressingSalon.Web.ViewModels.Appointments;
using EntityCustomer = HairdressingSalon.Data.Entities.Customer;

namespace HairdressingSalon.Web.Pages.Customer.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly AppointmentService _appointmentService;
        private readonly ServiceListService _serviceListService;
        private readonly HairdresserService _hairdresserService;
        private readonly CustomerService _customerService;

        public CreateModel(
            IMapper mapper,
            AppointmentService appointmentService,
            ServiceListService serviceListService,
            HairdresserService hairdresserService,
            CustomerService customerService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _serviceListService = serviceListService;
            _hairdresserService = hairdresserService;
            _customerService = customerService;
        }

        public async Task<IActionResult> OnGetAsync(int hairdresserId, int customerId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            var hairdresser = await _hairdresserService.GetByIdAsync(hairdresserId);

            if (hairdresser == null)
            {
                return NotFound();
            }

            await LoadData(customer, hairdresser);
            return Page();
        }

        [BindProperty]
        public AppointmentCreateModel Appointment { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var customer = await _customerService.GetByIdAsync(Appointment.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            var hairdresser = await _hairdresserService.GetByIdAsync(Appointment.HairdresserId);

            if (hairdresser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await LoadData(customer, hairdresser);
                return Page();
            }

            await _appointmentService.CreateAsync(_mapper.Map<Appointment>(Appointment));

            return RedirectToPage("./Index");
        }

        private async Task LoadData(EntityCustomer customer, Hairdresser hairdresser)
        {
            ViewData["CustomerId"] = new SelectList(_mapper.Map<IList<CustomerViewModel>>(new[] { customer }), "Id", "Name");
            ViewData["HairdresserId"] = new SelectList(_mapper.Map<IList<HairdresserViewModel>>(new[] { hairdresser }), "Id", "Name");
            var services = await _serviceListService.GetAllActiveServiceAsync();
            ViewData["ServiceId"] = new SelectList(_mapper.Map<IList<ServiceViewModel>>(services), "Id", "Name");
        }
    }
}
