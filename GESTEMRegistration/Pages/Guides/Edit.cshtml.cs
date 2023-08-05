using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GESTEMRegistration.Data;
using GESTEMRegistration.Models;

namespace GESTEMRegistration.Pages.Guides
{
    public class EditModel : PageModel
    {
        private readonly GESTEMRegistration.Data.GESTEMRegistrationContext _context;

        public EditModel(GESTEMRegistration.Data.GESTEMRegistrationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guide Guide { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Guide == null)
            {
                return NotFound();
            }

            var guide =  await _context.Guide.FirstOrDefaultAsync(m => m.ID == id);
            if (guide == null)
            {
                return NotFound();
            }
            Guide = guide;
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

            _context.Attach(Guide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(Guide.ID))
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

        private bool GuideExists(int id)
        {
          return (_context.Guide?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
