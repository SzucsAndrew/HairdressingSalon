using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using HairdressingSalon.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Bll.Services
{
    public class AppointmentService
    {
        private readonly HairdressingSalonDbContext _hairdressingSalonDbContext;
        public AppointmentService(HairdressingSalonDbContext hairdressingSalonDbContext)
        {
            _hairdressingSalonDbContext = hairdressingSalonDbContext;
        }
        public async Task<IList<Appointment>> GetCurrentCustomerAppoinments(int customerId)
        {
            return await _hairdressingSalonDbContext.Appointments
                .Include(x => x.Customer)
                .Include(x => x.Hairdresser)
                .Include(x => x.Service)
                .Where(x => x.CustomerId == customerId && x.DateTime > DateTime.UtcNow.AddMonths(-1))
                .OrderBy(x => x.DateTime)
                .ToListAsync();
        }

        public async Task<IList<Appointment>> GetCurrentHairdresserAppoinments(int hairdresserId)
        {
            return await _hairdressingSalonDbContext.Appointments
                .Include(x => x.Customer)
                .Include(x => x.Hairdresser)
                .Include(x => x.Service)
                .Where(x => x.HairdresserId == hairdresserId && x.DateTime > DateTime.UtcNow.AddMonths(-1))
                .OrderBy(x => x.DateTime)
                .ToListAsync();
        }

        public async Task CreateAsync(Appointment appointment)
        {
            var entry = _hairdressingSalonDbContext.Add(new Appointment());

            appointment.Status = AppointmentStatus.Waiting;
            entry.CurrentValues.SetValues(appointment);
            
            await _hairdressingSalonDbContext.SaveChangesAsync();
        }

        public async Task<Appointment?> GetAppoinments(int id)
        {
            return await _hairdressingSalonDbContext.Appointments
                .Include(x => x.Hairdresser)
                .Include(x => x.Service)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var appointment = await _hairdressingSalonDbContext.Appointments.SingleOrDefaultAsync(x => x.Id == id);
            appointment.Status = AppointmentStatus.Cancelled;
            await _hairdressingSalonDbContext.SaveChangesAsync();
        }
    }
}
