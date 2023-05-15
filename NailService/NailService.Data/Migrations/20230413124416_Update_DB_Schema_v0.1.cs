using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NailService.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update_DB_Schema_v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeOfSubService",
                table: "TypeOfWork",
                newName: "SubService");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubService",
                table: "TypeOfWork",
                newName: "TypeOfSubService");
        }
    }
}
