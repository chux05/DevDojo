using Microsoft.EntityFrameworkCore.Migrations;

namespace DevDojo.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Walk dog", "Backlog" },
                    { 2, "Gym", "Todo" },
                    { 3, "Paint", "Doing" },
                    { 4, "Run Marathon", "Done" },
                    { 5, "Walk cat", "Backlog" },
                    { 6, "Code", "Backlog" },
                    { 7, "Send grandma email", "Todo" },
                    { 8, "Make Tea", "Backlog" },
                    { 9, "fix plug", "Doing" },
                    { 10, "Buy gift", "Backlog" },
                    { 11, "Iron Clothes", "Doing" },
                    { 12, "Get groceries", "Done" },
                    { 13, "Get ready for party", "Todo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
