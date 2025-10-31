using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ToDoLists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ToDoLists",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ToDoItems",
                newName: "Title");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ToDoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ToDoListId",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoListId",
                table: "ToDoItems",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoLists_ToDoListId",
                table: "ToDoItems",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoLists_ToDoListId",
                table: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ToDoListId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ToDoListId",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ToDoLists",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDoLists",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDoItems",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "ToDoLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
