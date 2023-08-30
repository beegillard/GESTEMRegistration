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


        public async Task<IActionResult> OnGetAsync()
        {
            ShowData = false;

            if (!string.IsNullOrEmpty(EmailSearch))
            {
                var guide = await _context.Guide.FirstOrDefaultAsync(g => g.Email == EmailSearch.ToLower());

                if (guide == null)
                {
                    return NotFound();
                } else
                {
                    Guide = guide;
                    ShowData = true;

                }
                

            }

            
            return Page();
           
        }
    }
}
