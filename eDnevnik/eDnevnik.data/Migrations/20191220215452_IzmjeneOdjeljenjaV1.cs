using Microsoft.EntityFrameworkCore.Migrations;

namespace eDnevnik.data.Migrations
{
    public partial class IzmjeneOdjeljenjaV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikUceniciID",
                table: "odjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_odjeljenje_PredsjednikUceniciID",
                table: "odjeljenje");

            migrationBuilder.DropColumn(
                name: "PredsjednikUceniciID",
                table: "odjeljenje");

            migrationBuilder.AddColumn<string>(
                name: "ImeRoditelja",
                table: "ucenici",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PredsjednikID",
                table: "odjeljenje",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_PredsjednikID",
                table: "odjeljenje",
                column: "PredsjednikID");

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje",
                column: "PredsjednikID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikID",
                table: "odjeljenje");

            migrationBuilder.DropIndex(
                name: "IX_odjeljenje_PredsjednikID",
                table: "odjeljenje");

            migrationBuilder.DropColumn(
                name: "ImeRoditelja",
                table: "ucenici");

            migrationBuilder.DropColumn(
                name: "PredsjednikID",
                table: "odjeljenje");

            migrationBuilder.AddColumn<int>(
                name: "PredsjednikUceniciID",
                table: "odjeljenje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_odjeljenje_PredsjednikUceniciID",
                table: "odjeljenje",
                column: "PredsjednikUceniciID");

            migrationBuilder.AddForeignKey(
                name: "FK_odjeljenje_ucenici_PredsjednikUceniciID",
                table: "odjeljenje",
                column: "PredsjednikUceniciID",
                principalTable: "ucenici",
                principalColumn: "UceniciID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
