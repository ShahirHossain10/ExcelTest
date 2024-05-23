using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<NCD> NCDs { get; set; }
    public DbSet<NCD_Detail> NCD_Details { get; set; }
    public DbSet<Allergie> Allergies { get; set; }
    public DbSet<Allergie_Detail> Allergie_Details { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disease>().HasData(
            new Disease
            {
                Id = 1,
                Name = "Flu"
            },
            new Disease
            {
                Id = 2,
                Name = "Hepatitis A"
            },
            new Disease
            {
                Id = 3,
                Name = "Chickenpox"
            }
        );

        modelBuilder.Entity<NCD>().HasData(
            new NCD
            {
                Id = 1,
                Name = "Asthma"
            },
            new NCD
            {
                Id = 2,
                Name = "Cancer"
            },
            new NCD
            {
                Id = 3,
                Name = "Disorders of ear"
            },
            new NCD
            {
                Id = 4,
                Name = "Disorders of eye"
            },
            new NCD
            {
                Id = 5,
                Name = "Mental illness"
            }
        );

        modelBuilder.Entity<Allergie>().HasData(
            new Allergie
            {
                Id = 1,
                Name = "Drugs - Penicillin"
            },
            new Allergie
            {
                Id = 2,
                Name = "Drugs - Other"
            },
            new Allergie
            {
                Id = 3,
                Name = "Animal"
            },
            new Allergie
            {
                Id = 4,
                Name = "Food"
            },
            new Allergie
            {
                Id = 5,
                Name = "No Allergies"
            },
            new Allergie
            {
                Id = 6,
                Name = "Others"
            }
        );
    }
}
