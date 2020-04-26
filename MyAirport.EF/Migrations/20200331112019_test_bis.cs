using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC.MyAirport.EF.Migrations
{
    /// <summary>
    /// Classe gérant les migrations
    /// </summary>
    public partial class test_bis : Migration
    {
        /// <summary>
        /// Méthode en lien avec les migrations
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
        /// <summary>
        /// Méthode en lien avec les migrations
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dhc",
                table: "Vols",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
