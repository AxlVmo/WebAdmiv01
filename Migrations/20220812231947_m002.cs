using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAdmin.Migrations
{
    public partial class m002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdRol",
                table: "TblAlumnos",
                newName: "IdNivelEscolar");

            migrationBuilder.RenameColumn(
                name: "IdPerfil",
                table: "TblAlumnos",
                newName: "IdGenero");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "TblAlumnos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "TblAlumnos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlumnoCurp",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlumnoGrupoSanguineo",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaternoTutor",
                table: "TblAlumnos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoPaternoTutor",
                table: "TblAlumnos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "TblAlumnos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdColonia",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalidadMunicipio",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreTutor",
                table: "TblAlumnos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoTutor",
                table: "TblAlumnos",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CaTipotLicencias",
                keyColumn: "IdTipoLicencia",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlumnoCurp",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "AlumnoGrupoSanguineo",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "ApellidoMaternoTutor",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "ApellidoPaternoTutor",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "IdColonia",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "LocalidadMunicipio",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "NombreTutor",
                table: "TblAlumnos");

            migrationBuilder.DropColumn(
                name: "TelefonoTutor",
                table: "TblAlumnos");

            migrationBuilder.RenameColumn(
                name: "IdNivelEscolar",
                table: "TblAlumnos",
                newName: "IdRol");

            migrationBuilder.RenameColumn(
                name: "IdGenero",
                table: "TblAlumnos",
                newName: "IdPerfil");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoPaterno",
                table: "TblAlumnos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoMaterno",
                table: "TblAlumnos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "CaTipotLicencias",
                keyColumn: "IdTipoLicencia",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatAreas",
                keyColumn: "IdArea",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatCorpCents",
                keyColumn: "IdCorpCent",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEscolaridades",
                keyColumn: "IdEscolaridad",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatEstatus",
                keyColumn: "IdEstatusRegistro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatGeneros",
                keyColumn: "IdGenero",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatNivelEscolares",
                keyColumn: "IdNivelEscolar",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPerfiles",
                keyColumn: "IdPerfil",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 7,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPeriodosAmortizaciones",
                keyColumn: "IdPeriodoAmortiza",
                keyValue: 8,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatPersonalEstudios",
                keyColumn: "IdPersonalEstudio",
                keyValue: 6,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatProdServs",
                keyColumn: "IdProdServ",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatRoles",
                keyColumn: "IdRol",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoAlumnos",
                keyColumn: "IdTipoAlumno",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoCentros",
                keyColumn: "IdTipoCentro",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoContrataciones",
                keyColumn: "IdTipoContratacion",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoFormaPagos",
                keyColumn: "IdTipoFormaPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 3,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 4,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPagos",
                keyColumn: "IdTipoPago",
                keyValue: 5,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CatTipoPrestamos",
                keyColumn: "IdTipoPrestamo",
                keyValue: 2,
                column: "FechaRegistro",
                value: new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
