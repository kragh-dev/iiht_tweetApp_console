using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Com.Tweetapp.Model
{
    public partial class tweetAppDbContext : DbContext
    {
        public tweetAppDbContext()
        {
        }

        public tweetAppDbContext(DbContextOptions<tweetAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Tweet> Tweet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=J-A-R-V-I-S; database=tweetAppDb; trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__users__3213E83FE62DC531");

                entity.ToTable("app_user");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__users__AB6E6164F675DE8A")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Tweet>(entity =>
            {
                entity.ToTable("tweet");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(200);

                entity.Property(e => e.TweetId)
                    .HasColumnName("tweet_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tweet__user_id__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
