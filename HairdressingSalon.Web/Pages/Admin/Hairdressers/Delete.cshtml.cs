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
    public class DeleteModel : PageModel
    {
        private readonly HairdressingSalon.Data.HairdressingSalonDbContext _context;

        public DeleteModel(HairdressingSalon.Data.HairdressingSalonDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hairdressers == null)
            {
                return NotFound();
            }
            var hairdresser = await _context.Hairdressers.FindAsync(id);

            if (hairdresser != null)
            {
                Hairdresser = hairdresser;
                _context.Hairdressers.Remove(Hairdresser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
