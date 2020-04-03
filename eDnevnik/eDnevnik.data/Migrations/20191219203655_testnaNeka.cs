using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class testnaNeka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivDrzave = table.Column<string>(nullable: true),
                    Skraćenica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivGrada = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    LoginID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.LoginID);
                });

            migrationBuilder.CreateTable(
                name: "ostaliPodaciNastavnoOsoblje",
                columns: table => new
                {
                    OstaliPodaciNastavnoOsobljeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drzavljanstvo = table.Column<string>(nullable: true),
                    Nacionalnost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ostaliPodaciNastavnoOsoblje", x => x.OstaliPodaciNastavnoOsobljeID);
                });

            migrationBuilder.CreateTable(
                name: "podaciZavrsniIspit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    OcjenaZavrsnogRada = table.Column<int>(nullable: false),
                    OcjenaZavrsnogIspita = table.Column<int>(nullable: false),
                    OcjenaOdbrane = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podaciZavrsniIspit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "porodica",
                columns: table => new
                {
                    PorodicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusPorodiceUcenika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_porodica", x => x.PorodicaID);
                });

            migrationBuilder.CreateTable(
                name: "skolskaGodina",
                columns: table => new
                {
                    SkolskaGodinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skolskaGodina", x => x.SkolskaGodinaID);
                });

            migrationBuilder.CreateTable(
                name: "strucnaSprema",
                columns: table => new
                {
                    StrucnaSpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strucnaSprema", x => x.StrucnaSpremaID);
                });

            migrationBuilder.CreateTable(
                name: "zaposlenje",
                columns: table => new
                {
                    ZaposlenjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipZaposljenja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zaposlenje", x => x.ZaposlenjeID);
                });

            migrationBuilder.CreateTable(
                name: "podaciRodjenje",
                columns: table => new
                {
                    PodaciRodjenjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    OpćinaRođenja = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podaciRodjenje", x => x.PodaciRodjenjeID);
                    table.ForeignKey(
                        name: "FK_podaciRodjenje_drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_podaciRodjenje_grad_GradID",
                        column: x => x.GradID,
                        principalTable: "grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "podaciStanovanje",
                columns: table => new
                {
                    PodaciStanovanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradID = table.Column<int>(nullable: false),
                    DrzavaID = table.Column<int>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    OpćinaPrebivalista = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podaciStanovanje", x => x.PodaciStanovanjeID);
                    table.ForeignKey(
                        name: "FK_podaciStanovanje_drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_podaciStanovanje_grad_GradID",
                        column: x => x.GradID,
                        principalTable: "grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutorizacijskiToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: true),
                    LoginId = table.Column<int>(nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorizacijskiToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutorizacijskiToken_login_LoginId",
                        column: x => x.LoginId,
                        principalTable: "login",
                        principalColumn: "LoginID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ostaliPodaci",
                columns: table => new
                {
                    OstaliPodaciID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorodicaID = table.Column<int>(nullable: false),
                    Drzavljanstvo = table.Column<string>(nullable: true),
                    Nacionalnost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ostaliPodaci", x => x.OstaliPodaciID);
                    table.ForeignKey(
                        name: "FK_ostaliPodaci_porodica_PorodicaID",
                        column: x => x.PorodicaID,
                        principalTable: "porodica",
                        principalColumn: "PorodicaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "podaciZanimanje",
                columns: table => new
                {
                    PodaciZanimanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavrsenaSkola = table.Column<string>(nullable: true),
                    ZavrsenFakultet = table.Column<string>(nullable: true),
                    ZavrsenoZanimanje = table.Column<string>(nullable: true),
                    BrojDiplome = table.Column<string>(nullable: true),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    DrzavniIspit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podaciZanimanje", x => x.PodaciZanimanjeID);
                    table.ForeignKey(
                        name: "FK_podaciZanimanje_strucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "strucnaSprema",
                        principalColumn: "StrucnaSpremaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "administrator",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Pol = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    podaciStanovanjeID = table.Column<int>(nullable: false),
                    PodaciRodjenjeID = table.Column<int>(nullable: false),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    LoginID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrator", x => x.AdministratorID);
                    table.ForeignKey(
                        name: "FK_administrator_login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "login",
                        principalColumn: "LoginID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_administrator_podaciRodjenje_PodaciRodjenjeID",
                        column: x => x.PodaciRodjenjeID,
                        principalTable: "podaciRodjenje",
                        principalColumn: "PodaciRodjenjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_administrator_strucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "strucnaSprema",
                        principalColumn: "StrucnaSpremaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_administrator_podaciStanovanje_podaciStanovanjeID",
                        column: x => x.podaciStanovanjeID,
                        principalTable: "podaciStanovanje",
                        principalColumn: "PodaciStanovanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "roditelj",
                columns: table => new
                {
                    RoditeljID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    Zanimanje = table.Column<string>(nullable: true),
                    ZaposlenjeID = table.Column<int>(nullable: false),
                    PodaciStanovanjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roditelj", x => x.RoditeljID);
                    table.ForeignKey(
                        name: "FK_roditelj_podaciStanovanje_PodaciStanovanjeID",
                        column: x => x.PodaciStanovanjeID,
                        principalTable: "podaciStanovanje",
                        principalColumn: "PodaciStanovanjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_roditelj_strucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "strucnaSprema",
                        principalColumn: "StrucnaSpremaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_roditelj_zaposlenje_ZaposlenjeID",
                        column: x => x.ZaposlenjeID,
                        principalTable: "zaposlenje",
                        principalColumn: "ZaposlenjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ucenici",
                columns: table => new
                {
                    UceniciID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Pol = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    DatumUpisa = table.Column<DateTime>(nullable: false),
                    PodaciRodjenjeID = table.Column<int>(nullable: false),
                    PodaciStanovanjeID = table.Column<int>(nullable: false),
                    OstaliPodaciID = table.Column<int>(nullable: false),
                    ZavrsniIspitID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucenici", x => x.UceniciID);
                    table.ForeignKey(
                        name: "FK_ucenici_ostaliPodaci_OstaliPodaciID",
                        column: x => x.OstaliPodaciID,
                        principalTable: "ostaliPodaci",
                        principalColumn: "OstaliPodaciID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ucenici_podaciRodjenje_PodaciRodjenjeID",
                        column: x => x.PodaciRodjenjeID,
                        principalTable: "podaciRodjenje",
                        principalColumn: "PodaciRodjenjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ucenici_podaciStanovanje_PodaciStanovanjeID",
                        column: x => x.PodaciStanovanjeID,
                        principalTable: "podaciStanovanje",
                        principalColumn: "PodaciStanovanjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ucenici_podaciZavrsniIspit_ZavrsniIspitID",
                        column: x => x.ZavrsniIspitID,
                        principalTable: "podaciZavrsniIspit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nastavnoOsoblje",
                columns: table => new
                {
                    NastavnoOsobljeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    ImeRoditelja = table.Column<string>(nullable: true),
                    Pol = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    PodaciRodjenjeID = table.Column<int>(nullable: false),
                    PodaciStanovanjeID = table.Column<int>(nullable: false),
                    OstaliPodaciNastavnoOsobljeID = table.Column<int>(nullable: false),
                    podaciZanimanjeID = table.Column<int>(nullable: false),
                    LoginID = table.Column<int>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nastavnoOsoblje", x => x.NastavnoOsobljeID);
                    table.ForeignKey(
                        name: "FK_nastavnoOsoblje_login_LoginID",
                        column: x => x.LoginID,
                        principalTable: "login",
                        principalColumn: "LoginID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nastavnoOsoblje_ostaliPodaciNastavnoOsoblje_OstaliPodaciNastavnoOsobljeID",
                        column: x => x.OstaliPodaciNastavnoOsobljeID,
                        principalTable: "ostaliPodaciNastavnoOsoblje",
                        principalColumn: "OstaliPodaciNastavnoOsobljeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_nastavnoOsoblje_podaciRodjenje_PodaciRodjenjeID",
                        column: x => x.PodaciRodjenjeID,
                        principalTable: "podaciRodjenje",
                        principalColumn: "PodaciRodjenjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_nastavnoOsoblje_podaciStanovanje_PodaciStanovanjeID",
                        column: x => x.PodaciStanovanjeID,
                        principalTable: "podaciStanovanje",
                        principalColumn: "PodaciStanovanjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_nastavnoOsoblje_podaciZanimanje_podaciZanimanjeID",
                        column: x => x.podaciZanimanjeID,
                        principalTable: "podaciZanimanje",
                        principalColumn: "PodaciZanimanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "odjeljenje",
                columns: table => new
                {
                    OdjeljenjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razred = table.Column<int>(nullable: false),
                    Oznaka = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    RazrednikID = table.Column<int>(nullable: false),
                    PredsjednikUceniciID = table.Column<int>(nullable: true),
                    BlagajnikID = table.Column<int>(nullable: false),
                    Smjena = table.Column<string>(nullable: true),
                    skolskaGodinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odjeljenje", x => x.OdjeljenjeID);
                    table.ForeignKey(
                        name: "FK_odjeljenje_ucenici_BlagajnikID",
                        column: x => x.BlagajnikID,
                        principalTable: "ucenici",
                        principalColumn: "UceniciID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_odjeljenje_ucenici_PredsjednikUceniciID",
                        column: x => x.PredsjednikUceniciID,
                        principalTable: "ucenici",
                        principalColumn: "UceniciID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_odjeljenje_nastavnoOsoblje_RazrednikID",
                        column: x => x.RazrednikID,
                        principalTable: "nastavnoOsoblje",
                        principalColumn: "NastavnoOsobljeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_odjeljenje_skolskaGodina_skolskaGodinaID",
                        column: x => x.skolskaGodinaID,
                        principalTable: "skolskaGodina",
                        principalColumn: "SkolskaGodinaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "predmeti",
                columns: table => new
                {
                    PredmetiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    PredavacID = table.Column<int>(nullable: false),
                    Razred = table.Column<string>(nullable: true),
                    Izborni = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmeti", x => x.PredmetiID);
                    table.ForeignKey(
                        name: "FK_predmeti_nastavnoOsoblje_PredavacID",
                        column: x => x.PredavacID,
                        principalTable: "nastavnoOsoblje",
                        principalColumn: "NastavnoOsobljeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "skolskeSekcije",
                columns: table => new
                {
                    SkolskeSekcijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredavaciNastavnoOsobljeID = table.Column<int>(nullable: true),
                    NazivSekcije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skolskeSekcije", x => x.SkolskeSekcijeID);
                    table.ForeignKey(
                        name: "FK_skolskeSekcije_nastavnoOsoblje_PredavaciNastavnoOsobljeID",
                        column: x => x.PredavaciNastavnoOsobljeID,
                        principalTable: "nastavnoOsoblje",
                        principalColumn: "NastavnoOsobljeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uceniciOdjeljenje",
                columns: table => new
                {
                    uceniciID = table.Column<int>(nullable: false),
                    odjeljenjeID = table.Column<int>(nullable: false),
                    BrojUDneviku = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uceniciOdjeljenje", x => new { x.odjeljenjeID, x.uceniciID });
                    table.ForeignKey(
                        name: "FK_uceniciOdjeljenje_odjeljenje_odjeljenjeID",
                        column: x => x.odjeljenjeID,
                        principalTable: "odjeljenje",
                        principalColumn: "OdjeljenjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_uceniciOdjeljenje_ucenici_uceniciID",
                        column: x => x.uceniciID,
                        principalTable: "ucenici",
                        principalColumn: "UceniciID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PredavaciPredmetiOdjeljenje",
                columns: table => new
                {
                    NastavnoOsobljeID = table.Column<int>(nullable: false),
                    PredmetiID = table.Column<int>(nullable: false),
                    odjeljenjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredavaciPredmetiOdjeljenje", x => new { x.NastavnoOsobljeID, x.PredmetiID, x.odjeljenjeID });
                    table.ForeignKey(
                        name: "FK_PredavaciPredmetiOdjeljenje_nastavnoOsoblje_NastavnoOsobljeID",
                        column: x => x.NastavnoOsobljeID,
                        principalTable: "nastavnoOsoblje",
                        principalColumn: "NastavnoOsobljeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PredavaciPredmetiOdjeljenje_predmeti_PredmetiID",
                        column: x => x.PredmetiID,
                        principalTable: "predmeti",
                        principalColumn: "PredmetiID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PredavaciPredmetiOdjeljenje_odjeljenje_odjeljenjeID",
                        column: x => x.odjeljenjeID,
                        principalTable: "odjeljenje",
                        principalColumn: "OdjeljenjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "sekcijeUcenici",
                columns: table => new
                {
                    skolskeSekcijeID = table.Column<int>(nullable: false),
                    uceniciID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sekcijeUcenici", x => new { x.skolskeSekcijeID, x.uceniciID });
                    table.ForeignKey(
                        name: "FK_sekcijeUcenici_skolskeSekcije_skolskeSekcijeID",
                        column: x => x.skolskeSekcijeID,
                        principalTable: "skolskeSekcije",
                        principalColumn: "SkolskeSekcijeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_sekcijeUcenici_ucenici_uceniciID",
                        column: x => x.uceniciID,
                        principalTable: "ucenici",
                        principalColumn: "UceniciID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "slusaPredmet",
                columns: table => new
                {
                    NastavnoOsobljeID = table.Column<int>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false),
                    UceniciID = table.Column<int>(nullable: false),
                    OdjeljenjeID = table.Column<int>(nullable: false),
                    ZaključnaOcjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slusaPredmet", x => new { x.NastavnoOsobljeID, x.PredmetID, x.OdjeljenjeID, x.UceniciID });
                    table.ForeignKey(
                        name: "FK_slusaPredmet_uceniciOdjeljenje_UceniciID_OdjeljenjeID",
                        columns: x => new { x.UceniciID, x.OdjeljenjeID },
                        principalTable: "uceniciOdjeljenje",
                        principalColumns: new[] { "odjeljenjeID", "uceniciID" },
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_slusaPredmet_PredavaciPredmetiOdjeljenje_NastavnoOsobljeID_PredmetID_OdjeljenjeID",
                        columns: x => new { x.NastavnoOsobljeID, x.PredmetID, x.OdjeljenjeID },
                        principalTable: "PredavaciPredmetiOdjeljenje",
                        principalColumns: new[] { "NastavnoOsobljeID", "PredmetiID", "odjeljenjeID" },
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrator_LoginID",
                table: "administrator",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_administrator_PodaciRodjenjeID",
                table: "administrator",
                column: "PodaciRodjenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_administrator_StrucnaSpremaID",
                table: "administrator",
                column: "StrucnaSpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_administrator_podaciStanovanjeID",
                table: "administrator",
                column: "podaciStanovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_AutorizacijskiToken_LoginId",
                table: "AutorizacijskiToken",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_nastavnoOsoblje_LoginID",
                table: "nastavnoOsoblje",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_nastavnoOsoblje_OstaliPodaciNastavnoOsobljeID",
                table: "nastavnoOsoblje",
                column: "OstaliPodaciNastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_nastavnoOsoblje_PodaciRodjenjeID",
                table: "nastavnoOsoblje",
                column: "PodaciRodjenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_nastavnoOsoblje_PodaciStanovanjeID",
                table: "nastavnoOsoblje",
                column: "PodaciStanovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_nastavnoOsoblje_podaciZanimanjeID",
                table: "nastavnoOsoblje",
                column: "podaciZanimanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_BlagajnikID",
                table: "odjeljenje",
                column: "BlagajnikID");

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_PredsjednikUceniciID",
                table: "odjeljenje",
                column: "PredsjednikUceniciID");

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_RazrednikID",
                table: "odjeljenje",
                column: "RazrednikID");

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_skolskaGodinaID",
                table: "odjeljenje",
                column: "skolskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_ostaliPodaci_PorodicaID",
                table: "ostaliPodaci",
                column: "PorodicaID");

            migrationBuilder.CreateIndex(
                name: "IX_podaciRodjenje_DrzavaID",
                table: "podaciRodjenje",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_podaciRodjenje_GradID",
                table: "podaciRodjenje",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_podaciStanovanje_DrzavaID",
                table: "podaciStanovanje",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_podaciStanovanje_GradID",
                table: "podaciStanovanje",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_podaciZanimanje_StrucnaSpremaID",
                table: "podaciZanimanje",
                column: "StrucnaSpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_PredmetiID",
                table: "PredavaciPredmetiOdjeljenje",
                column: "PredmetiID");

            migrationBuilder.CreateIndex(
                name: "IX_PredavaciPredmetiOdjeljenje_odjeljenjeID",
                table: "PredavaciPredmetiOdjeljenje",
                column: "odjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_predmeti_PredavacID",
                table: "predmeti",
                column: "PredavacID");

            migrationBuilder.CreateIndex(
                name: "IX_roditelj_PodaciStanovanjeID",
                table: "roditelj",
                column: "PodaciStanovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_roditelj_StrucnaSpremaID",
                table: "roditelj",
                column: "StrucnaSpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_roditelj_ZaposlenjeID",
                table: "roditelj",
                column: "ZaposlenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_sekcijeUcenici_uceniciID",
                table: "sekcijeUcenici",
                column: "uceniciID");

            migrationBuilder.CreateIndex(
                name: "IX_skolskeSekcije_PredavaciNastavnoOsobljeID",
                table: "skolskeSekcije",
                column: "PredavaciNastavnoOsobljeID");

            migrationBuilder.CreateIndex(
                name: "IX_slusaPredmet_UceniciID_OdjeljenjeID",
                table: "slusaPredmet",
                columns: new[] { "UceniciID", "OdjeljenjeID" });

            migrationBuilder.CreateIndex(
                name: "IX_ucenici_OstaliPodaciID",
                table: "ucenici",
                column: "OstaliPodaciID");

            migrationBuilder.CreateIndex(
                name: "IX_ucenici_PodaciRodjenjeID",
                table: "ucenici",
                column: "PodaciRodjenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ucenici_PodaciStanovanjeID",
                table: "ucenici",
                column: "PodaciStanovanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ucenici_ZavrsniIspitID",
                table: "ucenici",
                column: "ZavrsniIspitID");

            migrationBuilder.CreateIndex(
                name: "IX_uceniciOdjeljenje_uceniciID",
                table: "uceniciOdjeljenje",
                column: "uceniciID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator");

            migrationBuilder.DropTable(
                name: "AutorizacijskiToken");

            migrationBuilder.DropTable(
                name: "roditelj");

            migrationBuilder.DropTable(
                name: "sekcijeUcenici");

            migrationBuilder.DropTable(
                name: "slusaPredmet");

            migrationBuilder.DropTable(
                name: "zaposlenje");

            migrationBuilder.DropTable(
                name: "skolskeSekcije");

            migrationBuilder.DropTable(
                name: "uceniciOdjeljenje");

            migrationBuilder.DropTable(
                name: "PredavaciPredmetiOdjeljenje");

            migrationBuilder.DropTable(
                name: "predmeti");

            migrationBuilder.DropTable(
                name: "odjeljenje");

            migrationBuilder.DropTable(
                name: "ucenici");

            migrationBuilder.DropTable(
                name: "nastavnoOsoblje");

            migrationBuilder.DropTable(
                name: "skolskaGodina");

            migrationBuilder.DropTable(
                name: "ostaliPodaci");

            migrationBuilder.DropTable(
                name: "podaciZavrsniIspit");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "ostaliPodaciNastavnoOsoblje");

            migrationBuilder.DropTable(
                name: "podaciRodjenje");

            migrationBuilder.DropTable(
                name: "podaciStanovanje");

            migrationBuilder.DropTable(
                name: "podaciZanimanje");

            migrationBuilder.DropTable(
                name: "porodica");

            migrationBuilder.DropTable(
                name: "drzava");

            migrationBuilder.DropTable(
                name: "grad");

            migrationBuilder.DropTable(
                name: "strucnaSprema");
        }
    }
}
