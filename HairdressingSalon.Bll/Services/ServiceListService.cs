using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HairdressingSalon.Bll.Services
{
    public class ServiceListService
    {
        private readonly HairdressingSalonDbContext _hairdressingSalonDbContext;

        public ServiceListService(HairdressingSalonDbContext hairdressingSalonDbContext)
        {
            _hairdressingSalonDbContext = hairdressingSalonDbContext;
        }

        public async Task<Service?> GetServiceAsync(int id)
        {
            return await _hairdressingSalonDbContext.Services.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Service>> GetAllServiceAsync()
        {
            return await _hairdressingSalonDbContext.Services.ToListAsync();
        }

        public async Task<IList<Service>> GetAllActiveServiceAsync()
        {
            return await _hairdressingSalonDbContext.Services.Where(x => x.IsActive).ToListAsync();
        }

        public async Task CreateAndUpdateAsync(Service service)
        {
            EntityEntry<Service> entry;
            if (service.Id != 0)
            {
                entry = _hairdressingSalonDbContext.Entry<Service>(await _hairdressingSalonDbContext.Services.FindAsync(service.Id));
            }
            else
            {
                entry = _hairdressingSalonDbContext.Add(new Service());
            }

            entry.CurrentValues.SetValues(service);
            await _hairdressingSalonDbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var service = await _hairdressingSalonDbContext.Services.SingleOrDefaultAsync(x => x.Id == id);
            service.IsActive = false;
            await _hairdressingSalonDbContext.SaveChangesAsync();
        }
    }
}
