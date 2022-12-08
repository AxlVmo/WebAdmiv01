using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAdmin.Migrations
{
    public partial class m002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreUsuarioCompra",
                table: "TblCompras");

            migrationBuilder.AlterColumn<string>(
                name: "FolioCompra",
                table: "TblCompras",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "CompraDesc",
                table: "TblCompras",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "CaTipotLicencias",
                keyColumn: "IdTipoLicencia",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCaracteristicaMovimientos",
                keyColumn: "IdCaracteristicaMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCaracteristicaMovimientos",
                keyColumn: "IdCaracteristicaMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 12,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatSubTipoMovimientos",
                keyColumn: "IdSubTipoMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatSubTipoMovimientos",
                keyColumn: "IdSubTipoMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCompras",
                keyColumn: "IdTipoCompra",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCompras",
                keyColumn: "IdTipoCompra",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoMovimientos",
                keyColumn: "IdTipoMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoMovimientos",
                keyColumn: "IdTipoMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoRecursos",
                keyColumn: "IdTipoRecurso",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoRecursos",
                keyColumn: "IdTipoRecurso",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoVentas",
                keyColumn: "IdTipoVenta",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoVentas",
                keyColumn: "IdTipoVenta",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FolioCompra",
                table: "TblCompras",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompraDesc",
                table: "TblCompras",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NombreUsuarioCompra",
                table: "TblCompras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CaTipotLicencias",
                keyColumn: "IdTipoLicencia",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCaracteristicaMovimientos",
                keyColumn: "IdCaracteristicaMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCaracteristicaMovimientos",
                keyColumn: "IdCaracteristicaMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 9,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 10,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 11,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatMeses",
                keyColumn: "IdMes",
                keyValue: 12,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatSubTipoMovimientos",
                keyColumn: "IdSubTipoMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatSubTipoMovimientos",
                keyColumn: "IdSubTipoMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCompras",
                keyColumn: "IdTipoCompra",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCompras",
                keyColumn: "IdTipoCompra",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoMovimientos",
                keyColumn: "IdTipoMovimiento",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoMovimientos",
                keyColumn: "IdTipoMovimiento",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPresupuestos",
                keyColumn: "IdTipoPresupuesto",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoRecursos",
                keyColumn: "IdTipoRecurso",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoRecursos",
                keyColumn: "IdTipoRecurso",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoVentas",
                keyColumn: "IdTipoVenta",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoVentas",
                keyColumn: "IdTipoVenta",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
