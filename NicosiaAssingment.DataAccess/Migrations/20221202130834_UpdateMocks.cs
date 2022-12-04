using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicosiaAssingment.DataAccess.Migrations
{
    public partial class UpdateMocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PwdHash",
                value: "c60217d999b4f9d57a00826a6c0f05e0cdb7601e9d80805512d631177189b736");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PwdHash",
                value: "5c009a36dcda289141dd3558f65d573a1452f5401f7c8e7ce728773d489d2790");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PwdHash",
                value: "e2714127da7a68b22a3214a6a10c3f58901254ff339be87dbb84687581e6ba0d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PwdHash",
                value: "301f402e5a2795f6b87a5eacd0be62fe8d0546a9d0f16f30fe5a0861125ea11d");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PwdHash",
                value: "0a4669a4ad54e010b0f574b691de1efdfcfee372e0048ab28ae04b202ca09ad5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PwdHash",
                value: "18138372fad4b94533cd4881f03dc6c69296dd897234e0cee83f727e2e6b1f63");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PwdHash",
                value: "54d5cb2d332dbdb4850293caae4559ce88b65163f1ea5d4e4b3ac49d772ded14");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PwdHash",
                value: "0d81684688d4057da4d9f6df64b28154b68afc2f1946a756302613c92fdd4986");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PwdHash",
                value: "1ec9baf4b0382c4a7eecb19c0d3dc53dd90964f38023fc273fb25829da7024d0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PwdHash",
                value: "95d8c859da2bf9c77e775a3e15221028863e13fc5280c6dc3b8c46d2ed32e13c");
        }
    }
}
