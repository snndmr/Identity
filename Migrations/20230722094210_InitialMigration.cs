using Microsoft.EntityFrameworkCore.Migrations;



namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("085fbdc5-6c50-4ca9-a846-71e96e7cf04b"), 21, "Valenka Wiggett", "Senior Developer" },
                    { new Guid("19a9e271-55d3-4e28-a408-90fc9bf70fb5"), 29, "Gene Kenefick", "Marketing Manager" },
                    { new Guid("4a26a426-963b-43f3-b517-8f38e39c697f"), 27, "Colleen Bosence", "Accountant III" },
                    { new Guid("88b52515-eb9e-4f1b-8915-93fd1cae7140"), 31, "Sigismundo McClarence", "Structural Engineer" },
                    { new Guid("b94bcae7-72ca-4f5a-986e-9da2c1ce3326"), 31, "Steward Blaszczynski", "Quality Control Specialist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
