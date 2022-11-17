using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products VALUES('Super mario world', 'Videojuego super mario world para super nintendo', 8, 'Juguetelandia', 750)");
            migrationBuilder.Sql("INSERT INTO Products VALUES('Ricochet Tyco r/c', 'Carro a control remoto Tyco', 8, 'Juguetes del norte', 500)");
            migrationBuilder.Sql("INSERT INTO Products VALUES('Halo master chief', 'Figura de accion Halo master chief', 8, 'Juguetes del norte', 300)");
            migrationBuilder.Sql("INSERT INTO Products VALUES('Hot Wheels auto', 'Auto Hot Wheels 1 pz', 8, 'Jugueterama', 25)");
            migrationBuilder.Sql("INSERT INTO Products VALUES('Matchbox 5paq', 'Surtido 5 paq autos matchbox', 8, 'Jugueterama', 139)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
