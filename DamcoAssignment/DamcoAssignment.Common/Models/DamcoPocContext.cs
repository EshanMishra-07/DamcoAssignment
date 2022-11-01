using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DamcoAssignment.Common.Models
{
    public partial class DamcoPocContext : DbContext
    {
        public DamcoPocContext()
        {
        }

        public DamcoPocContext(DbContextOptions<DamcoPocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentBlog> ContentBlogs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DS-LAP-0371\\SQLEXPRESS;Database=DamcoPoc;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentBlog>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("PK__ContentB__2907A87E5CAFE110");

                entity.ToTable("ContentBlog");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.BlogContent).IsUnicode(false);

                entity.Property(e => e.Doc)
                    .HasColumnType("datetime")
                    .HasColumnName("DOC");

                entity.Property(e => e.Dod).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Template)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Topic)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContentBlogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ContentBl__UserI__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Doc)
                    .HasColumnType("datetime")
                    .HasColumnName("DOC");

                entity.Property(e => e.Dol)
                    .HasColumnType("datetime")
                    .HasColumnName("DOL");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Roles)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
