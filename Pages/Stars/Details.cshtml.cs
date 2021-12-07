using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Stars
{
    public class DetailsModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public DetailsModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        public Star Star { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Star = await _context.Stars.FirstOrDefaultAsync(m => m.ID == id);

            if (Star == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
