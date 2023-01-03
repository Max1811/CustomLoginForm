using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginForm.DataAccess.Migrations
{
    public partial class AddOrderedAlternatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Alternatives");

            migrationBuilder.AddColumn<bool>(
                name: "IsVoted",
                table: "VotingResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderedAlternatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    VotingResultId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedAlternatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedAlternatives_VotingResults_VotingResultId",
                        column: x => x.VotingResultId,
                        principalTable: "VotingResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedAlternatives_VotingResultId",
                table: "OrderedAlternatives",
                column: "VotingResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedAlternatives");

            migrationBuilder.DropColumn(
                name: "IsVoted",
                table: "VotingResults");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Alternatives",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
