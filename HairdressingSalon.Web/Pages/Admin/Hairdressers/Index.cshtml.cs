using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class IndexModel : PageModel
    {
        private readonly HairdressingSalon.Data.HairdressingSalonDbContext _context;

        public IndexModel(HairdressingSalon.Data.HairdressingSalonDbContext context)
        {
            _context = context;
        }

        public IList<Hairdresser> Hairdresser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hairdressers != null)
            {
                Hairdresser = await _context.Hairdressers
                .Include(h => h.ApplicationUser).ToListAsync();
            }
        }
    }
}
