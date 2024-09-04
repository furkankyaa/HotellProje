using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_appuser_country_gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
