using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public ApplicationDbContext() : base()
    {
    }

   
}
