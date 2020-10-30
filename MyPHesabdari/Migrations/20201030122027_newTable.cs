using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPHesabdari.Migrations
{
    public partial class newTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyUnitId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrencyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyUnits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CurrencyUnits",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "TurkLira" });

            migrationBuilder.InsertData(
                table: "CurrencyUnits",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Toman" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyUnitId",
                table: "Expenses",
                column: "CurrencyUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CurrencyUnits_CurrencyUnitId",
                table: "Expenses",
                column: "CurrencyUnitId",
                principalTable: "CurrencyUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CurrencyUnits_CurrencyUnitId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "CurrencyUnits");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CurrencyUnitId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CurrencyUnitId",
                table: "Expenses");
        }
    }
}
