using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairdressingSalon.Data;
using HairdressingSalon.Data.Entities;

namespace HairdressingSalon.Web.Pages.Admin.Hairdressers
{
    public class CreateModel : PageModel
    {
        private readonly HairdressingSalon.Data.HairdressingSalonDbContext _context;

        public CreateModel(HairdressingSalon.Data.HairdressingSalonDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Hairdresser Hairdresser { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hairdressers.Add(Hairdresser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
