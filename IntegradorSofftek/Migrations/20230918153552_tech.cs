using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorSofftek.Migrations
{
    public partial class tech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR (100)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "VARCHAR (250)", nullable: false),
                    rol_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_rol_id",
                        column: x => x.rol_id,
                        principalTable: "Roles",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "rol_id", "rol_activo", "rol_descripcion", "rol_nombre" },
                values: new object[] { 1, true, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "rol_id", "rol_activo", "rol_descripcion", "rol_nombre" },
                values: new object[] { 2, true, "Consulta", "Consulta" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "CodUsuario", "Clave", "Dni", "Nombre", "rol_id" },
                values: new object[] { 1, "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 1234, "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rol_id",
                table: "Usuarios",
                column: "rol_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
