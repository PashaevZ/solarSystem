using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Planets
{
    public class CreateModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public CreateModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StarID"] = new SelectList(_context.Stars, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Planet Planet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Planets.Add(Planet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
