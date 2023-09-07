using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminUsers.Migrations
{
    public partial class primeramigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    idUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    idUsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idDepartamentoid = table.Column<int>(type: "int", nullable: true),
                    idCargoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_cargos_idCargoid",
                        column: x => x.idCargoid,
                        principalTable: "cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_users_departamentos_idDepartamentoid",
                        column: x => x.idDepartamentoid,
                        principalTable: "departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_idCargoid",
                table: "users",
                column: "idCargoid");

            migrationBuilder.CreateIndex(
                name: "IX_users_idDepartamentoid",
                table: "users",
                column: "idDepartamentoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "departamentos");
        }
    }
}
