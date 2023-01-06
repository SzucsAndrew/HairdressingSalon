using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HairdressingSalon.Bll.Services;
using AutoMapper;
using HairdressingSalon.Web.ViewModels.Appointments;

namespace HairdressingSalon.Web.Pages.Customer.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly AppointmentService _appointmentService;

        public DeleteModel(
            IMapper mapper,
            AppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        [BindProperty]
        public AppointmentViewModel Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppoinments(id.Value);

            if (appointment == null)
            {
                return NotFound();
            }
            else 
            {
                Appointment = _mapper.Map<AppointmentViewModel>(appointment);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointment = await _appointmentService.GetAppoinments(id.Value);

            if (appointment != null)
            {
                await _appointmentService.RemoveAsync(id.Value);
            }

            return RedirectToPage("/Index");
        }
    }
}
