using L3Lab.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3Lab.EntityFrameworkCore;

public class MessagesContext : DbContext
{
    public DbSet<L3LabMessage> L3LabMessages { get; set; }

    public string DbPath { get; }

    public MessagesContext(DbContextOptions<MessagesContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<L3LabMessage>().ToTable("L3LabMessage");
    }
}   
