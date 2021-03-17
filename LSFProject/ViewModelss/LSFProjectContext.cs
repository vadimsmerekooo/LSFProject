using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LSFProject
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

        public virtual DbSet<AspNetFavTarget> AspNetFavTargets { get; set; }
        public virtual DbSet<AspNetFile> AspNetFiles { get; set; }
        public virtual DbSet<AspNetForum> AspNetForums { get; set; }
        public virtual DbSet<AspNetForumAnswer> AspNetForumAnswers { get; set; }
        public virtual DbSet<AspNetForumQuestion> AspNetForumQuestions { get; set; }
        public virtual DbSet<AspNetForumStatus> AspNetForumStatuses { get; set; }
        public virtual DbSet<AspNetIcon> AspNetIcons { get; set; }
        public virtual DbSet<AspNetNews> AspNetNews { get; set; }
        public virtual DbSet<AspNetNewsCategory> AspNetNewsCategories { get; set; }
        public virtual DbSet<AspNetNewsComment> AspNetNewsComments { get; set; }
        public virtual DbSet<AspNetPage> AspNetPages { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetTarget> AspNetTargets { get; set; }
        public virtual DbSet<AspNetTraficRule> AspNetTraficRules { get; set; }
        public virtual DbSet<AspNetTreeMenu> AspNetTreeMenus { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetFavTarget>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.AspNetFavTargets)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK_AspNetFavTargets_AspNetTargets");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetFavTargets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetFavTargets_AspNetUsers");
            });

            modelBuilder.Entity<AspNetFile>(entity =>
            {
                entity.Property(e => e.DateAdd).HasColumnType("datetime");

                entity.Property(e => e.Path).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<AspNetForum>(entity =>
            {
                entity.ToTable("AspNetForum");

                entity.HasOne(d => d.QuestionsNavigation)
                    .WithMany(p => p.AspNetForums)
                    .HasForeignKey(d => d.Questions)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetForum_AspNetForumQuestion");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.AspNetForums)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetForum_AspNetForumStatus");
            });

            modelBuilder.Entity<AspNetForumAnswer>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(450);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.InverseAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_AspNetForumAnswers_AspNetForumAnswers");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AspNetForumAnswers)
                    .HasForeignKey(d => d.Author)
                    .HasConstraintName("FK_AspNetForumAnswers_AspNetUsers");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.AspNetForumAnswers)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetForumAnswers_AspNetForumQuestion");
            });

            modelBuilder.Entity<AspNetForumQuestion>(entity =>
            {
                entity.ToTable("AspNetForumQuestion");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AspNetForumQuestions)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetForumQuestion_AspNetUsers");
            });

            modelBuilder.Entity<AspNetForumStatus>(entity =>
            {
                entity.ToTable("AspNetForumStatus");

                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<AspNetNews>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Header).IsRequired();

                entity.Property(e => e.PreviewPhoto).HasColumnName("Preview_Photo");

                entity.Property(e => e.PreviewText).HasColumnName("Preview_Text");

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.AspNetNews)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetNews_AspNetUsers");

                entity.HasOne(d => d.PreviewPhotoNavigation)
                    .WithMany(p => p.AspNetNews)
                    .HasForeignKey(d => d.PreviewPhoto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetNews_AspNetFiles");
            });

            modelBuilder.Entity<AspNetNewsCategory>(entity =>
            {
                entity.Property(e => e.Category).IsRequired();
            });

            modelBuilder.Entity<AspNetNewsComment>(entity =>
            {
                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.AnswerNavigation)
                    .WithMany(p => p.InverseAnswerNavigation)
                    .HasForeignKey(d => d.Answer)
                    .HasConstraintName("FK_AspNetNewsComments_AspNetNewsComments");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.AspNetNewsComments)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetNewsComments_AspNetNews");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetNewsComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetNewsComments_AspNetUsers");
            });

            modelBuilder.Entity<AspNetPage>(entity =>
            {
                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.AspNetPages)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetPages_AspNetNewsCategories");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetTarget>(entity =>
            {
                entity.Property(e => e.StatesIds)
                    .HasMaxLength(50)
                    .HasColumnName("StatesIDs");
                entity.HasOne(d => d.ImagePathNavigation)
                    .WithMany(p => p.AspNetTargets)
                    .HasForeignKey(d => d.ImagePath)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetFiles_AspNetTargets");
            });

            modelBuilder.Entity<AspNetTreeMenu>(entity =>
            {
                entity.ToTable("AspNetTreeMenu");

                entity.Property(e => e.Item).IsRequired();

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_AspNetTreeMenu_AspNetTreeMenu");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.IconNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Icon)
                    .HasConstraintName("FK_AspNetUsers_AspNetIcons");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
