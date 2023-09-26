using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofftek.Migrations
{
    public partial class tech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol_activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.CodProyecto);
                    table.ForeignKey(
                        name: "FK_Proyectos_EstadosProyecto_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "VARCHAR (250)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    CodTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodProyecto = table.Column<int>(type: "int", nullable: false),
                    CodServicio = table.Column<int>(type: "int", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.CodTrabajo);
                    table.ForeignKey(
                        name: "FK_Trabajos_Proyectos_CodProyecto",
                        column: x => x.CodProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "CodProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Servicios_CodServicio",
                        column: x => x.CodServicio,
                        principalTable: "Servicios",
                        principalColumn: "CodServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosProyecto",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Confirmado" },
                    { 3, "Terminado" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "rol_id", "rol_activo", "rol_descripcion", "rol_nombre" },
                values: new object[,]
                {
                    { 1, true, "Administrador", "Administrador" },
                    { 2, true, "Consultor", "Consultor" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "CodServicio", "Descr", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 1, "Servicio 1", true, 10000m },
                    { 2, "Servicio 2", true, 20000m }
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "CodProyecto", "Direccion", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Direccion 1", 1, "Proyecto 1" },
                    { 2, "Direccion 2", 2, "Proyecto 2" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "Clave", "Dni", "Nombre", "RolId" },
                values: new object[,]
                {
                    { 1, "cb096c1ca77084ae25d67db3826eba376c48cf53aa308e30ccf52179628f88e8", 1234, "admin", 1 },
                    { 2, "1a46b1050c114b9b93e9b47547b1316c7ae52b233591ffc3a5c0c2030e9d78a7", 12345, "consultor", 2 }
                });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "CantHoras", "CodProyecto", "CodServicio", "fecha", "ValorHora" },
                values: new object[] { 1, 10, 1, 1, new DateTime(2023, 9, 26, 12, 44, 30, 231, DateTimeKind.Local).AddTicks(3601), 10000m });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "CodTrabajo", "CantHoras", "CodProyecto", "CodServicio", "fecha", "ValorHora" },
                values: new object[] { 2, 20, 2, 2, new DateTime(2023, 9, 26, 12, 44, 30, 231, DateTimeKind.Local).AddTicks(3612), 20000m });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_EstadoId",
                table: "Proyectos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_CodProyecto",
                table: "Trabajos",
                column: "CodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_CodServicio",
                table: "Trabajos",
                column: "CodServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "EstadosProyecto");
        }
    }
}
