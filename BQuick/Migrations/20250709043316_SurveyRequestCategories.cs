using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class SurveyRequestCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategorySurveyRequest_SurveyCategories_SurveyCategoriesSurveyCategoryID",
                table: "SurveyCategorySurveyRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyCategorySurveyRequest_SurveyRequests_SurveyRequestsSurveyRequestID",
                table: "SurveyCategorySurveyRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyCategorySurveyRequest",
                table: "SurveyCategorySurveyRequest");

            migrationBuilder.RenameTable(
                name: "SurveyCategorySurveyRequest",
                newName: "SurveyRequestCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyCategorySurveyRequest_SurveyRequestsSurveyRequestID",
                table: "SurveyRequestCategories",
                newName: "IX_SurveyRequestCategories_SurveyRequestsSurveyRequestID");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                table: "RFQ_Items",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyRequestCategories",
                table: "SurveyRequestCategories",
                columns: new[] { "SurveyCategoriesSurveyCategoryID", "SurveyRequestsSurveyRequestID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyRequestCategories_SurveyCategories_SurveyCategoriesSurveyCategoryID",
                table: "SurveyRequestCategories",
                column: "SurveyCategoriesSurveyCategoryID",
                principalTable: "SurveyCategories",
                principalColumn: "SurveyCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyRequestCategories_SurveyRequests_SurveyRequestsSurveyRequestID",
                table: "SurveyRequestCategories",
                column: "SurveyRequestsSurveyRequestID",
                principalTable: "SurveyRequests",
                principalColumn: "SurveyRequestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyRequestCategories_SurveyCategories_SurveyCategoriesSurveyCategoryID",
                table: "SurveyRequestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyRequestCategories_SurveyRequests_SurveyRequestsSurveyRequestID",
                table: "SurveyRequestCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyRequestCategories",
                table: "SurveyRequestCategories");

            migrationBuilder.RenameTable(
                name: "SurveyRequestCategories",
                newName: "SurveyCategorySurveyRequest");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyRequestCategories_SurveyRequestsSurveyRequestID",
                table: "SurveyCategorySurveyRequest",
                newName: "IX_SurveyCategorySurveyRequest_SurveyRequestsSurveyRequestID");

            migrationBuilder.AlterColumn<string>(
                name: "UoM",
                table: "RFQ_Items",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyCategorySurveyRequest",
                table: "SurveyCategorySurveyRequest",
                columns: new[] { "SurveyCategoriesSurveyCategoryID", "SurveyRequestsSurveyRequestID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyCategorySurveyRequest_SurveyCategories_SurveyCategoriesSurveyCategoryID",
                table: "SurveyCategorySurveyRequest",
                column: "SurveyCategoriesSurveyCategoryID",
                principalTable: "SurveyCategories",
                principalColumn: "SurveyCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyCategorySurveyRequest_SurveyRequests_SurveyRequestsSurveyRequestID",
                table: "SurveyCategorySurveyRequest",
                column: "SurveyRequestsSurveyRequestID",
                principalTable: "SurveyRequests",
                principalColumn: "SurveyRequestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
