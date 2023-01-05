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
    public class DetailsModel : PageModel
    {
        private readonly HairdressingSalon.Data.HairdressingSalonDbContext _context;

        public DetailsModel(HairdressingSalon.Data.HairdressingSalonDbContext context)
        {
            _context = context;
        }

      public Hairdresser Hairdresser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hairdressers == null)
            {
                return NotFound();
            }

            var hairdresser = await _context.Hairdressers.FirstOrDefaultAsync(m => m.Id == id);
            if (hairdresser == null)
            {
                return NotFound();
            }
            else 
            {
                Hairdresser = hairdresser;
            }
            return Page();
        }
    }
}
