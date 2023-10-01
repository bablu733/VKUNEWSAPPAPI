using Microsoft.EntityFrameworkCore;
using VKUNEWSAPPAPI.Data.Models;

namespace VKUNEWSAPPAPI.Data
{
    public class VKUNEWSAPPAPIDbContext:DbContext
    {
        public VKUNEWSAPPAPIDbContext(DbContextOptions<VKUNEWSAPPAPIDbContext> options) : base(options) 
        { 

        } 

        public DbSet<Admin> Admin { get; set; }
      
    }
}
