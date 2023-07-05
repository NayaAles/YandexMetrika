using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YandexMetrika.Entities;

namespace YandexMetrika;

public partial class ByProductTypeContext : DbContext
{
    public ByProductTypeContext()
    {
    }

    public ByProductTypeContext(DbContextOptions<ByProductTypeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DomainTurnover> DomainTurnovers { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<InnDomain> InnDomains { get; set; }

    public virtual DbSet<Main> Mains { get; set; }

    public virtual DbSet<MainEmail> MainEmails { get; set; }

    public virtual DbSet<MainPhone> MainPhones { get; set; }

    public virtual DbSet<Minu> Minus { get; set; }

    public virtual DbSet<PhonesEmail> PhonesEmails { get; set; }

    public virtual DbSet<PhonesInn> PhonesInns { get; set; }

    public virtual DbSet<Turnover> Turnovers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.0.64;database=by_product_type;user id=by_product_type;password=by_product_type_XKrX0t;default command timeout=0", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DomainTurnover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("domain_turnover");

            entity.HasIndex(e => e.DomainCorp, "domain_corp").IsUnique();

            entity.HasIndex(e => e.DomainSecondCorp, "domain_sec");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abs)
                .HasPrecision(20, 3)
                .HasColumnName("abs");
            entity.Property(e => e.Cmc)
                .HasPrecision(20, 3)
                .HasColumnName("cmc");
            entity.Property(e => e.Dkser)
                .HasPrecision(20, 3)
                .HasColumnName("dkser");
            entity.Property(e => e.DomainCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_corp");
            entity.Property(e => e.DomainSecondCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_second_corp");
            entity.Property(e => e.Erlikid)
                .HasPrecision(20, 3)
                .HasColumnName("erlikid");
            entity.Property(e => e.Fct)
                .HasPrecision(20, 3)
                .HasColumnName("fct");
            entity.Property(e => e.Festo)
                .HasPrecision(20, 3)
                .HasColumnName("festo");
            entity.Property(e => e.Fiztech)
                .HasPrecision(20, 3)
                .HasColumnName("fiztech");
            entity.Property(e => e.Gazses)
                .HasPrecision(20, 3)
                .HasColumnName("gazses");
            entity.Property(e => e.Gibriding)
                .HasPrecision(20, 3)
                .HasColumnName("gibriding");
            entity.Property(e => e.Hamlet)
                .HasPrecision(20, 3)
                .HasColumnName("hamlet");
            entity.Property(e => e.Hcme)
                .HasPrecision(20, 3)
                .HasColumnName("hcme");
            entity.Property(e => e.Kamotsi)
                .HasPrecision(20, 3)
                .HasColumnName("kamotsi");
            entity.Property(e => e.Krass)
                .HasPrecision(20, 3)
                .HasColumnName("krass");
            entity.Property(e => e.Lindegaz)
                .HasPrecision(20, 3)
                .HasColumnName("lindegaz");
            entity.Property(e => e.ListInn)
                .HasMaxLength(1000)
                .HasColumnName("list_inn");
            entity.Property(e => e.Manometr)
                .HasPrecision(20, 3)
                .HasColumnName("manometr");
            entity.Property(e => e.Manoterm)
                .HasPrecision(20, 3)
                .HasColumnName("manoterm");
            entity.Property(e => e.Manotom)
                .HasPrecision(20, 3)
                .HasColumnName("manotom");
            entity.Property(e => e.Metallrukav)
                .HasPrecision(20, 3)
                .HasColumnName("metallrukav");
            entity.Property(e => e.Meter)
                .HasPrecision(20, 3)
                .HasColumnName("meter");
            entity.Property(e => e.Metran)
                .HasPrecision(20, 3)
                .HasColumnName("metran");
            entity.Property(e => e.Monnpo)
                .HasPrecision(20, 3)
                .HasColumnName("monnpo");
            entity.Property(e => e.Monooo)
                .HasPrecision(20, 3)
                .HasColumnName("monooo");
            entity.Property(e => e.Nps)
                .HasPrecision(20, 3)
                .HasColumnName("nps");
            entity.Property(e => e.Nta)
                .HasPrecision(20, 3)
                .HasColumnName("nta");
            entity.Property(e => e.Parker)
                .HasPrecision(20, 3)
                .HasColumnName("parker");
            entity.Property(e => e.Rosma)
                .HasPrecision(20, 3)
                .HasColumnName("rosma");
            entity.Property(e => e.Shtauf)
                .HasPrecision(20, 3)
                .HasColumnName("shtauf");
            entity.Property(e => e.Shver)
                .HasPrecision(20, 3)
                .HasColumnName("shver");
            entity.Property(e => e.Sigm)
                .HasPrecision(20, 3)
                .HasColumnName("sigm");
            entity.Property(e => e.Spechcc)
                .HasPrecision(20, 3)
                .HasColumnName("spechcc");
            entity.Property(e => e.Taikan)
                .HasPrecision(20, 3)
                .HasColumnName("taikan");
            entity.Property(e => e.Tatkompl)
                .HasPrecision(20, 3)
                .HasColumnName("tatkompl");
            entity.Property(e => e.Teplokont)
                .HasPrecision(20, 3)
                .HasColumnName("teplokont");
            entity.Property(e => e.Turnover).HasColumnName("turnover");
            entity.Property(e => e.Umas)
                .HasPrecision(20, 3)
                .HasColumnName("umas");
            entity.Property(e => e.Ural)
                .HasPrecision(20, 3)
                .HasColumnName("ural");
            entity.Property(e => e.Vsp)
                .HasPrecision(20, 3)
                .HasColumnName("vsp");
            entity.Property(e => e.Wika)
                .HasPrecision(20, 3)
                .HasColumnName("wika");
            entity.Property(e => e.Yok)
                .HasPrecision(20, 3)
                .HasColumnName("yok");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("emails");

            entity.HasIndex(e => e.Email1, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Email1)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.SourceCreate)
                .HasMaxLength(400)
                .HasColumnName("source_create");
        });

