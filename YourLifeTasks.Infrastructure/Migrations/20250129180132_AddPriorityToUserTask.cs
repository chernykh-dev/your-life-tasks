using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourLifeTasks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriorityToUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "priority",
                table: "user_tasks",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priority",
                table: "user_tasks");
        }
    }
}
