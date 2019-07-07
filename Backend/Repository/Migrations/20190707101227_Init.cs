using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    CDepartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NDepartamento = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Departamento_pk", x => x.CDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDNI = table.Column<long>(nullable: false),
                    NUsuario = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    NumTelefono = table.Column<long>(nullable: false),
                    usuario = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    pswd = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Cdistrito = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Usuario_pk", x => x.CUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CCiudad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NCiudad = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ciudad_pk", x => x.CCiudad);
                    table.ForeignKey(
                        name: "Ciudad_Departamento",
                        column: x => x.CDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "CDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    CJugador = table.Column<int>(nullable: false),
                    TDireccion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Jugador_pk", x => x.CJugador);
                    table.ForeignKey(
                        name: "Jugador_Usuario",
                        column: x => x.CJugador,
                        principalTable: "Usuario",
                        principalColumn: "CUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    CPropietario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Propietario_pk", x => x.CPropietario);
                    table.ForeignKey(
                        name: "Propietario_Usuario",
                        column: x => x.CPropietario,
                        principalTable: "Usuario",
                        principalColumn: "CUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    CDistrito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NDistrito = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CCiudad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Distrito_pk", x => x.CDistrito);
                    table.ForeignKey(
                        name: "Distrito_Ciudad",
                        column: x => x.CCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "CCiudad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calle",
                columns: table => new
                {
                    CCalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NCalle = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CDistrito = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Calle_pk", x => x.CCalle);
                    table.ForeignKey(
                        name: "Calle_Distrito",
                        column: x => x.CDistrito,
                        principalTable: "Distrito",
                        principalColumn: "CDistrito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    CEquipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NEquipo = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TDescripcion = table.Column<string>(type: "text", nullable: false),
                    NumParticipantes = table.Column<int>(nullable: false),
                    DFechaJuego = table.Column<DateTime>(type: "date", nullable: false),
                    CDistrito = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Equipo_pk", x => x.CEquipo);
                    table.ForeignKey(
                        name: "Equipo_Distrito",
                        column: x => x.CDistrito,
                        principalTable: "Distrito",
                        principalColumn: "CDistrito",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cancha",
                columns: table => new
                {
                    CCancha = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPropietario = table.Column<int>(nullable: false),
                    CCalle = table.Column<int>(nullable: false),
                    NCancha = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TDireccion = table.Column<string>(type: "text", nullable: false),
                    MPrecioHora = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cancha_pk", x => x.CCancha);
                    table.ForeignKey(
                        name: "Cancha_Calle",
                        column: x => x.CCalle,
                        principalTable: "Calle",
                        principalColumn: "CCalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Cancha_Propietario",
                        column: x => x.CPropietario,
                        principalTable: "Propietario",
                        principalColumn: "CPropietario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    CParticipante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CJugador = table.Column<int>(nullable: false),
                    CEquipo = table.Column<int>(nullable: false),
                    FEsAdministrador = table.Column<bool>(nullable: false),
                    DFechaUnion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Participante_pk", x => x.CParticipante);
                    table.ForeignKey(
                        name: "Usuario_Equipo_Equipo",
                        column: x => x.CEquipo,
                        principalTable: "Equipo",
                        principalColumn: "CEquipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Jugador_Equipo_Jugador",
                        column: x => x.CJugador,
                        principalTable: "Jugador",
                        principalColumn: "CJugador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    CAlquiler = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CEquipo = table.Column<int>(nullable: false),
                    CCancha = table.Column<int>(nullable: false),
                    DFechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DFechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumHoras = table.Column<int>(nullable: false),
                    MDescuento = table.Column<decimal>(type: "money", nullable: false),
                    MTotal = table.Column<decimal>(type: "money", nullable: false),
                    FPagado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Alquiler_pk", x => x.CAlquiler);
                    table.ForeignKey(
                        name: "Alquiler_Cancha",
                        column: x => x.CCancha,
                        principalTable: "Cancha",
                        principalColumn: "CCancha",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Alquiler_Equipo",
                        column: x => x.CEquipo,
                        principalTable: "Equipo",
                        principalColumn: "CEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleParticipante",
                columns: table => new
                {
                    CDetalleParticipante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CAlquiler = table.Column<int>(nullable: false),
                    CParticipante = table.Column<int>(nullable: false),
                    MCuota = table.Column<decimal>(type: "money", nullable: false),
                    FPartePagada = table.Column<bool>(nullable: false),
                    NCupos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DetalleParticipante_pk", x => x.CDetalleParticipante);
                    table.ForeignKey(
                        name: "Alquiler_Jugador_Equipo_Alquiler",
                        column: x => x.CAlquiler,
                        principalTable: "Alquiler",
                        principalColumn: "CAlquiler",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Alquiler_Jugador_Equipo_Participante",
                        column: x => x.CParticipante,
                        principalTable: "Participante",
                        principalColumn: "CParticipante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_CCancha",
                table: "Alquiler",
                column: "CCancha");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_CEquipo",
                table: "Alquiler",
                column: "CEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Calle_CDistrito",
                table: "Calle",
                column: "CDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_CCalle",
                table: "Cancha",
                column: "CCalle");

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_CPropietario",
                table: "Cancha",
                column: "CPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_CDepartamento",
                table: "Ciudad",
                column: "CDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleParticipante_CAlquiler",
                table: "DetalleParticipante",
                column: "CAlquiler");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleParticipante_CParticipante",
                table: "DetalleParticipante",
                column: "CParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_CCiudad",
                table: "Distrito",
                column: "CCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_CDistrito",
                table: "Equipo",
                column: "CDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_CEquipo",
                table: "Participante",
                column: "CEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_CJugador",
                table: "Participante",
                column: "CJugador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleParticipante");

            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Calle");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
