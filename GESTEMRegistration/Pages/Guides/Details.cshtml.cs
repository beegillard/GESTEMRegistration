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
    public class DetailsModel : PageModel
    {
        private readonly GESTEMRegistration.Data.GESTEMRegistrationContext _context;

        public DetailsModel(GESTEMRegistration.Data.GESTEMRegistrationContext context)
        {
            _context = context;
        }

      public Guide Guide { get; set; } = default!;
    public bool ShowData { get; set; }

        public void OnGet()
        {
            ShowData = false;
        }


        public async Task<IActionResult> OnPostAsync(string? email)
        {
            if (email == null || _context.Guide == null)
            {
                return NotFound();
            }

            var guide = await _context.Guide.FirstOrDefaultAsync(m => m.Email == email);
            if (guide == null)
            {
                return NotFound();
            }
            else 
            {
                ShowData = true;
                Guide = guide;
            }
            return Page();
        } 
    }
}
