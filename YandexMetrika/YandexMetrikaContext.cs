using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YandexMetrika.Entities;

namespace YandexMetrika;

public partial class YandexMetrikaContext : DbContext
{
    public YandexMetrikaContext()
    {
    }

    public YandexMetrikaContext(DbContextOptions<YandexMetrikaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InProgress> InProgresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.0.64;database=yandex_metrika;user id=yandex_metrika;password=yandex_metrika_nE7bva;default command timeout=0", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<InProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("in_progress");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(32)
                .HasColumnName("id");
            entity.Property(e => e.ContactData)
                .HasMaxLength(150)
                .HasColumnName("contact_data");
            entity.Property(e => e.CreateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.DataType)
                .HasMaxLength(5)
                .HasColumnName("data_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
