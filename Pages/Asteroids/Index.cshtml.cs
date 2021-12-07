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
    public class IndexModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public IndexModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        public IList<Asteroid> Asteroid { get;set; }

        public async Task OnGetAsync()
        {
            Asteroid = await _context.Asteroids
                .Include(a => a.Star).ToListAsync();
        }
    }
}
