using ContactManagement.Models;
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

    public DbSet<Contact> contacts { get; set; }

    public override int SaveChanges()
    {
        //Soft-Delete
        foreach (var item in ChangeTracker.Entries()
           .Where(e => e.State == EntityState.Deleted &&
           e.Metadata.GetProperties().Any(x => x.Name == "IsDeleted")))
        {
            item.State = EntityState.Unchanged;
            item.CurrentValues["IsDeleted"] = true;
        }
        return base.SaveChanges();
    }
}