        modelBuilder.Entity<InnDomain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inn_domain");

            entity.HasIndex(e => new { e.DomainCorp, e.DomainSecondCorp }, "domains");

            entity.HasIndex(e => e.Inn, "inn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DomainCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_corp");
            entity.Property(e => e.DomainSecondCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_second_corp");
            entity.Property(e => e.Inn)
                .HasMaxLength(100)
                .HasColumnName("inn");
        });

        modelBuilder.Entity<Main>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("main");

            entity.HasIndex(e => e.DomainCorp, "domain");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abs)
                .HasPrecision(20, 3)
                .HasColumnName("abs");
            entity.Property(e => e.Cmc)
                .HasPrecision(20, 3)
                .HasColumnName("cmc");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Dkser)
                .HasPrecision(20, 3)
                .HasColumnName("dkser");
            entity.Property(e => e.DomainCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_corp");
            entity.Property(e => e.DomainSecondCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_second_corp");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Erlikid)
                .HasPrecision(20, 3)
                .HasColumnName("erlikid");
            entity.Property(e => e.Fct)
                .HasPrecision(20, 3)
                .HasColumnName("fct");
            entity.Property(e => e.Festo)
                .HasPrecision(20, 3)
                .HasColumnName("festo");
            entity.Property(e => e.Fiztech)
                .HasPrecision(20, 3)
                .HasColumnName("fiztech");
            entity.Property(e => e.Gazses)
                .HasPrecision(20, 3)
                .HasColumnName("gazses");
            entity.Property(e => e.Gibriding)
                .HasPrecision(20, 3)
                .HasColumnName("gibriding");
            entity.Property(e => e.Hamlet)
                .HasPrecision(20, 3)
                .HasColumnName("hamlet");
            entity.Property(e => e.Hcme)
                .HasPrecision(20, 3)
                .HasColumnName("hcme");
            entity.Property(e => e.Kamotsi)
                .HasPrecision(20, 3)
                .HasColumnName("kamotsi");
            entity.Property(e => e.Krass)
                .HasPrecision(20, 3)
                .HasColumnName("krass");
            entity.Property(e => e.Lindegaz)
                .HasPrecision(20, 3)
                .HasColumnName("lindegaz");
            entity.Property(e => e.ListInn)
                .HasMaxLength(1000)
                .HasColumnName("list_inn");
            entity.Property(e => e.Manometr)
                .HasPrecision(20, 3)
                .HasColumnName("manometr");
            entity.Property(e => e.Manoterm)
                .HasPrecision(20, 3)
                .HasColumnName("manoterm");
            entity.Property(e => e.Manotom)
                .HasPrecision(20, 3)
                .HasColumnName("manotom");
            entity.Property(e => e.Metallrukav)
                .HasPrecision(20, 3)
                .HasColumnName("metallrukav");
            entity.Property(e => e.Meter)
                .HasPrecision(20, 3)
                .HasColumnName("meter");
            entity.Property(e => e.Metran)
                .HasPrecision(20, 3)
                .HasColumnName("metran");
            entity.Property(e => e.Monnpo)
                .HasPrecision(20, 3)
                .HasColumnName("monnpo");
            entity.Property(e => e.Monooo)
                .HasPrecision(20, 3)
                .HasColumnName("monooo");
            entity.Property(e => e.Nps)
                .HasPrecision(20, 3)
                .HasColumnName("nps");
            entity.Property(e => e.Nta)
                .HasPrecision(20, 3)
                .HasColumnName("nta");
            entity.Property(e => e.Parker)
                .HasPrecision(20, 3)
                .HasColumnName("parker");
            entity.Property(e => e.Rosma)
                .HasPrecision(20, 3)
                .HasColumnName("rosma");
            entity.Property(e => e.Shtauf)
                .HasPrecision(20, 3)
                .HasColumnName("shtauf");
            entity.Property(e => e.Shver)
                .HasPrecision(20, 3)
                .HasColumnName("shver");
            entity.Property(e => e.Sigm)
                .HasPrecision(20, 3)
                .HasColumnName("sigm");
            entity.Property(e => e.SourceCreate)
                .HasMaxLength(400)
                .HasColumnName("source_create");
            entity.Property(e => e.Spechcc)
                .HasPrecision(20, 3)
                .HasColumnName("spechcc");
            entity.Property(e => e.Taikan)
                .HasPrecision(20, 3)
                .HasColumnName("taikan");
            entity.Property(e => e.Tatkompl)
                .HasPrecision(20, 3)
                .HasColumnName("tatkompl");
            entity.Property(e => e.Teplokont)
                .HasPrecision(20, 3)
                .HasColumnName("teplokont");
            entity.Property(e => e.Turnover).HasColumnName("turnover");
            entity.Property(e => e.Umas)
                .HasPrecision(20, 3)
                .HasColumnName("umas");
            entity.Property(e => e.Ural)
                .HasPrecision(20, 3)
                .HasColumnName("ural");
            entity.Property(e => e.Vsp)
                .HasPrecision(20, 3)
                .HasColumnName("vsp");
            entity.Property(e => e.Wika)
                .HasPrecision(20, 3)
                .HasColumnName("wika");
            entity.Property(e => e.Yok)
                .HasPrecision(20, 3)
                .HasColumnName("yok");
        });

        modelBuilder.Entity<MainEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("main_emails");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abs)
                .HasPrecision(20, 3)
                .HasColumnName("abs");
            entity.Property(e => e.Cmc)
                .HasPrecision(20, 3)
                .HasColumnName("cmc");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Dkser)
                .HasPrecision(20, 3)
                .HasColumnName("dkser");
            entity.Property(e => e.DomainCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_corp");
            entity.Property(e => e.DomainSecondCorp)
                .HasMaxLength(200)
                .HasColumnName("domain_second_corp");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Erlikid)
                .HasPrecision(20, 3)
                .HasColumnName("erlikid");
            entity.Property(e => e.Fct)
                .HasPrecision(20, 3)
                .HasColumnName("fct");
            entity.Property(e => e.Festo)
                .HasPrecision(20, 3)
                .HasColumnName("festo");
            entity.Property(e => e.Fiztech)
                .HasPrecision(20, 3)
                .HasColumnName("fiztech");
            entity.Property(e => e.Gazses)
                .HasPrecision(20, 3)
                .HasColumnName("gazses");
            entity.Property(e => e.Gibriding)
                .HasPrecision(20, 3)
                .HasColumnName("gibriding");
            entity.Property(e => e.Hamlet)
                .HasPrecision(20, 3)
                .HasColumnName("hamlet");
            entity.Property(e => e.Hcme)
                .HasPrecision(20, 3)
                .HasColumnName("hcme");
            entity.Property(e => e.Kamotsi)
                .HasPrecision(20, 3)
                .HasColumnName("kamotsi");
            entity.Property(e => e.Krass)
                .HasPrecision(20, 3)
                .HasColumnName("krass");
            entity.Property(e => e.Lindegaz)
                .HasPrecision(20, 3)
                .HasColumnName("lindegaz");
            entity.Property(e => e.ListInn)
                .HasMaxLength(1000)
                .HasColumnName("list_inn");
            entity.Property(e => e.Manometr)
                .HasPrecision(20, 3)
                .HasColumnName("manometr");
            entity.Property(e => e.Manoterm)
                .HasPrecision(20, 3)
                .HasColumnName("manoterm");
            entity.Property(e => e.Manotom)
                .HasPrecision(20, 3)
                .HasColumnName("manotom");
            entity.Property(e => e.Metallrukav)
                .HasPrecision(20, 3)
                .HasColumnName("metallrukav");
            entity.Property(e => e.Meter)
                .HasPrecision(20, 3)
                .HasColumnName("meter");
            entity.Property(e => e.Metran)
                .HasPrecision(20, 3)
                .HasColumnName("metran");
            entity.Property(e => e.Monnpo)
                .HasPrecision(20, 3)
                .HasColumnName("monnpo");
            entity.Property(e => e.Monooo)
                .HasPrecision(20, 3)
                .HasColumnName("monooo");
            entity.Property(e => e.Nps)
                .HasPrecision(20, 3)
                .HasColumnName("nps");
            entity.Property(e => e.Nta)
                .HasPrecision(20, 3)
                .HasColumnName("nta");
            entity.Property(e => e.Parker)
                .HasPrecision(20, 3)
                .HasColumnName("parker");
            entity.Property(e => e.Rosma)
                .HasPrecision(20, 3)
                .HasColumnName("rosma");
            entity.Property(e => e.Shtauf)
                .HasPrecision(20, 3)
                .HasColumnName("shtauf");
            entity.Property(e => e.Shver)
                .HasPrecision(20, 3)
                .HasColumnName("shver");
            entity.Property(e => e.Sigm)
                .HasPrecision(20, 3)
                .HasColumnName("sigm");
            entity.Property(e => e.SourceCreate)
                .HasMaxLength(400)
                .HasColumnName("source_create");
            entity.Property(e => e.Spechcc)
                .HasPrecision(20, 3)
                .HasColumnName("spechcc");
            entity.Property(e => e.Taikan)
                .HasPrecision(20, 3)
                .HasColumnName("taikan");
            entity.Property(e => e.Tatkompl)
                .HasPrecision(20, 3)
                .HasColumnName("tatkompl");
            entity.Property(e => e.Teplokont)
                .HasPrecision(20, 3)
                .HasColumnName("teplokont");
            entity.Property(e => e.Turnover).HasColumnName("turnover");
            entity.Property(e => e.Umas)
                .HasPrecision(20, 3)
                .HasColumnName("umas");
            entity.Property(e => e.Ural)
                .HasPrecision(20, 3)
                .HasColumnName("ural");
            entity.Property(e => e.Vsp)
                .HasPrecision(20, 3)
                .HasColumnName("vsp");
            entity.Property(e => e.Wika)
                .HasPrecision(20, 3)
                .HasColumnName("wika");
            entity.Property(e => e.Yok)
                .HasPrecision(20, 3)
                .HasColumnName("yok");
        });

        modelBuilder.Entity<MainPhone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("main_phones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abs)
                .HasPrecision(20, 3)
                .HasColumnName("abs");
            entity.Property(e => e.Cmc)
                .HasPrecision(20, 3)
                .HasColumnName("cmc");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Dkser)
                .HasPrecision(20, 3)
                .HasColumnName("dkser");
            entity.Property(e => e.Erlikid)
                .HasPrecision(20, 3)
                .HasColumnName("erlikid");
            entity.Property(e => e.Fct)
                .HasPrecision(20, 3)
                .HasColumnName("fct");
            entity.Property(e => e.Festo)
                .HasPrecision(20, 3)
                .HasColumnName("festo");
            entity.Property(e => e.Fiztech)
                .HasPrecision(20, 3)
                .HasColumnName("fiztech");
            entity.Property(e => e.Gazses)
                .HasPrecision(20, 3)
                .HasColumnName("gazses");
            entity.Property(e => e.Gibriding)
                .HasPrecision(20, 3)
                .HasColumnName("gibriding");
            entity.Property(e => e.Hamlet)
                .HasPrecision(20, 3)
                .HasColumnName("hamlet");
            entity.Property(e => e.Hcme)
                .HasPrecision(20, 3)
                .HasColumnName("hcme");
            entity.Property(e => e.Kamotsi)
                .HasPrecision(20, 3)
                .HasColumnName("kamotsi");
            entity.Property(e => e.Krass)
                .HasPrecision(20, 3)
                .HasColumnName("krass");
            entity.Property(e => e.Lindegaz)
                .HasPrecision(20, 3)
                .HasColumnName("lindegaz");
            entity.Property(e => e.ListInn)
                .HasMaxLength(1000)
                .HasColumnName("list_inn");
            entity.Property(e => e.Manometr)
                .HasPrecision(20, 3)
                .HasColumnName("manometr");
            entity.Property(e => e.Manoterm)
                .HasPrecision(20, 3)
                .HasColumnName("manoterm");
            entity.Property(e => e.Manotom)
                .HasPrecision(20, 3)
                .HasColumnName("manotom");
            entity.Property(e => e.Metallrukav)
                .HasPrecision(20, 3)
                .HasColumnName("metallrukav");
            entity.Property(e => e.Meter)
                .HasPrecision(20, 3)
                .HasColumnName("meter");
            entity.Property(e => e.Metran)
                .HasPrecision(20, 3)
                .HasColumnName("metran");
            entity.Property(e => e.Monnpo)
                .HasPrecision(20, 3)
                .HasColumnName("monnpo");
            entity.Property(e => e.Monooo)
                .HasPrecision(20, 3)
                .HasColumnName("monooo");
            entity.Property(e => e.Nps)
                .HasPrecision(20, 3)
                .HasColumnName("nps");
            entity.Property(e => e.Nta)
                .HasPrecision(20, 3)
                .HasColumnName("nta");
            entity.Property(e => e.Parker)
                .HasPrecision(20, 3)
                .HasColumnName("parker");
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .HasColumnName("phone");
            entity.Property(e => e.Rosma)
                .HasPrecision(20, 3)
                .HasColumnName("rosma");
            entity.Property(e => e.Shtauf)
                .HasPrecision(20, 3)
                .HasColumnName("shtauf");
            entity.Property(e => e.Shver)
                .HasPrecision(20, 3)
                .HasColumnName("shver");
            entity.Property(e => e.Sigm)
                .HasPrecision(20, 3)
                .HasColumnName("sigm");
            entity.Property(e => e.SourceCreate)
                .HasMaxLength(400)
                .HasColumnName("source_create");
            entity.Property(e => e.Spechcc)
                .HasPrecision(20, 3)
                .HasColumnName("spechcc");
            entity.Property(e => e.Taikan)
                .HasPrecision(20, 3)
                .HasColumnName("taikan");
            entity.Property(e => e.Tatkompl)
                .HasPrecision(20, 3)
                .HasColumnName("tatkompl");
            entity.Property(e => e.Teplokont)
                .HasPrecision(20, 3)
                .HasColumnName("teplokont");
            entity.Property(e => e.Turnover).HasColumnName("turnover");
            entity.Property(e => e.Umas)
                .HasPrecision(20, 3)
                .HasColumnName("umas");
            entity.Property(e => e.Ural)
                .HasPrecision(20, 3)
                .HasColumnName("ural");
            entity.Property(e => e.Vsp)
                .HasPrecision(20, 3)
                .HasColumnName("vsp");
            entity.Property(e => e.Wika)
                .HasPrecision(20, 3)
                .HasColumnName("wika");
            entity.Property(e => e.Yok)
                .HasPrecision(20, 3)
                .HasColumnName("yok");
        });

        modelBuilder.Entity<Minu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("minus");

            entity.HasIndex(e => e.DomainMinus, "minus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DomainMinus)
                .HasMaxLength(200)
                .HasColumnName("domain_minus");
        });

        modelBuilder.Entity<PhonesEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("phones_email");

            entity.HasIndex(e => e.Email, "emails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<PhonesInn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("phones_inn");

            entity.HasIndex(e => e.Inn, "inn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreate).HasColumnName("date_create");
            entity.Property(e => e.Inn)
                .HasMaxLength(100)
                .HasColumnName("inn");
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .HasColumnName("phone");
            entity.Property(e => e.SourceCreate)
                .HasMaxLength(400)
                .HasColumnName("source_create");
        });

        modelBuilder.Entity<Turnover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turnovers");

            entity.HasIndex(e => e.Inn, "inn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abs)
                .HasPrecision(20, 3)
                .HasColumnName("abs");
            entity.Property(e => e.Cmc)
                .HasPrecision(20, 3)
                .HasColumnName("cmc");
            entity.Property(e => e.Dkser)
                .HasPrecision(20, 3)
                .HasColumnName("dkser");
            entity.Property(e => e.Erlikid)
                .HasPrecision(20, 3)
                .HasColumnName("erlikid");
            entity.Property(e => e.Fct)
                .HasPrecision(20, 3)
                .HasColumnName("fct");
            entity.Property(e => e.Festo)
                .HasPrecision(20, 3)
                .HasColumnName("festo");
            entity.Property(e => e.Fiztech)
                .HasPrecision(20, 3)
                .HasColumnName("fiztech");
            entity.Property(e => e.Gazses)
                .HasPrecision(20, 3)
                .HasColumnName("gazses");
            entity.Property(e => e.Gibriding)
                .HasPrecision(20, 3)
                .HasColumnName("gibriding");
            entity.Property(e => e.Hamlet)
                .HasPrecision(20, 3)
                .HasColumnName("hamlet");
            entity.Property(e => e.Hcme)
                .HasPrecision(20, 3)
                .HasColumnName("hcme");
            entity.Property(e => e.Inn)
                .HasMaxLength(100)
                .HasColumnName("inn");
            entity.Property(e => e.Kamotsi)
                .HasPrecision(20, 3)
                .HasColumnName("kamotsi");
            entity.Property(e => e.Krass)
                .HasPrecision(20, 3)
                .HasColumnName("krass");
            entity.Property(e => e.Lindegaz)
                .HasPrecision(20, 3)
                .HasColumnName("lindegaz");
            entity.Property(e => e.Manometr)
                .HasPrecision(20, 3)
                .HasColumnName("manometr");
            entity.Property(e => e.Manoterm)
                .HasPrecision(20, 3)
                .HasColumnName("manoterm");
            entity.Property(e => e.Manotom)
                .HasPrecision(20, 3)
                .HasColumnName("manotom");
            entity.Property(e => e.Metallrukav)
                .HasPrecision(20, 3)
                .HasColumnName("metallrukav");
            entity.Property(e => e.Meter)
                .HasPrecision(20, 3)
                .HasColumnName("meter");
            entity.Property(e => e.Metran)
                .HasPrecision(20, 3)
                .HasColumnName("metran");
            entity.Property(e => e.Monnpo)
                .HasPrecision(20, 3)
                .HasColumnName("monnpo");
            entity.Property(e => e.Monooo)
                .HasPrecision(20, 3)
                .HasColumnName("monooo");
            entity.Property(e => e.Nps)
                .HasPrecision(20, 3)
                .HasColumnName("nps");
            entity.Property(e => e.Nta)
                .HasPrecision(20, 3)
                .HasColumnName("nta");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(300)
                .HasColumnName("organization_name");
            entity.Property(e => e.Parker)
                .HasPrecision(20, 3)
                .HasColumnName("parker");
            entity.Property(e => e.Rosma)
                .HasPrecision(20, 3)
                .HasColumnName("rosma");
            entity.Property(e => e.Shtauf)
                .HasPrecision(20, 3)
                .HasColumnName("shtauf");
            entity.Property(e => e.Shver)
                .HasPrecision(20, 3)
                .HasColumnName("shver");
            entity.Property(e => e.Sigm)
                .HasPrecision(20, 3)
                .HasColumnName("sigm");
            entity.Property(e => e.Spechcc)
                .HasPrecision(20, 3)
                .HasColumnName("spechcc");
            entity.Property(e => e.SumTurnover).HasColumnName("sum_turnover");
            entity.Property(e => e.Taikan)
                .HasPrecision(20, 3)
                .HasColumnName("taikan");
            entity.Property(e => e.Tatkompl)
                .HasPrecision(20, 3)
                .HasColumnName("tatkompl");
            entity.Property(e => e.Teplokont)
                .HasPrecision(20, 3)
                .HasColumnName("teplokont");
            entity.Property(e => e.Umas)
                .HasPrecision(20, 3)
                .HasColumnName("umas");
            entity.Property(e => e.Ural)
                .HasPrecision(20, 3)
                .HasColumnName("ural");
            entity.Property(e => e.Vsp)
                .HasPrecision(20, 3)
                .HasColumnName("vsp");
            entity.Property(e => e.Wika)
                .HasPrecision(20, 3)
                .HasColumnName("wika");
            entity.Property(e => e.Yok)
                .HasPrecision(20, 3)
                .HasColumnName("yok");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
