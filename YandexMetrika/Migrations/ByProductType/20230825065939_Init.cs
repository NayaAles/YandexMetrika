using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YandexMetrika.Migrations.ByProductType
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "domain_turnover",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    domain_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_second_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    list_inn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nta = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fct = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    wika = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hamlet = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    dkser = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hcme = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gazses = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    taikan = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    parker = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    vsp = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shver = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shtauf = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    tatkompl = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    yok = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metran = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    teplokont = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monnpo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monooo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    ural = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    nps = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gibriding = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    kamotsi = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    cmc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    festo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    rosma = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    umas = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    meter = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fiztech = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manotom = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manoterm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manometr = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metallrukav = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    spechcc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    krass = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sigm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    abs = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    lindegaz = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    erlikid = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    turnover = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_create = table.Column<DateOnly>(type: "date", nullable: true),
                    source_create = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "inn_domain",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    inn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_second_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "main",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_second_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    list_inn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nta = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fct = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    wika = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hamlet = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    dkser = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hcme = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gazses = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    taikan = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    parker = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    vsp = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shver = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shtauf = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    tatkompl = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    yok = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metran = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    teplokont = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monnpo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monooo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    ural = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    nps = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gibriding = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    kamotsi = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    cmc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    festo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    rosma = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    umas = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    meter = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fiztech = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manotom = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manoterm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manometr = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metallrukav = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    spechcc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    krass = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sigm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    abs = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    lindegaz = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    erlikid = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    turnover = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    date_create = table.Column<DateOnly>(type: "date", nullable: true),
                    source_create = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "main_emails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain_second_corp = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    list_inn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nta = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fct = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    wika = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hamlet = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    dkser = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hcme = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gazses = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    taikan = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    parker = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    vsp = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shver = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shtauf = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    tatkompl = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    yok = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metran = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    teplokont = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monnpo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monooo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    ural = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    nps = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gibriding = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    kamotsi = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    cmc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    festo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    rosma = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    umas = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    meter = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fiztech = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manotom = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manoterm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manometr = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metallrukav = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    spechcc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    krass = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sigm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    abs = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    lindegaz = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    erlikid = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    turnover = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    date_create = table.Column<DateOnly>(type: "date", nullable: true),
                    source_create = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "main_phones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    phone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    list_inn = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nta = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fct = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    wika = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hamlet = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    dkser = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hcme = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gazses = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    taikan = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    parker = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    vsp = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shver = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shtauf = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    tatkompl = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    yok = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metran = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    teplokont = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monnpo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monooo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    ural = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    nps = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gibriding = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    kamotsi = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    cmc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    festo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    rosma = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    umas = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    meter = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fiztech = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manotom = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manoterm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manometr = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metallrukav = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    spechcc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    krass = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sigm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    abs = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    lindegaz = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    erlikid = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    turnover = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    date_create = table.Column<DateOnly>(type: "date", nullable: true),
                    source_create = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "minus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    domain_minus = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "phones_email",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "phones_inn",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    inn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_create = table.Column<DateOnly>(type: "date", nullable: true),
                    source_create = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "turnovers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    inn = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    organization_name = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nta = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fct = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    wika = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hamlet = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    dkser = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    hcme = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gazses = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    taikan = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    parker = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    vsp = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shver = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    shtauf = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    tatkompl = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    yok = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metran = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    teplokont = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monnpo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    monooo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    ural = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    nps = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    gibriding = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    kamotsi = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    cmc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    festo = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    rosma = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    umas = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    meter = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    fiztech = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manotom = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manoterm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    manometr = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    metallrukav = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    spechcc = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    krass = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sigm = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    abs = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    lindegaz = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    erlikid = table.Column<decimal>(type: "decimal(20,3)", precision: 20, scale: 3, nullable: true),
                    sum_turnover = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "domain_corp",
                table: "domain_turnover",
                column: "domain_corp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "domain_sec",
                table: "domain_turnover",
                column: "domain_second_corp");

            migrationBuilder.CreateIndex(
                name: "email",
                table: "emails",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "domains",
                table: "inn_domain",
                columns: new[] { "domain_corp", "domain_second_corp" });

            migrationBuilder.CreateIndex(
                name: "inn",
                table: "inn_domain",
                column: "inn");

            migrationBuilder.CreateIndex(
                name: "domain",
                table: "main",
                column: "domain_corp");

            migrationBuilder.CreateIndex(
                name: "email1",
                table: "main",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "email2",
                table: "main_emails",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "minus",
                table: "minus",
                column: "domain_minus");

            migrationBuilder.CreateIndex(
                name: "emails",
                table: "phones_email",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "inn1",
                table: "phones_inn",
                column: "inn");

            migrationBuilder.CreateIndex(
                name: "inn2",
                table: "turnovers",
                column: "inn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "domain_turnover");

            migrationBuilder.DropTable(
                name: "emails");

            migrationBuilder.DropTable(
                name: "inn_domain");

            migrationBuilder.DropTable(
                name: "main");

            migrationBuilder.DropTable(
                name: "main_emails");

            migrationBuilder.DropTable(
                name: "main_phones");

            migrationBuilder.DropTable(
                name: "minus");

            migrationBuilder.DropTable(
                name: "phones_email");

            migrationBuilder.DropTable(
                name: "phones_inn");

            migrationBuilder.DropTable(
                name: "turnovers");
        }
    }
}
