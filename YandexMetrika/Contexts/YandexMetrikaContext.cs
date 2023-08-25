using Microsoft.EntityFrameworkCore;
using YandexMetrika.EntitiesYandexMetrika;

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

    public virtual DbSet<AddLog> AddLogs { get; set; }

    public virtual DbSet<InProgress> InProgresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(SecureData.Get("ConnectionYandexMetrika"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AddLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("add_logs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Log)
                .HasColumnType("text")
                .HasColumnName("log");
        });

        modelBuilder.Entity<InProgress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("in_progress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmailsMd5)
                .HasMaxLength(32)
                .HasColumnName("emails_md5");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(11)
                .HasColumnName("order_status");
            entity.Property(e => e.PhonesMd5)
                .HasMaxLength(32)
                .HasColumnName("Phones_md5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
