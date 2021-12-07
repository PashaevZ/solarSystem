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
    public class IndexModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public IndexModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        public IList<DwarfPlanet> DwarfPlanet { get;set; }

        public async Task OnGetAsync()
        {
            DwarfPlanet = await _context.DwarfPlanets
                .Include(d => d.Star).ToListAsync();
        }
    }
}
