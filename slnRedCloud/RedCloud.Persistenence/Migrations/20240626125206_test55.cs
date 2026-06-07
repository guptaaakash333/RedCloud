using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedCloud.Persistenence.Migrations
{
    /// <inheritdoc />
    public partial class test55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignCreditDetailsVM",
                columns: table => new
                {
                    GetRateAssignCreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InboundSMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundSMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InboundMMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutboundMMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignCreditDetailsVM", x => x.GetRateAssignCreditId);
                });

            migrationBuilder.CreateTable(
                name: "GetAllAssignCredit",
                columns: table => new
                {
                    RateAssignCreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GetAllAssignCreditName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GetAllAssignCreditTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetAllAssignCredit", x => x.RateAssignCreditId);
                });

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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                name: "AssignCreditDetailsVM");

            migrationBuilder.DropTable(
                name: "GetAllAssignCredit");

            migrationBuilder.DropTable(
                name: "MessagingUsers");
        }
    }
}
