using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class AppDB : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDB(DbContextOptions<AppDB> options): base(options)
        {
            
        }
    }
}