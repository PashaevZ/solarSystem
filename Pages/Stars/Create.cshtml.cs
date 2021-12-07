using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using solarsystem.Data;
using solarsystem.Models;

namespace solarsystem.Pages.Stars
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
            return Page();
        }

        [BindProperty]
        public Star Star { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stars.Add(Star);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
