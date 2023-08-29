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

        [BindProperty(SupportsGet = true)]
        public string? EmailSearch { get; set; }


        public void OnGet()
        {
            ShowData = false;
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Guide == null)
            {
                return NotFound();
            }

            var guide = await _context.Guide.FirstOrDefaultAsync(m => m.ID== id);
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
