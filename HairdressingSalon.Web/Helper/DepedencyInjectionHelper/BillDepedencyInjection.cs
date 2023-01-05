using HairdressingSalon.Bll.Services;

namespace HairdressingSalon.Web.Helper.DepedencyInjectionHelper
{
    public static class BillDepedencyInjection
    {
        public static void AddBllLayer(this IServiceCollection service)
        {
            AddServices(service);
        }

        private static void AddServices(IServiceCollection service)
        {
            service.AddScoped<HairdresserService>();
            service.AddScoped<AppointmentService>();
            service.AddScoped<CustomerService>();
            service.AddScoped<OpeningHourService>();
        }
    }
}
