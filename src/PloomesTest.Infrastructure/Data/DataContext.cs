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
            modelBuilder.Entity<Client>(builder =>
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(),
                        v => (ClientType)Enum.Parse(typeof(ClientType), v));

                builder.Property(c => c.FederalDocument)
                    .IsRequired()
                    .HasMaxLength(14);

                builder.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                builder.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(250);

                builder.Property(c => c.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                builder.Property(c => c.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                builder.Property(c => c.City)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(c => c.State)
                    .IsRequired()
                    .HasMaxLength(40);

                builder.Property(c => c.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();

                builder.Property(c => c.Country)
                    .IsRequired()
                    .HasMaxLength(60);

                builder.Property(c => c.CreatedAt)
                    .IsRequired();

                builder.Property(c => c.UpdatedAt)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}