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
    public class DetailsModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public DetailsModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

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
    }
}
