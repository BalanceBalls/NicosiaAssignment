using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicosiaAssingment.DataAccess.Migrations
{
    public partial class FixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ApproverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TargetSectionId",
                table: "Messages");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ApproverId",
                table: "Messages",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TargetSectionId",
                table: "Messages",
                column: "TargetSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_ApproverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_TargetSectionId",
                table: "Messages");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ApproverId",
                table: "Messages",
                column: "ApproverId",
                unique: true,
                filter: "[ApproverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TargetSectionId",
                table: "Messages",
                column: "TargetSectionId",
                unique: true);
        }
    }
}
