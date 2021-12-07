using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Asteroids
{
    public class DeleteModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public DeleteModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asteroid Asteroid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asteroid = await _context.Asteroids
                .Include(a => a.Star).FirstOrDefaultAsync(m => m.ID == id);

            if (Asteroid == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asteroid = await _context.Asteroids.FindAsync(id);

            if (Asteroid != null)
            {
                _context.Asteroids.Remove(Asteroid);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
