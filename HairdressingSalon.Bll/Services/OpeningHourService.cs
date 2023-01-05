using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Bll.Services
{
    public class OpeningHourService
    {
        private readonly HairdressingSalonDbContext _hairdressingSalonDbContext;

        public OpeningHourService(HairdressingSalonDbContext hairdressingSalonDbContext)
        {
            _hairdressingSalonDbContext = hairdressingSalonDbContext;
        }

        public async Task<IList<OpeningHour>> GetAllOpeningHours()
        {
            return await _hairdressingSalonDbContext.OpeningHours.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<OpeningHour?> GetById(int id)
        {
            return await _hairdressingSalonDbContext.OpeningHours.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(OpeningHour openingHour)
        {
            var currentOpeningHour = await _hairdressingSalonDbContext.OpeningHours.FindAsync(openingHour.Id);
            var entry = _hairdressingSalonDbContext.Entry<OpeningHour>(currentOpeningHour);
            var dayOfWeek = currentOpeningHour.DayOfWeek;

            entry.CurrentValues.SetValues(openingHour);

            currentOpeningHour.DayOfWeek = dayOfWeek;

            await _hairdressingSalonDbContext.SaveChangesAsync();
        }
    }
}
