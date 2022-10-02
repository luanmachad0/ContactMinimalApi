using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMinimalApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingContactColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Peoples_PeopleId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Peoples",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Peoples_PeopleId",
                table: "Contacts",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Peoples_PeopleId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Peoples",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PeopleId",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Peoples_PeopleId",
                table: "Contacts",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id");
        }
    }
}
