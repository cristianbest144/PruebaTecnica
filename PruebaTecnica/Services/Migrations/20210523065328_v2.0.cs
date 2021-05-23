using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PermitType",
                table: "Permit",
                newName: "IdPermitType");

            migrationBuilder.CreateIndex(
                name: "IX_Permit_IdPermitType",
                table: "Permit",
                column: "IdPermitType");

            migrationBuilder.AddForeignKey(
                name: "FK_Permit_PermitType_IdPermitType",
                table: "Permit",
                column: "IdPermitType",
                principalTable: "PermitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permit_PermitType_IdPermitType",
                table: "Permit");

            migrationBuilder.DropIndex(
                name: "IX_Permit_IdPermitType",
                table: "Permit");

            migrationBuilder.RenameColumn(
                name: "IdPermitType",
                table: "Permit",
                newName: "PermitType");
        }
    }
}
