using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.DwarfPlanets
{
    public class DeleteModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public DeleteModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DwarfPlanet DwarfPlanet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DwarfPlanet = await _context.DwarfPlanets
                .Include(d => d.Star).FirstOrDefaultAsync(m => m.ID == id);

            if (DwarfPlanet == null)
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

            DwarfPlanet = await _context.DwarfPlanets.FindAsync(id);

            if (DwarfPlanet != null)
            {
                _context.DwarfPlanets.Remove(DwarfPlanet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
