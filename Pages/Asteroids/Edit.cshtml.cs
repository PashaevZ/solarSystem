using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Asteroids
{
    public class EditModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public EditModel(solarsystem.Data.SolarSystContext context)
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
           ViewData["StarID"] = new SelectList(_context.Stars, "ID", "ID");
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

            _context.Attach(Asteroid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsteroidExists(Asteroid.ID))
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

        private bool AsteroidExists(int id)
        {
            return _context.Asteroids.Any(e => e.ID == id);
        }
    }
}
