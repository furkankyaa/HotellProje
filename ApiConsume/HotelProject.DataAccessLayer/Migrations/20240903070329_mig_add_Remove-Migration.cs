using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_RemoveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_messageCategories_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sendMessages",
                table: "sendMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_messageCategories",
                table: "messageCategories");

            migrationBuilder.RenameTable(
                name: "sendMessages",
                newName: "SendMessages");

            migrationBuilder.RenameTable(
                name: "messageCategories",
                newName: "MessageCategories");

            migrationBuilder.AddColumn<string>(
                name: "WorkDepartment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendMessages",
                table: "SendMessages",
                column: "SendMessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageCategories",
                table: "MessageCategories",
                column: "MessageCategoryID");

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    WorkLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkLocationName = table.Column<int>(type: "int", nullable: false),
                    WorkLocationCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.WorkLocationID);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID",
                principalTable: "MessageCategories",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MessageCategories_MessageCategoryID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "WorkLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendMessages",
                table: "SendMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageCategories",
                table: "MessageCategories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkDepartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "SendMessages",
                newName: "sendMessages");

            migrationBuilder.RenameTable(
                name: "MessageCategories",
                newName: "messageCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sendMessages",
                table: "sendMessages",
                column: "SendMessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messageCategories",
                table: "messageCategories",
                column: "MessageCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_messageCategories_MessageCategoryID",
                table: "Contacts",
                column: "MessageCategoryID",
                principalTable: "messageCategories",
                principalColumn: "MessageCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
