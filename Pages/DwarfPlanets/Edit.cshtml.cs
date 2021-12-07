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

namespace solarsystem.Pages.DwarfPlanets
{
    public class EditModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public EditModel(solarsystem.Data.SolarSystContext context)
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

            _context.Attach(DwarfPlanet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DwarfPlanetExists(DwarfPlanet.ID))
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

        private bool DwarfPlanetExists(int id)
        {
            return _context.DwarfPlanets.Any(e => e.ID == id);
        }
    }
}
