using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using FinManager.Data.Entities;

namespace FinManager.Data
{
    public class FinManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public FinManagerDbContext(DbContextOptions<FinManagerDbContext> options)
            : base(options) { }
    }
}
