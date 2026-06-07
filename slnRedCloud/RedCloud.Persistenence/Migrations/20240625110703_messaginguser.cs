using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedCloud.Persistenence.Migrations
{
    /// <inheritdoc />
    public partial class messaginguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessagingUsers",
                columns: table => new
                {
                    MessagingUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessagingUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessagingUserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessagingUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessagingUserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagingUsers", x => x.MessagingUserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagingUsers");
        }
    }
}
