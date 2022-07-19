using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAdmin.Migrations
{
    public partial class _0002m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatTipoDevoluciones",
                columns: table => new
                {
                    IdTipoDevolucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDevolucionDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoDevoluciones", x => x.IdTipoDevolucion);
                });

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatTipoDevoluciones");

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
