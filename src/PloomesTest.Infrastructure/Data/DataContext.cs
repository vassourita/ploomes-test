using Microsoft.EntityFrameworkCore;

using PloomesTest.Core.Entities;

namespace PloomesTest.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Client>(builder =>
            {
                _ = builder.HasKey(c => c.Id);

                _ = builder.Property(c => c.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(),
                        v => (ClientType)Enum.Parse(typeof(ClientType), v));

                _ = builder.Property(c => c.FederalDocument)
                    .IsRequired()
                    .HasMaxLength(14);

                _ = builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                _ = builder.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                _ = builder.Property(c => c.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                _ = builder.Property(c => c.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                _ = builder.Property(c => c.City)
                    .IsRequired()
                    .HasMaxLength(100);

                _ = builder.Property(c => c.State)
                    .IsRequired()
                    .HasMaxLength(40);

                _ = builder.Property(c => c.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();

                _ = builder.Property(c => c.Country)
                    .IsRequired()
                    .HasMaxLength(60);

                _ = builder.Property(c => c.CreatedAt)
                    .IsRequired();

                _ = builder.Property(c => c.UpdatedAt)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}