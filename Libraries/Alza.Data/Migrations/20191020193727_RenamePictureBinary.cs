using Microsoft.EntityFrameworkCore.Migrations;

namespace Alza.Data.Migrations
{
    public partial class RenamePictureBinary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureBinaryDataModel_Picture_PictureId",
                table: "PictureBinaryDataModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PictureBinaryDataModel",
                table: "PictureBinaryDataModel");

            migrationBuilder.RenameTable(
                name: "PictureBinaryDataModel",
                newName: "PictureBinary");

            migrationBuilder.RenameIndex(
                name: "IX_PictureBinaryDataModel_PictureId",
                table: "PictureBinary",
                newName: "IX_PictureBinary_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PictureBinary",
                table: "PictureBinary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PictureBinary_Picture_PictureId",
                table: "PictureBinary",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PictureBinary_Picture_PictureId",
                table: "PictureBinary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PictureBinary",
                table: "PictureBinary");

            migrationBuilder.RenameTable(
                name: "PictureBinary",
                newName: "PictureBinaryDataModel");

            migrationBuilder.RenameIndex(
                name: "IX_PictureBinary_PictureId",
                table: "PictureBinaryDataModel",
                newName: "IX_PictureBinaryDataModel_PictureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PictureBinaryDataModel",
                table: "PictureBinaryDataModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PictureBinaryDataModel_Picture_PictureId",
                table: "PictureBinaryDataModel",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
