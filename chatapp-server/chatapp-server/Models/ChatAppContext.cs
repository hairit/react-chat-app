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
        public virtual DbSet<Invitation> Invitations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MARCUS\\TUONGHAI;Initial Catalog=ChatApp;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__ChatGrou__149AF36A0ACFF95D");

                entity.ToTable("ChatGroup");

                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatGroups)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatGroup__Creat__267ABA7A");

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Groups)
                    .UsingEntity<Dictionary<string, object>>(
                        "GroupUser",
                        l => l.HasOne<ChatUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GroupUser__UserI__2A4B4B5E"),
                        r => r.HasOne<ChatGroup>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__GroupUser__Group__29572725"),
                        j =>
                        {
                            j.HasKey("GroupId", "UserId").HasName("PK__GroupUse__C5E27FAEBFB2A8E0");

                            j.ToTable("GroupUser");
                        });
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__ChatMess__C87C0C9C3FB2BDEE");

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
                    .HasName("PK__ChatUser__1788CC4C4E0AF840");

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

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("Invitation");

                entity.Property(e => e.InvitationId).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InvitationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invitatio__Creat__30F848ED");

                entity.HasOne(d => d.IsInvitedUser)
                    .WithMany(p => p.InvitationIsInvitedUsers)
                    .HasForeignKey(d => d.IsInvitedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invitatio__IsInv__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
