using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Web.ViewModels.Appointments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalon.Web.ViewComponents
{
    public class CustomerAppointmentsViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CustomerService _customerService;
        private readonly AppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public CustomerAppointmentsViewComponent(
            AppointmentService appointmentService,
            CustomerService customerService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _customerService = customerService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var customer = await _customerService.GetCustomerAsync(user.Id);

            var appontments = await _appointmentService.GetCurrentCustomerAppoinments(customer.Id);
            return View(_mapper.Map<IList<AppointmentViewModel>>(appontments));
        }
    }
}
