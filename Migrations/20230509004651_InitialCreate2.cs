using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_PokemonOwners_PokemonOwnerPokemonId_PokemonOwnerOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropIndex(
                name: "IX_PokemonOwners_PokemonOwnerPokemonId_PokemonOwnerOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropColumn(
                name: "PokemonOwnerOwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropColumn(
                name: "PokemonOwnerPokemonId",
                table: "PokemonOwners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonOwnerOwnerId",
                table: "PokemonOwners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonOwnerPokemonId",
                table: "PokemonOwners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwners_PokemonOwnerPokemonId_PokemonOwnerOwnerId",
                table: "PokemonOwners",
                columns: new[] { "PokemonOwnerPokemonId", "PokemonOwnerOwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_PokemonOwners_PokemonOwnerPokemonId_PokemonOwnerOwnerId",
                table: "PokemonOwners",
                columns: new[] { "PokemonOwnerPokemonId", "PokemonOwnerOwnerId" },
                principalTable: "PokemonOwners",
                principalColumns: new[] { "PokemonId", "OwnerId" });
        }
    }
}
