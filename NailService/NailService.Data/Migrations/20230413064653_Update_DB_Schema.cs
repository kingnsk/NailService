using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NailService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_DB_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfWork_Clients_ClientId",
                table: "TypeOfWork");

            migrationBuilder.DropIndex(
                name: "IX_TypeOfWork_ClientId",
                table: "TypeOfWork");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TypeOfWork_ClientId",
                table: "TypeOfWork",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfWork_Clients_ClientId",
                table: "TypeOfWork",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
