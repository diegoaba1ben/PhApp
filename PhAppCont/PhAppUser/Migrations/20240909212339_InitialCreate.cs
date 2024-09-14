using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhAppUser.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EsRepresentanteLegal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Apellido1 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdenTributaria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EntSalud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjProf = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepLegales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlcaldiaEmisora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepLegales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepLegales_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    EstadoActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permisos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarios", x => new { x.UsuarioId, x.CargoId });
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuarioPermiso",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "int", nullable: false),
                    PerfilesUsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilesCargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarioPermiso", x => new { x.PermisosId, x.PerfilesUsuarioId, x.PerfilesCargoId });
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioPermiso_PerfilUsuarios_PerfilesUsuarioId_PerfilesCargoId",
                        columns: x => new { x.PerfilesUsuarioId, x.PerfilesCargoId },
                        principalTable: "PerfilUsuarios",
                        principalColumns: new[] { "UsuarioId", "CargoId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarioPermiso_Permisos_PermisosId",
                        column: x => x.PermisosId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarioPermiso_PerfilesUsuarioId_PerfilesCargoId",
                table: "PerfilUsuarioPermiso",
                columns: new[] { "PerfilesUsuarioId", "PerfilesCargoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_CargoId",
                table: "PerfilUsuarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_CategoriaId",
                table: "Permisos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RepLegales_CargoId",
                table: "RepLegales",
                column: "CargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuarioPermiso");

            migrationBuilder.DropTable(
                name: "RepLegales");

            migrationBuilder.DropTable(
                name: "PerfilUsuarios");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
