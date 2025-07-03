using Microsoft.EntityFrameworkCore;
using ProyectAntivirusBackend.Models;
using ServiceModel = ProyectAntivirusBackend.Models.Service;

namespace ProyectAntivirusBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Tablas de la base de datos
        public DbSet<User> Users { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<OpportunityType> OpportunityTypes { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public required IEnumerable<object> Ratingsatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno entre User y Profile
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a uno entre User y AuthUser
            modelBuilder.Entity<User>()
                .HasOne(u => u.AuthUser)
                .WithOne(a => a.User)
                .HasForeignKey<AuthUser>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índice único para el correo
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Opportunity>()
                .Property(o => o.PublicationDate)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Opportunity>()
                .Property(o => o.ExpirationDate)
                .HasColumnType("timestamp with time zone");

            // Relación uno a muchos entre Opportunity y OpportunityType
            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.OpportunityTypes)
                .WithMany(ot => ot.Opportunities)
                .HasForeignKey(o => o.OpportunityTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Opportunity y Institution
            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Institutions)
                .WithMany()
                .HasForeignKey(o => o.InstitutionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Opportunity y Sector
            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Sectors)
                .WithMany()
                .HasForeignKey(o => o.SectorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Opportunity y Locality
            modelBuilder.Entity<Opportunity>()
                .HasOne(o => o.Localities)
                .WithMany()
                .HasForeignKey(o => o.LocalityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre OpportunityType y Locality
            modelBuilder.Entity<OpportunityType>()
                .HasOne(o => o.Categories)
                .WithMany()
                .HasForeignKey(o => o.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Request y Opportunity
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Opportunity)
                .WithMany()
                .HasForeignKey(r => r.OpportunityId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Request y User
            modelBuilder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre Service y ServiceType
            modelBuilder.Entity<ServiceModel>()
                .HasOne(s => s.ServiceType)
                .WithMany(st => st.Services)
                .HasForeignKey(s => s.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Índice único para el título de la oportunidad
            modelBuilder.Entity<Opportunity>()
                .HasIndex(o => o.Title)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Opportunity)
                .WithMany(o => o.Ratings)
                .HasForeignKey(r => r.OpportunityId);

            modelBuilder.Entity<Rating>()
                .Property(r => r.CreatedAt)
                .HasColumnName("created_at");

            modelBuilder.Entity<Rating>()
                .Property(r => r.UserId)
                .IsRequired(false);

            modelBuilder.Entity<OpportunityType>().ToTable("opportunity_types");
            modelBuilder.Entity<Sector>().ToTable("sectors");
            modelBuilder.Entity<Institution>().ToTable("institutions");
            modelBuilder.Entity<Locality>().ToTable("localities");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Rating>().ToTable("rating");
            modelBuilder.Entity<Favorite>().ToTable("favorites");

        }
    }
}
