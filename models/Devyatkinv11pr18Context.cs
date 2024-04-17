using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prac18.models;

public partial class Devyatkinv11pr18Context : DbContext
{
    public Devyatkinv11pr18Context()
    {
    }

    public Devyatkinv11pr18Context(DbContextOptions<Devyatkinv11pr18Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Veteran> Veterans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Devyatkinv11pr18; User=исп-31; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veteran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__veterans__3213E83FA329C1B7");

            entity.ToTable("veterans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ВозрастнуюГруппа)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Возрастную_группа");
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.НомерКомнаты).HasColumnName("Номер_комнаты");
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
