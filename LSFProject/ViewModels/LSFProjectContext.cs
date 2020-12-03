using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LSFProject.ViewModels
{
    public partial class LSFProjectContext : DbContext
    {
        public LSFProjectContext()
        {
        }

        public LSFProjectContext(DbContextOptions<LSFProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-GMR70BN0\\SQLEXPRESS;Database=LSFProject;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<News>(entity =>
            {

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Header).IsRequired();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PreviewPhoto)
                    .IsRequired()
                    .HasColumnName("Preview_Photo");

                entity.Property(e => e.PreviewText).HasColumnName("Preview_Text");

                entity.Property(e => e.Url).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
