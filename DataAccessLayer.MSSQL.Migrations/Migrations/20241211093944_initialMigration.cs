using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.MSSQL.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingRecords_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accountUsers",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountUsers", x => new { x.AccountId, x.UserId });
                    table.ForeignKey(
                        name: "FK_accountUsers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_accountUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecordFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordFields_TrainingRecords_RecordID",
                        column: x => x.RecordID,
                        principalTable: "TrainingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Salt", "UserName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "c8f03cbe8b4d321c601a18b2a46ee83ccf7ac684e8768c6a46648cb45a8ec504", "a3bcd4f1e6b1c2d4", "john_doe123" },
                    { 2, "jane.smith@example.com", "9efcbedb2b6328e3384b207e49cd42428c77ad8f4b34c637d3b8bfa91fc4f76e", "f4ac0a5bda6723b8", "jane_smith456" },
                    { 3, "charlie.brown@example.com", "02bbf3c177953e24b5a49848b1bb7794b225225226f5acb628ed5e7a564264cb", "d1e5f4c9b3a7e9c2", "charlie_brown789" },
                    { 4, "alice.wonder@example.com", "4d7505d99f81fcb6b4f56b9350b47e03354b859fd4ea6b92c9a1b0e602f7c72f", "ab2f8b79a3b5c1d2", "alice_wonder123" },
                    { 5, "bob.builder@example.com", "f0533b863a32d8c7c7e213869874f3ab25f436ae77c3da522dc11e619e4bb92b", "2c6f8b9a7f3d2e19", "bob_builder567" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.InsertData(
                table: "TrainingRecords",
                columns: new[] { "Id", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecordFields",
                columns: new[] { "Id", "Description", "Name", "RecordID" },
                values: new object[,]
                {
                    { 1, "Description for Record 1", "Record 1 Name", 1 },
                    { 2, "Description for Record 2", "Record 2 Name", 2 },
                    { 3, "Description for Record 3", "Record 3 Name", 2 },
                    { 4, "Description for Record 4", "Record 4 Name", 3 },
                    { 5, "Description for Record 5", "Record 5 Name", 4 },
                    { 6, "Description for Record 6", "Record 6 Name", 4 }
                });

            migrationBuilder.InsertData(
                table: "accountUsers",
                columns: new[] { "AccountId", "UserId", "Id" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 1, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountUsers_UserId",
                table: "accountUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordFields_RecordID",
                table: "RecordFields",
                column: "RecordID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingRecords_OwnerId",
                table: "TrainingRecords",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountUsers");

            migrationBuilder.DropTable(
                name: "RecordFields");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TrainingRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
