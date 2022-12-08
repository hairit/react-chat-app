using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace chatapp_server.Models
{
    public partial class ChatAppContext : DbContext
    {
        public ChatAppContext()
        {
        }

        public ChatAppContext(DbContextOptions<ChatAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatGroup> ChatGroups { get; set; } = null!;
        public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public virtual DbSet<ChatUser> ChatUsers { get; set; } = null!;
        public virtual DbSet<GroupUser> GroupUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ChatApp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__ChatGrou__149AF36A86AB91EE");

                entity.ToTable("ChatGroup");

                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatGroups)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatGroup__Creat__267ABA7A");
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__ChatMess__C87C0C9C82A476D4");

                entity.ToTable("ChatMessage");

                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__ChatMessa__Creat__2D27B809");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__ChatMessa__Group__2E1BDC42");
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__ChatUser__1788CC4CEF11A891");

                entity.ToTable("ChatUser");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId })
                    .HasName("PK__GroupUse__C5E27FAEC71F942A");

                entity.ToTable("GroupUser");

                entity.Property(e => e.IsApproved)
                    .HasMaxLength(20)
                    .HasColumnName("isApproved");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupUser__Group__29572725");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupUser__UserI__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
