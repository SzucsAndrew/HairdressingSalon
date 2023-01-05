using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Web.ViewModels.Appointments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalon.Web.ViewComponents
{
    public class HairdressersAppointmentsViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HairdresserService _hairdresserService;
        private readonly AppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public HairdressersAppointmentsViewComponent(
            AppointmentService appointmentService,
            HairdresserService hairdresserService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _hairdresserService = hairdresserService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var hairdresser = await _hairdresserService.GetHairdresserAsync(user.Id);

            var appontments = await _appointmentService.GetCurrentHairdresserAppoinments(hairdresser.Id);
            return View(_mapper.Map<IList<AppointmentViewModel>>(appontments));
        }
    }
}
