using Microsoft.EntityFrameworkCore;
using GESTEMRegistration.Data;

namespace GESTEMRegistration.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GESTEMRegistrationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<GESTEMRegistrationContext>>()))
        {
            if (context == null || context.Guide == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Guide.Any())
            {
                return;   // DB has been seeded
            }

            context.Guide.AddRange(
                new Guide
                {
                    Name = "Bobo McBoogie",
                    Email = "Bobo@bobo.com",
                    PrevVolunteer = false,
                }
            );
            context.SaveChanges();
        }
    }
}