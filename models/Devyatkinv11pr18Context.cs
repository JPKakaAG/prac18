using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prac18;

public partial class Devyatkinv11pr18Context : DbContext
{
    public Devyatkinv11pr18Context()
    {
    }

    public Devyatkinv11pr18Context(DbContextOptions<Devyatkinv11pr18Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<RoomAssignment> RoomAssignments { get; set; }

    public virtual DbSet<Veteran> Veterans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Devyatkinv11pr18; User=исп-31; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hotels__3213E83FF32A8AAF");

            entity.ToTable("hotels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Адрес)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Город)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.НазваниеГостиницы)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Название_гостиницы");
            entity.Property(e => e.НомерКомнаты).HasColumnName("Номер_комнаты");
        });

        modelBuilder.Entity<RoomAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room_ass__3213E83FF5A33C13");

            entity.ToTable("room_assignments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdОтеля).HasColumnName("id_отеля");
            entity.Property(e => e.IdСпортсмена).HasColumnName("id_спортсмена");
            entity.Property(e => e.НомерКомнаты).HasColumnName("Номер_комнаты");

            entity.HasOne(d => d.IdОтеляNavigation).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.IdОтеля)
                .HasConstraintName("FK__room_assi__hotel__286302EC");

            entity.HasOne(d => d.IdСпортсменаNavigation).WithMany(p => p.RoomAssignments)
                .HasForeignKey(d => d.IdСпортсмена)
                .HasConstraintName("FK__room_assi__athle__29572725");
        });

        modelBuilder.Entity<Veteran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__veterans__3213E83FA329C1B7");

            entity.ToTable("veterans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ВозрастнуюГруппа)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("возрастную группа");
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Отчество)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
