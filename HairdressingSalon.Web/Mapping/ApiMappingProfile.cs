using AutoMapper;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Web.Helper;
using HairdressingSalon.Web.ViewModels.Appointments;
using HairdressingSalon.Web.ViewModels.Customers;
using HairdressingSalon.Web.ViewModels.Hairdressers;
using HairdressingSalon.Web.ViewModels.OpeningHours;
using HairdressingSalon.Web.ViewModels.Services;

namespace HairdressingSalon.Web.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Hairdresser, HairdresserViewModel>();
            CreateMap<Hairdresser, HairdresserCreateModel>();
            CreateMap<HairdresserCreateModel, Hairdresser>();
            CreateMap<Hairdresser, HairdresserEditModel>();
            CreateMap<HairdresserEditModel, Hairdresser>();
            CreateMap<Hairdresser, HairdresserDetailsModel>();

            CreateMap<Customer, CustomerViewModel>();

            CreateMap<Appointment, AppointmentCreateModel>();
            CreateMap<AppointmentCreateModel, Appointment>();
            CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(x => x.CustomerName, d => d.MapFrom(t => t.Customer.Name))
                .ForMember(x => x.HairdresserName, d => d.MapFrom(t => t.Hairdresser.Name))
                .ForMember(x => x.ServiceName, d => d.MapFrom(t => t.Service.Name))
                .ForMember(x => x.ServiceDuration, d => d.MapFrom(t => t.Service.Duration));

            CreateMap<OpeningHour, OpeningHourViewModel>()
                 .ForMember(x => x.DayOfWeek, d => d.MapFrom(t => DayNameHelper.GetDayName(t.DayOfWeek)));
            CreateMap<OpeningHourEditModel, OpeningHour>()
                .ForMember(x => x.DayOfWeek, d => d.Ignore());
            CreateMap<OpeningHour, OpeningHourEditModel>()
                .ForMember(x => x.DayOfWeek, d => d.MapFrom(t => DayNameHelper.GetDayName(t.DayOfWeek)));

            CreateMap<ServiceCreateModel, Service>();
            CreateMap<Service, ServiceEditModel>();
            CreateMap<ServiceEditModel, Service>();
            CreateMap<Service, ServiceViewModel>();
        }
    }
}
