using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GESTEMRegistration.Models;

namespace GESTEMRegistration.Data
{
    public class GESTEMRegistrationContext : DbContext
    {
        public GESTEMRegistrationContext (DbContextOptions<GESTEMRegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<GESTEMRegistration.Models.Guide> Guide { get; set; } = default!;
    }
}
