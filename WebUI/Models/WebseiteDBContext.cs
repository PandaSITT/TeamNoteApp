using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebUI.Models
{
    public partial class WebseiteDBContext : DbContext
    {
        public WebseiteDBContext()
        {
        }

        public WebseiteDBContext(DbContextOptions<WebseiteDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Geschlecht> Geschlechts { get; set; }
        public virtual DbSet<Raeume> Raeumes { get; set; }
        public virtual DbSet<RaumOverview> RaumOverviews { get; set; }
        public virtual DbSet<RaumUser> RaumUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserOverview> UserOverviews { get; set; }
        public virtual DbSet<UserPasswort> UserPassworts { get; set; }
        public virtual DbSet<UserRolle> UserRolles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost; Database=WebseiteDB; User Id=Dev; Password=73r6eWVMUBfc73Bv; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.ToTable("Content");

                entity.HasIndex(e => e.CRaumId, "C_Raum_ID");

                entity.HasIndex(e => e.CUserCreatorId, "C_User_Creator_ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CPinned).HasColumnName("C_Pinned");

                entity.Property(e => e.CRaumId).HasColumnName("C_Raum_ID");

                entity.Property(e => e.CText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("C_Text");

                entity.Property(e => e.CUserCreatorId).HasColumnName("C_User_Creator_ID");

                entity.HasOne(d => d.CRaum)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.CRaumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Content_ibfk_1");

                entity.HasOne(d => d.CUserCreator)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.CUserCreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Content_ibfk_2");
            });

            modelBuilder.Entity<Geschlecht>(entity =>
            {
                entity.HasKey(e => e.GId)
                    .HasName("PRIMARY");

                entity.ToTable("Geschlecht");

                entity.Property(e => e.GId).HasColumnName("G_ID");

                entity.Property(e => e.GAnrede)
                    .HasMaxLength(255)
                    .HasColumnName("G_Anrede");

                entity.Property(e => e.GName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("G_Name");
            });

            modelBuilder.Entity<Raeume>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PRIMARY");

                entity.ToTable("Raeume");

                entity.HasIndex(e => e.RUserManagerId, "R_User_Manager_ID");

                entity.Property(e => e.RId).HasColumnName("R_ID");

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("R_Name");

                entity.Property(e => e.RUserManagerId).HasColumnName("R_User_Manager_ID");

                entity.HasOne(d => d.RUserManager)
                    .WithMany(p => p.Raeumes)
                    .HasForeignKey(d => d.RUserManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Raeume_ibfk_1");
            });

            modelBuilder.Entity<RaumOverview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Raum_Overview");

                entity.Property(e => e.ManagerId).HasColumnName("Manager ID");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(255)
                    .HasColumnName("Manager Name");

                entity.Property(e => e.RaumId).HasColumnName("Raum ID");

                entity.Property(e => e.RaumName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Raum Name");

                entity.Property(e => e.UserCount).HasColumnName("User Count");
            });

            modelBuilder.Entity<RaumUser>(entity =>
            {
                entity.HasKey(e => new { e.RuRaumId, e.RuUserId })
                    .HasName("PRIMARY");

                entity.ToTable("Raum_User");

                entity.HasIndex(e => e.RuUserId, "RU_User_ID");

                entity.Property(e => e.RuRaumId).HasColumnName("RU_Raum_ID");

                entity.Property(e => e.RuUserId).HasColumnName("RU_User_ID");

                entity.Property(e => e.RuRaumAdmin).HasColumnName("RU_Raum_Admin");

                entity.HasOne(d => d.RuRaum)
                    .WithMany(p => p.RaumUsers)
                    .HasForeignKey(d => d.RuRaumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Raum_User_ibfk_1");

                entity.HasOne(d => d.RuUser)
                    .WithMany(p => p.RaumUsers)
                    .HasForeignKey(d => d.RuUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Raum_User_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.ToTable("User");

                entity.HasIndex(e => e.UBenutzername, "U_Benutzername")
                    .IsUnique();

                entity.HasIndex(e => e.UGeschlechtId, "U_Geschlecht_ID");

                entity.HasIndex(e => e.URolleId, "U_Rolle_ID");

                entity.Property(e => e.UId).HasColumnName("U_ID");

                entity.Property(e => e.UBenutzername)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("U_Benutzername");

                entity.Property(e => e.UEmail)
                    .HasMaxLength(255)
                    .HasColumnName("U_Email");

                entity.Property(e => e.UGeschlechtId).HasColumnName("U_Geschlecht_ID");

                entity.Property(e => e.UNachname)
                    .HasMaxLength(255)
                    .HasColumnName("U_Nachname");

                entity.Property(e => e.URolleId).HasColumnName("U_Rolle_ID");

                entity.Property(e => e.UVorname)
                    .HasMaxLength(255)
                    .HasColumnName("U_Vorname");

                entity.HasOne(d => d.UGeschlecht)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UGeschlechtId)
                    .HasConstraintName("User_ibfk_1");

                entity.HasOne(d => d.URolle)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.URolleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_ibfk_2");
            });

            modelBuilder.Entity<UserOverview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("User_Overview");

                entity.Property(e => e.Benutzername)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Geschlecht).HasMaxLength(255);

                entity.Property(e => e.Nachname).HasMaxLength(255);

                entity.Property(e => e.Rolle).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("User ID");

                entity.Property(e => e.Vorname).HasMaxLength(255);
            });

            modelBuilder.Entity<UserPasswort>(entity =>
            {
                entity.HasKey(e => e.UpUserId)
                    .HasName("PRIMARY");

                entity.ToTable("User_Passwort");

                entity.Property(e => e.UpUserId).HasColumnName("UP_User_ID");

                entity.Property(e => e.UpPasswort)
                    .HasMaxLength(255)
                    .HasColumnName("UP_Passwort");

                entity.HasOne(d => d.UpUser)
                    .WithOne(p => p.UserPasswort)
                    .HasForeignKey<UserPasswort>(d => d.UpUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Passwort_ibfk_1");
            });

            modelBuilder.Entity<UserRolle>(entity =>
            {
                entity.HasKey(e => e.UrId)
                    .HasName("PRIMARY");

                entity.ToTable("User_Rolle");

                entity.Property(e => e.UrId).HasColumnName("UR_ID");

                entity.Property(e => e.UrName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("UR_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
