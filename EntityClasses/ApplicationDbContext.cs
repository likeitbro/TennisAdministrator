using EntityClasses.Person;
using EntityClasses.Sales;
using EntityClasses.Tournaments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses;

internal class ApplicationDbContext: DbContext
{
    public DbSet<ProductType> ProductTypes { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<SaleDetail> SaleDetails { get; set; }

    public DbSet<Sale> Sales {  get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<TrainerType> TrainerTypes { get; set; }

    public DbSet<Trainer> Trainers { get; set; }

    public DbSet<Court> Courts { get; set; }

    public DbSet<Specialization> Specializations { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<TournamentAttendee> TournamentAttendees { get; set; }

    public DbSet<Sport> Sports { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-HS2KJMA\SQLEXPRESS;Database=TennisDB;ConnectRetryCount=0");
    }
}
