using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GESTEMRegistration.Data;
using GESTEMRegistration.Models;

namespace GESTEMRegistration.Pages.Guides
{
    public class CreateModel : PageModel
    {
        private readonly GESTEMRegistration.Data.GESTEMRegistrationContext _context;

        public CreateModel(GESTEMRegistration.Data.GESTEMRegistrationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Guide Guide { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Guide == null || Guide == null)
            {
                return Page();
            }

       //add check if already registered, redirect to details

            _context.Guide.Add(Guide);
            await _context.SaveChangesAsync();

            return RedirectToPage("../GuideConfirmation");
        }
    }
}
