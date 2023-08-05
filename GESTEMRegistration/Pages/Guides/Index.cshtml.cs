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
    public class IndexModel : PageModel
    {
        private readonly GESTEMRegistration.Data.GESTEMRegistrationContext _context;

        public IndexModel(GESTEMRegistration.Data.GESTEMRegistrationContext context)
        {
            _context = context;
        }

        public IList<Guide> Guide { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Guide != null)
            {
                Guide = await _context.Guide.ToListAsync();
            }
        }
    }
}
