using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.DbContext;

public class Context : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Show> Shows { get; set; }
    public DbSet<Episode> Episodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EFC/Data.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Show>().HasKey(show => show.ShowId);
        modelBuilder.Entity<Episode>().HasKey(episode => episode.EpisodeId);
        
            
    }

    
}