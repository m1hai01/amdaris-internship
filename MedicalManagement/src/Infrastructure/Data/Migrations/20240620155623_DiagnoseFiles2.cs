using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DiagnoseFiles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisFile_Diagnoses_DiagnoseId",
                table: "DiagnosisFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosisFile",
                table: "DiagnosisFile");

            migrationBuilder.RenameTable(
                name: "DiagnosisFile",
                newName: "DiagnosisFiles");

            migrationBuilder.RenameIndex(
                name: "IX_DiagnosisFile_DiagnoseId",
                table: "DiagnosisFiles",
                newName: "IX_DiagnosisFiles_DiagnoseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiagnoseId",
                table: "DiagnosisFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosisFiles",
                table: "DiagnosisFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisFiles_Diagnoses_DiagnoseId",
                table: "DiagnosisFiles",
                column: "DiagnoseId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisFiles_Diagnoses_DiagnoseId",
                table: "DiagnosisFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosisFiles",
                table: "DiagnosisFiles");

            migrationBuilder.RenameTable(
                name: "DiagnosisFiles",
                newName: "DiagnosisFile");

            migrationBuilder.RenameIndex(
                name: "IX_DiagnosisFiles_DiagnoseId",
                table: "DiagnosisFile",
                newName: "IX_DiagnosisFile_DiagnoseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiagnoseId",
                table: "DiagnosisFile",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosisFile",
                table: "DiagnosisFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisFile_Diagnoses_DiagnoseId",
                table: "DiagnosisFile",
                column: "DiagnoseId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }
    }
}
