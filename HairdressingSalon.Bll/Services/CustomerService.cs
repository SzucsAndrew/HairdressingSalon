using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Bll.Services
{
    public class CustomerService
    {
        private readonly HairdressingSalonDbContext _hairdressingSalonDbContext;
        public CustomerService(HairdressingSalonDbContext hairdressingSalonDbContext)
        {
            _hairdressingSalonDbContext = hairdressingSalonDbContext;
        }

        public async Task<Customer?> GetCustomerAsync(int applicationUserId)
        {
            return await _hairdressingSalonDbContext.Customers.SingleOrDefaultAsync(x => x.ApplicationUserId == applicationUserId);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _hairdressingSalonDbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
