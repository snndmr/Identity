using Microsoft.EntityFrameworkCore.Migrations;



namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class InsertedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "755bda54-3bc8-48aa-8e58-4e5101b79023", "f8f43229-5d80-4ee9-8811-c48905bf854c", "Guest", "GUEST" },
                    { "e26b6e41-5e97-4cda-9fdd-a58782e14a69", "700c804c-df71-4323-b446-10926703d60b", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "755bda54-3bc8-48aa-8e58-4e5101b79023");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e26b6e41-5e97-4cda-9fdd-a58782e14a69");
        }
    }
}
