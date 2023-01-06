using AutoMapper;
using HairdressingSalon.Bll.Services;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Data.SeedData;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HairdressingSalon.Web.ViewComponents
{
    public class HairdresserListViewComponent : ViewComponent
    {
        private readonly HairdresserService _hairdresserService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CustomerService _customerService;

        public HairdresserListViewComponent(
            HairdresserService hairdresserService,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            CustomerService customerService)
        {
            _hairdresserService = hairdresserService;
            _mapper = mapper;
            _userManager = userManager;
            _customerService = customerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var name = User?.Identity?.Name;
            int? customerId = null;
            if (name != null && User.IsInRole(RoleHelper.Customers)) {
                var user = await _userManager.FindByNameAsync(name);
                var customer = await _customerService.GetCustomerAsync(user.Id);
                customerId = customer.Id;
            }
            var hairdressers = _mapper.Map<IList<HairdresserViewModel>>(await _hairdresserService.GetAllActiveHairdresserAsync());
            return View(new HairdresserListModel { CustomerId = customerId, Hairdressers = hairdressers });
        }
    }
}
