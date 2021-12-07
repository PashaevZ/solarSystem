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
    public class IndexModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public IndexModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        public IList<Satellite> Satellite { get;set; }

        public async Task OnGetAsync()
        {
            Satellite = await _context.Satellites
                .Include(s => s.Planet).ToListAsync();
        }
    }
}
