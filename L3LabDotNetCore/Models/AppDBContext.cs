using L3Lab.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace L3Lab.EntityFrameworkCore;

public class AppDBContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public string DbPath { get; }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().ToTable("Notes");
    }
}   
