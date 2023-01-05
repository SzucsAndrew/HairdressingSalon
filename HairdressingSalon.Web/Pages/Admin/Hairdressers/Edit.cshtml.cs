using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class EditModel : PageModel
    {
        private readonly HairdressingSalon.Data.HairdressingSalonDbContext _context;

        public EditModel(HairdressingSalon.Data.HairdressingSalonDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hairdresser Hairdresser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hairdressers == null)
            {
                return NotFound();
            }

            var hairdresser =  await _context.Hairdressers.FirstOrDefaultAsync(m => m.Id == id);
            if (hairdresser == null)
            {
                return NotFound();
            }
            Hairdresser = hairdresser;
           ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hairdresser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairdresserExists(Hairdresser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HairdresserExists(int id)
        {
          return _context.Hairdressers.Any(e => e.Id == id);
        }
    }
}
