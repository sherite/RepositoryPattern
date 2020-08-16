namespace Entities.DataContext.Data
{
    using Entities.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new WebApiDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebApiDbContext>>()))
            {
                if (_context.Users.Any())
                {
                    return;
                }

                _context.Users.AddRange(
                    new User { Nombre = "Carlos Porcel" }
                 );

                _context.SaveChanges();
            }
        }
    }
}