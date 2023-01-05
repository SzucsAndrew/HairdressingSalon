using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HairdressingSalon.Bll.Services
{
    public class HairdresserService
    {
        private readonly HairdressingSalonDbContext _hairdressingSalonDbContext;
        public HairdresserService(HairdressingSalonDbContext hairdressingSalonDbContext)
        {
            _hairdressingSalonDbContext = hairdressingSalonDbContext;
        }

        public async Task<IList<Hairdresser>> GetAllHairdresserAsync()
        {
            return await _hairdressingSalonDbContext.Hairdressers.Where(h => !h.Fired).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var hairdresser = await _hairdressingSalonDbContext.Hairdressers.FindAsync(id);
            if (hairdresser != null)
            {
                hairdresser.Fired = true;
                await _hairdressingSalonDbContext.SaveChangesAsync();
            }
        }

        public async Task AddOrUpdateHairdresserAsync(Hairdresser hairdresser)
        {
            EntityEntry<Hairdresser> entry;
            if (hairdresser.Id != 0)
            {
                entry = _hairdressingSalonDbContext.Entry<Hairdresser>(await _hairdressingSalonDbContext.Hairdressers.FindAsync(hairdresser.Id));
            }
            else
            {
                entry = _hairdressingSalonDbContext.Add(new Hairdresser());
            }

            entry.CurrentValues.SetValues(hairdresser);

            await _hairdressingSalonDbContext.SaveChangesAsync();
        }

        public async Task<Hairdresser?> GetHairdresserAsync(int applicationUserId)
        {
            return await _hairdressingSalonDbContext.Hairdressers.SingleOrDefaultAsync(h => h.ApplicationUserId == applicationUserId);
        }

        public async Task<Hairdresser?> GetByIdAsync(int id)
        {
            return await _hairdressingSalonDbContext.Hairdressers.SingleOrDefaultAsync(h => h.Id == id);
        }
    }
}
