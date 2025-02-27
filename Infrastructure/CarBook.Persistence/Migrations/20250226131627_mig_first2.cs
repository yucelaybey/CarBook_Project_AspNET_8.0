using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_first2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cars_CarID1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarID1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarID1",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandID",
                table: "Cars",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandID",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarID1",
                table: "Cars",
                column: "CarID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cars_CarID1",
                table: "Cars",
                column: "CarID1",
                principalTable: "Cars",
                principalColumn: "CarID");
        }
    }
}
