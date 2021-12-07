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

namespace solarsystem.Pages.Stars
{
    public class EditModel : PageModel
    {
        private readonly solarsystem.Data.SolarSystContext _context;

        public EditModel(solarsystem.Data.SolarSystContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Star).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarExists(Star.ID))
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

        private bool StarExists(int id)
        {
            return _context.Stars.Any(e => e.ID == id);
        }
    }
}
