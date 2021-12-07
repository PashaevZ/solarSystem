using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Satellites
{
    public class DeleteModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public DeleteModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Satellite Satellite { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Satellite = await _context.Satellites
                .Include(s => s.Planet).FirstOrDefaultAsync(m => m.ID == id);

            if (Satellite == null)
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

            Satellite = await _context.Satellites.FindAsync(id);

            if (Satellite != null)
            {
                _context.Satellites.Remove(Satellite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
