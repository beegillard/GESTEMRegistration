using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GESTEMRegistration.Data;
using GESTEMRegistration.Models;

namespace GESTEMRegistration.Pages.Guides
{
    public class DeleteModel : PageModel
    {
        private readonly GESTEMRegistration.Data.GESTEMRegistrationContext _context;

        public DeleteModel(GESTEMRegistration.Data.GESTEMRegistrationContext context)
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

            var guide = await _context.Guide.FirstOrDefaultAsync(m => m.ID == id);

            if (guide == null)
            {
                return NotFound();
            }
            else 
            {
                Guide = guide;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Guide == null)
            {
                return NotFound();
            }
            var guide = await _context.Guide.FindAsync(id);

            if (guide != null)
            {
                Guide = guide;
                _context.Guide.Remove(Guide);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../GuideConfirmation");
        }
    }
}
