using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.AuthSubject).HasMaxLength(255).IsRequired();
            e.HasIndex(x => x.AuthSubject).IsUnique();

            e.Property(x => x.CreateAt)
                .HasColumnType("datetime(6)")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

            e.Property(x => x.UpdateAt)
                .HasColumnType("datetime(6)")
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<Profile>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.FirstName).HasMaxLength(100);
            e.Property(x => x.LastName).HasMaxLength(100);

            e.Property(x => x.DateOfBirth).HasColumnType("datetime(6)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");


            e.HasIndex(x => x.UserId).IsUnique();

            e.HasOne(x => x.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            e.Property(x => x.Gender).HasConversion<string>();
            e.Property(x => x.HeightUnit).HasConversion<string>();
            e.Property(x => x.WeightUnit).HasConversion<string>();
        });
    }
}
