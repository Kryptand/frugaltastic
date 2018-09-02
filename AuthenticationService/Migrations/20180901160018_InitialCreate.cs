using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthenticationCredentials",
                columns: table => new
                {
                    AuthenticationGuid = table.Column<Guid>(nullable: false),
                    UserIdentification = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationCredentials", x => x.AuthenticationGuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ApplicationUserGuid = table.Column<Guid>(nullable: false),
                    AuthenticationModelGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ApplicationUserGuid);
                    table.ForeignKey(
                        name: "FK_Users_AuthenticationCredentials_AuthenticationModelGuid",
                        column: x => x.AuthenticationModelGuid,
                        principalTable: "AuthenticationCredentials",
                        principalColumn: "AuthenticationGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthenticationModelGuid",
                table: "Users",
                column: "AuthenticationModelGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuthenticationCredentials");
        }
    }
}
