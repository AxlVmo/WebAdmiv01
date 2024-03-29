﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAdmin.Migrations
{
    public partial class _0001m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: true),
                    NombreUsuario = table.Column<string>(type: "text", nullable: true),
                    NombreEmpresa = table.Column<string>(type: "text", nullable: true),
                    IdArea = table.Column<int>(type: "integer", nullable: true),
                    IdGenero = table.Column<int>(type: "integer", nullable: true),
                    IdPerfil = table.Column<int>(type: "integer", nullable: true),
                    IdRol = table.Column<int>(type: "integer", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CorreoAcceso = table.Column<string>(type: "text", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "bytea", nullable: true),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatAreas",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatAreas", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "CatCategorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriaDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCategorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "CatCodigosPostales",
                columns: table => new
                {
                    IdCodigosPostales = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dcodigo = table.Column<string>(type: "text", nullable: true),
                    Dasenta = table.Column<string>(type: "text", nullable: true),
                    DtipoAsenta = table.Column<string>(type: "text", nullable: true),
                    Dmnpio = table.Column<string>(type: "text", nullable: true),
                    Destado = table.Column<string>(type: "text", nullable: true),
                    Dciudad = table.Column<string>(type: "text", nullable: true),
                    Dcp = table.Column<string>(type: "text", nullable: true),
                    Cestado = table.Column<string>(type: "text", nullable: true),
                    Coficina = table.Column<string>(type: "text", nullable: true),
                    Ccp = table.Column<string>(type: "text", nullable: true),
                    CtipoAsenta = table.Column<string>(type: "text", nullable: true),
                    Cmnpio = table.Column<string>(type: "text", nullable: true),
                    IdAsentaCpcons = table.Column<string>(type: "text", nullable: true),
                    Dzona = table.Column<string>(type: "text", nullable: true),
                    CcveCiudad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCodigosPostales", x => x.IdCodigosPostales);
                });

            migrationBuilder.CreateTable(
                name: "CatCorpCents",
                columns: table => new
                {
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CorpCentDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCorpCents", x => x.IdCorpCent);
                });

            migrationBuilder.CreateTable(
                name: "CatEscolaridades",
                columns: table => new
                {
                    IdEscolaridad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EscolaridadDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEscolaridades", x => x.IdEscolaridad);
                });

            migrationBuilder.CreateTable(
                name: "CatEstatus",
                columns: table => new
                {
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstatusDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatEstatus", x => x.IdEstatusRegistro);
                });

            migrationBuilder.CreateTable(
                name: "CatGeneros",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeneroDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatGeneros", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "CaTipotLicencias",
                columns: table => new
                {
                    IdTipoLicencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LicenciaDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaTipotLicencias", x => x.IdTipoLicencia);
                });

            migrationBuilder.CreateTable(
                name: "CatNivelEscolares",
                columns: table => new
                {
                    IdNivelEscolar = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NivelEscolarDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatNivelEscolares", x => x.IdNivelEscolar);
                });

            migrationBuilder.CreateTable(
                name: "CatPerfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PerfilDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPerfiles", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "CatPeriodosAmortizaciones",
                columns: table => new
                {
                    IdPeriodoAmortiza = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodoAmortizaDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPeriodosAmortizaciones", x => x.IdPeriodoAmortiza);
                });

            migrationBuilder.CreateTable(
                name: "CatProdServs",
                columns: table => new
                {
                    IdProdServ = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdServDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProdServs", x => x.IdProdServ);
                });

            migrationBuilder.CreateTable(
                name: "CatProductos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoInterno = table.Column<string>(type: "text", nullable: true),
                    CodigoExterno = table.Column<string>(type: "text", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    DescProducto = table.Column<string>(type: "text", nullable: true),
                    CantidadMinima = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    ProductoPrecioUno = table.Column<decimal>(type: "numeric", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "numeric", nullable: false),
                    SubCosto = table.Column<decimal>(type: "numeric", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatProductos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "CatRoles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatRoles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoAlumnos",
                columns: table => new
                {
                    IdTipoAlumno = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoAlumnoDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoAlumnos", x => x.IdTipoAlumno);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoCentros",
                columns: table => new
                {
                    IdTipoCentro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoCentroDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoCentros", x => x.IdTipoCentro);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoContrataciones",
                columns: table => new
                {
                    IdTipoContratacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoContratacionDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoContrataciones", x => x.IdTipoContratacion);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoDirecciones",
                columns: table => new
                {
                    IdTipoDireccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDireccionDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoDirecciones", x => x.IdTipoDireccion);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoFormaPagos",
                columns: table => new
                {
                    IdTipoFormaPago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoFormaPagoDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoFormaPagos", x => x.IdTipoFormaPago);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoPagos",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPagoDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoPagos", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoPrestamos",
                columns: table => new
                {
                    IdTipoPrestamo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPrestamoDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoPrestamos", x => x.IdTipoPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoServicios",
                columns: table => new
                {
                    IdTipoServicio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoServicioDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoServicios", x => x.IdTipoServicio);
                });

            migrationBuilder.CreateTable(
                name: "CatTipoSuministros",
                columns: table => new
                {
                    IdTipoSuministro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoSuministroDesc = table.Column<string>(type: "text", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTipoSuministros", x => x.IdTipoSuministro);
                });

            migrationBuilder.CreateTable(
                name: "FilesOnDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Data = table.Column<byte[]>(type: "bytea", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UploadedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesOnDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesOnFileSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FileType = table.Column<string>(type: "text", nullable: true),
                    Extension = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UploadedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesOnFileSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelCompraPagos",
                columns: table => new
                {
                    IdRelComprasPago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoReferencia = table.Column<string>(type: "text", nullable: true),
                    CantidadPago = table.Column<int>(type: "integer", nullable: false),
                    IdCompra = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelCompraPagos", x => x.IdRelComprasPago);
                });

            migrationBuilder.CreateTable(
                name: "RelVentasPagos",
                columns: table => new
                {
                    IdRelVentasPago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoReferencia = table.Column<string>(type: "text", nullable: true),
                    CantidadPago = table.Column<int>(type: "integer", nullable: false),
                    IdVenta = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelVentasPagos", x => x.IdRelVentasPago);
                });

            migrationBuilder.CreateTable(
                name: "TblAlumnoContactos",
                columns: table => new
                {
                    IdAlumnoContacto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    NombreAlumnoContacto = table.Column<string>(type: "text", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "text", nullable: true),
                    IdAlumno = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAlumnoContactos", x => x.IdAlumnoContacto);
                });

            migrationBuilder.CreateTable(
                name: "TblAlumnoDirecciones",
                columns: table => new
                {
                    IdAlumnoDirecciones = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoDireccion = table.Column<int>(type: "integer", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: false),
                    CodigoPostal = table.Column<string>(type: "text", nullable: true),
                    IdColonia = table.Column<string>(type: "text", nullable: true),
                    Colonia = table.Column<string>(type: "text", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "text", nullable: true),
                    Ciudad = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdAlumno = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAlumnoDirecciones", x => x.IdAlumnoDirecciones);
                });

            migrationBuilder.CreateTable(
                name: "TblAlumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTipoAlumno = table.Column<int>(type: "integer", nullable: false),
                    NombreAlumno = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: true),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    IdRol = table.Column<int>(type: "integer", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "text", nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    ClaveAcceso = table.Column<string>(type: "text", nullable: true),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUCorporativoCentro = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaAcceso = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAlumnos", x => x.IdAlumno);
                });

            migrationBuilder.CreateTable(
                name: "TblBancos",
                columns: table => new
                {
                    IdBanco = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    CantidadDeposito = table.Column<double>(type: "double precision", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBancos", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "TblCentros",
                columns: table => new
                {
                    IdCentro = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTipoLicencia = table.Column<int>(type: "integer", nullable: false),
                    IdTipoCentro = table.Column<int>(type: "integer", nullable: false),
                    NombreCentro = table.Column<string>(type: "text", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: true),
                    CodigoPostal = table.Column<string>(type: "text", nullable: true),
                    IdColonia = table.Column<string>(type: "text", nullable: true),
                    Colonia = table.Column<string>(type: "text", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "text", nullable: true),
                    Ciudad = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdCorporativo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioControl = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCentros", x => x.IdCentro);
                });

            migrationBuilder.CreateTable(
                name: "TblCompras",
                columns: table => new
                {
                    IdCompra = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroCompra = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioCompra = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCentro = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTipoPago = table.Column<int>(type: "integer", nullable: false),
                    CodigoPago = table.Column<string>(type: "text", nullable: true),
                    FechaAlterna = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCompras", x => x.IdCompra);
                });

            migrationBuilder.CreateTable(
                name: "TblCorporativos",
                columns: table => new
                {
                    IdCorporativo = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreCorporativo = table.Column<string>(type: "text", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: true),
                    CodigoPostal = table.Column<string>(type: "text", nullable: true),
                    IdColonia = table.Column<string>(type: "text", nullable: true),
                    Colonia = table.Column<string>(type: "text", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "text", nullable: true),
                    Ciudad = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdEmpresa = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCorporativos", x => x.IdCorporativo);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "text", nullable: false),
                    Rfc = table.Column<string>(type: "text", nullable: true),
                    GiroComercial = table.Column<string>(type: "text", nullable: true),
                    Calle = table.Column<string>(type: "text", nullable: true),
                    CodigoPostal = table.Column<string>(type: "text", nullable: true),
                    IdColonia = table.Column<string>(type: "text", nullable: true),
                    Colonia = table.Column<string>(type: "text", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "text", nullable: true),
                    Ciudad = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpresas", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "TblPrestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTipoPrestamo = table.Column<int>(type: "integer", nullable: false),
                    PrestamoDesc = table.Column<string>(type: "text", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    CantidadPrestamo = table.Column<double>(type: "double precision", nullable: false),
                    IdUsuarioPrestamo = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPrestamos", x => x.IdPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorContactos",
                columns: table => new
                {
                    IdProveedorContacto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    NombreProveedorContacto = table.Column<string>(type: "text", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "text", nullable: true),
                    IdProveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorContactos", x => x.IdProveedorContacto);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedorDirecciones",
                columns: table => new
                {
                    IdProveedorDirecciones = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoDireccion = table.Column<int>(type: "integer", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: true),
                    CodigoPostal = table.Column<string>(type: "text", nullable: true),
                    IdColonia = table.Column<string>(type: "text", nullable: true),
                    Colonia = table.Column<string>(type: "text", nullable: true),
                    LocalidadMunicipio = table.Column<string>(type: "text", nullable: true),
                    Ciudad = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdProveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedorDirecciones", x => x.IdProveedorDirecciones);
                });

            migrationBuilder.CreateTable(
                name: "TblProveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreProveedor = table.Column<string>(type: "text", nullable: false),
                    Rfc = table.Column<string>(type: "text", nullable: true),
                    GiroComercial = table.Column<string>(type: "text", nullable: true),
                    IdCorporativo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "TblServicio",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoInterno = table.Column<string>(type: "text", nullable: true),
                    CodigoExterno = table.Column<string>(type: "text", nullable: false),
                    IdTipoServicio = table.Column<int>(type: "integer", nullable: false),
                    DescServicio = table.Column<string>(type: "text", nullable: true),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    ServicioPrecioUno = table.Column<decimal>(type: "numeric", nullable: false),
                    PorcentajePrecioUno = table.Column<decimal>(type: "numeric", nullable: false),
                    SubCosto = table.Column<decimal>(type: "numeric", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblServicio", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "TblSuministros",
                columns: table => new
                {
                    IdSuministro = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoSuministro = table.Column<int>(type: "integer", nullable: false),
                    SuministroDesc = table.Column<string>(type: "text", nullable: false),
                    NumeroReferencia = table.Column<string>(type: "text", nullable: false),
                    FechaFacturacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MontoSuministro = table.Column<double>(type: "double precision", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSuministros", x => x.IdSuministro);
                });

            migrationBuilder.CreateTable(
                name: "TblVenta",
                columns: table => new
                {
                    IdVenta = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroVenta = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioVenta = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCentro = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTipoPago = table.Column<int>(type: "integer", nullable: false),
                    CodigoPago = table.Column<string>(type: "text", nullable: true),
                    FechaAlterna = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVenta", x => x.IdVenta);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: false),
                    IdCorporativo = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCorpCent = table.Column<int>(type: "integer", nullable: false),
                    IdArea = table.Column<int>(type: "integer", nullable: false),
                    IdGenero = table.Column<int>(type: "integer", nullable: false),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false),
                    IdRol = table.Column<int>(type: "integer", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CorreoAcceso = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    ImagenPErfil = table.Column<byte[]>(type: "bytea", nullable: true),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false),
                    CatNivelEscolarIdNivelEscolar = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_CatNivelEscolares_CatNivelEscolarIdNivelEscolar",
                        column: x => x.CatNivelEscolarIdNivelEscolar,
                        principalTable: "CatNivelEscolares",
                        principalColumn: "IdNivelEscolar");
                });

            migrationBuilder.CreateTable(
                name: "RelCompraProductos",
                columns: table => new
                {
                    IdRelCompraProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Producto = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrecio = table.Column<double>(type: "double precision", nullable: false),
                    Descuento = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false),
                    IdCompra = table.Column<Guid>(type: "uuid", nullable: false),
                    TblCompraIdCompra = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelCompraProductos", x => x.IdRelCompraProducto);
                    table.ForeignKey(
                        name: "FK_RelCompraProductos_TblCompras_TblCompraIdCompra",
                        column: x => x.TblCompraIdCompra,
                        principalTable: "TblCompras",
                        principalColumn: "IdCompra");
                });

            migrationBuilder.CreateTable(
                name: "RelVentaProducto",
                columns: table => new
                {
                    IdRelVentaProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Producto = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrecio = table.Column<double>(type: "double precision", nullable: false),
                    Descuento = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    IdUsuarioModifico = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdEstatusRegistro = table.Column<int>(type: "integer", nullable: false),
                    IdVenta = table.Column<Guid>(type: "uuid", nullable: false),
                    TblVentaIdVenta = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelVentaProducto", x => x.IdRelVentaProducto);
                    table.ForeignKey(
                        name: "FK_RelVentaProducto_TblVenta_TblVentaIdVenta",
                        column: x => x.TblVentaIdVenta,
                        principalTable: "TblVenta",
                        principalColumn: "IdVenta");
                });

            migrationBuilder.InsertData(
                table: "CatAreas",
                columns: new[] { "IdArea", "AreaDesc", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico" },
                values: new object[,]
                {
                    { 1, "DIRECCION", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "ADMINISTRATIVA", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, "RECURSOS HUMANOS", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, "PRODUCCION DIGITAL", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, "FINANZAS/CONTABILIDAD", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 6, "MARKETING/VENTAS", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 7, "TIC", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "CatCodigosPostales",
                columns: new[] { "IdCodigosPostales", "Ccp", "CcveCiudad", "Cestado", "Cmnpio", "Coficina", "CtipoAsenta", "Dasenta", "Dciudad", "Dcodigo", "Dcp", "Destado", "Dmnpio", "DtipoAsenta", "Dzona", "IdAsentaCpcons" },
                values: new object[,]
                {
                    { 1, "0", "01", "09", "010", "01001", "09", "San Ángel", "Ciudad de México", "01000", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0001" },
                    { 2, "0", "01", "09", "010", "01001", "09", "Los Alpes", "Ciudad de México", "01010", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0005" },
                    { 3, "0", "01", "09", "010", "01001", "09", "Guadalupe Inn", "Ciudad de México", "01020", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0006" },
                    { 4, "0", "01", "09", "010", "01001", "28", "Axotla", "Ciudad de México", "01030", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0009" },
                    { 5, "0", "01", "09", "010", "01001", "09", "Florida", "Ciudad de México", "01030", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0010" },
                    { 6, "0", "01", "09", "010", "01001", "09", "Campestre", "Ciudad de México", "01040", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0012" },
                    { 7, "0", "01", "09", "010", "01001", "28", "Tlacopac", "Ciudad de México", "01049", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0014" },
                    { 8, "0", "01", "09", "010", "01001", "09", "Ex-Hacienda de Guadalupe Chimalistac", "Ciudad de México", "01050", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0016" },
                    { 9, "0", "01", "09", "010", "01001", "09", "Altavista", "Ciudad de México", "01060", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0017" },
                    { 10, "0", "01", "09", "010", "01001", "09", "San Ángel Inn", "Ciudad de México", "01060", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0018" },
                    { 11, "0", "01", "09", "010", "01001", "09", "Chimalistac", "Ciudad de México", "01070", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0019" },
                    { 12, "0", "01", "09", "010", "01001", "09", "Progreso Tizapan", "Ciudad de México", "01080", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0022" },
                    { 13, "0", "01", "09", "010", "01001", "09", "Ermita Tizapan", "Ciudad de México", "01089", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0024" },
                    { 14, "0", "01", "09", "010", "01001", "02", "La Otra Banda", "Ciudad de México", "01090", "01001", "Ciudad de México", "Álvaro Obregón", "Barrio", "Urbano", "0025" },
                    { 15, "0", "01", "09", "010", "01001", "02", "Loreto", "Ciudad de México", "01090", "01001", "Ciudad de México", "Álvaro Obregón", "Barrio", "Urbano", "0026" },
                    { 16, "0", "01", "09", "010", "01001", "28", "Tizapan", "Ciudad de México", "01090", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0028" },
                    { 17, "0", "01", "09", "010", "01131", "09", "Pólvora", "Ciudad de México", "01100", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0031" },
                    { 18, "0", "01", "09", "010", "01131", "09", "La Conchita", "Ciudad de México", "01109", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0033" },
                    { 19, "0", "01", "09", "010", "01131", "09", "Belém de las Flores", "Ciudad de México", "01110", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0034" },
                    { 20, "0", "01", "09", "010", "01131", "09", "El Capulín", "Ciudad de México", "01110", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0036" },
                    { 21, "0", "01", "09", "010", "01131", "09", "Ampliación El Capulín", "Ciudad de México", "01110", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0037" },
                    { 22, "0", "01", "09", "010", "01131", "09", "Liberales de 1857", "Ciudad de México", "01110", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0039" },
                    { 23, "0", "01", "09", "010", "01131", "09", "Acueducto", "Ciudad de México", "01120", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0042" },
                    { 24, "0", "01", "09", "010", "01131", "09", "Cove", "Ciudad de México", "01120", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0044" },
                    { 25, "0", "01", "09", "010", "01131", "09", "Hidalgo", "Ciudad de México", "01120", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0046" },
                    { 26, "0", "01", "09", "010", "01131", "09", "Las Américas", "Ciudad de México", "01120", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0047" },
                    { 27, "0", "01", "09", "010", "01131", "09", "Ampliación Acueducto", "Ciudad de México", "01125", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0043" },
                    { 28, "0", "01", "09", "010", "01131", "09", "Paraíso", "Ciudad de México", "01130", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0052" },
                    { 29, "0", "01", "09", "010", "01131", "09", "Molino de Santo Domingo", "Ciudad de México", "01130", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0053" },
                    { 30, "0", "01", "09", "010", "01131", "09", "Real del Monte", "Ciudad de México", "01130", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0056" },
                    { 31, "0", "01", "09", "010", "01131", "09", "Reacomodo Pino Suárez", "Ciudad de México", "01139", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0058" },
                    { 32, "0", "01", "09", "010", "01131", "09", "Bellavista", "Ciudad de México", "01140", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0059" },
                    { 33, "0", "01", "09", "010", "01131", "09", "José Maria Pino Suárez", "Ciudad de México", "01140", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0060" },
                    { 34, "0", "01", "09", "010", "01131", "09", "Cristo Rey", "Ciudad de México", "01150", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0063" },
                    { 35, "0", "01", "09", "010", "01131", "09", "Tolteca", "Ciudad de México", "01150", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0064" },
                    { 36, "0", "01", "09", "010", "01131", "09", "Bosque", "Ciudad de México", "01160", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0066" },
                    { 37, "0", "01", "09", "010", "01131", "09", "Isidro Fabela", "Ciudad de México", "01160", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0067" },
                    { 38, "0", "01", "09", "010", "01131", "09", "Maria G. de García Ruiz", "Ciudad de México", "01160", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0068" },
                    { 39, "0", "01", "09", "010", "01131", "09", "1a Victoria", "Ciudad de México", "01160", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0069" },
                    { 40, "0", "01", "09", "010", "01131", "09", "Abraham M. González", "Ciudad de México", "01170", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0074" },
                    { 41, "0", "01", "09", "010", "01131", "09", "Carola", "Ciudad de México", "01180", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0076" },
                    { 42, "0", "01", "09", "010", "01131", "09", "8 de Agosto", "Ciudad de México", "01180", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0077" },
                    { 43, "0", "01", "09", "010", "01131", "09", "San Pedro de los Pinos", "Ciudad de México", "01180", "01131", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0078" },
                    { 44, "0", "01", "09", "010", "01401", "09", "Arturo Martínez", "Ciudad de México", "01200", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0079" },
                    { 45, "0", "01", "09", "010", "01401", "28", "Santa Fe", "Ciudad de México", "01210", "01401", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0082" },
                    { 46, "0", "01", "09", "010", "01401", "09", "Lomas de Santa Fe", "Ciudad de México", "01219", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0084" },
                    { 47, "0", "01", "09", "010", "01401", "09", "La Estrella", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2681" },
                    { 48, "0", "01", "09", "010", "01401", "09", "Bonanza", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0085" },
                    { 49, "0", "01", "09", "010", "01401", "09", "Cuevitas", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0086" },
                    { 50, "0", "01", "09", "010", "01401", "09", "El Cuernito", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0087" },
                    { 51, "0", "01", "09", "010", "01401", "09", "Mártires de Tacubaya", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0089" },
                    { 52, "0", "01", "09", "010", "01401", "09", "Zenón Delgado", "Ciudad de México", "01220", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0090" },
                    { 53, "0", "01", "09", "010", "01401", "09", "Campo de Tiro los Gamitos", "Ciudad de México", "01230", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0092" },
                    { 54, "0", "01", "09", "010", "01401", "09", "Los Gamitos", "Ciudad de México", "01230", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0097" },
                    { 55, "0", "01", "09", "010", "01401", "09", "Tlapechico", "Ciudad de México", "01230", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0098" },
                    { 56, "0", "01", "09", "010", "01401", "09", "El Piru Santa Fe", "Ciudad de México", "01230", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0132" },
                    { 57, "0", "01", "09", "010", "01401", "09", "El Piru 2a Ampliación", "Ciudad de México", "01230", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0224" },
                    { 58, "0", "01", "09", "010", "01401", "09", "La Huerta", "Ciudad de México", "01239", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0102" },
                    { 59, "0", "01", "09", "010", "01401", "09", "Pueblo Nuevo", "Ciudad de México", "01240", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0103" },
                    { 60, "0", "01", "09", "010", "01401", "09", "El Árbol", "Ciudad de México", "01250", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0104" },
                    { 61, "0", "01", "09", "010", "01401", "09", "Ladera", "Ciudad de México", "01250", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0105" },
                    { 62, "0", "01", "09", "010", "01401", "09", "Lomas de Nuevo México", "Ciudad de México", "01250", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0106" },
                    { 63, "0", "01", "09", "010", "01401", "09", "Margarita Maza de Juárez", "Ciudad de México", "01250", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0107" },
                    { 64, "0", "01", "09", "010", "01401", "09", "Tecolalco", "Ciudad de México", "01250", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0108" },
                    { 65, "0", "01", "09", "010", "01401", "09", "Ampliación La Cebada", "Ciudad de México", "01259", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0109" },
                    { 66, "0", "01", "09", "010", "01401", "09", "La Mexicana 2a Ampliación", "Ciudad de México", "01259", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2845" },
                    { 67, "0", "01", "09", "010", "01401", "09", "Calzada Jalalpa", "Ciudad de México", "01260", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0110" },
                    { 68, "0", "01", "09", "010", "01401", "09", "La Mexicana", "Ciudad de México", "01260", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0112" },
                    { 69, "0", "01", "09", "010", "01401", "09", "Ampliación La Mexicana", "Ciudad de México", "01260", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0113" },
                    { 70, "0", "01", "09", "010", "01401", "09", "La Palmita", "Ciudad de México", "01260", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0114" },
                    { 71, "0", "01", "09", "010", "01401", "09", "Liberación Proletaria", "Ciudad de México", "01260", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0115" },
                    { 72, "0", "01", "09", "010", "01401", "09", "1a Sección Cañada", "Ciudad de México", "01269", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0117" },
                    { 73, "0", "01", "09", "010", "01401", "09", "2a Sección Cañada", "Ciudad de México", "01269", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0118" },
                    { 74, "0", "01", "09", "010", "01401", "09", "El Tejocote", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0120" },
                    { 75, "0", "01", "09", "010", "01401", "09", "La Presa", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0121" },
                    { 76, "0", "01", "09", "010", "01401", "09", "Golondrinas", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0123" },
                    { 77, "0", "01", "09", "010", "01401", "09", "Golondrinas 1a Sección", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0124" },
                    { 78, "0", "01", "09", "010", "01401", "09", "Golondrinas 2a Sección", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0125" },
                    { 79, "0", "01", "09", "010", "01401", "09", "Lomas de Capula", "Ciudad de México", "01270", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0127" },
                    { 80, "0", "01", "09", "010", "01401", "09", "Villa Solidaridad", "Ciudad de México", "01275", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0131" },
                    { 81, "0", "01", "09", "010", "01401", "09", "El Pirul", "Ciudad de México", "01276", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0093" },
                    { 82, "0", "01", "09", "010", "01401", "09", "Desarrollo Urbano", "Ciudad de México", "01278", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0133" },
                    { 83, "0", "01", "09", "010", "01401", "09", "Lomas de Becerra", "Ciudad de México", "01279", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0136" },
                    { 84, "0", "01", "09", "010", "01401", "09", "Arvide", "Ciudad de México", "01280", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0138" },
                    { 85, "0", "01", "09", "010", "01401", "09", "El Pocito", "Ciudad de México", "01280", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0139" },
                    { 86, "0", "01", "09", "010", "01401", "09", "Francisco Villa", "Ciudad de México", "01280", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0140" },
                    { 87, "0", "01", "09", "010", "01401", "09", "La Joya", "Ciudad de México", "01280", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0141" },
                    { 88, "0", "01", "09", "010", "01401", "09", "El Rodeo", "Ciudad de México", "01285", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0144" },
                    { 89, "0", "01", "09", "010", "01401", "09", "Reacomodo El Cuernito", "Ciudad de México", "01289", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0146" },
                    { 90, "0", "01", "09", "010", "01401", "09", "Piloto Adolfo López Mateos", "Ciudad de México", "01290", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0147" },
                    { 91, "0", "01", "09", "010", "01401", "09", "Presidentes", "Ciudad de México", "01290", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0148" },
                    { 92, "0", "01", "09", "010", "01401", "09", "Jalalpa Tepito 2a Ampliación", "Ciudad de México", "01296", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0152" },
                    { 93, "0", "01", "09", "010", "01401", "09", "Ampliación Jalalpa", "Ciudad de México", "01296", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0153" },
                    { 94, "0", "01", "09", "010", "01401", "09", "Jalalpa Tepito", "Ciudad de México", "01296", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0154" },
                    { 95, "0", "01", "09", "010", "01401", "09", "Ampliación Piloto Adolfo López Mateos", "Ciudad de México", "01298", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0156" },
                    { 96, "0", "01", "09", "010", "01401", "09", "1a Ampliación Presidentes", "Ciudad de México", "01299", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0160" },
                    { 97, "0", "01", "09", "010", "01401", "09", "2a Ampliación Presidentes", "Ciudad de México", "01299", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0161" },
                    { 98, "0", "01", "09", "010", "01401", "09", "San Gabriel", "Ciudad de México", "01310", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0163" },
                    { 99, "0", "01", "09", "010", "01401", "09", "Carlos A. Madrazo", "Ciudad de México", "01320", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0164" },
                    { 100, "0", "01", "09", "010", "01401", "09", "Paseo de las Lomas", "Ciudad de México", "01330", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0168" },
                    { 101, "0", "01", "09", "010", "01401", "09", "Bejero del Pueblo Santa Fe", "Ciudad de México", "01340", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0170" },
                    { 102, "0", "01", "09", "010", "01401", "09", "Santa Fe", "Ciudad de México", "01376", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0171" },
                    { 103, "0", "01", "09", "010", "01401", "09", "Santa Fe Peña Blanca", "Ciudad de México", "01376", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2682" },
                    { 104, "0", "01", "09", "010", "01401", "09", "Santa Fe La Loma", "Ciudad de México", "01376", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2683" },
                    { 105, "0", "01", "09", "010", "01401", "09", "Santa Fe Centro Ciudad", "Ciudad de México", "01376", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2864" },
                    { 106, "0", "01", "09", "010", "01401", "09", "Jalalpa El Grande", "Ciudad de México", "01377", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0172" },
                    { 107, "0", "01", "09", "010", "01401", "09", "Santa Fe Tlayapaca", "Ciudad de México", "01389", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0176" },
                    { 108, "0", "01", "09", "010", "01401", "09", "Olivar del Conde 1a Sección", "Ciudad de México", "01400", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0181" },
                    { 109, "0", "01", "09", "010", "01401", "09", "Preconcreto", "Ciudad de México", "01400", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0184" },
                    { 110, "0", "01", "09", "010", "01401", "09", "Galeana", "Ciudad de México", "01407", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0187" },
                    { 111, "0", "01", "09", "010", "01401", "09", "Olivar del Conde 2a Sección", "Ciudad de México", "01408", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0188" },
                    { 112, "0", "01", "09", "010", "01401", "09", "Barrio Norte", "Ciudad de México", "01410", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0193" },
                    { 113, "0", "01", "09", "010", "01401", "09", "Palmas", "Ciudad de México", "01410", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0194" },
                    { 114, "0", "01", "09", "010", "01401", "09", "Minas Cristo Rey", "Ciudad de México", "01419", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0195" },
                    { 115, "0", "01", "09", "010", "01401", "09", "Sacramento", "Ciudad de México", "01420", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0196" },
                    { 116, "0", "01", "09", "010", "01401", "02", "Santa María Nonoalco", "Ciudad de México", "01420", "01401", "Ciudad de México", "Álvaro Obregón", "Barrio", "Urbano", "0197" },
                    { 117, "0", "01", "09", "010", "01401", "09", "Colina del Sur", "Ciudad de México", "01430", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0198" },
                    { 118, "0", "01", "09", "010", "01401", "09", "Hogar y Redención", "Ciudad de México", "01450", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0202" },
                    { 119, "0", "01", "09", "010", "01401", "09", "Alfonso XIII", "Ciudad de México", "01460", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0204" },
                    { 120, "0", "01", "09", "010", "01401", "02", "Alfalfar", "Ciudad de México", "01470", "01401", "Ciudad de México", "Álvaro Obregón", "Barrio", "Urbano", "0206" },
                    { 121, "0", "01", "09", "010", "01401", "09", "Molino de Rosas", "Ciudad de México", "01470", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0207" },
                    { 122, "0", "01", "09", "010", "01401", "09", "Lomas de Plateros", "Ciudad de México", "01480", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0209" },
                    { 123, "0", "01", "09", "010", "01401", "09", "La Cascada", "Ciudad de México", "01490", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0211" },
                    { 124, "0", "01", "09", "010", "01401", "28", "Santa Lucía", "Ciudad de México", "01500", "01401", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0213" },
                    { 125, "0", "01", "09", "010", "01401", "09", "Miguel Gaona Armenta", "Ciudad de México", "01500", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2704" },
                    { 126, "0", "01", "09", "010", "01401", "28", "Santa Lucía Chantepec", "Ciudad de México", "01509", "01401", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0221" },
                    { 127, "0", "01", "09", "010", "01401", "09", "Garcimarrero", "Ciudad de México", "01510", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0222" },
                    { 128, "0", "01", "09", "010", "01401", "09", "La Araña", "Ciudad de México", "01510", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0223" },
                    { 129, "0", "01", "09", "010", "01401", "09", "Los Cedros", "Ciudad de México", "01510", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2636" },
                    { 130, "0", "01", "09", "010", "01401", "09", "Ampliación Los Pirules", "Ciudad de México", "01520", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0094" },
                    { 131, "0", "01", "09", "010", "01401", "09", "Estado de Hidalgo", "Ciudad de México", "01520", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0225" },
                    { 132, "0", "01", "09", "010", "01401", "09", "Ampliación Estado de Hidalgo", "Ciudad de México", "01520", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0226" },
                    { 133, "0", "01", "09", "010", "01401", "09", "Piru Santa Lucía", "Ciudad de México", "01520", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0227" },
                    { 134, "0", "01", "09", "010", "01401", "09", "El Politoco", "Ciudad de México", "01520", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2841" },
                    { 135, "0", "01", "09", "010", "01401", "09", "Corpus Christy", "Ciudad de México", "01530", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0229" },
                    { 136, "0", "01", "09", "010", "01401", "09", "Tepopotla", "Ciudad de México", "01538", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0232" },
                    { 137, "0", "01", "09", "010", "01401", "09", "Acuilotla", "Ciudad de México", "01539", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0233" },
                    { 138, "0", "01", "09", "010", "01401", "09", "Cooperativa Unión Olivos", "Ciudad de México", "01539", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2643" },
                    { 139, "0", "01", "09", "010", "01401", "09", "Balcones de Cehuayo", "Ciudad de México", "01540", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0238" },
                    { 140, "0", "01", "09", "010", "01401", "09", "Cehuaya", "Ciudad de México", "01540", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0239" },
                    { 141, "0", "01", "09", "010", "01401", "09", "Llano Redondo", "Ciudad de México", "01540", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0240" },
                    { 142, "0", "01", "09", "010", "01401", "09", "Punta de Cehuaya", "Ciudad de México", "01540", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0241" },
                    { 143, "0", "01", "09", "010", "01401", "09", "Villa Progresista", "Ciudad de México", "01548", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2638" },
                    { 144, "0", "01", "09", "010", "01401", "09", "Dos Ríos del Pueblo Santa Lucía", "Ciudad de México", "01549", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0243" },
                    { 145, "0", "01", "09", "010", "01401", "09", "Tepeaca", "Ciudad de México", "01550", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0245" },
                    { 146, "0", "01", "09", "010", "01401", "09", "Ampliación Tepeaca", "Ciudad de México", "01550", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0246" },
                    { 147, "0", "01", "09", "010", "01401", "09", "Rinconada Las Cuevitas", "Ciudad de México", "01550", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2849" },
                    { 148, "0", "01", "09", "010", "01401", "09", "Ave Real", "Ciudad de México", "01560", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0248" },
                    { 149, "0", "01", "09", "010", "01401", "09", "Canutillo", "Ciudad de México", "01560", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0249" },
                    { 150, "0", "01", "09", "010", "01401", "09", "Canutillo 3a Sección", "Ciudad de México", "01560", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0250" },
                    { 151, "0", "01", "09", "010", "01401", "09", "Canutillo 2a Sección", "Ciudad de México", "01560", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0251" },
                    { 152, "0", "01", "09", "010", "01401", "09", "Hueytlale", "Ciudad de México", "01566", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2747" },
                    { 153, "0", "01", "09", "010", "01401", "09", "Reacomodo Valentín Gómez Farías", "Ciudad de México", "01569", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0255" },
                    { 154, "0", "01", "09", "010", "01401", "09", "Tarango", "Ciudad de México", "01588", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0259" },
                    { 155, "0", "01", "09", "010", "01401", "09", "El Rincón", "Ciudad de México", "01590", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0261" },
                    { 156, "0", "01", "09", "010", "01401", "09", "Merced Gómez", "Ciudad de México", "01600", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0263" },
                    { 157, "0", "01", "09", "010", "01401", "09", "Colinas de Tarango", "Ciudad de México", "01610", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0265" },
                    { 158, "0", "01", "09", "010", "01401", "09", "Profesor J. Arturo López Martínez", "Ciudad de México", "01610", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2639" },
                    { 159, "0", "01", "09", "010", "01401", "09", "Arcos Centenario", "Ciudad de México", "01618", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0267" },
                    { 160, "0", "01", "09", "010", "01401", "09", "Ex-Hacienda de Tarango", "Ciudad de México", "01618", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2745" },
                    { 161, "0", "01", "09", "010", "01401", "09", "Rinconada de Tarango", "Ciudad de México", "01619", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0269" },
                    { 162, "0", "01", "09", "010", "01401", "09", "La Martinica", "Ciudad de México", "01619", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0268" },
                    { 163, "0", "01", "09", "010", "01401", "09", "Lomas de Tarango", "Ciudad de México", "01620", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0270" },
                    { 164, "0", "01", "09", "010", "01401", "09", "Lomas de Puerta Grande", "Ciudad de México", "01630", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0271" },
                    { 165, "0", "01", "09", "010", "01401", "09", "Puerta Grande", "Ciudad de México", "01630", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0273" },
                    { 166, "0", "01", "09", "010", "01401", "09", "Los Juristas", "Ciudad de México", "01630", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2640" },
                    { 167, "0", "01", "09", "010", "01401", "09", "Herón Proal", "Ciudad de México", "01640", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0275" },
                    { 168, "0", "01", "09", "010", "01401", "09", "Ponciano Arriaga", "Ciudad de México", "01645", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0276" },
                    { 169, "0", "01", "09", "010", "01401", "09", "La Milagrosa", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0277" },
                    { 170, "0", "01", "09", "010", "01401", "09", "Palmas Axotitla", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0278" },
                    { 171, "0", "01", "09", "010", "01401", "09", "Tlacuitlapa", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0279" },
                    { 172, "0", "01", "09", "010", "01401", "09", "Ampliación Tlacuitlapa", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0280" },
                    { 173, "0", "01", "09", "010", "01401", "09", "2o Reacomodo Tlacuitlapa", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0281" },
                    { 174, "0", "01", "09", "010", "01401", "09", "El Ruedo", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2844" },
                    { 175, "0", "01", "09", "010", "01401", "09", "Santa Lucía Chantepec", "Ciudad de México", "01650", "01401", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2848" },
                    { 176, "0", "01", "09", "010", "01001", "09", "La Joyita del Pueblo Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0282" },
                    { 177, "0", "01", "09", "010", "01001", "09", "Ocotillos del Pueblo Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0283" },
                    { 178, "0", "01", "09", "010", "01001", "09", "San Agustín del Pueblo Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0284" },
                    { 179, "0", "01", "09", "010", "01001", "09", "2a Del Moral del Pueblo Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0285" },
                    { 180, "0", "01", "09", "010", "01001", "09", "Tecalcapa del Pueblo Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0286" },
                    { 181, "0", "01", "09", "010", "01001", "28", "Tetelpan", "Ciudad de México", "01700", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0287" },
                    { 182, "0", "01", "09", "010", "01001", "09", "El Encino del Pueblo Tetelpan", "Ciudad de México", "01708", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0291" },
                    { 183, "0", "01", "09", "010", "01001", "09", "El Mirador del Pueblo Tetelpan", "Ciudad de México", "01708", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0292" },
                    { 184, "0", "01", "09", "010", "01001", "09", "Las Águilas", "Ciudad de México", "01710", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0294" },
                    { 185, "0", "01", "09", "010", "01001", "09", "Ampliación Alpes", "Ciudad de México", "01710", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0295" },
                    { 186, "0", "01", "09", "010", "01001", "09", "Lomas de Guadalupe", "Ciudad de México", "01720", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0297" },
                    { 187, "0", "01", "09", "010", "01001", "09", "Alcantarilla", "Ciudad de México", "01729", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0298" },
                    { 188, "0", "01", "09", "010", "01001", "09", "Lomas de las Águilas", "Ciudad de México", "01730", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0299" },
                    { 189, "0", "01", "09", "010", "01001", "09", "Puente Colorado", "Ciudad de México", "01730", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0300" },
                    { 190, "0", "01", "09", "010", "01001", "09", "La Peñita del Pueblo Tetelpan", "Ciudad de México", "01740", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0303" },
                    { 191, "0", "01", "09", "010", "01001", "09", "San Clemente Norte", "Ciudad de México", "01740", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0304" },
                    { 192, "0", "01", "09", "010", "01001", "09", "San Clemente Sur", "Ciudad de México", "01740", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2842" },
                    { 193, "0", "01", "09", "010", "01001", "09", "Las Águilas 1a Sección", "Ciudad de México", "01750", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0305" },
                    { 194, "0", "01", "09", "010", "01001", "09", "Las Águilas 2o Parque", "Ciudad de México", "01750", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0306" },
                    { 195, "0", "01", "09", "010", "01001", "09", "Las Águilas 3er Parque", "Ciudad de México", "01750", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0307" },
                    { 196, "0", "01", "09", "010", "01001", "09", "Ampliación Las Águilas", "Ciudad de México", "01759", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0308" },
                    { 197, "0", "01", "09", "010", "01001", "09", "Atlamaya", "Ciudad de México", "01760", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0309" },
                    { 198, "0", "01", "09", "010", "01001", "09", "Flor de María", "Ciudad de México", "01760", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0310" },
                    { 199, "0", "01", "09", "010", "01001", "09", "La Herradura del Pueblo Tetelpan", "Ciudad de México", "01760", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0311" },
                    { 200, "0", "01", "09", "010", "01001", "09", "La Angostura", "Ciudad de México", "01770", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0315" },
                    { 201, "0", "01", "09", "010", "01001", "09", "San José del Olivar", "Ciudad de México", "01770", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0316" },
                    { 202, "0", "01", "09", "010", "01001", "09", "Olivar de los Padres", "Ciudad de México", "01780", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0318" },
                    { 203, "0", "01", "09", "010", "01001", "09", "Tizampampano del Pueblo Tetelpan", "Ciudad de México", "01780", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0319" },
                    { 204, "0", "01", "09", "010", "01001", "09", "Miguel Hidalgo", "Ciudad de México", "01789", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0323" },
                    { 205, "0", "01", "09", "010", "01001", "09", "Lomas de los Ángeles del Pueblo Tetelpan", "Ciudad de México", "01790", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0324" },
                    { 206, "0", "01", "09", "010", "01001", "09", "Lomas de San Ángel Inn", "Ciudad de México", "01790", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0325" },
                    { 207, "0", "01", "09", "010", "01001", "28", "San Bartolo Ameyalco", "Ciudad de México", "01800", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0327" },
                    { 208, "0", "01", "09", "010", "01001", "09", "Rancho San Francisco Pueblo San Bartolo Ameyalco", "Ciudad de México", "01807", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0328" },
                    { 209, "0", "01", "09", "010", "01001", "09", "Villa Verdún", "Ciudad de México", "01810", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0330" },
                    { 210, "0", "01", "09", "010", "01001", "09", "Lomas Axomiatla", "Ciudad de México", "01820", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0332" },
                    { 211, "0", "01", "09", "010", "01001", "09", "Ejido San Mateo", "Ciudad de México", "01820", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2843" },
                    { 212, "0", "01", "09", "010", "01001", "28", "Santa Rosa Xochiac", "Ciudad de México", "01830", "01001", "Ciudad de México", "Álvaro Obregón", "Pueblo", "Urbano", "0333" },
                    { 213, "0", "01", "09", "010", "01001", "09", "Torres de Potrero", "Ciudad de México", "01840", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0334" },
                    { 214, "0", "01", "09", "010", "01001", "09", "Rincón de la Bolsa", "Ciudad de México", "01849", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0337" },
                    { 215, "0", "01", "09", "010", "01001", "09", "Rancho del Carmen del Pueblo San Bartolo Ameyalco", "Ciudad de México", "01849", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2847" },
                    { 216, "0", "01", "09", "010", "01001", "09", "Lomas de Chamontoya", "Ciudad de México", "01857", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0341" },
                    { 217, "0", "01", "09", "010", "01001", "09", "Tlacoyaque", "Ciudad de México", "01859", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0343" },
                    { 218, "0", "01", "09", "010", "01001", "09", "Lomas de La Era", "Ciudad de México", "01860", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0344" },
                    { 219, "0", "01", "09", "010", "01001", "09", "Lomas del Capulín", "Ciudad de México", "01863", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0003" },
                    { 220, "0", "01", "09", "010", "01001", "09", "Lomas de los Cedros", "Ciudad de México", "01870", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0345" },
                    { 221, "0", "01", "09", "010", "01001", "09", "Jardines del Pedregal", "Ciudad de México", "01900", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "0347" },
                    { 222, "0", "01", "09", "010", "01001", "09", "San Jerónimo Aculco", "Ciudad de México", "01904", "01001", "Ciudad de México", "Álvaro Obregón", "Colonia", "Urbano", "2846" },
                    { 223, "0", "02", "09", "002", "02011", "09", "Centro de Azcapotzalco", "Ciudad de México", "02000", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0353" },
                    { 224, "0", "02", "09", "002", "02011", "02", "Los Reyes", "Ciudad de México", "02010", "02011", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0356" },
                    { 225, "0", "02", "09", "002", "02011", "09", "San Rafael", "Ciudad de México", "02010", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0357" },
                    { 226, "0", "02", "09", "002", "02011", "02", "Nuevo Barrio San Rafael", "Ciudad de México", "02010", "02011", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0358" },
                    { 227, "0", "02", "09", "002", "02011", "02", "San Marcos", "Ciudad de México", "02020", "02011", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0360" },
                    { 228, "0", "02", "09", "002", "02011", "09", "Santo Tomás", "Ciudad de México", "02020", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0361" },
                    { 229, "0", "02", "09", "002", "02011", "09", "Del Maestro", "Ciudad de México", "02040", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0362" },
                    { 230, "0", "02", "09", "002", "02011", "09", "San Sebastián", "Ciudad de México", "02040", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0363" },
                    { 231, "0", "02", "09", "002", "02011", "09", "Libertad", "Ciudad de México", "02050", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0364" },
                    { 232, "0", "02", "09", "002", "02011", "28", "Santa María Malinalco", "Ciudad de México", "02050", "02011", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0365" },
                    { 233, "0", "02", "09", "002", "02011", "09", "Sindicato Mexicano de Electricistas", "Ciudad de México", "02060", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0368" },
                    { 234, "0", "02", "09", "002", "02011", "09", "Un Hogar Para Cada Trabajador", "Ciudad de México", "02060", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0369" },
                    { 235, "0", "02", "09", "002", "02011", "09", "Del Recreo", "Ciudad de México", "02070", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0371" },
                    { 236, "0", "02", "09", "002", "02011", "02", "Nextengo", "Ciudad de México", "02070", "02011", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0372" },
                    { 237, "0", "02", "09", "002", "02011", "09", "Clavería", "Ciudad de México", "02080", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0374" },
                    { 238, "0", "02", "09", "002", "02011", "09", "Sector Naval", "Ciudad de México", "02080", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0376" },
                    { 239, "0", "02", "09", "002", "02011", "09", "San Álvaro", "Ciudad de México", "02090", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0377" },
                    { 240, "0", "02", "09", "002", "02011", "09", "Ángel Zimbrón", "Ciudad de México", "02099", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0378" },
                    { 241, "0", "02", "09", "002", "02011", "09", "El Rosario", "Ciudad de México", "02100", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0379" },
                    { 242, "0", "02", "09", "002", "02011", "28", "San Martín Xochinahuac", "Ciudad de México", "02120", "02011", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0385" },
                    { 243, "0", "02", "09", "002", "02011", "09", "Nueva El Rosario", "Ciudad de México", "02128", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0389" },
                    { 244, "0", "02", "09", "002", "02011", "09", "Nueva España", "Ciudad de México", "02129", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0390" },
                    { 245, "0", "02", "09", "002", "02011", "09", "Tierra Nueva", "Ciudad de México", "02130", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0391" },
                    { 246, "0", "02", "09", "002", "02011", "09", "Santa Inés", "Ciudad de México", "02140", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0392" },
                    { 247, "0", "02", "09", "002", "02011", "09", "Pasteros", "Ciudad de México", "02150", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0393" },
                    { 248, "0", "02", "09", "002", "02011", "28", "Santo Domingo", "Ciudad de México", "02160", "02011", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0394" },
                    { 249, "0", "02", "09", "002", "02011", "09", "Reynosa Tamaulipas", "Ciudad de México", "02200", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0396" },
                    { 250, "0", "02", "09", "002", "02011", "28", "Santa Bárbara", "Ciudad de México", "02230", "02011", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0397" },
                    { 251, "0", "02", "09", "002", "02011", "02", "San Andrés", "Ciudad de México", "02240", "02011", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0398" },
                    { 252, "0", "02", "09", "002", "02011", "28", "San Andrés", "Ciudad de México", "02240", "02011", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0399" },
                    { 253, "0", "02", "09", "002", "02431", "28", "Santa Catarina", "Ciudad de México", "02250", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0400" },
                    { 254, "0", "02", "09", "002", "02601", "09", "Industrial Vallejo", "Ciudad de México", "02300", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0402" },
                    { 255, "0", "02", "09", "002", "02601", "09", "Ferrería", "Ciudad de México", "02310", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0404" },
                    { 256, "0", "02", "09", "002", "02601", "28", "San Andrés de las Salinas", "Ciudad de México", "02320", "02601", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0405" },
                    { 257, "0", "02", "09", "002", "02601", "02", "Huautla de las Salinas", "Ciudad de México", "02330", "02601", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0406" },
                    { 258, "0", "02", "09", "002", "02601", "09", "Santa Cruz de las Salinas", "Ciudad de México", "02340", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0407" },
                    { 259, "0", "02", "09", "002", "02601", "09", "Las Salinas", "Ciudad de México", "02360", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0409" },
                    { 260, "0", "02", "09", "002", "02431", "28", "San Juan Tlihuaca", "Ciudad de México", "02400", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0410" },
                    { 261, "0", "02", "09", "002", "02431", "09", "Prados del Rosario", "Ciudad de México", "02410", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0412" },
                    { 262, "0", "02", "09", "002", "02431", "09", "Ex-Hacienda El Rosario", "Ciudad de México", "02420", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0415" },
                    { 263, "0", "02", "09", "002", "02431", "09", "Providencia", "Ciudad de México", "02440", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0418" },
                    { 264, "0", "02", "09", "002", "02431", "09", "Tezozomoc", "Ciudad de México", "02459", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0421" },
                    { 265, "0", "02", "09", "002", "02431", "09", "La Preciosa", "Ciudad de México", "02460", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0422" },
                    { 266, "0", "02", "09", "002", "02431", "09", "Ampliación Petrolera", "Ciudad de México", "02470", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0423" },
                    { 267, "0", "02", "09", "002", "02431", "09", "Petrolera", "Ciudad de México", "02480", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0425" },
                    { 268, "0", "02", "09", "002", "02431", "02", "San Mateo", "Ciudad de México", "02490", "02431", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0427" },
                    { 269, "0", "02", "09", "002", "02011", "09", "Unidad Cuitláhuac", "Ciudad de México", "02500", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0428" },
                    { 270, "0", "02", "09", "002", "02011", "09", "El Jagüey", "Ciudad de México", "02519", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0430" },
                    { 271, "0", "02", "09", "002", "02601", "17", "Estación Pantaco", "Ciudad de México", "02520", "02601", "Ciudad de México", "Azcapotzalco", "Equipamiento", "Urbano", "0431" },
                    { 272, "0", "02", "09", "002", "02011", "09", "Jardín Azpeitia", "Ciudad de México", "02530", "02011", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0439" },
                    { 273, "0", "02", "09", "002", "02601", "09", "Pro-Hogar", "Ciudad de México", "02600", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0441" },
                    { 274, "0", "02", "09", "002", "02601", "02", "Coltongo", "Ciudad de México", "02630", "02601", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0443" },
                    { 275, "0", "02", "09", "002", "02601", "09", "Coltongo", "Ciudad de México", "02630", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "2798" },
                    { 276, "0", "02", "09", "002", "02601", "09", "Monte Alto", "Ciudad de México", "02640", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0444" },
                    { 277, "0", "02", "09", "002", "02601", "09", "Trabajadores de Hierro", "Ciudad de México", "02650", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0445" },
                    { 278, "0", "02", "09", "002", "02601", "09", "Euzkadi", "Ciudad de México", "02660", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0446" },
                    { 279, "0", "02", "09", "002", "02601", "09", "Cosmopolita", "Ciudad de México", "02670", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0447" },
                    { 280, "0", "02", "09", "002", "02601", "09", "Potrero del Llano", "Ciudad de México", "02680", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0448" },
                    { 281, "0", "02", "09", "002", "02431", "28", "San Miguel Amantla", "Ciudad de México", "02700", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0449" },
                    { 282, "0", "02", "09", "002", "02431", "28", "San Pedro Xalpa", "Ciudad de México", "02710", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0451" },
                    { 283, "0", "02", "09", "002", "02431", "09", "Ampliación San Pedro Xalpa", "Ciudad de México", "02719", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0454" },
                    { 284, "0", "02", "09", "002", "02431", "09", "San Antonio", "Ciudad de México", "02720", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0456" },
                    { 285, "0", "02", "09", "002", "02431", "28", "San Bartolo Cahualtongo", "Ciudad de México", "02720", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0457" },
                    { 286, "0", "02", "09", "002", "02431", "28", "San Francisco Tetecala", "Ciudad de México", "02730", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0459" },
                    { 287, "0", "02", "09", "002", "02431", "28", "Santiago Ahuizotla", "Ciudad de México", "02750", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0461" },
                    { 288, "0", "02", "09", "002", "02431", "09", "Industrial San Antonio", "Ciudad de México", "02760", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0462" },
                    { 289, "0", "02", "09", "002", "02431", "02", "Santa Lucía", "Ciudad de México", "02760", "02431", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0463" },
                    { 290, "0", "02", "09", "002", "02431", "28", "Santa Cruz Acayucan", "Ciudad de México", "02770", "02431", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0464" },
                    { 291, "0", "02", "09", "002", "02431", "09", "Plenitud", "Ciudad de México", "02780", "02431", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0465" },
                    { 292, "0", "02", "09", "002", "02431", "02", "Santa Apolonia", "Ciudad de México", "02790", "02431", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0466" },
                    { 293, "0", "02", "09", "002", "02601", "09", "Nueva Santa María", "Ciudad de México", "02800", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0467" },
                    { 294, "0", "02", "09", "002", "02601", "09", "Ignacio Allende", "Ciudad de México", "02810", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0469" },
                    { 295, "0", "02", "09", "002", "02601", "09", "Victoria de las Democracias", "Ciudad de México", "02810", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0470" },
                    { 296, "0", "02", "09", "002", "02601", "02", "San Bernabé", "Ciudad de México", "02830", "02601", "Ciudad de México", "Azcapotzalco", "Barrio", "Urbano", "0473" },
                    { 297, "0", "02", "09", "002", "02601", "09", "Obrero Popular", "Ciudad de México", "02840", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0474" },
                    { 298, "0", "02", "09", "002", "02601", "09", "Tlatilco", "Ciudad de México", "02860", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0476" },
                    { 299, "0", "02", "09", "002", "02601", "09", "San Salvador Xochimanca", "Ciudad de México", "02870", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0477" },
                    { 300, "0", "02", "09", "002", "02601", "09", "Aguilera", "Ciudad de México", "02900", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0478" },
                    { 301, "0", "02", "09", "002", "02601", "09", "Aldana", "Ciudad de México", "02910", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0479" },
                    { 302, "0", "02", "09", "002", "02601", "09", "Ampliación Cosmopolita", "Ciudad de México", "02920", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0480" },
                    { 303, "0", "02", "09", "002", "02601", "09", "Liberación", "Ciudad de México", "02930", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0481" },
                    { 304, "0", "02", "09", "002", "02601", "09", "Porvenir", "Ciudad de México", "02940", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0482" },
                    { 305, "0", "02", "09", "002", "02601", "09", "Del Gas", "Ciudad de México", "02950", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0483" },
                    { 306, "0", "02", "09", "002", "02601", "28", "San Francisco Xocotitla", "Ciudad de México", "02960", "02601", "Ciudad de México", "Azcapotzalco", "Pueblo", "Urbano", "0484" },
                    { 307, "0", "02", "09", "002", "02601", "09", "Ampliación Del Gas", "Ciudad de México", "02970", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0485" },
                    { 308, "0", "02", "09", "002", "02601", "09", "Arenal", "Ciudad de México", "02980", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0486" },
                    { 309, "0", "02", "09", "002", "02601", "09", "Patrimonio Familiar", "Ciudad de México", "02980", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0487" },
                    { 310, "0", "02", "09", "002", "02601", "09", "La Raza", "Ciudad de México", "02990", "02601", "Ciudad de México", "Azcapotzalco", "Colonia", "Urbano", "0488" },
                    { 311, "0", "03", "09", "014", "03001", "09", "Piedad Narvarte", "Ciudad de México", "03000", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0489" },
                    { 312, "0", "03", "09", "014", "03001", "09", "Atenor Salas", "Ciudad de México", "03010", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0491" },
                    { 313, "0", "03", "09", "014", "03001", "09", "Narvarte Poniente", "Ciudad de México", "03020", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0493" },
                    { 314, "0", "03", "09", "014", "03001", "09", "Narvarte Oriente", "Ciudad de México", "03023", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "2623" },
                    { 315, "0", "03", "09", "014", "03001", "09", "Del Valle Centro", "Ciudad de México", "03100", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0496" },
                    { 316, "0", "03", "09", "014", "03001", "09", "Insurgentes San Borja", "Ciudad de México", "03100", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "2624" },
                    { 317, "0", "03", "09", "014", "03001", "09", "Del Valle Norte", "Ciudad de México", "03103", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "2621" },
                    { 318, "0", "03", "09", "014", "03001", "09", "Del Valle Sur", "Ciudad de México", "03104", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "2622" },
                    { 319, "0", "03", "09", "014", "03001", "09", "Tlacoquemécatl", "Ciudad de México", "03200", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0501" },
                    { 320, "0", "03", "09", "014", "03001", "09", "Actipan", "Ciudad de México", "03230", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0505" },
                    { 321, "0", "03", "09", "014", "03001", "09", "Acacias", "Ciudad de México", "03240", "03001", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0506" },
                    { 322, "0", "03", "09", "014", "03501", "09", "Portales Sur", "Ciudad de México", "03300", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0507" },
                    { 323, "0", "03", "09", "014", "03501", "09", "Portales Norte", "Ciudad de México", "03303", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "2625" },
                    { 324, "0", "03", "09", "014", "03501", "09", "Santa Cruz Atoyac", "Ciudad de México", "03310", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0509" },
                    { 325, "0", "03", "09", "014", "03501", "09", "Residencial Emperadores", "Ciudad de México", "03320", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0512" },
                    { 326, "0", "03", "09", "014", "03501", "09", "Xoco", "Ciudad de México", "03330", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0513" },
                    { 327, "0", "03", "09", "014", "03501", "09", "General Pedro María Anaya", "Ciudad de México", "03340", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0515" },
                    { 328, "0", "03", "09", "014", "03501", "09", "Álamos", "Ciudad de México", "03400", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0516" },
                    { 329, "0", "03", "09", "014", "03501", "09", "Postal", "Ciudad de México", "03410", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0518" },
                    { 330, "0", "03", "09", "014", "03501", "09", "Miguel Alemán", "Ciudad de México", "03420", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0519" },
                    { 331, "0", "03", "09", "014", "03501", "09", "Josefa Ortiz de Domínguez", "Ciudad de México", "03430", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0521" },
                    { 332, "0", "03", "09", "014", "03501", "09", "Niños Héroes", "Ciudad de México", "03440", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0522" },
                    { 333, "0", "03", "09", "014", "03501", "09", "Nativitas", "Ciudad de México", "03500", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0523" },
                    { 334, "0", "03", "09", "014", "03501", "09", "Moderna", "Ciudad de México", "03510", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0525" },
                    { 335, "0", "03", "09", "014", "03501", "09", "Iztaccihuatl", "Ciudad de México", "03520", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0526" },
                    { 336, "0", "03", "09", "014", "03501", "09", "Villa de Cortes", "Ciudad de México", "03530", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0527" },
                    { 337, "0", "03", "09", "014", "03501", "09", "Del Carmen", "Ciudad de México", "03540", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0528" },
                    { 338, "0", "03", "09", "014", "03501", "09", "Zacahuitzco", "Ciudad de México", "03550", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0529" },
                    { 339, "0", "03", "09", "014", "03501", "09", "Albert", "Ciudad de México", "03560", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0530" },
                    { 340, "0", "03", "09", "014", "03501", "09", "Portales Oriente", "Ciudad de México", "03570", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0531" },
                    { 341, "0", "03", "09", "014", "03501", "09", "Miravalle", "Ciudad de México", "03580", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0532" },
                    { 342, "0", "03", "09", "014", "03501", "09", "Ermita", "Ciudad de México", "03590", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0533" },
                    { 343, "0", "03", "09", "014", "03501", "09", "Vértiz Narvarte", "Ciudad de México", "03600", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0534" },
                    { 344, "0", "03", "09", "014", "03501", "09", "Américas Unidas", "Ciudad de México", "03610", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0535" },
                    { 345, "0", "03", "09", "014", "03501", "09", "Periodista", "Ciudad de México", "03620", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0536" },
                    { 346, "0", "03", "09", "014", "03501", "09", "Independencia", "Ciudad de México", "03630", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0537" },
                    { 347, "0", "03", "09", "014", "03501", "09", "Del Lago", "Ciudad de México", "03640", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0538" },
                    { 348, "0", "03", "09", "014", "03501", "09", "Letrán Valle", "Ciudad de México", "03650", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0539" },
                    { 349, "0", "03", "09", "014", "03501", "09", "San Simón Ticumac", "Ciudad de México", "03660", "03501", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0540" },
                    { 350, "0", "03", "09", "014", "03901", "09", "Santa María Nonoalco", "Ciudad de México", "03700", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0541" },
                    { 351, "0", "03", "09", "014", "03901", "09", "Ciudad de los Deportes", "Ciudad de México", "03710", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0542" },
                    { 352, "0", "03", "09", "014", "03901", "09", "Nochebuena", "Ciudad de México", "03720", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0543" },
                    { 353, "0", "03", "09", "014", "03901", "09", "San Juan", "Ciudad de México", "03730", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0544" },
                    { 354, "0", "03", "09", "014", "03901", "09", "Extremadura Insurgentes", "Ciudad de México", "03740", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0545" },
                    { 355, "0", "03", "09", "014", "03901", "09", "San Pedro de los Pinos", "Ciudad de México", "03800", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0546" },
                    { 356, "0", "03", "09", "014", "03901", "09", "Nápoles", "Ciudad de México", "03810", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0548" },
                    { 357, "0", "03", "09", "014", "03901", "09", "8 de Agosto", "Ciudad de México", "03820", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0552" },
                    { 358, "0", "03", "09", "014", "03901", "09", "Ampliación Nápoles", "Ciudad de México", "03840", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0554" },
                    { 359, "0", "03", "09", "014", "03901", "09", "San José Insurgentes", "Ciudad de México", "03900", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0556" },
                    { 360, "0", "03", "09", "014", "03901", "09", "Mixcoac", "Ciudad de México", "03910", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0558" },
                    { 361, "0", "03", "09", "014", "03901", "09", "Insurgentes Mixcoac", "Ciudad de México", "03920", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0559" },
                    { 362, "0", "03", "09", "014", "03901", "09", "Merced Gómez", "Ciudad de México", "03930", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0561" },
                    { 363, "0", "03", "09", "014", "03901", "09", "Crédito Constructor", "Ciudad de México", "03940", "03901", "Ciudad de México", "Benito Juárez", "Colonia", "Urbano", "0562" },
                    { 364, "0", "04", "09", "003", "03501", "09", "Villa Coyoacán", "Ciudad de México", "04000", "03501", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0563" },
                    { 365, "0", "04", "09", "003", "03501", "02", "Santa Catarina", "Ciudad de México", "04010", "03501", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0566" },
                    { 366, "0", "04", "09", "003", "03501", "02", "La Concepción", "Ciudad de México", "04020", "03501", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0567" },
                    { 367, "0", "04", "09", "003", "03501", "02", "San Lucas", "Ciudad de México", "04030", "03501", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0569" },
                    { 368, "0", "04", "09", "003", "03501", "09", "Parque San Andrés", "Ciudad de México", "04040", "03501", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0570" },
                    { 369, "0", "04", "09", "003", "03501", "09", "Del Carmen", "Ciudad de México", "04100", "03501", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0571" },
                    { 370, "0", "04", "09", "003", "03501", "09", "San Diego Churubusco", "Ciudad de México", "04120", "03501", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0577" },
                    { 371, "0", "04", "09", "003", "03501", "09", "San Mateo", "Ciudad de México", "04120", "03501", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0578" },
                    { 372, "0", "04", "09", "003", "04831", "09", "Campestre Churubusco", "Ciudad de México", "04200", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0580" },
                    { 373, "0", "04", "09", "003", "04831", "09", "Churubusco Country Club", "Ciudad de México", "04210", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0582" },
                    { 374, "0", "04", "09", "003", "04831", "09", "Prado Churubusco", "Ciudad de México", "04230", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0584" },
                    { 375, "0", "04", "09", "003", "04831", "09", "Hermosillo", "Ciudad de México", "04240", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0586" },
                    { 376, "0", "04", "09", "003", "04831", "09", "Paseos de Taxqueña", "Ciudad de México", "04250", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0587" },
                    { 377, "0", "04", "09", "003", "04831", "02", "San Francisco Culhuacán Barrio de San Francisco", "Ciudad de México", "04260", "04831", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0590" },
                    { 378, "0", "04", "09", "003", "04831", "02", "San Francisco Culhuacán Barrio de La Magdalena", "Ciudad de México", "04260", "04831", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "2807" },
                    { 379, "0", "04", "09", "003", "04831", "02", "San Francisco Culhuacán Barrio de Santa Ana", "Ciudad de México", "04260", "04831", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "2808" },
                    { 380, "0", "04", "09", "003", "04831", "02", "San Francisco Culhuacán Barrio de San Juan", "Ciudad de México", "04260", "04831", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "2831" },
                    { 381, "0", "04", "09", "003", "04831", "09", "Ajusco", "Ciudad de México", "04300", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0596" },
                    { 382, "0", "04", "09", "003", "04831", "09", "Romero de Terreros", "Ciudad de México", "04310", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0601" },
                    { 383, "0", "04", "09", "003", "04831", "02", "Oxtopulco Universidad", "Ciudad de México", "04318", "04831", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0603" },
                    { 384, "0", "04", "09", "003", "04831", "09", "Cuadrante de San Francisco", "Ciudad de México", "04320", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0606" },
                    { 385, "0", "04", "09", "003", "04831", "09", "Pedregal de San Francisco", "Ciudad de México", "04320", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0608" },
                    { 386, "0", "04", "09", "003", "04331", "09", "El Rosedal", "Ciudad de México", "04330", "04331", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0612" },
                    { 387, "0", "04", "09", "003", "04331", "28", "Los Reyes", "Ciudad de México", "04330", "04331", "Ciudad de México", "Coyoacán", "Pueblo", "Urbano", "0613" },
                    { 388, "0", "04", "09", "003", "04331", "02", "Del Niño Jesús", "Ciudad de México", "04330", "04331", "Ciudad de México", "Coyoacán", "Barrio", "Urbano", "0614" },
                    { 389, "0", "04", "09", "003", "04831", "09", "Copilco El Bajo", "Ciudad de México", "04340", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0622" },
                    { 390, "0", "04", "09", "003", "04831", "09", "Copilco El Alto", "Ciudad de México", "04360", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0632" },
                    { 391, "0", "04", "09", "003", "04831", "09", "Copilco Universidad", "Ciudad de México", "04360", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0633" },
                    { 392, "0", "04", "09", "003", "04831", "09", "Pedregal de Santo Domingo", "Ciudad de México", "04369", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0636" },
                    { 393, "0", "04", "09", "003", "04831", "09", "Atlántida", "Ciudad de México", "04370", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0637" },
                    { 394, "0", "04", "09", "003", "04831", "09", "Ciudad Jardín", "Ciudad de México", "04370", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0638" },
                    { 395, "0", "04", "09", "003", "04831", "09", "El Rosario", "Ciudad de México", "04380", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0640" },
                    { 396, "0", "04", "09", "003", "04831", "28", "La Candelaria", "Ciudad de México", "04380", "04831", "Ciudad de México", "Coyoacán", "Pueblo", "Urbano", "0641" },
                    { 397, "0", "04", "09", "003", "04831", "09", "Huayamilpas", "Ciudad de México", "04390", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0643" },
                    { 398, "0", "04", "09", "003", "04831", "09", "Nueva Díaz Ordaz", "Ciudad de México", "04390", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0644" },
                    { 399, "0", "04", "09", "003", "04831", "09", "Educación", "Ciudad de México", "04400", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0645" },
                    { 400, "0", "04", "09", "003", "04831", "09", "Petrolera Taxqueña", "Ciudad de México", "04410", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0646" },
                    { 401, "0", "04", "09", "003", "04831", "09", "Ex-Ejido de San Francisco Culhuacán", "Ciudad de México", "04420", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0649" },
                    { 402, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección V", "Ciudad de México", "04440", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0651" },
                    { 403, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección II", "Ciudad de México", "04440", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2810" },
                    { 404, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección I", "Ciudad de México", "04440", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2811" },
                    { 405, "0", "04", "09", "003", "04831", "09", "El Centinela", "Ciudad de México", "04450", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0652" },
                    { 406, "0", "04", "09", "003", "04831", "09", "Avante", "Ciudad de México", "04460", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0653" },
                    { 407, "0", "04", "09", "003", "04831", "09", "Presidentes Ejidales 1a Sección", "Ciudad de México", "04470", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0655" },
                    { 408, "0", "04", "09", "003", "04831", "09", "Presidentes Ejidales 2a Sección", "Ciudad de México", "04470", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2805" },
                    { 409, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección VI", "Ciudad de México", "04480", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0657" },
                    { 410, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección III", "Ciudad de México", "04480", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2809" },
                    { 411, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM CROC", "Ciudad de México", "04480", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2812" },
                    { 412, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección X-A", "Ciudad de México", "04480", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2815" },
                    { 413, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección VII", "Ciudad de México", "04489", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0658" },
                    { 414, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección Piloto", "Ciudad de México", "04490", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0659" },
                    { 415, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Canal Nacional", "Ciudad de México", "04490", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2813" },
                    { 416, "0", "04", "09", "003", "14391", "09", "Jardines del Pedregal de San Ángel", "Ciudad de México", "04500", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0660" },
                    { 417, "0", "04", "09", "003", "04831", "17", "Universidad Nacional Autónoma de México", "Ciudad de México", "04510", "04831", "Ciudad de México", "Coyoacán", "Equipamiento", "Urbano", "2793" },
                    { 418, "0", "04", "09", "003", "04831", "09", "La Otra Banda", "Ciudad de México", "04519", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0664" },
                    { 419, "0", "04", "09", "003", "14391", "09", "Insurgentes Cuicuilco", "Ciudad de México", "04530", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0665" },
                    { 420, "0", "04", "09", "003", "14391", "09", "Pedregal de Santa Úrsula", "Ciudad de México", "04600", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0669" },
                    { 421, "0", "04", "09", "003", "04831", "09", "Xotepingo", "Ciudad de México", "04610", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0670" },
                    { 422, "0", "04", "09", "003", "04831", "28", "San Pablo Tepetlapa", "Ciudad de México", "04620", "04831", "Ciudad de México", "Coyoacán", "Pueblo", "Urbano", "0671" },
                    { 423, "0", "04", "09", "003", "04831", "09", "Adolfo Ruiz Cortínes", "Ciudad de México", "04630", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0672" },
                    { 424, "0", "04", "09", "003", "04831", "09", "El Reloj", "Ciudad de México", "04640", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0673" },
                    { 425, "0", "04", "09", "003", "14391", "28", "Santa Úrsula Coapa", "Ciudad de México", "04650", "14391", "Ciudad de México", "Coyoacán", "Pueblo", "Urbano", "0676" },
                    { 426, "0", "04", "09", "003", "14391", "09", "Joyas del Pedregal", "Ciudad de México", "04660", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0677" },
                    { 427, "0", "04", "09", "003", "14391", "09", "Pedregal de Carrasco", "Ciudad de México", "04700", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0678" },
                    { 428, "0", "04", "09", "003", "14391", "09", "Olímpica", "Ciudad de México", "04710", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0680" },
                    { 429, "0", "04", "09", "003", "14391", "09", "Cantil del Pedregal", "Ciudad de México", "04730", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0686" },
                    { 430, "0", "04", "09", "003", "14391", "09", "Bosques de Tetlameya", "Ciudad de México", "04730", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0687" },
                    { 431, "0", "04", "09", "003", "14391", "09", "El Caracol", "Ciudad de México", "04739", "14391", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0690" },
                    { 432, "0", "04", "09", "003", "04831", "09", "Alianza Popular Revolucionaria", "Ciudad de México", "04800", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0691" },
                    { 433, "0", "04", "09", "003", "04831", "09", "Los Cedros", "Ciudad de México", "04800", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0692" },
                    { 434, "0", "04", "09", "003", "04831", "09", "Prados de Coyoacán", "Ciudad de México", "04810", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0695" },
                    { 435, "0", "04", "09", "003", "04831", "09", "Emiliano Zapata", "Ciudad de México", "04815", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0696" },
                    { 436, "0", "04", "09", "003", "04831", "09", "Los Cipreses", "Ciudad de México", "04830", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0697" },
                    { 437, "0", "04", "09", "003", "04831", "09", "Ex-Ejido de San Pablo Tepetlapa", "Ciudad de México", "04840", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2806" },
                    { 438, "0", "04", "09", "003", "04831", "09", "Espartaco", "Ciudad de México", "04870", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0706" },
                    { 439, "0", "04", "09", "003", "04831", "09", "Jardines de Coyoacán", "Ciudad de México", "04890", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0708" },
                    { 440, "0", "04", "09", "003", "04831", "09", "Los Olivos", "Ciudad de México", "04890", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0709" },
                    { 441, "0", "04", "09", "003", "04831", "09", "El Parque de Coyoacán", "Ciudad de México", "04899", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0711" },
                    { 442, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección VIII", "Ciudad de México", "04909", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0714" },
                    { 443, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección IX-A", "Ciudad de México", "04909", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0715" },
                    { 444, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección IX-B", "Ciudad de México", "04909", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2814" },
                    { 445, "0", "04", "09", "003", "04831", "09", "Carmen Serdán", "Ciudad de México", "04910", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0716" },
                    { 446, "0", "04", "09", "003", "04831", "09", "Cafetales", "Ciudad de México", "04918", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0717" },
                    { 447, "0", "04", "09", "003", "04831", "09", "Emiliano Zapata Fraccionamiento Popular", "Ciudad de México", "04919", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0718" },
                    { 448, "0", "04", "09", "003", "04831", "09", "Los Girasoles", "Ciudad de México", "04920", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0719" },
                    { 449, "0", "04", "09", "003", "04831", "09", "Las Campanas", "Ciudad de México", "04929", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0723" },
                    { 450, "0", "04", "09", "003", "04831", "09", "Santa Cecilia", "Ciudad de México", "04930", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0724" },
                    { 451, "0", "04", "09", "003", "04831", "09", "Campestre Coyoacán", "Ciudad de México", "04938", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0725" },
                    { 452, "0", "04", "09", "003", "04831", "09", "Culhuacán CTM Sección X", "Ciudad de México", "04939", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0726" },
                    { 453, "0", "04", "09", "003", "04831", "09", "Los Sauces", "Ciudad de México", "04940", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0727" },
                    { 454, "0", "04", "09", "003", "04831", "09", "El Mirador", "Ciudad de México", "04950", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0728" },
                    { 455, "0", "04", "09", "003", "04831", "09", "Villa Quietud", "Ciudad de México", "04960", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0729" },
                    { 456, "0", "04", "09", "003", "04831", "09", "Haciendas de Coyoacán", "Ciudad de México", "04970", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0730" },
                    { 457, "0", "04", "09", "003", "04831", "09", "Ex-Ejido de Santa Úrsula Coapa", "Ciudad de México", "04980", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0674" },
                    { 458, "0", "04", "09", "003", "04831", "09", "Ex-Hacienda Coapa", "Ciudad de México", "04980", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "0731" },
                    { 459, "0", "04", "09", "003", "04831", "09", "Viejo Ejido de Santa Úrsula Coapa", "Ciudad de México", "04980", "04831", "Ciudad de México", "Coyoacán", "Colonia", "Urbano", "2792" },
                    { 460, "0", "05", "09", "004", "05501", "09", "Cuajimalpa", "Ciudad de México", "05000", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0732" },
                    { 461, "0", "05", "09", "004", "05501", "09", "Zentlapatl", "Ciudad de México", "05010", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0735" },
                    { 462, "0", "05", "09", "004", "05501", "09", "Loma del Padre", "Ciudad de México", "05020", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0736" },
                    { 463, "0", "05", "09", "004", "05501", "09", "San Pedro", "Ciudad de México", "05030", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0737" },
                    { 464, "0", "05", "09", "004", "05501", "09", "La Manzanita", "Ciudad de México", "05030", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "2867" },
                    { 465, "0", "05", "09", "004", "05501", "28", "San Pablo Chimalpa", "Ciudad de México", "05050", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Pueblo", "Urbano", "0740" },
                    { 466, "0", "05", "09", "004", "05501", "09", "Lomas de Vista Hermosa", "Ciudad de México", "05100", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0746" },
                    { 467, "0", "05", "09", "004", "05501", "09", "Cooperativa Palo Alto", "Ciudad de México", "05110", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0748" },
                    { 468, "0", "05", "09", "004", "05501", "09", "Granjas Palo Alto", "Ciudad de México", "05118", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0751" },
                    { 469, "0", "05", "09", "004", "05501", "09", "Campestre Palo Alto", "Ciudad de México", "05119", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0752" },
                    { 470, "0", "05", "09", "004", "05501", "09", "Bosques de las Lomas", "Ciudad de México", "05120", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0753" },
                    { 471, "0", "05", "09", "004", "05501", "09", "Lomas del Chamizal", "Ciudad de México", "05129", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0758" },
                    { 472, "0", "05", "09", "004", "05501", "09", "San José de los Cedros", "Ciudad de México", "05200", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0766" },
                    { 473, "0", "05", "09", "004", "05501", "09", "Granjas Navidad", "Ciudad de México", "05219", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0768" },
                    { 474, "0", "05", "09", "004", "05501", "09", "Tepetongo", "Ciudad de México", "05220", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0769" },
                    { 475, "0", "05", "09", "004", "05501", "09", "El Ébano", "Ciudad de México", "05230", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0770" },
                    { 476, "0", "05", "09", "004", "05501", "09", "El Molino", "Ciudad de México", "05240", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0774" },
                    { 477, "0", "05", "09", "004", "05501", "09", "Jesús del Monte", "Ciudad de México", "05260", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0777" },
                    { 478, "0", "05", "09", "004", "05501", "09", "Amado Nervo", "Ciudad de México", "05269", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0780" },
                    { 479, "0", "05", "09", "004", "05501", "09", "Manzanastitla", "Ciudad de México", "05270", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0782" },
                    { 480, "0", "05", "09", "004", "05501", "09", "Adolfo López Mateos", "Ciudad de México", "05280", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0783" },
                    { 481, "0", "05", "09", "004", "05501", "09", "El Molinito", "Ciudad de México", "05310", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0785" },
                    { 482, "0", "05", "09", "004", "05501", "09", "El Yaqui", "Ciudad de México", "05320", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0786" },
                    { 483, "0", "05", "09", "004", "05501", "09", "Lomas de Memetla", "Ciudad de México", "05330", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0787" },
                    { 484, "0", "05", "09", "004", "05501", "09", "Memetla", "Ciudad de México", "05330", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0788" },
                    { 485, "0", "05", "09", "004", "05501", "09", "Ampliación Memetla", "Ciudad de México", "05330", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0789" },
                    { 486, "0", "05", "09", "004", "05501", "09", "Ampliación el Yaqui", "Ciudad de México", "05330", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "2869" },
                    { 487, "0", "05", "09", "004", "05501", "09", "Santa Fe Cuajimalpa", "Ciudad de México", "05348", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0792" },
                    { 488, "0", "05", "09", "004", "05501", "09", "Locaxco", "Ciudad de México", "05360", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0794" },
                    { 489, "0", "05", "09", "004", "05501", "09", "Las Tinajas", "Ciudad de México", "05370", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0797" },
                    { 490, "0", "05", "09", "004", "05501", "09", "Lomas de San Pedro", "Ciudad de México", "05379", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0799" },
                    { 491, "0", "05", "09", "004", "05501", "09", "El Tianguillo", "Ciudad de México", "05400", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0800" },
                    { 492, "0", "05", "09", "004", "05501", "28", "San Lorenzo Acopilco", "Ciudad de México", "05410", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Pueblo", "Urbano", "0801" },
                    { 493, "0", "05", "09", "004", "05501", "09", "1° de Mayo", "Ciudad de México", "05410", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "2866" },
                    { 494, "0", "05", "09", "004", "05501", "09", "Contadero", "Ciudad de México", "05500", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0803" },
                    { 495, "0", "05", "09", "004", "05501", "09", "La Venta", "Ciudad de México", "05520", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0808" },
                    { 496, "0", "05", "09", "004", "05501", "09", "Abdías García Soto", "Ciudad de México", "05530", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0809" },
                    { 497, "0", "05", "09", "004", "05501", "28", "San Mateo Tlaltenango", "Ciudad de México", "05600", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Pueblo", "Urbano", "0810" },
                    { 498, "0", "05", "09", "004", "05501", "28", "Santa Rosa Xochiac", "Ciudad de México", "05610", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Pueblo", "Urbano", "2868" },
                    { 499, "0", "05", "09", "004", "05501", "09", "Cruz Blanca", "Ciudad de México", "05700", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0819" },
                    { 500, "0", "05", "09", "004", "05501", "09", "Las Maromas", "Ciudad de México", "05710", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0820" },
                    { 501, "0", "05", "09", "004", "05501", "09", "Xalpa", "Ciudad de México", "05730", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0825" },
                    { 502, "0", "05", "09", "004", "05501", "09", "La Pila", "Ciudad de México", "05750", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0827" },
                    { 503, "0", "05", "09", "004", "05501", "09", "Las Lajas", "Ciudad de México", "05760", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0829" },
                    { 504, "0", "05", "09", "004", "05501", "09", "Agua Bendita", "Ciudad de México", "05780", "05501", "Ciudad de México", "Cuajimalpa de Morelos", "Colonia", "Urbano", "0833" },
                    { 505, "0", "06", "09", "015", "06002", "09", "Centro (Área 1)", "Ciudad de México", "06000", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0838" },
                    { 506, "0", "06", "09", "015", "06002", "09", "Centro (Área 2)", "Ciudad de México", "06010", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0847" },
                    { 507, "0", "06", "09", "015", "06002", "09", "Centro (Área 3)", "Ciudad de México", "06020", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0850" },
                    { 508, "0", "06", "09", "015", "06002", "09", "Tabacalera", "Ciudad de México", "06030", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0853" },
                    { 509, "0", "06", "09", "015", "06002", "09", "Centro (Área 4)", "Ciudad de México", "06040", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0860" },
                    { 510, "0", "06", "09", "015", "06002", "09", "Centro (Área 5)", "Ciudad de México", "06050", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0863" },
                    { 511, "0", "06", "09", "015", "06002", "09", "Centro (Área 6)", "Ciudad de México", "06060", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0867" },
                    { 512, "0", "06", "09", "015", "06002", "09", "Centro (Área 7)", "Ciudad de México", "06070", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0873" },
                    { 513, "0", "06", "09", "015", "06002", "09", "Centro (Área 8)", "Ciudad de México", "06080", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0875" },
                    { 514, "0", "06", "09", "015", "06002", "09", "Centro (Área 9)", "Ciudad de México", "06090", "06002", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0879" },
                    { 515, "0", "06", "09", "015", "06401", "09", "Hipódromo", "Ciudad de México", "06100", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0882" },
                    { 516, "0", "06", "09", "015", "06401", "09", "Condesa", "Ciudad de México", "06140", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0884" },
                    { 517, "0", "06", "09", "015", "06401", "09", "Hipódromo Condesa", "Ciudad de México", "06170", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0886" },
                    { 518, "0", "06", "09", "015", "06401", "09", "Morelos", "Ciudad de México", "06200", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0891" },
                    { 519, "0", "06", "09", "015", "06401", "09", "Peralvillo", "Ciudad de México", "06220", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0894" },
                    { 520, "0", "06", "09", "015", "06401", "09", "Valle Gómez", "Ciudad de México", "06240", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0895" },
                    { 521, "0", "06", "09", "015", "06401", "09", "Ex-Hipódromo de Peralvillo", "Ciudad de México", "06250", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0896" },
                    { 522, "0", "06", "09", "015", "06401", "09", "Maza", "Ciudad de México", "06270", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0898" },
                    { 523, "0", "06", "09", "015", "06401", "09", "Felipe Pescador", "Ciudad de México", "06280", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0899" },
                    { 524, "0", "06", "09", "015", "06401", "09", "Guerrero", "Ciudad de México", "06300", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0900" },
                    { 525, "0", "06", "09", "015", "06401", "09", "Buenavista", "Ciudad de México", "06350", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0906" },
                    { 526, "0", "06", "09", "015", "06401", "09", "Santa María la Ribera", "Ciudad de México", "06400", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0911" },
                    { 527, "0", "06", "09", "015", "06401", "09", "Santa María Insurgentes", "Ciudad de México", "06430", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0913" },
                    { 528, "0", "06", "09", "015", "06401", "09", "Atlampa", "Ciudad de México", "06450", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0914" },
                    { 529, "0", "06", "09", "015", "06401", "09", "San Rafael", "Ciudad de México", "06470", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0915" },
                    { 530, "0", "06", "09", "015", "06401", "09", "Cuauhtémoc", "Ciudad de México", "06500", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0919" },
                    { 531, "0", "06", "09", "015", "06401", "09", "Juárez", "Ciudad de México", "06600", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0930" },
                    { 532, "0", "06", "09", "015", "06401", "09", "Roma Norte", "Ciudad de México", "06700", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0947" },
                    { 533, "0", "06", "09", "015", "06401", "09", "Doctores", "Ciudad de México", "06720", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0955" },
                    { 534, "0", "06", "09", "015", "06401", "09", "Roma Sur", "Ciudad de México", "06760", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0966" },
                    { 535, "0", "06", "09", "015", "06401", "09", "Buenos Aires", "Ciudad de México", "06780", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0970" },
                    { 536, "0", "06", "09", "015", "06401", "09", "Obrera", "Ciudad de México", "06800", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0974" },
                    { 537, "0", "06", "09", "015", "06401", "09", "Tránsito", "Ciudad de México", "06820", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0978" },
                    { 538, "0", "06", "09", "015", "06401", "09", "Esperanza", "Ciudad de México", "06840", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0980" },
                    { 539, "0", "06", "09", "015", "06401", "09", "Asturias", "Ciudad de México", "06850", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0981" },
                    { 540, "0", "06", "09", "015", "06401", "09", "Vista Alegre", "Ciudad de México", "06860", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0982" },
                    { 541, "0", "06", "09", "015", "06401", "09", "Paulino Navarro", "Ciudad de México", "06870", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0983" },
                    { 542, "0", "06", "09", "015", "06401", "09", "Algarin", "Ciudad de México", "06880", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0984" },
                    { 543, "0", "06", "09", "015", "06401", "09", "Ampliación Asturias", "Ciudad de México", "06890", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0986" },
                    { 544, "0", "06", "09", "015", "06401", "09", "Nonoalco Tlatelolco", "Ciudad de México", "06900", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0988" },
                    { 545, "0", "06", "09", "015", "06401", "09", "San Simón Tolnáhuac", "Ciudad de México", "06920", "06401", "Ciudad de México", "Cuauhtémoc", "Colonia", "Urbano", "0989" },
                    { 546, "0", "07", "09", "005", "07001", "09", "Aragón la Villa", "Ciudad de México", "07000", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "0991" },
                    { 547, "0", "07", "09", "005", "07001", "09", "Rosas del Tepeyac", "Ciudad de México", "07010", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "0994" },
                    { 548, "0", "07", "09", "005", "07001", "09", "Santa Isabel Tola", "Ciudad de México", "07010", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "0995" },
                    { 549, "0", "07", "09", "005", "07001", "09", "Tepetates", "Ciudad de México", "07010", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "0996" },
                    { 550, "0", "07", "09", "005", "07001", "09", "Tepeyac Insurgentes", "Ciudad de México", "07020", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "0997" },
                    { 551, "0", "07", "09", "005", "07001", "28", "Santiago Atzacoalco", "Ciudad de México", "07040", "07001", "Ciudad de México", "Gustavo A. Madero", "Pueblo", "Urbano", "0998" },
                    { 552, "0", "07", "09", "005", "07001", "09", "Villa Gustavo A. Madero", "Ciudad de México", "07050", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1001" },
                    { 553, "0", "07", "09", "005", "07001", "09", "15 de Agosto", "Ciudad de México", "07058", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1003" },
                    { 554, "0", "07", "09", "005", "07001", "09", "Estanzuela", "Ciudad de México", "07060", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1005" },
                    { 555, "0", "07", "09", "005", "07001", "09", "Triunfo de La República", "Ciudad de México", "07069", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1006" },
                    { 556, "0", "07", "09", "005", "07001", "09", "La Cruz", "Ciudad de México", "07070", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1007" },
                    { 557, "0", "07", "09", "005", "07001", "09", "Dinamita", "Ciudad de México", "07070", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1008" },
                    { 558, "0", "07", "09", "005", "07001", "09", "Martín Carrera", "Ciudad de México", "07070", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1010" },
                    { 559, "0", "07", "09", "005", "07001", "09", "Gabriel Hernández", "Ciudad de México", "07080", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1011" },
                    { 560, "0", "07", "09", "005", "07001", "09", "Ampliación Gabriel Hernández", "Ciudad de México", "07089", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1012" },
                    { 561, "0", "07", "09", "005", "07001", "09", "C.T.M. Atzacoalco", "Ciudad de México", "07090", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1013" },
                    { 562, "0", "07", "09", "005", "07001", "09", "C.T.M. El Risco", "Ciudad de México", "07090", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1014" },
                    { 563, "0", "07", "09", "005", "07201", "09", "Cuautepec Barrio Alto", "Ciudad de México", "07100", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1016" },
                    { 564, "0", "07", "09", "005", "07201", "09", "San Miguel", "Ciudad de México", "07100", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1017" },
                    { 565, "0", "07", "09", "005", "07201", "09", "San Antonio", "Ciudad de México", "07109", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1019" },
                    { 566, "0", "07", "09", "005", "07201", "09", "Lomas de Cuautepec", "Ciudad de México", "07110", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1021" },
                    { 567, "0", "07", "09", "005", "07201", "09", "Malacates", "Ciudad de México", "07119", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1022" },
                    { 568, "0", "07", "09", "005", "07201", "09", "Ampliación Malacates", "Ciudad de México", "07119", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1227" },
                    { 569, "0", "07", "09", "005", "07201", "09", "Compositores Mexicanos", "Ciudad de México", "07130", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1023" },
                    { 570, "0", "07", "09", "005", "07201", "09", "El Tepetatal", "Ciudad de México", "07130", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1024" },
                    { 571, "0", "07", "09", "005", "07201", "09", "Arboledas", "Ciudad de México", "07140", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1026" },
                    { 572, "0", "07", "09", "005", "07201", "09", "Ampliación Arboledas", "Ciudad de México", "07140", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1027" },
                    { 573, "0", "07", "09", "005", "07201", "09", "Forestal", "Ciudad de México", "07140", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1028" },
                    { 574, "0", "07", "09", "005", "07201", "09", "Forestal I", "Ciudad de México", "07140", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1029" },
                    { 575, "0", "07", "09", "005", "07201", "09", "Forestal II", "Ciudad de México", "07144", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2885" },
                    { 576, "0", "07", "09", "005", "07201", "09", "La Lengüeta", "Ciudad de México", "07144", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2887" },
                    { 577, "0", "07", "09", "005", "07201", "09", "Parque Metropolitano", "Ciudad de México", "07149", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1031" },
                    { 578, "0", "07", "09", "005", "07201", "09", "Juventino Rosas", "Ciudad de México", "07150", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1032" },
                    { 579, "0", "07", "09", "005", "07201", "09", "La Casilda", "Ciudad de México", "07150", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1033" },
                    { 580, "0", "07", "09", "005", "07201", "09", "Loma La Palma", "Ciudad de México", "07160", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1034" },
                    { 581, "0", "07", "09", "005", "07201", "09", "Luis Donaldo Colosio", "Ciudad de México", "07164", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2548" },
                    { 582, "0", "07", "09", "005", "07201", "09", "Tlacaélel", "Ciudad de México", "07164", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2549" },
                    { 583, "0", "07", "09", "005", "07201", "09", "Graciano Sánchez", "Ciudad de México", "07164", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2717" },
                    { 584, "0", "07", "09", "005", "07201", "09", "Prados de Cuautepec", "Ciudad de México", "07164", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2718" },
                    { 585, "0", "07", "09", "005", "07201", "09", "Palmatitla", "Ciudad de México", "07170", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1035" },
                    { 586, "0", "07", "09", "005", "07201", "09", "Cocoyotes", "Ciudad de México", "07180", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1036" },
                    { 587, "0", "07", "09", "005", "07201", "09", "General Felipe Berriozabal", "Ciudad de México", "07180", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1037" },
                    { 588, "0", "07", "09", "005", "07201", "09", "Ampliación Cocoyotes", "Ciudad de México", "07180", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2687" },
                    { 589, "0", "07", "09", "005", "07201", "09", "6 de Junio", "Ciudad de México", "07183", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2688" },
                    { 590, "0", "07", "09", "005", "07201", "09", "Vista Hermosa", "Ciudad de México", "07187", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1038" },
                    { 591, "0", "07", "09", "005", "07201", "09", "Tlalpexco", "Ciudad de México", "07188", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1039" },
                    { 592, "0", "07", "09", "005", "07201", "09", "Ahuehuetes", "Ciudad de México", "07189", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1040" },
                    { 593, "0", "07", "09", "005", "07201", "09", "Valle de Madero", "Ciudad de México", "07190", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1041" },
                    { 594, "0", "07", "09", "005", "07201", "09", "Del Carmen", "Ciudad de México", "07199", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1042" },
                    { 595, "0", "07", "09", "005", "07201", "09", "Cuautepec de Madero", "Ciudad de México", "07200", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1043" },
                    { 596, "0", "07", "09", "005", "07201", "09", "Del Bosque", "Ciudad de México", "07207", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1046" },
                    { 597, "0", "07", "09", "005", "07201", "09", "Guadalupe Victoria Cuautepec", "Ciudad de México", "07209", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1048" },
                    { 598, "0", "07", "09", "005", "07201", "09", "Chalma de Guadalupe", "Ciudad de México", "07210", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1049" },
                    { 599, "0", "07", "09", "005", "07201", "09", "Ampliación Chalma de Guadalupe", "Ciudad de México", "07214", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2884" },
                    { 600, "0", "07", "09", "005", "07201", "09", "Castillo Chico", "Ciudad de México", "07220", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1051" },
                    { 601, "0", "07", "09", "005", "07201", "09", "Castillo Grande", "Ciudad de México", "07220", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1052" },
                    { 602, "0", "07", "09", "005", "07201", "09", "Ampliación Castillo Grande", "Ciudad de México", "07224", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2883" },
                    { 603, "0", "07", "09", "005", "07201", "09", "Zona Escolar", "Ciudad de México", "07230", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1053" },
                    { 604, "0", "07", "09", "005", "07201", "09", "Zona Escolar Oriente", "Ciudad de México", "07239", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1054" },
                    { 605, "0", "07", "09", "005", "07201", "09", "El Arbolillo", "Ciudad de México", "07240", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1056" },
                    { 606, "0", "07", "09", "005", "07201", "09", "Benito Juárez", "Ciudad de México", "07250", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1061" },
                    { 607, "0", "07", "09", "005", "07201", "09", "Ampliación Benito Juárez", "Ciudad de México", "07259", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1063" },
                    { 608, "0", "07", "09", "005", "07201", "09", "Solidaridad Nacional", "Ciudad de México", "07268", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1065" },
                    { 609, "0", "07", "09", "005", "07201", "09", "Residencial Acueducto de Guadalupe", "Ciudad de México", "07270", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1067" },
                    { 610, "0", "07", "09", "005", "07201", "09", "Acueducto de Guadalupe", "Ciudad de México", "07279", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1069" },
                    { 611, "0", "07", "09", "005", "07201", "09", "Jorge Negrete", "Ciudad de México", "07280", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1070" },
                    { 612, "0", "07", "09", "005", "07201", "09", "La Pastora", "Ciudad de México", "07290", "07201", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1071" },
                    { 613, "0", "07", "09", "005", "07051", "09", "Lindavista Norte", "Ciudad de México", "07300", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1072" },
                    { 614, "0", "07", "09", "005", "07051", "09", "Lindavista Sur", "Ciudad de México", "07300", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2888" },
                    { 615, "0", "07", "09", "005", "07311", "02", "Candelaria Ticomán", "Ciudad de México", "07310", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1075" },
                    { 616, "0", "07", "09", "005", "07311", "02", "La Purísima Ticomán", "Ciudad de México", "07320", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1079" },
                    { 617, "0", "07", "09", "005", "07311", "09", "Residencial la Escalera", "Ciudad de México", "07320", "07311", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1080" },
                    { 618, "0", "07", "09", "005", "07311", "09", "Santa María Ticomán", "Ciudad de México", "07330", "07311", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1085" },
                    { 619, "0", "07", "09", "005", "07311", "02", "La Laguna Ticomán", "Ciudad de México", "07340", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1087" },
                    { 620, "0", "07", "09", "005", "07311", "09", "San José Ticomán", "Ciudad de México", "07340", "07311", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1088" },
                    { 621, "0", "07", "09", "005", "07311", "02", "Guadalupe Ticomán", "Ciudad de México", "07350", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1091" },
                    { 622, "0", "07", "09", "005", "07311", "02", "San Juan y Guadalupe Ticomán", "Ciudad de México", "07350", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1092" },
                    { 623, "0", "07", "09", "005", "07311", "02", "San Rafael Ticomán", "Ciudad de México", "07359", "07311", "Ciudad de México", "Gustavo A. Madero", "Barrio", "Urbano", "1093" },
                    { 624, "0", "07", "09", "005", "07051", "09", "San Pedro Zacatenco", "Ciudad de México", "07360", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1095" },
                    { 625, "0", "07", "09", "005", "07051", "09", "Residencial Zacatenco", "Ciudad de México", "07369", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1097" },
                    { 626, "0", "07", "09", "005", "07001", "09", "Capultitlan", "Ciudad de México", "07370", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1098" },
                    { 627, "0", "07", "09", "005", "07001", "09", "Maximino Ávila Camacho", "Ciudad de México", "07380", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1099" },
                    { 628, "0", "07", "09", "005", "07001", "09", "Tlacamaca", "Ciudad de México", "07380", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1100" },
                    { 629, "0", "07", "09", "005", "07001", "09", "Salvador Díaz Mirón", "Ciudad de México", "07400", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1101" },
                    { 630, "0", "07", "09", "005", "07001", "09", "Juan González Romero", "Ciudad de México", "07410", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1102" },
                    { 631, "0", "07", "09", "005", "07001", "09", "Villa Hermosa", "Ciudad de México", "07410", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1103" },
                    { 632, "0", "07", "09", "005", "07001", "09", "El Coyol", "Ciudad de México", "07420", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1105" },
                    { 633, "0", "07", "09", "005", "07001", "09", "Nueva Atzacoalco", "Ciudad de México", "07420", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1106" },
                    { 634, "0", "07", "09", "005", "07001", "09", "Del Obrero", "Ciudad de México", "07430", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1108" },
                    { 635, "0", "07", "09", "005", "07001", "09", "Vasco de Quiroga", "Ciudad de México", "07440", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1109" },
                    { 636, "0", "07", "09", "005", "07001", "09", "DM Nacional", "Ciudad de México", "07450", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1110" },
                    { 637, "0", "07", "09", "005", "07001", "09", "Ferrocarrilera", "Ciudad de México", "07455", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1111" },
                    { 638, "0", "07", "09", "005", "07001", "09", "LI Legislatura", "Ciudad de México", "07456", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1112" },
                    { 639, "0", "07", "09", "005", "07001", "09", "Granjas Modernas", "Ciudad de México", "07460", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1117" },
                    { 640, "0", "07", "09", "005", "07001", "09", "Constitución de la República", "Ciudad de México", "07469", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1118" },
                    { 641, "0", "07", "09", "005", "07001", "09", "Ampliación San Juan de Aragón", "Ciudad de México", "07470", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1119" },
                    { 642, "0", "07", "09", "005", "07001", "09", "San Pedro El Chico", "Ciudad de México", "07480", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1120" },
                    { 643, "0", "07", "09", "005", "07501", "09", "La Pradera", "Ciudad de México", "07500", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1122" },
                    { 644, "0", "07", "09", "005", "07501", "09", "Pradera II Sección", "Ciudad de México", "07509", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1125" },
                    { 645, "0", "07", "09", "005", "07501", "09", "San Felipe de Jesús", "Ciudad de México", "07510", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1126" },
                    { 646, "0", "07", "09", "005", "07501", "09", "25 de Julio", "Ciudad de México", "07520", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1128" },
                    { 647, "0", "07", "09", "005", "07501", "09", "Campestre Aragón", "Ciudad de México", "07530", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1129" },
                    { 648, "0", "07", "09", "005", "07501", "09", "La Esmeralda", "Ciudad de México", "07540", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1131" },
                    { 649, "0", "07", "09", "005", "07501", "09", "Providencia", "Ciudad de México", "07550", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1135" },
                    { 650, "0", "07", "09", "005", "07501", "09", "Ampliación Providencia", "Ciudad de México", "07560", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1136" },
                    { 651, "0", "07", "09", "005", "07501", "09", "Villa de Aragón", "Ciudad de México", "07570", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1137" },
                    { 652, "0", "07", "09", "005", "07501", "09", "Ampliación Casas Alemán", "Ciudad de México", "07580", "07501", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1138" },
                    { 653, "0", "07", "09", "005", "07001", "09", "Progreso Nacional", "Ciudad de México", "07600", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1139" },
                    { 654, "0", "07", "09", "005", "07001", "09", "Santa Rosa", "Ciudad de México", "07620", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1141" },
                    { 655, "0", "07", "09", "005", "07001", "09", "San José de la Escalera", "Ciudad de México", "07630", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1142" },
                    { 656, "0", "07", "09", "005", "07001", "09", "Santiago Atepetlac", "Ciudad de México", "07640", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1143" },
                    { 657, "0", "07", "09", "005", "07001", "09", "Ampliación Progreso Nacional", "Ciudad de México", "07650", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1144" },
                    { 658, "0", "07", "09", "005", "07001", "09", "Guadalupe Proletaria", "Ciudad de México", "07670", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1146" },
                    { 659, "0", "07", "09", "005", "07001", "09", "Ampliación Guadalupe Proletaria", "Ciudad de México", "07680", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1147" },
                    { 660, "0", "07", "09", "005", "07001", "09", "Nueva Industrial Vallejo", "Ciudad de México", "07700", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1148" },
                    { 661, "0", "07", "09", "005", "07001", "09", "Siete Maravillas", "Ciudad de México", "07707", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1149" },
                    { 662, "0", "07", "09", "005", "07001", "09", "Torres Lindavista", "Ciudad de México", "07708", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1150" },
                    { 663, "0", "07", "09", "005", "07001", "09", "Lindavista Vallejo I Sección", "Ciudad de México", "07720", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1153" },
                    { 664, "0", "07", "09", "005", "07051", "09", "Churubusco Tepeyac", "Ciudad de México", "07730", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1155" },
                    { 665, "0", "07", "09", "005", "07051", "09", "Montevideo", "Ciudad de México", "07730", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1156" },
                    { 666, "0", "07", "09", "005", "07051", "09", "San Bartolo Atepehuacan", "Ciudad de México", "07730", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1157" },
                    { 667, "0", "07", "09", "005", "07051", "09", "Planetario Lindavista", "Ciudad de México", "07739", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1159" },
                    { 668, "0", "07", "09", "005", "07051", "09", "Valle del Tepeyac", "Ciudad de México", "07740", "07051", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1160" },
                    { 669, "0", "07", "09", "005", "07001", "09", "Nueva Vallejo", "Ciudad de México", "07750", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1161" },
                    { 670, "0", "07", "09", "005", "07001", "09", "Lindavista Vallejo III Sección", "Ciudad de México", "07754", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2890" },
                    { 671, "0", "07", "09", "005", "07001", "09", "Lindavista Vallejo II Sección", "Ciudad de México", "07755", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2889" },
                    { 672, "0", "07", "09", "005", "07001", "09", "Magdalena de las Salinas", "Ciudad de México", "07760", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1162" },
                    { 673, "0", "07", "09", "005", "07001", "09", "Panamericana", "Ciudad de México", "07770", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1163" },
                    { 674, "0", "07", "09", "005", "07001", "09", "Ampliación Panamericana", "Ciudad de México", "07770", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1164" },
                    { 675, "0", "07", "09", "005", "07001", "09", "Defensores de La República", "Ciudad de México", "07780", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1166" },
                    { 676, "0", "07", "09", "005", "07001", "09", "Héroe de Nacozari", "Ciudad de México", "07780", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1167" },
                    { 677, "0", "07", "09", "005", "07001", "09", "Guadalupe Victoria", "Ciudad de México", "07790", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1168" },
                    { 678, "0", "07", "09", "005", "07001", "09", "Vallejo Poniente", "Ciudad de México", "07790", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1169" },
                    { 679, "0", "07", "09", "005", "07001", "09", "Industrial", "Ciudad de México", "07800", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1170" },
                    { 680, "0", "07", "09", "005", "07001", "09", "Estrella", "Ciudad de México", "07810", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1172" },
                    { 681, "0", "07", "09", "005", "07001", "09", "Aragón Inguarán", "Ciudad de México", "07820", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1174" },
                    { 682, "0", "07", "09", "005", "07001", "09", "Tres Estrellas", "Ciudad de México", "07820", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1175" },
                    { 683, "0", "07", "09", "005", "07001", "09", "Gertrudis Sánchez 1a Sección", "Ciudad de México", "07830", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1176" },
                    { 684, "0", "07", "09", "005", "07001", "09", "Gertrudis Sánchez 3a Sección", "Ciudad de México", "07838", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "2886" },
                    { 685, "0", "07", "09", "005", "07001", "09", "Gertrudis Sánchez 2a Sección", "Ciudad de México", "07839", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1178" },
                    { 686, "0", "07", "09", "005", "07001", "09", "Guadalupe Tepeyac", "Ciudad de México", "07840", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1179" },
                    { 687, "0", "07", "09", "005", "07001", "09", "7 de Noviembre", "Ciudad de México", "07840", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1180" },
                    { 688, "0", "07", "09", "005", "07001", "09", "Bondojito", "Ciudad de México", "07850", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1181" },
                    { 689, "0", "07", "09", "005", "07001", "09", "Faja de Oro", "Ciudad de México", "07850", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1182" },
                    { 690, "0", "07", "09", "005", "07001", "09", "Ampliación Emiliano Zapata", "Ciudad de México", "07858", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1183" },
                    { 691, "0", "07", "09", "005", "07001", "09", "Ampliación Mártires de Río Blanco", "Ciudad de México", "07859", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1184" },
                    { 692, "0", "07", "09", "005", "07001", "09", "La Joyita", "Ciudad de México", "07860", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1185" },
                    { 693, "0", "07", "09", "005", "07001", "09", "Tablas de San Agustín", "Ciudad de México", "07860", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1187" },
                    { 694, "0", "07", "09", "005", "07001", "09", "Belisario Domínguez", "Ciudad de México", "07869", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1188" },
                    { 695, "0", "07", "09", "005", "07001", "09", "Guadalupe Insurgentes", "Ciudad de México", "07870", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1189" },
                    { 696, "0", "07", "09", "005", "07001", "09", "Vallejo", "Ciudad de México", "07870", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1190" },
                    { 697, "0", "07", "09", "005", "07001", "09", "Mártires de Río Blanco", "Ciudad de México", "07880", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1191" },
                    { 698, "0", "07", "09", "005", "07001", "09", "Emiliano Zapata", "Ciudad de México", "07889", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1192" },
                    { 699, "0", "07", "09", "005", "07001", "09", "Cuchilla La Joya", "Ciudad de México", "07890", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1193" },
                    { 700, "0", "07", "09", "005", "07001", "09", "La Joya", "Ciudad de México", "07890", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1194" },
                    { 701, "0", "07", "09", "005", "07001", "09", "Nueva Tenochtitlán", "Ciudad de México", "07890", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1195" },
                    { 702, "0", "07", "09", "005", "07001", "09", "La Malinche", "Ciudad de México", "07899", "07001", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1196" },
                    { 703, "0", "07", "09", "005", "07981", "09", "Cuchilla del Tesoro", "Ciudad de México", "07900", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1197" },
                    { 704, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón VII Sección", "Ciudad de México", "07910", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1199" },
                    { 705, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón VI Sección", "Ciudad de México", "07918", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1200" },
                    { 706, "0", "07", "09", "005", "07981", "09", "Ex Ejido San Juan de Aragón Sector 32", "Ciudad de México", "07919", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1201" },
                    { 707, "0", "07", "09", "005", "07981", "09", "El Olivo", "Ciudad de México", "07920", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1202" },
                    { 708, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón", "Ciudad de México", "07920", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1203" },
                    { 709, "0", "07", "09", "005", "07981", "09", "Indeco", "Ciudad de México", "07930", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1204" },
                    { 710, "0", "07", "09", "005", "07981", "09", "Héroes de Chapultepec", "Ciudad de México", "07939", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1205" },
                    { 711, "0", "07", "09", "005", "07981", "09", "Ex Ejido San Juan de Aragón Sector 33", "Ciudad de México", "07940", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1206" },
                    { 712, "0", "07", "09", "005", "07981", "28", "San Juan de Aragón", "Ciudad de México", "07950", "07981", "Ciudad de México", "Gustavo A. Madero", "Pueblo", "Urbano", "1207" },
                    { 713, "0", "07", "09", "005", "07981", "09", "Héroes de Cerro Prieto", "Ciudad de México", "07960", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1211" },
                    { 714, "0", "07", "09", "005", "07981", "09", "Ex Escuela de Tiro", "Ciudad de México", "07960", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1212" },
                    { 715, "0", "07", "09", "005", "07981", "09", "Fernando Casas Alemán", "Ciudad de México", "07960", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1213" },
                    { 716, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón I Sección", "Ciudad de México", "07969", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1215" },
                    { 717, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón II Sección", "Ciudad de México", "07969", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1216" },
                    { 718, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón III Sección", "Ciudad de México", "07970", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1217" },
                    { 719, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón IV Sección", "Ciudad de México", "07979", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1218" },
                    { 720, "0", "07", "09", "005", "07981", "09", "San Juan de Aragón V Sección", "Ciudad de México", "07979", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1219" },
                    { 721, "0", "07", "09", "005", "07981", "09", "Narciso Bassols", "Ciudad de México", "07980", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1220" },
                    { 722, "0", "07", "09", "005", "07981", "09", "C.T.M. Aragón", "Ciudad de México", "07990", "07981", "Ciudad de México", "Gustavo A. Madero", "Colonia", "Urbano", "1222" },
                    { 723, "0", "08", "09", "006", "08231", "09", "Gabriel Ramos Millán Sección Bramadero", "Ciudad de México", "08000", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1233" },
                    { 724, "0", "08", "09", "006", "08231", "09", "Ex-Ejido de La Magdalena Mixiuhca", "Ciudad de México", "08010", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1237" },
                    { 725, "0", "08", "09", "006", "08231", "09", "Ampliación Gabriel Ramos Millán", "Ciudad de México", "08020", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1238" },
                    { 726, "0", "08", "09", "006", "08231", "09", "Gabriel Ramos Millán Sección Cuchilla", "Ciudad de México", "08030", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1241" },
                    { 727, "0", "08", "09", "006", "08231", "09", "Carlos Zapata Vela", "Ciudad de México", "08040", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1242" },
                    { 728, "0", "08", "09", "006", "08231", "09", "Agrícola Pantitlán", "Ciudad de México", "08100", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1244" },
                    { 729, "0", "08", "09", "006", "08231", "09", "Viaducto Piedad", "Ciudad de México", "08200", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1250" },
                    { 730, "0", "08", "09", "006", "08231", "09", "Nueva Santa Anita", "Ciudad de México", "08210", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1251" },
                    { 731, "0", "08", "09", "006", "08231", "02", "San Pedro", "Ciudad de México", "08220", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1252" },
                    { 732, "0", "08", "09", "006", "08231", "02", "San Francisco Xicaltongo", "Ciudad de México", "08230", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1253" },
                    { 733, "0", "08", "09", "006", "08231", "02", "Santiago Norte", "Ciudad de México", "08240", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1254" },
                    { 734, "0", "08", "09", "006", "08231", "09", "Santa Anita", "Ciudad de México", "08300", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1255" },
                    { 735, "0", "08", "09", "006", "08231", "09", "La Cruz", "Ciudad de México", "08310", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1256" },
                    { 736, "0", "08", "09", "006", "08231", "09", "Fraccionamiento Coyuya", "Ciudad de México", "08320", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1257" },
                    { 737, "0", "08", "09", "006", "08231", "09", "Granjas México", "Ciudad de México", "08400", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1258" },
                    { 738, "0", "08", "09", "006", "08231", "09", "Cuchilla Agrícola Oriental", "Ciudad de México", "08420", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1262" },
                    { 739, "0", "08", "09", "006", "08231", "09", "Agrícola Oriental", "Ciudad de México", "08500", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1263" },
                    { 740, "0", "08", "09", "006", "08231", "09", "El Rodeo", "Ciudad de México", "08510", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1265" },
                    { 741, "0", "08", "09", "006", "08231", "02", "La Asunción", "Ciudad de México", "08600", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1269" },
                    { 742, "0", "08", "09", "006", "08231", "02", "Zapotla", "Ciudad de México", "08610", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1270" },
                    { 743, "0", "08", "09", "006", "08231", "02", "Los Reyes", "Ciudad de México", "08620", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1272" },
                    { 744, "0", "08", "09", "006", "08231", "02", "San Miguel", "Ciudad de México", "08650", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1277" },
                    { 745, "0", "08", "09", "006", "08231", "09", "Juventino Rosas", "Ciudad de México", "08700", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1278" },
                    { 746, "0", "08", "09", "006", "08231", "09", "Tlazintla", "Ciudad de México", "08710", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1279" },
                    { 747, "0", "08", "09", "006", "08231", "09", "Gabriel Ramos Millán Sección Tlacotal", "Ciudad de México", "08720", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1280" },
                    { 748, "0", "08", "09", "006", "08231", "09", "Gabriel Ramos Millán", "Ciudad de México", "08730", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1281" },
                    { 749, "0", "08", "09", "006", "08231", "09", "INPI Picos", "Ciudad de México", "08760", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1284" },
                    { 750, "0", "08", "09", "006", "08231", "09", "Los Picos de Iztacalco Sección 2A", "Ciudad de México", "08760", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "2795" },
                    { 751, "0", "08", "09", "006", "08231", "09", "Los Picos de Iztacalco Sección 1B", "Ciudad de México", "08760", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "2796" },
                    { 752, "0", "08", "09", "006", "08231", "09", "Los Picos de Iztacalco Sección 1A", "Ciudad de México", "08770", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1285" },
                    { 753, "0", "08", "09", "006", "08231", "02", "Santiago Sur", "Ciudad de México", "08800", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1286" },
                    { 754, "0", "08", "09", "006", "08231", "09", "Reforma Iztaccíhuatl Norte", "Ciudad de México", "08810", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1288" },
                    { 755, "0", "08", "09", "006", "08231", "09", "Militar Marte", "Ciudad de México", "08830", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1291" },
                    { 756, "0", "08", "09", "006", "08231", "09", "Reforma Iztaccíhuatl Sur", "Ciudad de México", "08840", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1292" },
                    { 757, "0", "08", "09", "006", "08231", "09", "INFONAVIT Iztacalco", "Ciudad de México", "08900", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1293" },
                    { 758, "0", "08", "09", "006", "08231", "02", "Santa Cruz", "Ciudad de México", "08910", "08231", "Ciudad de México", "Iztacalco", "Barrio", "Urbano", "1294" },
                    { 759, "0", "08", "09", "006", "08231", "09", "Jardines Tecma", "Ciudad de México", "08920", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1295" },
                    { 760, "0", "08", "09", "006", "08231", "09", "Campamento 2 de Octubre", "Ciudad de México", "08930", "08231", "Ciudad de México", "Iztacalco", "Colonia", "Urbano", "1296" },
                    { 761, "0", "09", "09", "007", "09081", "02", "La Asunción", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1299" },
                    { 762, "0", "09", "09", "007", "09081", "02", "San Ignacio", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1300" },
                    { 763, "0", "09", "09", "007", "09081", "02", "San José", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1301" },
                    { 764, "0", "09", "09", "007", "09081", "02", "San Lucas", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1302" },
                    { 765, "0", "09", "09", "007", "09081", "02", "San Pablo", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1303" },
                    { 766, "0", "09", "09", "007", "09081", "02", "San Pedro", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1304" },
                    { 767, "0", "09", "09", "007", "09081", "02", "Santa Bárbara", "Ciudad de México", "09000", "09081", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1305" },
                    { 768, "0", "09", "09", "007", "09081", "09", "Real del Moral", "Ciudad de México", "09010", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1308" },
                    { 769, "0", "09", "09", "007", "09081", "09", "Dr. Alfonso Ortiz Tirado", "Ciudad de México", "09020", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1310" },
                    { 770, "0", "09", "09", "007", "09081", "09", "Paseos de Churubusco", "Ciudad de México", "09030", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1314" },
                    { 771, "0", "09", "09", "007", "09081", "09", "Central de Abasto", "Ciudad de México", "09040", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1316" },
                    { 772, "0", "09", "09", "007", "09081", "09", "Escuadrón 201", "Ciudad de México", "09060", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1320" },
                    { 773, "0", "09", "09", "007", "09081", "09", "Sector Popular", "Ciudad de México", "09060", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1321" },
                    { 774, "0", "09", "09", "007", "09081", "09", "Granjas de San Antonio", "Ciudad de México", "09070", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1322" },
                    { 775, "0", "09", "09", "007", "09081", "09", "Cacama", "Ciudad de México", "09080", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1325" },
                    { 776, "0", "09", "09", "007", "09081", "09", "Unidad Modelo", "Ciudad de México", "09089", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1328" },
                    { 777, "0", "09", "09", "007", "09081", "09", "Héroes de Churubusco", "Ciudad de México", "09090", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1329" },
                    { 778, "0", "09", "09", "007", "09081", "28", "Mexicaltzingo", "Ciudad de México", "09099", "09081", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1330" },
                    { 779, "0", "09", "09", "007", "09181", "09", "Juan Escutia", "Ciudad de México", "09100", "09181", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1331" },
                    { 780, "0", "09", "09", "007", "09181", "28", "San Lorenzo Xicotencatl", "Ciudad de México", "09130", "09181", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1334" },
                    { 781, "0", "09", "09", "007", "09181", "09", "Santa Martha Acatitla Norte", "Ciudad de México", "09140", "09181", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1335" },
                    { 782, "0", "09", "09", "007", "09181", "09", "Ermita Zaragoza", "Ciudad de México", "09180", "09181", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1339" },
                    { 783, "0", "09", "09", "007", "09201", "09", "Unidad Vicente Guerrero", "Ciudad de México", "09200", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1341" },
                    { 784, "0", "09", "09", "007", "09201", "09", "Chinampac de Juárez", "Ciudad de México", "09208", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1345" },
                    { 785, "0", "09", "09", "007", "09201", "09", "Renovación", "Ciudad de México", "09209", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1352" },
                    { 786, "0", "09", "09", "007", "09201", "09", "Tepalcates", "Ciudad de México", "09210", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1355" },
                    { 787, "0", "09", "09", "007", "09201", "09", "Unidad Ejército Constitucionalista", "Ciudad de México", "09220", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1357" },
                    { 788, "0", "09", "09", "007", "09201", "09", "Álvaro Obregón", "Ciudad de México", "09230", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1364" },
                    { 789, "0", "09", "09", "007", "09201", "09", "Ejército de Oriente", "Ciudad de México", "09230", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1365" },
                    { 790, "0", "09", "09", "007", "09201", "09", "El Paraíso", "Ciudad de México", "09230", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1368" },
                    { 791, "0", "09", "09", "007", "09201", "09", "José María Morelos y Pavón", "Ciudad de México", "09230", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1369" },
                    { 792, "0", "09", "09", "007", "09201", "09", "Ejército de Oriente Zona Peñón", "Ciudad de México", "09239", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1370" },
                    { 793, "0", "09", "09", "007", "09201", "09", "Progresista", "Ciudad de México", "09240", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1371" },
                    { 794, "0", "09", "09", "007", "09201", "09", "La Regadera", "Ciudad de México", "09250", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1373" },
                    { 795, "0", "09", "09", "007", "09201", "09", "Constitución de 1917", "Ciudad de México", "09260", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1375" },
                    { 796, "0", "09", "09", "007", "09201", "09", "Colonial Iztapalapa", "Ciudad de México", "09270", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1376" },
                    { 797, "0", "09", "09", "007", "09201", "09", "Jacarandas", "Ciudad de México", "09280", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1377" },
                    { 798, "0", "09", "09", "007", "09201", "09", "Santa Cruz Meyehualco", "Ciudad de México", "09290", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1378" },
                    { 799, "0", "09", "09", "007", "09201", "09", "Guadalupe del Moral", "Ciudad de México", "09300", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1380" },
                    { 800, "0", "09", "09", "007", "09201", "09", "Leyes de Reforma 1a Sección", "Ciudad de México", "09310", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1382" },
                    { 801, "0", "09", "09", "007", "09201", "09", "Leyes de Reforma 2a Sección", "Ciudad de México", "09310", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1383" },
                    { 802, "0", "09", "09", "007", "09201", "09", "Leyes de Reforma 3a Sección", "Ciudad de México", "09310", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2839" },
                    { 803, "0", "09", "09", "007", "09201", "09", "Cuchilla del Moral", "Ciudad de México", "09319", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1384" },
                    { 804, "0", "09", "09", "007", "09201", "09", "Sideral", "Ciudad de México", "09320", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1388" },
                    { 805, "0", "09", "09", "007", "09201", "09", "Albarrada", "Ciudad de México", "09350", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1392" },
                    { 806, "0", "09", "09", "007", "09201", "09", "Eva Sámano de López Mateos", "Ciudad de México", "09359", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1393" },
                    { 807, "0", "09", "09", "007", "09201", "09", "Ampliación San Miguel", "Ciudad de México", "09360", "09201", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1399" },
                    { 808, "0", "09", "09", "007", "09201", "02", "San Miguel", "Ciudad de México", "09360", "09201", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1398" },
                    { 809, "0", "09", "09", "007", "09081", "28", "San Juanico Nextipac", "Ciudad de México", "09400", "09081", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1407" },
                    { 810, "0", "09", "09", "007", "09081", "09", "El Sifón", "Ciudad de México", "09400", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1408" },
                    { 811, "0", "09", "09", "007", "09081", "28", "Aculco", "Ciudad de México", "09410", "09081", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1410" },
                    { 812, "0", "09", "09", "007", "09081", "09", "Jardines de Churubusco", "Ciudad de México", "09410", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1412" },
                    { 813, "0", "09", "09", "007", "09081", "28", "Magdalena Atlazolpa", "Ciudad de México", "09410", "09081", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1413" },
                    { 814, "0", "09", "09", "007", "09081", "09", "San José Aculco", "Ciudad de México", "09410", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1414" },
                    { 815, "0", "09", "09", "007", "09081", "09", "Los Picos VI-B", "Ciudad de México", "09420", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1415" },
                    { 816, "0", "09", "09", "007", "09081", "09", "Nueva Rosita", "Ciudad de México", "09420", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1416" },
                    { 817, "0", "09", "09", "007", "09081", "09", "Purísima Atlazolpa", "Ciudad de México", "09429", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1417" },
                    { 818, "0", "09", "09", "007", "09081", "09", "Apatlaco", "Ciudad de México", "09430", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1418" },
                    { 819, "0", "09", "09", "007", "09081", "09", "El Triunfo", "Ciudad de México", "09430", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1419" },
                    { 820, "0", "09", "09", "007", "09081", "09", "Ampliación El Triunfo", "Ciudad de México", "09438", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1422" },
                    { 821, "0", "09", "09", "007", "09081", "09", "El Retoño", "Ciudad de México", "09440", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1425" },
                    { 822, "0", "09", "09", "007", "09081", "09", "San Andrés Tetepilco", "Ciudad de México", "09440", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1426" },
                    { 823, "0", "09", "09", "007", "09081", "09", "Zacahuitzco", "Ciudad de México", "09440", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2840" },
                    { 824, "0", "09", "09", "007", "09081", "09", "Banjidal", "Ciudad de México", "09450", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1429" },
                    { 825, "0", "09", "09", "007", "09081", "09", "Justo Sierra", "Ciudad de México", "09460", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1430" },
                    { 826, "0", "09", "09", "007", "09081", "09", "Sinatel", "Ciudad de México", "09470", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1431" },
                    { 827, "0", "09", "09", "007", "09081", "09", "Ampliación Sinatel", "Ciudad de México", "09479", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1432" },
                    { 828, "0", "09", "09", "007", "09081", "09", "El Prado", "Ciudad de México", "09480", "09081", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1433" },
                    { 829, "0", "09", "09", "007", "09511", "28", "Santa María Aztahuacán", "Ciudad de México", "09500", "09511", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1435" },
                    { 830, "0", "09", "09", "007", "09511", "09", "Santa María Aztahuacán Ampliación", "Ciudad de México", "09500", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2565" },
                    { 831, "0", "09", "09", "007", "09511", "28", "Santa Martha Acatitla", "Ciudad de México", "09510", "09511", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1436" },
                    { 832, "0", "09", "09", "007", "09511", "09", "El Edén", "Ciudad de México", "09520", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1439" },
                    { 833, "0", "09", "09", "007", "09511", "28", "San Sebastián Tecoloxtitla", "Ciudad de México", "09520", "09511", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1440" },
                    { 834, "0", "09", "09", "007", "09511", "09", "Santa Martha Acatitla Sur", "Ciudad de México", "09530", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1441" },
                    { 835, "0", "09", "09", "007", "09511", "09", "Monte Alban", "Ciudad de México", "09550", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1443" },
                    { 836, "0", "09", "09", "007", "09511", "09", "Paraje Zacatepec", "Ciudad de México", "09560", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1444" },
                    { 837, "0", "09", "09", "007", "09511", "09", "Santa María Aztahuacán", "Ciudad de México", "09570", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1445" },
                    { 838, "0", "09", "09", "007", "09511", "09", "Ejército de Agua Prieta", "Ciudad de México", "09578", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1449" },
                    { 839, "0", "09", "09", "007", "09511", "28", "Santiago Acahualtepec", "Ciudad de México", "09600", "09511", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1453" },
                    { 840, "0", "09", "09", "007", "09511", "09", "Santiago Acahualtepec 1ra. Ampliación", "Ciudad de México", "09608", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1454" },
                    { 841, "0", "09", "09", "007", "09511", "09", "Santiago Acahualtepec 2a. Ampliación", "Ciudad de México", "09609", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1455" },
                    { 842, "0", "09", "09", "007", "09511", "09", "Lomas de Zaragoza", "Ciudad de México", "09620", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1456" },
                    { 843, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Corrales", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1481" },
                    { 844, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Acorralado", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2850" },
                    { 845, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Avisadero", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2851" },
                    { 846, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Capilla", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2852" },
                    { 847, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Guadalupe", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2853" },
                    { 848, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Iztlahuaca", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2854" },
                    { 849, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Jardines", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2855" },
                    { 850, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección La Cruz", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2856" },
                    { 851, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Loma Alta", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2857" },
                    { 852, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Mercedes", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2858" },
                    { 853, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Palmitas", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2859" },
                    { 854, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Puente", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2860" },
                    { 855, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Ranchito", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2861" },
                    { 856, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Rancho Bajo", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2862" },
                    { 857, "0", "09", "09", "007", "09511", "09", "San Miguel Teotongo Sección Torres", "Ciudad de México", "09630", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2863" },
                    { 858, "0", "09", "09", "007", "09511", "09", "Campestre Potrero", "Ciudad de México", "09637", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1461" },
                    { 859, "0", "09", "09", "007", "09511", "09", "Ampliación Emiliano Zapata", "Ciudad de México", "09638", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1462" },
                    { 860, "0", "09", "09", "007", "09511", "09", "Lomas de la Estancia", "Ciudad de México", "09640", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1464" },
                    { 861, "0", "09", "09", "007", "09511", "09", "Xalpa", "Ciudad de México", "09640", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1465" },
                    { 862, "0", "09", "09", "007", "09511", "09", "San Pablo", "Ciudad de México", "09648", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1467" },
                    { 863, "0", "09", "09", "007", "09511", "09", "Citlalli", "Ciudad de México", "09660", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1470" },
                    { 864, "0", "09", "09", "007", "09511", "09", "Palmitas", "Ciudad de México", "09670", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1471" },
                    { 865, "0", "09", "09", "007", "09511", "09", "Tenorios", "Ciudad de México", "09680", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1473" },
                    { 866, "0", "09", "09", "007", "09511", "09", "Barranca de Guadalupe", "Ciudad de México", "09689", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1477" },
                    { 867, "0", "09", "09", "007", "09511", "09", "Iztlahuacán", "Ciudad de México", "09690", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1478" },
                    { 868, "0", "09", "09", "007", "09511", "09", "Miravalles", "Ciudad de México", "09696", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1480" },
                    { 869, "0", "09", "09", "007", "09511", "09", "Miguel de La Madrid Hurtado", "Ciudad de México", "09698", "09511", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1482" },
                    { 870, "0", "09", "09", "007", "09291", "09", "Buenavista", "Ciudad de México", "09700", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1485" },
                    { 871, "0", "09", "09", "007", "09291", "09", "Carlos Hank Gonzalez", "Ciudad de México", "09700", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1486" },
                    { 872, "0", "09", "09", "007", "09291", "09", "Desarrollo Urbano Quetzalcoatl", "Ciudad de México", "09700", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1488" },
                    { 873, "0", "09", "09", "007", "09291", "28", "Santa Cruz Meyehualco", "Ciudad de México", "09700", "09291", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1491" },
                    { 874, "0", "09", "09", "007", "09291", "09", "Degollado", "Ciudad de México", "09704", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1492" },
                    { 875, "0", "09", "09", "007", "09291", "09", "Degollado - Mexicatlalli", "Ciudad de México", "09705", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2726" },
                    { 876, "0", "09", "09", "007", "09291", "09", "San José Buenavista", "Ciudad de México", "09706", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1497" },
                    { 877, "0", "09", "09", "007", "09291", "09", "Mixcoatl", "Ciudad de México", "09708", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1500" },
                    { 878, "0", "09", "09", "007", "09291", "09", "Lomas de Santa Cruz", "Ciudad de México", "09709", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1501" },
                    { 879, "0", "09", "09", "007", "09291", "09", "Los Ángeles Apanoaya", "Ciudad de México", "09710", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1502" },
                    { 880, "0", "09", "09", "007", "09291", "09", "Francisco Villa", "Ciudad de México", "09720", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1505" },
                    { 881, "0", "09", "09", "007", "09291", "09", "La Era", "Ciudad de México", "09720", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1506" },
                    { 882, "0", "09", "09", "007", "09291", "09", "Reforma Política", "Ciudad de México", "09730", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1508" },
                    { 883, "0", "09", "09", "007", "09291", "09", "Presidentes de México", "Ciudad de México", "09740", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1511" },
                    { 884, "0", "09", "09", "007", "09291", "09", "Insurgentes", "Ciudad de México", "09750", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1512" },
                    { 885, "0", "09", "09", "007", "09291", "09", "La Polvorilla", "Ciudad de México", "09750", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1514" },
                    { 886, "0", "09", "09", "007", "09291", "09", "Las Peñas", "Ciudad de México", "09750", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1515" },
                    { 887, "0", "09", "09", "007", "09291", "09", "Consejo Agrarista Mexicano", "Ciudad de México", "09760", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1518" },
                    { 888, "0", "09", "09", "007", "09291", "09", "El Triángulo", "Ciudad de México", "09769", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1523" },
                    { 889, "0", "09", "09", "007", "09291", "09", "Puente Blanco", "Ciudad de México", "09770", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1524" },
                    { 890, "0", "09", "09", "007", "09291", "09", "Año de Juárez", "Ciudad de México", "09780", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1527" },
                    { 891, "0", "09", "09", "007", "09291", "09", "Lomas de San Lorenzo", "Ciudad de México", "09780", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1528" },
                    { 892, "0", "09", "09", "007", "09291", "28", "San Lorenzo Tezonco", "Ciudad de México", "09790", "09291", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1531" },
                    { 893, "0", "09", "09", "007", "09821", "28", "Culhuacán", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1532" },
                    { 894, "0", "09", "09", "007", "09821", "09", "El Mirador", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1534" },
                    { 895, "0", "09", "09", "007", "09821", "09", "Estrella Culhuacán", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1535" },
                    { 896, "0", "09", "09", "007", "09821", "09", "Fuego Nuevo", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1536" },
                    { 897, "0", "09", "09", "007", "09821", "09", "San Antonio Culhuacán", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1538" },
                    { 898, "0", "09", "09", "007", "09821", "02", "San Antonio Culhuacán", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1539" },
                    { 899, "0", "09", "09", "007", "09821", "02", "San Simón Culhuacán", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1540" },
                    { 900, "0", "09", "09", "007", "09821", "02", "Tula", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1541" },
                    { 901, "0", "09", "09", "007", "09821", "09", "Valle de Luces", "Ciudad de México", "09800", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1542" },
                    { 902, "0", "09", "09", "007", "09821", "09", "Granjas Esmeralda", "Ciudad de México", "09810", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1547" },
                    { 903, "0", "09", "09", "007", "09821", "09", "Los Cipreses", "Ciudad de México", "09810", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1548" },
                    { 904, "0", "09", "09", "007", "09821", "09", "Minerva", "Ciudad de México", "09810", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1549" },
                    { 905, "0", "09", "09", "007", "09821", "09", "Progreso del Sur", "Ciudad de México", "09810", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1550" },
                    { 906, "0", "09", "09", "007", "09821", "09", "Valle del Sur", "Ciudad de México", "09819", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1551" },
                    { 907, "0", "09", "09", "007", "09821", "09", "El Santuario", "Ciudad de México", "09820", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1552" },
                    { 908, "0", "09", "09", "007", "09821", "09", "Estrella del Sur", "Ciudad de México", "09820", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1553" },
                    { 909, "0", "09", "09", "007", "09821", "09", "Ricardo Flores Magón", "Ciudad de México", "09820", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1556" },
                    { 910, "0", "09", "09", "007", "09821", "09", "Santa Isabel Industrial", "Ciudad de México", "09820", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1557" },
                    { 911, "0", "09", "09", "007", "09821", "09", "Ampliación Ricardo Flores Magón", "Ciudad de México", "09828", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1559" },
                    { 912, "0", "09", "09", "007", "09821", "09", "Ampliación El Santuario", "Ciudad de México", "09829", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1560" },
                    { 913, "0", "09", "09", "007", "09821", "09", "El Manto", "Ciudad de México", "09830", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1562" },
                    { 914, "0", "09", "09", "007", "09821", "09", "El Molino", "Ciudad de México", "09830", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1563" },
                    { 915, "0", "09", "09", "007", "09821", "09", "Lomas El Manto", "Ciudad de México", "09830", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1565" },
                    { 916, "0", "09", "09", "007", "09821", "09", "Los Ángeles", "Ciudad de México", "09830", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1566" },
                    { 917, "0", "09", "09", "007", "09821", "09", "Paraje San Juan", "Ciudad de México", "09830", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1568" },
                    { 918, "0", "09", "09", "007", "09821", "09", "San Miguel 8va. Ampliación", "Ciudad de México", "09837", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1570" },
                    { 919, "0", "09", "09", "007", "09821", "09", "Plan de Iguala", "Ciudad de México", "09838", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1571" },
                    { 920, "0", "09", "09", "007", "09821", "09", "Ampliación Paraje San Juan", "Ciudad de México", "09839", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1573" },
                    { 921, "0", "09", "09", "007", "09821", "09", "San Juan Joya", "Ciudad de México", "09839", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1576" },
                    { 922, "0", "09", "09", "007", "09821", "28", "Los Reyes Culhuacán", "Ciudad de México", "09840", "09821", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1578" },
                    { 923, "0", "09", "09", "007", "09821", "09", "Ampliación Los Reyes", "Ciudad de México", "09849", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1580" },
                    { 924, "0", "09", "09", "007", "09821", "09", "San Juan Xalpa", "Ciudad de México", "09850", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1586" },
                    { 925, "0", "09", "09", "007", "09821", "09", "San Nicolás Tolentino", "Ciudad de México", "09850", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1588" },
                    { 926, "0", "09", "09", "007", "09821", "09", "Santa María del Monte", "Ciudad de México", "09850", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1589" },
                    { 927, "0", "09", "09", "007", "09821", "09", "Estado de Veracruz", "Ciudad de México", "09856", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1590" },
                    { 928, "0", "09", "09", "007", "09821", "09", "Ampliación Veracruzana", "Ciudad de México", "09856", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1591" },
                    { 929, "0", "09", "09", "007", "09821", "09", "Paraje San Juan Cerro", "Ciudad de México", "09858", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1594" },
                    { 930, "0", "09", "09", "007", "09821", "09", "Benito Juárez", "Ciudad de México", "09859", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1595" },
                    { 931, "0", "09", "09", "007", "09821", "09", "Bellavista", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1596" },
                    { 932, "0", "09", "09", "007", "09821", "09", "Ampliación Bellavista", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1597" },
                    { 933, "0", "09", "09", "007", "09821", "09", "Casa Blanca", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1598" },
                    { 934, "0", "09", "09", "007", "09821", "09", "Cerro de La Estrella", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1600" },
                    { 935, "0", "09", "09", "007", "09821", "09", "Parque Nacional Cerro  de la Estrella", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1601" },
                    { 936, "0", "09", "09", "007", "09821", "09", "El Rodeo", "Ciudad de México", "09860", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1602" },
                    { 937, "0", "09", "09", "007", "09821", "09", "San Juan Estrella", "Ciudad de México", "09868", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1607" },
                    { 938, "0", "09", "09", "007", "09821", "09", "12 de Diciembre", "Ciudad de México", "09870", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1609" },
                    { 939, "0", "09", "09", "007", "09821", "09", "San Andrés Tomatlán", "Ciudad de México", "09870", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1611" },
                    { 940, "0", "09", "09", "007", "09821", "28", "San Andrés Tomatlán", "Ciudad de México", "09870", "09821", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1613" },
                    { 941, "0", "09", "09", "007", "09821", "28", "Santa María Tomatlán", "Ciudad de México", "09870", "09821", "Ciudad de México", "Iztapalapa", "Pueblo", "Urbano", "1616" },
                    { 942, "0", "09", "09", "007", "09821", "09", "El Vergel", "Ciudad de México", "09880", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1620" },
                    { 943, "0", "09", "09", "007", "09821", "09", "Granjas Estrella", "Ciudad de México", "09880", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1621" },
                    { 944, "0", "09", "09", "007", "09821", "09", "Lomas Estrella", "Ciudad de México", "09890", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1629" },
                    { 945, "0", "09", "09", "007", "09821", "09", "Carlos Jonguitud Barrios", "Ciudad de México", "09897", "09821", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1633" },
                    { 946, "0", "09", "09", "007", "09291", "02", "Guadalupe", "Ciudad de México", "09900", "09291", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1637" },
                    { 947, "0", "09", "09", "007", "09291", "02", "San Antonio", "Ciudad de México", "09900", "09291", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1638" },
                    { 948, "0", "09", "09", "007", "09291", "02", "San Lorenzo", "Ciudad de México", "09900", "09291", "Ciudad de México", "Iztapalapa", "Barrio", "Urbano", "1639" },
                    { 949, "0", "09", "09", "007", "09291", "09", "La Esperanza", "Ciudad de México", "09910", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1640" },
                    { 950, "0", "09", "09", "007", "09291", "09", "José López Portillo", "Ciudad de México", "09920", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1643" },
                    { 951, "0", "09", "09", "007", "09291", "09", "El Rosario", "Ciudad de México", "09930", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1644" },
                    { 952, "0", "09", "09", "007", "09291", "09", "Jardines de San Lorenzo Tezonco", "Ciudad de México", "09940", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1645" },
                    { 953, "0", "09", "09", "007", "09291", "09", "Celoalliotli", "Ciudad de México", "09960", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1646" },
                    { 954, "0", "09", "09", "007", "09291", "09", "USCOVI", "Ciudad de México", "09960", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1647" },
                    { 955, "0", "09", "09", "007", "09291", "09", "El Molino Tezonco", "Ciudad de México", "09960", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1648" },
                    { 956, "0", "09", "09", "007", "09291", "09", "Allapetlalli", "Ciudad de México", "09960", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1961" },
                    { 957, "0", "09", "09", "007", "09291", "09", "La Planta", "Ciudad de México", "09960", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "2736" },
                    { 958, "0", "09", "09", "007", "09291", "09", "Cananea", "Ciudad de México", "09969", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1651" },
                    { 959, "0", "09", "09", "007", "09291", "09", "Valle de San Lorenzo", "Ciudad de México", "09970", "09291", "Ciudad de México", "Iztapalapa", "Colonia", "Urbano", "1652" },
                    { 960, "0", "10", "09", "008", "10021", "09", "Lomas Quebradas", "Ciudad de México", "10000", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1672" },
                    { 961, "0", "10", "09", "008", "10021", "09", "La Malinche", "Ciudad de México", "10010", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1673" },
                    { 962, "0", "10", "09", "008", "10021", "09", "San Bartolo Ameyalco", "Ciudad de México", "10010", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1674" },
                    { 963, "0", "10", "09", "008", "10021", "09", "Cuauhtémoc", "Ciudad de México", "10020", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1675" },
                    { 964, "0", "10", "09", "008", "10101", "09", "El Maestro", "Ciudad de México", "10130", "10101", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1681" },
                    { 965, "0", "10", "09", "008", "10701", "09", "San Jerónimo Lídice", "Ciudad de México", "10200", "10701", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1682" },
                    { 966, "0", "10", "09", "008", "10021", "28", "San Bernabé Ocotepec", "Ciudad de México", "10300", "10021", "Ciudad de México", "La Magdalena Contreras", "Pueblo", "Urbano", "1686" },
                    { 967, "0", "10", "09", "008", "10021", "09", "El Tanque", "Ciudad de México", "10320", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1690" },
                    { 968, "0", "10", "09", "008", "10021", "09", "Las Cruces", "Ciudad de México", "10330", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1691" },
                    { 969, "0", "10", "09", "008", "10021", "09", "Los Padres", "Ciudad de México", "10340", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1692" },
                    { 970, "0", "10", "09", "008", "10021", "09", "Lomas de San Bernabé", "Ciudad de México", "10350", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1693" },
                    { 971, "0", "10", "09", "008", "10021", "09", "Huayatla", "Ciudad de México", "10360", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1694" },
                    { 972, "0", "10", "09", "008", "10581", "09", "Ampliación Potrerillo", "Ciudad de México", "10368", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1695" },
                    { 973, "0", "10", "09", "008", "10021", "09", "Ampliación Lomas de San Bernabé", "Ciudad de México", "10369", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1696" },
                    { 974, "0", "10", "09", "008", "10021", "09", "Tierra Unida", "Ciudad de México", "10369", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "2669" },
                    { 975, "0", "10", "09", "008", "10021", "09", "Palmas", "Ciudad de México", "10370", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1697" },
                    { 976, "0", "10", "09", "008", "10021", "09", "Atacaxco", "Ciudad de México", "10378", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1698" },
                    { 977, "0", "10", "09", "008", "10021", "09", "Vista Hermosa", "Ciudad de México", "10379", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1700" },
                    { 978, "0", "10", "09", "008", "10021", "09", "Barros Sierra", "Ciudad de México", "10380", "10021", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1701" },
                    { 979, "0", "10", "09", "008", "10701", "09", "San Jerónimo Aculco", "Ciudad de México", "10400", "10701", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1702" },
                    { 980, "0", "10", "09", "008", "10581", "09", "Barrio San Francisco", "Ciudad de México", "10500", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1703" },
                    { 981, "0", "10", "09", "008", "10581", "09", "Barranca Seca", "Ciudad de México", "10580", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1707" },
                    { 982, "0", "10", "09", "008", "10581", "09", "El Rosal", "Ciudad de México", "10600", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1710" },
                    { 983, "0", "10", "09", "008", "10581", "09", "El Toro", "Ciudad de México", "10610", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1713" },
                    { 984, "0", "10", "09", "008", "10581", "09", "Potrerillo", "Ciudad de México", "10620", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1714" },
                    { 985, "0", "00", "09", "008", "10581", "04", "El Ocotal", "", "10630", "10581", "Ciudad de México", "La Magdalena Contreras", "Campamento", "Urbano", "2706" },
                    { 986, "0", "10", "09", "008", "10581", "09", "La Carbonera", "Ciudad de México", "10640", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1716" },
                    { 987, "0", "10", "09", "008", "10581", "09", "Pueblo Nuevo Alto", "Ciudad de México", "10640", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1717" },
                    { 988, "0", "10", "09", "008", "10581", "09", "Pueblo Nuevo Bajo", "Ciudad de México", "10640", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1718" },
                    { 989, "0", "10", "09", "008", "10581", "09", "El Ermitaño", "Ciudad de México", "10660", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1720" },
                    { 990, "0", "10", "09", "008", "10701", "09", "Héroes de Padierna", "Ciudad de México", "10700", "10701", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1721" },
                    { 991, "0", "10", "09", "008", "10901", "09", "Santa Teresa", "Ciudad de México", "10710", "10901", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1723" },
                    { 992, "0", "10", "09", "008", "10581", "09", "La Cruz", "Ciudad de México", "10800", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1728" },
                    { 993, "0", "10", "09", "008", "10581", "09", "San Francisco", "Ciudad de México", "10810", "10581", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1730" }
                });

            migrationBuilder.InsertData(
                table: "CatCodigosPostales",
                columns: new[] { "IdCodigosPostales", "Ccp", "CcveCiudad", "Cestado", "Cmnpio", "Coficina", "CtipoAsenta", "Dasenta", "Dciudad", "Dcodigo", "Dcp", "Destado", "Dmnpio", "DtipoAsenta", "Dzona", "IdAsentaCpcons" },
                values: new object[,]
                {
                    { 994, "0", "10", "09", "008", "10901", "09", "La Guadalupe", "Ciudad de México", "10820", "10901", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1731" },
                    { 995, "0", "10", "09", "008", "10901", "09", "La Concepción", "Ciudad de México", "10830", "10901", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1732" },
                    { 996, "0", "10", "09", "008", "10901", "02", "Las Calles", "Ciudad de México", "10840", "10901", "Ciudad de México", "La Magdalena Contreras", "Barrio", "Urbano", "1733" },
                    { 997, "0", "10", "09", "008", "10901", "02", "Plazuela del Pedregal", "Ciudad de México", "10840", "10901", "Ciudad de México", "La Magdalena Contreras", "Barrio", "Urbano", "1734" },
                    { 998, "0", "10", "09", "008", "10901", "28", "San Nicolás Totolapan", "Ciudad de México", "10900", "10901", "Ciudad de México", "La Magdalena Contreras", "Pueblo", "Urbano", "1735" },
                    { 999, "0", "10", "09", "008", "10581", "28", "La Magdalena", "Ciudad de México", "10910", "10581", "Ciudad de México", "La Magdalena Contreras", "Pueblo", "Urbano", "1737" },
                    { 1000, "0", "10", "09", "008", "10901", "09", "Las Huertas", "Ciudad de México", "10920", "10901", "Ciudad de México", "La Magdalena Contreras", "Colonia", "Urbano", "1738" },
                    { 1001, "0", "10", "09", "008", "10901", "04", "Tierra Colorada", "Ciudad de México", "10926", "10901", "Ciudad de México", "La Magdalena Contreras", "Campamento", "Urbano", "1739" },
                    { 1002, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec I Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1745" },
                    { 1003, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec VIII Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2774" },
                    { 1004, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec II Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2775" },
                    { 1005, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec III Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2776" },
                    { 1006, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec IV Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2777" },
                    { 1007, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec V Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2778" },
                    { 1008, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec VI Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2779" },
                    { 1009, "0", "11", "09", "016", "11801", "09", "Lomas de Chapultepec VII Sección", "Ciudad de México", "11000", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2780" },
                    { 1010, "0", "11", "09", "016", "11801", "09", "Molino del Rey", "Ciudad de México", "11040", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1752" },
                    { 1011, "0", "11", "09", "016", "11801", "17", "Bosque de Chapultepec II Sección", "Ciudad de México", "11100", "11801", "Ciudad de México", "Miguel Hidalgo", "Equipamiento", "Urbano", "1754" },
                    { 1012, "0", "11", "09", "016", "11801", "17", "Bosque de Chapultepec III Sección", "Ciudad de México", "11100", "11801", "Ciudad de México", "Miguel Hidalgo", "Equipamiento", "Urbano", "2772" },
                    { 1013, "0", "11", "09", "016", "11411", "09", "Lomas Hermosa", "Ciudad de México", "11200", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1757" },
                    { 1014, "0", "11", "09", "016", "11411", "09", "Lomas de Sotelo", "Ciudad de México", "11200", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1758" },
                    { 1015, "0", "11", "09", "016", "11411", "28", "San Lorenzo Tlaltenango", "Ciudad de México", "11210", "11411", "Ciudad de México", "Miguel Hidalgo", "Pueblo", "Urbano", "1761" },
                    { 1016, "0", "11", "09", "016", "11411", "09", "Periodista", "Ciudad de México", "11220", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1764" },
                    { 1017, "0", "11", "09", "016", "11411", "09", "Argentina Poniente", "Ciudad de México", "11230", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1765" },
                    { 1018, "0", "11", "09", "016", "11411", "09", "Ignacio Manuel Altamirano", "Ciudad de México", "11240", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1767" },
                    { 1019, "0", "11", "09", "016", "11411", "09", "10 de Abril", "Ciudad de México", "11250", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1768" },
                    { 1020, "0", "11", "09", "016", "11411", "09", "México Nuevo", "Ciudad de México", "11260", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1770" },
                    { 1021, "0", "11", "09", "016", "11411", "09", "San Joaquín", "Ciudad de México", "11260", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1771" },
                    { 1022, "0", "11", "09", "016", "11411", "09", "Argentina Antigua", "Ciudad de México", "11270", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1772" },
                    { 1023, "0", "11", "09", "016", "11411", "09", "Torre Blanca", "Ciudad de México", "11280", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1773" },
                    { 1024, "0", "11", "09", "016", "11411", "09", "Ampliación Torre Blanca", "Ciudad de México", "11289", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1774" },
                    { 1025, "0", "11", "09", "016", "11411", "09", "Huíchapan", "Ciudad de México", "11290", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1775" },
                    { 1026, "0", "11", "09", "016", "11411", "09", "San Diego Ocoyoacac", "Ciudad de México", "11290", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1776" },
                    { 1027, "0", "11", "09", "016", "11411", "09", "Verónica Anzures", "Ciudad de México", "11300", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1777" },
                    { 1028, "0", "11", "09", "016", "11411", "09", "Mariano Escobedo", "Ciudad de México", "11310", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1780" },
                    { 1029, "0", "11", "09", "016", "11411", "09", "Anáhuac I Sección", "Ciudad de México", "11320", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1782" },
                    { 1030, "0", "11", "09", "016", "11411", "09", "Anáhuac II Sección", "Ciudad de México", "11320", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2771" },
                    { 1031, "0", "11", "09", "016", "11411", "09", "Un Hogar Para Nosotros", "Ciudad de México", "11330", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1784" },
                    { 1032, "0", "11", "09", "016", "11411", "09", "Santo Tomas", "Ciudad de México", "11340", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1785" },
                    { 1033, "0", "11", "09", "016", "11411", "09", "Plutarco Elías Calles", "Ciudad de México", "11350", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1786" },
                    { 1034, "0", "11", "09", "016", "11411", "09", "Agricultura", "Ciudad de México", "11360", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1787" },
                    { 1035, "0", "11", "09", "016", "11411", "09", "Tlaxpana", "Ciudad de México", "11370", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1789" },
                    { 1036, "0", "11", "09", "016", "11411", "09", "Popotla", "Ciudad de México", "11400", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1791" },
                    { 1037, "0", "11", "09", "016", "11411", "09", "Legaria", "Ciudad de México", "11410", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1793" },
                    { 1038, "0", "11", "09", "016", "11411", "28", "Tacuba", "Ciudad de México", "11410", "11411", "Ciudad de México", "Miguel Hidalgo", "Pueblo", "Urbano", "1794" },
                    { 1039, "0", "11", "09", "016", "11411", "09", "Nextitla", "Ciudad de México", "11420", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1796" },
                    { 1040, "0", "11", "09", "016", "11411", "09", "Pensil Norte", "Ciudad de México", "11430", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1797" },
                    { 1041, "0", "11", "09", "016", "11411", "09", "Ventura Pérez de Alva", "Ciudad de México", "11430", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1798" },
                    { 1042, "0", "11", "09", "016", "11411", "09", "Reforma Pensil", "Ciudad de México", "11440", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1799" },
                    { 1043, "0", "11", "09", "016", "11411", "09", "San Juanico", "Ciudad de México", "11440", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1800" },
                    { 1044, "0", "11", "09", "016", "11411", "09", "Ahuehuetes Anáhuac", "Ciudad de México", "11450", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1801" },
                    { 1045, "0", "11", "09", "016", "11411", "09", "Modelo Pensil", "Ciudad de México", "11450", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1802" },
                    { 1046, "0", "11", "09", "016", "11411", "09", "Peralitos", "Ciudad de México", "11450", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1803" },
                    { 1047, "0", "11", "09", "016", "11411", "09", "Dos Lagos", "Ciudad de México", "11460", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1804" },
                    { 1048, "0", "11", "09", "016", "11411", "09", "Lago Norte", "Ciudad de México", "11460", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1805" },
                    { 1049, "0", "11", "09", "016", "11411", "09", "Lago Sur", "Ciudad de México", "11460", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1806" },
                    { 1050, "0", "11", "09", "016", "11411", "09", "Los Manzanos", "Ciudad de México", "11460", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1807" },
                    { 1051, "0", "11", "09", "016", "11411", "09", "5 de Mayo", "Ciudad de México", "11470", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1808" },
                    { 1052, "0", "11", "09", "016", "11411", "09", "Deportivo Pensil", "Ciudad de México", "11470", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1809" },
                    { 1053, "0", "11", "09", "016", "11411", "09", "Francisco I Madero", "Ciudad de México", "11480", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1811" },
                    { 1054, "0", "11", "09", "016", "11411", "09", "Popo", "Ciudad de México", "11480", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1812" },
                    { 1055, "0", "11", "09", "016", "11411", "09", "Ampliación Popo", "Ciudad de México", "11489", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1813" },
                    { 1056, "0", "11", "09", "016", "11411", "09", "Cuauhtémoc Pensil", "Ciudad de México", "11490", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1814" },
                    { 1057, "0", "11", "09", "016", "11411", "09", "Pensil Sur", "Ciudad de México", "11490", "11411", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1815" },
                    { 1058, "0", "11", "09", "016", "11591", "09", "Irrigación", "Ciudad de México", "11500", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1816" },
                    { 1059, "0", "11", "09", "016", "11591", "09", "Polanco I Sección", "Ciudad de México", "11510", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2781" },
                    { 1060, "0", "11", "09", "016", "11591", "09", "Granada", "Ciudad de México", "11520", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1822" },
                    { 1061, "0", "11", "09", "016", "11591", "09", "Ampliación Granada", "Ciudad de México", "11529", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1823" },
                    { 1062, "0", "11", "09", "016", "11591", "09", "Polanco II Sección", "Ciudad de México", "11530", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2782" },
                    { 1063, "0", "11", "09", "016", "11591", "09", "Polanco III Sección", "Ciudad de México", "11540", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2783" },
                    { 1064, "0", "11", "09", "016", "11591", "09", "Polanco IV Sección", "Ciudad de México", "11550", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2784" },
                    { 1065, "0", "11", "09", "016", "11591", "09", "Polanco V Sección", "Ciudad de México", "11560", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2785" },
                    { 1066, "0", "11", "09", "016", "11591", "09", "Chapultepec Morales", "Ciudad de México", "11570", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "0001" },
                    { 1067, "0", "11", "09", "016", "11591", "17", "Bosque de Chapultepec I Sección", "Ciudad de México", "11580", "11591", "Ciudad de México", "Miguel Hidalgo", "Equipamiento", "Urbano", "1833" },
                    { 1068, "0", "11", "09", "016", "11591", "09", "Anzures", "Ciudad de México", "11590", "11591", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1838" },
                    { 1069, "0", "11", "09", "016", "11801", "09", "Residencial Militar", "Ciudad de México", "11600", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1843" },
                    { 1070, "0", "11", "09", "016", "11801", "09", "Manuel Avila Camacho", "Ciudad de México", "11610", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1844" },
                    { 1071, "0", "11", "09", "016", "53001", "17", "Campo Militar 1", "Ciudad de México", "11619", "53001", "Ciudad de México", "Miguel Hidalgo", "Equipamiento", "Urbano", "1846" },
                    { 1072, "0", "11", "09", "016", "11801", "09", "Reforma Social", "Ciudad de México", "11650", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1855" },
                    { 1073, "0", "11", "09", "016", "11801", "09", "Bosque de las Lomas", "Ciudad de México", "11700", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1856" },
                    { 1074, "0", "11", "09", "016", "11801", "09", "Escandón I Sección", "Ciudad de México", "11800", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1858" },
                    { 1075, "0", "11", "09", "016", "11801", "09", "Escandón II Sección", "Ciudad de México", "11800", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2773" },
                    { 1076, "0", "11", "09", "016", "11801", "09", "16 de Septiembre", "Ciudad de México", "11810", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1860" },
                    { 1077, "0", "11", "09", "016", "11801", "09", "América", "Ciudad de México", "11820", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1861" },
                    { 1078, "0", "11", "09", "016", "11801", "09", "Daniel Garza", "Ciudad de México", "11830", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1862" },
                    { 1079, "0", "11", "09", "016", "11801", "09", "Ampliación Daniel Garza", "Ciudad de México", "11840", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1863" },
                    { 1080, "0", "11", "09", "016", "11801", "09", "San Miguel Chapultepec I Sección", "Ciudad de México", "11850", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1864" },
                    { 1081, "0", "11", "09", "016", "11801", "09", "San Miguel Chapultepec II Sección", "Ciudad de México", "11850", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2786" },
                    { 1082, "0", "11", "09", "016", "11801", "09", "Observatorio", "Ciudad de México", "11860", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1865" },
                    { 1083, "0", "11", "09", "016", "11801", "09", "Tacubaya", "Ciudad de México", "11870", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1867" },
                    { 1084, "0", "11", "09", "016", "11801", "09", "Lomas de Bezares", "Ciudad de México", "11910", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1869" },
                    { 1085, "0", "11", "09", "016", "11801", "09", "Real de las Lomas", "Ciudad de México", "11920", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1870" },
                    { 1086, "0", "11", "09", "016", "11801", "09", "Lomas de Reforma", "Ciudad de México", "11930", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "2789" },
                    { 1087, "0", "11", "09", "016", "11801", "09", "Lomas Altas", "Ciudad de México", "11950", "11801", "Ciudad de México", "Miguel Hidalgo", "Colonia", "Urbano", "1874" },
                    { 1088, "0", "12", "09", "009", "12001", "02", "La Concepción", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1877" },
                    { 1089, "0", "12", "09", "009", "12001", "02", "La Luz", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1878" },
                    { 1090, "0", "12", "09", "009", "12001", "02", "Los Ángeles", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1879" },
                    { 1091, "0", "12", "09", "009", "12001", "02", "San Mateo", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1881" },
                    { 1092, "0", "12", "09", "009", "12001", "02", "Santa Cruz", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1882" },
                    { 1093, "0", "12", "09", "009", "12001", "02", "Santa Martha", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1883" },
                    { 1094, "0", "12", "09", "009", "12001", "09", "Villa Milpa Alta Centro", "Ciudad de México", "12000", "12001", "Ciudad de México", "Milpa Alta", "Colonia", "Urbano", "1884" },
                    { 1095, "0", "12", "09", "009", "12001", "02", "San Agustin", "Ciudad de México", "12070", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1889" },
                    { 1096, "0", "12", "09", "009", "12001", "28", "San Agustin Ohtenco", "Ciudad de México", "12080", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1890" },
                    { 1097, "0", "12", "09", "009", "12001", "02", "Cruztitla", "Ciudad de México", "12100", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1891" },
                    { 1098, "0", "12", "09", "009", "12001", "02", "Tecaxtitla", "Ciudad de México", "12100", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1893" },
                    { 1099, "0", "12", "09", "009", "12001", "02", "Tenantitla", "Ciudad de México", "12100", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1894" },
                    { 1100, "0", "12", "09", "009", "12001", "02", "Xaltipac", "Ciudad de México", "12100", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1895" },
                    { 1101, "0", "12", "09", "009", "12001", "02", "Xochitepec", "Ciudad de México", "12100", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1896" },
                    { 1102, "0", "12", "09", "009", "13611", "09", "Emiliano Zapata", "Ciudad de México", "12110", "13611", "Ciudad de México", "Milpa Alta", "Colonia", "Urbano", "2010" },
                    { 1103, "0", "12", "09", "009", "13611", "09", "La Conchita", "Ciudad de México", "12110", "13611", "Ciudad de México", "Milpa Alta", "Colonia", "Urbano", "2011" },
                    { 1104, "0", "12", "09", "009", "12001", "02", "Nochtla", "Ciudad de México", "12200", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1897" },
                    { 1105, "0", "12", "09", "009", "12001", "02", "Ocotitla", "Ciudad de México", "12200", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1898" },
                    { 1106, "0", "12", "09", "009", "12001", "02", "Panchimalco", "Ciudad de México", "12200", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1899" },
                    { 1107, "0", "12", "09", "009", "12001", "02", "Tula", "Ciudad de México", "12200", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1901" },
                    { 1108, "0", "12", "09", "009", "12001", "28", "San Bartolomé Xicomulco", "Ciudad de México", "12250", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1903" },
                    { 1109, "0", "12", "09", "009", "12001", "28", "San Salvador Cuauhtenco", "Ciudad de México", "12300", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1904" },
                    { 1110, "0", "12", "09", "009", "12001", "02", "Centro", "Ciudad de México", "12400", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1905" },
                    { 1111, "0", "12", "09", "009", "12001", "02", "San Juan", "Ciudad de México", "12400", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1906" },
                    { 1112, "0", "12", "09", "009", "12001", "02", "San Miguel", "Ciudad de México", "12400", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1907" },
                    { 1113, "0", "12", "09", "009", "12001", "02", "Chalmita", "Ciudad de México", "12410", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "2870" },
                    { 1114, "0", "12", "09", "009", "12001", "28", "San Lorenzo Tlacoyucan", "Ciudad de México", "12500", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1910" },
                    { 1115, "0", "12", "09", "009", "12001", "28", "San Jerónimo Miacatlán", "Ciudad de México", "12600", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1911" },
                    { 1116, "0", "12", "09", "009", "12001", "28", "San Francisco Tecoxpa", "Ciudad de México", "12700", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1912" },
                    { 1117, "0", "12", "09", "009", "12001", "28", "San Juan Tepenahuac", "Ciudad de México", "12800", "12001", "Ciudad de México", "Milpa Alta", "Pueblo", "Urbano", "1913" },
                    { 1118, "0", "12", "09", "009", "12001", "02", "La Lupita Teticpac", "Ciudad de México", "12910", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "2871" },
                    { 1119, "0", "12", "09", "009", "12001", "02", "San Marcos", "Ciudad de México", "12920", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "1880" },
                    { 1120, "0", "12", "09", "009", "12001", "02", "San Miguel", "Ciudad de México", "12930", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "2873" },
                    { 1121, "0", "12", "09", "009", "12001", "02", "San José", "Ciudad de México", "12940", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "2874" },
                    { 1122, "0", "12", "09", "009", "12001", "02", "La Lupita Xolco", "Ciudad de México", "12950", "12001", "Ciudad de México", "Milpa Alta", "Barrio", "Urbano", "2872" },
                    { 1123, "0", "13", "09", "011", "13011", "02", "La Asunción", "Ciudad de México", "13000", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1919" },
                    { 1124, "0", "13", "09", "011", "13011", "09", "Santa Cecilia", "Ciudad de México", "13010", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1923" },
                    { 1125, "0", "13", "09", "011", "13011", "09", "San José", "Ciudad de México", "13020", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1924" },
                    { 1126, "0", "13", "09", "011", "13011", "02", "San Juan", "Ciudad de México", "13030", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1925" },
                    { 1127, "0", "13", "09", "011", "13011", "02", "San Mateo", "Ciudad de México", "13040", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1926" },
                    { 1128, "0", "13", "09", "011", "13011", "09", "La Habana", "Ciudad de México", "13050", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1928" },
                    { 1129, "0", "13", "09", "011", "13011", "02", "La Guadalupe", "Ciudad de México", "13060", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1929" },
                    { 1130, "0", "13", "09", "011", "13011", "02", "Santa Ana", "Ciudad de México", "13060", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1930" },
                    { 1131, "0", "13", "09", "011", "13011", "02", "La Magdalena", "Ciudad de México", "13070", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1931" },
                    { 1132, "0", "13", "09", "011", "13011", "02", "San Miguel", "Ciudad de México", "13070", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1932" },
                    { 1133, "0", "13", "09", "011", "13011", "02", "Los Reyes", "Ciudad de México", "13080", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1933" },
                    { 1134, "0", "13", "09", "011", "13011", "09", "Quiahuatla", "Ciudad de México", "13090", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1934" },
                    { 1135, "0", "13", "09", "011", "13011", "09", "San Sebastián", "Ciudad de México", "13093", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2497" },
                    { 1136, "0", "13", "09", "011", "13011", "09", "San Isidro", "Ciudad de México", "13094", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2898" },
                    { 1137, "0", "13", "09", "011", "13011", "02", "San Andrés", "Ciudad de México", "13099", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1935" },
                    { 1138, "0", "13", "09", "011", "13011", "02", "La Guadalupe", "Ciudad de México", "13100", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1937" },
                    { 1139, "0", "13", "09", "011", "13011", "09", "Ampliación Santa Catarina", "Ciudad de México", "13120", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1942" },
                    { 1140, "0", "13", "09", "011", "13011", "02", "Santiago", "Ciudad de México", "13120", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1943" },
                    { 1141, "0", "13", "09", "011", "13011", "02", "La Concepción", "Ciudad de México", "13150", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1945" },
                    { 1142, "0", "13", "09", "011", "13011", "02", "San Miguel", "Ciudad de México", "13180", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1946" },
                    { 1143, "0", "13", "09", "011", "13221", "09", "Miguel Hidalgo", "Ciudad de México", "13200", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1947" },
                    { 1144, "0", "13", "09", "011", "13221", "09", "Los Olivos", "Ciudad de México", "13210", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1949" },
                    { 1145, "0", "13", "09", "011", "13221", "09", "Las Arboledas", "Ciudad de México", "13219", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1950" },
                    { 1146, "0", "13", "09", "011", "13221", "09", "Ampliación Los Olivos", "Ciudad de México", "13219", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1951" },
                    { 1147, "0", "13", "09", "011", "13221", "09", "La Nopalera", "Ciudad de México", "13220", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1952" },
                    { 1148, "0", "13", "09", "011", "13221", "09", "Granjas Cabrera", "Ciudad de México", "13230", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1955" },
                    { 1149, "0", "13", "09", "011", "13221", "09", "La Turba", "Ciudad de México", "13250", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1957" },
                    { 1150, "0", "13", "09", "011", "13221", "09", "Del Mar", "Ciudad de México", "13270", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1958" },
                    { 1151, "0", "13", "09", "011", "13221", "09", "La Draga", "Ciudad de México", "13273", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2580" },
                    { 1152, "0", "13", "09", "011", "13221", "09", "Villa Centroamericana", "Ciudad de México", "13278", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1959" },
                    { 1153, "0", "13", "09", "011", "13221", "09", "Agrícola Metropolitana", "Ciudad de México", "13280", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1962" },
                    { 1154, "0", "13", "09", "011", "13221", "02", "Santa Ana Centro", "Ciudad de México", "13300", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1963" },
                    { 1155, "0", "13", "09", "011", "13221", "02", "Santiago Centro", "Ciudad de México", "13300", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1964" },
                    { 1156, "0", "13", "09", "011", "13221", "02", "Santa Ana Poniente", "Ciudad de México", "13300", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2891" },
                    { 1157, "0", "13", "09", "011", "13221", "02", "Santa Ana Norte", "Ciudad de México", "13300", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2893" },
                    { 1158, "0", "13", "09", "011", "13221", "02", "Santiago Norte", "Ciudad de México", "13300", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2894" },
                    { 1159, "0", "13", "09", "011", "13221", "09", "Zapotitla", "Ciudad de México", "13310", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1966" },
                    { 1160, "0", "13", "09", "011", "13221", "09", "Ampliación Zapotitla", "Ciudad de México", "13315", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2897" },
                    { 1161, "0", "13", "09", "011", "13221", "09", "La Estación", "Ciudad de México", "13319", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1970" },
                    { 1162, "0", "13", "09", "011", "13221", "09", "La Conchita Zapotitlán", "Ciudad de México", "13360", "13221", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1971" },
                    { 1163, "0", "13", "09", "011", "13221", "02", "Santa Ana Sur", "Ciudad de México", "13360", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2895" },
                    { 1164, "0", "13", "09", "011", "13221", "02", "Santiago Sur", "Ciudad de México", "13360", "13221", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2896" },
                    { 1165, "0", "13", "09", "011", "13011", "28", "San Francisco Tlaltenco", "Ciudad de México", "13400", "13011", "Ciudad de México", "Tláhuac", "Pueblo", "Urbano", "1972" },
                    { 1166, "0", "13", "09", "011", "13011", "09", "López Portillo", "Ciudad de México", "13410", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1973" },
                    { 1167, "0", "13", "09", "011", "13011", "09", "Ampliación José López Portillo", "Ciudad de México", "13419", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1975" },
                    { 1168, "0", "13", "09", "011", "13011", "09", "Selene", "Ciudad de México", "13420", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1976" },
                    { 1169, "0", "13", "09", "011", "13011", "09", "Ampliación Selene", "Ciudad de México", "13430", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1978" },
                    { 1170, "0", "13", "09", "011", "13011", "09", "Zacatenco", "Ciudad de México", "13440", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1980" },
                    { 1171, "0", "13", "09", "011", "13011", "09", "Guadalupe Tlaltenco", "Ciudad de México", "13450", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1981" },
                    { 1172, "0", "13", "09", "011", "13011", "09", "Ojo de Agua", "Ciudad de México", "13450", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1982" },
                    { 1173, "0", "13", "09", "011", "13011", "09", "El Triángulo", "Ciudad de México", "13460", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1983" },
                    { 1174, "0", "13", "09", "011", "13011", "02", "San Agustín", "Ciudad de México", "13508", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1985" },
                    { 1175, "0", "13", "09", "011", "13011", "02", "La Soledad", "Ciudad de México", "13508", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2593" },
                    { 1176, "0", "13", "09", "011", "13011", "02", "La Concepción", "Ciudad de México", "13509", "13011", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "1986" },
                    { 1177, "0", "13", "09", "011", "13011", "09", "La Lupita", "Ciudad de México", "13510", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1987" },
                    { 1178, "0", "13", "09", "011", "13011", "09", "Francisco Villa", "Ciudad de México", "13520", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1988" },
                    { 1179, "0", "13", "09", "011", "13011", "09", "Jaime Torres Bodet", "Ciudad de México", "13530", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1990" },
                    { 1180, "0", "13", "09", "011", "13011", "09", "La Asunción", "Ciudad de México", "13530", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1991" },
                    { 1181, "0", "13", "09", "011", "13011", "09", "El Rosario", "Ciudad de México", "13540", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1992" },
                    { 1182, "0", "13", "09", "011", "13011", "09", "Tierra Blanca", "Ciudad de México", "13540", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1994" },
                    { 1183, "0", "13", "09", "011", "13011", "09", "Ampliación La Conchita", "Ciudad de México", "13545", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2587" },
                    { 1184, "0", "13", "09", "011", "13011", "09", "Peña Alta", "Ciudad de México", "13549", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1995" },
                    { 1185, "0", "13", "09", "011", "13011", "09", "Jardines del Llano", "Ciudad de México", "13550", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1997" },
                    { 1186, "0", "13", "09", "011", "13011", "09", "Potrero del Llano", "Ciudad de México", "13550", "13011", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "1998" },
                    { 1187, "0", "13", "09", "011", "13611", "02", "San Bartolomé", "Ciudad de México", "13600", "13611", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2002" },
                    { 1188, "0", "13", "09", "011", "13611", "02", "Los Reyes", "Ciudad de México", "13610", "13611", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2004" },
                    { 1189, "0", "13", "09", "011", "13611", "02", "Santa Cruz", "Ciudad de México", "13625", "13611", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2005" },
                    { 1190, "0", "13", "09", "011", "13611", "02", "San Agustín", "Ciudad de México", "13630", "13611", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2007" },
                    { 1191, "0", "13", "09", "011", "13611", "02", "San Miguel", "Ciudad de México", "13640", "13611", "Ciudad de México", "Tláhuac", "Barrio", "Urbano", "2008" },
                    { 1192, "0", "13", "09", "011", "13611", "28", "San Nicolás Tetelco", "Ciudad de México", "13700", "13611", "Ciudad de México", "Tláhuac", "Pueblo", "Urbano", "2009" },
                    { 1193, "0", "13", "09", "011", "13611", "09", "Tepantitlamilco", "Ciudad de México", "13700", "13611", "Ciudad de México", "Tláhuac", "Colonia", "Urbano", "2892" },
                    { 1194, "0", "14", "09", "012", "14091", "09", "Tlalpan Centro", "Ciudad de México", "14000", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2027" },
                    { 1195, "0", "14", "09", "012", "14091", "09", "Tlalpan", "Ciudad de México", "14000", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2876" },
                    { 1196, "0", "14", "09", "012", "14091", "09", "Parque del Pedregal", "Ciudad de México", "14010", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2029" },
                    { 1197, "0", "14", "09", "012", "14091", "09", "Villa Olímpica", "Ciudad de México", "14020", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2035" },
                    { 1198, "0", "14", "09", "012", "14091", "09", "Isidro Fabela", "Ciudad de México", "14030", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2036" },
                    { 1199, "0", "14", "09", "012", "14091", "09", "Ampliación Isidro Fabela", "Ciudad de México", "14039", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2041" },
                    { 1200, "0", "14", "09", "012", "14091", "09", "Cantera Puente de Piedra", "Ciudad de México", "14040", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2042" },
                    { 1201, "0", "14", "09", "012", "14091", "09", "Pueblo Quieto", "Ciudad de México", "14040", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2043" },
                    { 1202, "0", "14", "09", "012", "14091", "09", "Comuneros de Santa Úrsula", "Ciudad de México", "14049", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2044" },
                    { 1203, "0", "14", "09", "012", "14091", "09", "Toriello Guerra", "Ciudad de México", "14050", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2045" },
                    { 1204, "0", "14", "09", "012", "14091", "09", "Peña Pobre", "Ciudad de México", "14060", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2046" },
                    { 1205, "0", "14", "09", "012", "14091", "09", "Rómulo Sánchez Mireles", "Ciudad de México", "14070", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2048" },
                    { 1206, "0", "14", "09", "012", "14091", "02", "San Fernando", "Ciudad de México", "14070", "14091", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2049" },
                    { 1207, "0", "14", "09", "012", "14091", "09", "San Pedro Apóstol", "Ciudad de México", "14070", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2050" },
                    { 1208, "0", "14", "09", "012", "14091", "09", "Belisario Domínguez Sección XVI", "Ciudad de México", "14080", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2051" },
                    { 1209, "0", "14", "09", "012", "14091", "02", "Del Niño Jesús", "Ciudad de México", "14080", "14091", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2052" },
                    { 1210, "0", "14", "09", "012", "14091", "09", "La Joya", "Ciudad de México", "14090", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2054" },
                    { 1211, "0", "14", "09", "012", "14201", "09", "Pedregal de San Nicolás 1A Sección", "Ciudad de México", "14100", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2060" },
                    { 1212, "0", "14", "09", "012", "14201", "09", "Pedregal de San Nicolás 2A Sección", "Ciudad de México", "14100", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2061" },
                    { 1213, "0", "14", "09", "012", "14201", "09", "Pedregal de San Nicolás 3A Sección", "Ciudad de México", "14100", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2062" },
                    { 1214, "0", "14", "09", "012", "14201", "09", "Pedregal de San Nicolás 4A Sección", "Ciudad de México", "14100", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2063" },
                    { 1215, "0", "14", "09", "012", "14201", "09", "Pedregal de San Nicolás 5ª Sección", "Ciudad de México", "14100", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2064" },
                    { 1216, "0", "14", "09", "012", "14201", "09", "Chichicaspatl", "Ciudad de México", "14108", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2067" },
                    { 1217, "0", "14", "09", "012", "14201", "09", "Ampliación Fuentes del Pedregal", "Ciudad de México", "14110", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2881" },
                    { 1218, "0", "14", "09", "012", "14201", "09", "Rincón del Pedregal", "Ciudad de México", "14120", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2071" },
                    { 1219, "0", "14", "09", "012", "14201", "09", "Fuentes del Pedregal", "Ciudad de México", "14140", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2074" },
                    { 1220, "0", "14", "09", "012", "14201", "09", "Lomas del Pedregal Framboyanes", "Ciudad de México", "14150", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2078" },
                    { 1221, "0", "14", "09", "012", "14201", "09", "Popular Santa Teresa", "Ciudad de México", "14160", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2079" },
                    { 1222, "0", "14", "09", "012", "14201", "09", "Héroes de Padierna", "Ciudad de México", "14200", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2080" },
                    { 1223, "0", "14", "09", "012", "14201", "09", "Jardines del Ajusco", "Ciudad de México", "14200", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2081" },
                    { 1224, "0", "14", "09", "012", "14201", "09", "Colinas del Ajusco", "Ciudad de México", "14208", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2083" },
                    { 1225, "0", "14", "09", "012", "14201", "09", "Torres de Padierna", "Ciudad de México", "14209", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2084" },
                    { 1226, "0", "14", "09", "012", "14201", "09", "Jardines en la Montaña", "Ciudad de México", "14210", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2085" },
                    { 1227, "0", "14", "09", "012", "14201", "17", "Six Flags (Reino Aventura)", "Ciudad de México", "14219", "14201", "Ciudad de México", "Tlalpan", "Equipamiento", "Urbano", "2087" },
                    { 1228, "0", "14", "09", "012", "14201", "17", "Parque Nacional Bosque del Pedregal", "Ciudad de México", "14219", "14201", "Ciudad de México", "Tlalpan", "Equipamiento", "Urbano", "2187" },
                    { 1229, "0", "14", "09", "012", "14201", "09", "Cuchilla de Padierna", "Ciudad de México", "14220", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2088" },
                    { 1230, "0", "14", "09", "012", "14201", "09", "Lomas del Pedregal", "Ciudad de México", "14220", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2090" },
                    { 1231, "0", "14", "09", "012", "14201", "09", "Cultura Maya", "Ciudad de México", "14230", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2091" },
                    { 1232, "0", "14", "09", "012", "14201", "09", "Los Encinos", "Ciudad de México", "14239", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2093" },
                    { 1233, "0", "14", "09", "012", "14201", "09", "Lomas de Padierna", "Ciudad de México", "14240", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2094" },
                    { 1234, "0", "14", "09", "012", "14201", "09", "Lomas Hidalgo", "Ciudad de México", "14240", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2095" },
                    { 1235, "0", "14", "09", "012", "14201", "09", "Cruz del Farol", "Ciudad de México", "14248", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2096" },
                    { 1236, "0", "14", "09", "012", "14201", "09", "Miguel Hidalgo 2A Sección", "Ciudad de México", "14250", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2098" },
                    { 1237, "0", "14", "09", "012", "14201", "09", "Miguel Hidalgo 3A Sección", "Ciudad de México", "14250", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2099" },
                    { 1238, "0", "14", "09", "012", "14201", "09", "Miguel Hidalgo 4A Sección", "Ciudad de México", "14250", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2100" },
                    { 1239, "0", "14", "09", "012", "14201", "09", "Miguel Hidalgo", "Ciudad de México", "14250", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2101" },
                    { 1240, "0", "14", "09", "012", "14201", "02", "El Capulín", "Ciudad de México", "14260", "14201", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2102" },
                    { 1241, "0", "14", "09", "012", "14201", "09", "Miguel Hidalgo 1A Sección", "Ciudad de México", "14260", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2103" },
                    { 1242, "0", "14", "09", "012", "14201", "09", "Zacayucan Peña Pobre", "Ciudad de México", "14266", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2106" },
                    { 1243, "0", "14", "09", "012", "14201", "02", "De Caramagüey", "Ciudad de México", "14267", "14201", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2107" },
                    { 1244, "0", "14", "09", "012", "14201", "02", "La Lonja", "Ciudad de México", "14268", "14201", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2108" },
                    { 1245, "0", "14", "09", "012", "14201", "02", "La Fama", "Ciudad de México", "14269", "14201", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2109" },
                    { 1246, "0", "14", "09", "012", "14201", "09", "Primavera", "Ciudad de México", "14270", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2110" },
                    { 1247, "0", "14", "09", "012", "14201", "09", "Paraje 38", "Ciudad de México", "14275", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2111" },
                    { 1248, "0", "14", "09", "012", "14391", "09", "Nueva Oriental Coapa", "Ciudad de México", "14300", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2113" },
                    { 1249, "0", "14", "09", "012", "14391", "09", "Residencial Acoxpa", "Ciudad de México", "14300", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2114" },
                    { 1250, "0", "14", "09", "012", "14391", "09", "Residencial Miramontes", "Ciudad de México", "14300", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2115" },
                    { 1251, "0", "14", "09", "012", "14391", "09", "Ex Hacienda Coapa", "Ciudad de México", "14308", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2879" },
                    { 1252, "0", "14", "09", "012", "14391", "09", "Belisario Domínguez", "Ciudad de México", "14310", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2120" },
                    { 1253, "0", "14", "09", "012", "14391", "09", "Floresta Coyoacán", "Ciudad de México", "14310", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2121" },
                    { 1254, "0", "14", "09", "012", "14391", "09", "Vergel Coapa", "Ciudad de México", "14320", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2123" },
                    { 1255, "0", "14", "09", "012", "14391", "09", "Rinconada Coapa 2A Sección", "Ciudad de México", "14325", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2125" },
                    { 1256, "0", "14", "09", "012", "14391", "09", "Tenorios", "Ciudad de México", "14326", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2126" },
                    { 1257, "0", "14", "09", "012", "14391", "09", "Granjas Coapa", "Ciudad de México", "14330", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2132" },
                    { 1258, "0", "14", "09", "012", "14391", "09", "Rinconada Coapa 1A Sección", "Ciudad de México", "14330", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2134" },
                    { 1259, "0", "14", "09", "012", "14391", "09", "Vergel de Coyoacán", "Ciudad de México", "14340", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2145" },
                    { 1260, "0", "14", "09", "012", "14391", "09", "Vergel del Sur", "Ciudad de México", "14340", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2146" },
                    { 1261, "0", "14", "09", "012", "14391", "09", "Prado Coapa 1A Sección", "Ciudad de México", "14350", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2147" },
                    { 1262, "0", "14", "09", "012", "14391", "09", "Prado Coapa 2A Sección", "Ciudad de México", "14357", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2149" },
                    { 1263, "0", "14", "09", "012", "14391", "09", "Prado Coapa 3A Sección", "Ciudad de México", "14357", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2150" },
                    { 1264, "0", "14", "09", "012", "14391", "09", "Magisterial", "Ciudad de México", "14360", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2153" },
                    { 1265, "0", "14", "09", "012", "14391", "09", "Magisterial Coapa", "Ciudad de México", "14360", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2877" },
                    { 1266, "0", "14", "09", "012", "14391", "09", "Residencial Chimali", "Ciudad de México", "14370", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2155" },
                    { 1267, "0", "14", "09", "012", "14391", "28", "San Lorenzo Huipulco", "Ciudad de México", "14370", "14391", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2157" },
                    { 1268, "0", "14", "09", "012", "14391", "09", "Villa Lázaro Cárdenas", "Ciudad de México", "14370", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2158" },
                    { 1269, "0", "14", "09", "012", "14391", "09", "Arboledas del Sur", "Ciudad de México", "14376", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2159" },
                    { 1270, "0", "14", "09", "012", "14391", "09", "Hacienda San Juan", "Ciudad de México", "14377", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2161" },
                    { 1271, "0", "14", "09", "012", "14391", "09", "A.M.S.A", "Ciudad de México", "14380", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2163" },
                    { 1272, "0", "14", "09", "012", "14391", "09", "San Bartolo El Chico", "Ciudad de México", "14380", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2167" },
                    { 1273, "0", "14", "09", "012", "14391", "09", "Rancho los Colorines", "Ciudad de México", "14386", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2168" },
                    { 1274, "0", "14", "09", "012", "14391", "09", "Ex Hacienda San Juan de Dios", "Ciudad de México", "14387", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2169" },
                    { 1275, "0", "14", "09", "012", "14391", "09", "Guadalupe", "Ciudad de México", "14388", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2170" },
                    { 1276, "0", "14", "09", "012", "14391", "09", "Arenal de Guadalupe", "Ciudad de México", "14389", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2172" },
                    { 1277, "0", "14", "09", "012", "14391", "09", "Rinconada Las Hadas", "Ciudad de México", "14390", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2174" },
                    { 1278, "0", "14", "09", "012", "14391", "09", "Narciso Mendoza", "Ciudad de México", "14390", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2175" },
                    { 1279, "0", "14", "09", "012", "14391", "09", "Residencial Villa Coapa", "Ciudad de México", "14390", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2176" },
                    { 1280, "0", "14", "09", "012", "14391", "09", "Villa Coapa", "Ciudad de México", "14390", "14391", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2878" },
                    { 1281, "0", "14", "09", "012", "14091", "28", "San Andrés Totoltepec", "Ciudad de México", "14400", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2179" },
                    { 1282, "0", "14", "09", "012", "14091", "09", "Divisadero", "Ciudad de México", "14406", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2182" },
                    { 1283, "0", "14", "09", "012", "14091", "09", "Nuevo Renacimiento de Axalco", "Ciudad de México", "14408", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2183" },
                    { 1284, "0", "14", "09", "012", "14091", "09", "Tecorral", "Ciudad de México", "14409", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2184" },
                    { 1285, "0", "14", "09", "012", "14091", "09", "Fuentes Brotantes", "Ciudad de México", "14410", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2186" },
                    { 1286, "0", "14", "09", "012", "14091", "09", "Cumbres de Tepetongo", "Ciudad de México", "14420", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2188" },
                    { 1287, "0", "14", "09", "012", "14091", "09", "Mesa de los Hornos", "Ciudad de México", "14420", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2190" },
                    { 1288, "0", "14", "09", "012", "14091", "28", "Santa Úrsula Xitla", "Ciudad de México", "14420", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2192" },
                    { 1289, "0", "14", "09", "012", "14091", "09", "Texcaltenco", "Ciudad de México", "14426", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2194" },
                    { 1290, "0", "14", "09", "012", "14091", "09", "Tlaxcaltenco la Mesa", "Ciudad de México", "14426", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2195" },
                    { 1291, "0", "14", "09", "012", "14091", "09", "San Juan Tepeximilpa", "Ciudad de México", "14427", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2196" },
                    { 1292, "0", "14", "09", "012", "14091", "09", "Tepeximilpa la Paz", "Ciudad de México", "14427", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2197" },
                    { 1293, "0", "14", "09", "012", "14091", "09", "Santísima Trinidad", "Ciudad de México", "14429", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2200" },
                    { 1294, "0", "14", "09", "012", "14091", "02", "El Truenito", "Ciudad de México", "14430", "14091", "Ciudad de México", "Tlalpan", "Barrio", "Urbano", "2201" },
                    { 1295, "0", "14", "09", "012", "14091", "09", "Tlalcoligia", "Ciudad de México", "14430", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2203" },
                    { 1296, "0", "14", "09", "012", "14091", "09", "Pedregal de Santa Úrsula Xitla", "Ciudad de México", "14438", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2205" },
                    { 1297, "0", "14", "09", "012", "14091", "09", "Pedregal de las Águilas", "Ciudad de México", "14439", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2206" },
                    { 1298, "0", "14", "09", "012", "14091", "09", "Los Volcanes", "Ciudad de México", "14440", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2207" },
                    { 1299, "0", "14", "09", "012", "14091", "09", "El Mirador 1A Sección", "Ciudad de México", "14449", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2208" },
                    { 1300, "0", "14", "09", "012", "14091", "09", "El Mirador 2A Sección", "Ciudad de México", "14449", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2209" },
                    { 1301, "0", "14", "09", "012", "14091", "09", "El Mirador 3A Sección", "Ciudad de México", "14449", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2210" },
                    { 1302, "0", "14", "09", "012", "14091", "09", "Tlalpuente", "Ciudad de México", "14460", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2213" },
                    { 1303, "0", "14", "09", "012", "14091", "09", "Plan de Ayala", "Ciudad de México", "14470", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2214" },
                    { 1304, "0", "14", "09", "012", "14091", "09", "La Palma", "Ciudad de México", "14476", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2216" },
                    { 1305, "0", "14", "09", "012", "14091", "09", "Viveros Coatectlán", "Ciudad de México", "14479", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2219" },
                    { 1306, "0", "14", "09", "012", "14091", "28", "La Magdalena Petlacalco", "Ciudad de México", "14480", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2220" },
                    { 1307, "0", "14", "09", "012", "14091", "28", "San Miguel Xicalco", "Ciudad de México", "14490", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2221" },
                    { 1308, "0", "14", "09", "012", "14091", "28", "San Miguel Topilejo", "Ciudad de México", "14500", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2222" },
                    { 1309, "0", "14", "09", "012", "14091", "09", "Valle Escondido", "Ciudad de México", "14600", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2229" },
                    { 1310, "0", "14", "09", "012", "14091", "09", "Colinas del Bosque", "Ciudad de México", "14608", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2231" },
                    { 1311, "0", "14", "09", "012", "14091", "09", "Las Tórtolas", "Ciudad de México", "14609", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2232" },
                    { 1312, "0", "14", "09", "012", "14091", "09", "Arenal Tepepan", "Ciudad de México", "14610", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2233" },
                    { 1313, "0", "14", "09", "012", "14091", "09", "Club de Golf México", "Ciudad de México", "14620", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2741" },
                    { 1314, "0", "14", "09", "012", "14091", "09", "San Buenaventura", "Ciudad de México", "14629", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2236" },
                    { 1315, "0", "14", "09", "012", "14091", "28", "Chimalcoyoc", "Ciudad de México", "14630", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2237" },
                    { 1316, "0", "14", "09", "012", "14091", "09", "Villa Tlalpan", "Ciudad de México", "14630", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2238" },
                    { 1317, "0", "14", "09", "012", "14091", "09", "Ejidos de San Pedro Mártir", "Ciudad de México", "14640", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2240" },
                    { 1318, "0", "14", "09", "012", "14091", "09", "Fuentes de Tepepan", "Ciudad de México", "14643", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2241" },
                    { 1319, "0", "14", "09", "012", "14091", "09", "Valle de Tepepan", "Ciudad de México", "14646", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2245" },
                    { 1320, "0", "14", "09", "012", "14091", "09", "Juventud Unida", "Ciudad de México", "14647", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2246" },
                    { 1321, "0", "14", "09", "012", "14091", "09", "Movimiento Organizado de Tlalpan", "Ciudad de México", "14647", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2247" },
                    { 1322, "0", "14", "09", "012", "14091", "09", "Rinconada El Mirador", "Ciudad de México", "14647", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2880" },
                    { 1323, "0", "14", "09", "012", "14091", "28", "San Pedro Mártir", "Ciudad de México", "14650", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2252" },
                    { 1324, "0", "14", "09", "012", "14091", "09", "Heróico Colegio Militar", "Ciudad de México", "14653", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2882" },
                    { 1325, "0", "14", "09", "012", "14091", "09", "Tlalmille", "Ciudad de México", "14657", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2258" },
                    { 1326, "0", "14", "09", "012", "14091", "09", "Mirador del Valle", "Ciudad de México", "14658", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2259" },
                    { 1327, "0", "14", "09", "012", "14091", "09", "María Esther Zuno de Echeverría", "Ciudad de México", "14659", "14091", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2260" },
                    { 1328, "0", "14", "09", "012", "14201", "28", "San Miguel Ajusco", "Ciudad de México", "14700", "14201", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2261" },
                    { 1329, "0", "14", "09", "012", "14201", "28", "Santo Tomas Ajusco", "Ciudad de México", "14710", "14201", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2262" },
                    { 1330, "0", "14", "09", "012", "14201", "09", "Belvedere Ajusco", "Ciudad de México", "14720", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2263" },
                    { 1331, "0", "14", "09", "012", "14201", "09", "Lomas de Cuilotepec", "Ciudad de México", "14730", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2265" },
                    { 1332, "0", "14", "09", "012", "14201", "04", "Lomas de Tepemecatl", "Ciudad de México", "14735", "14201", "Ciudad de México", "Tlalpan", "Campamento", "Rural", "2695" },
                    { 1333, "0", "14", "09", "012", "14201", "09", "Vistas del Pedregal", "Ciudad de México", "14737", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2268" },
                    { 1334, "0", "14", "09", "012", "14201", "09", "Bosques del Pedregal", "Ciudad de México", "14738", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2269" },
                    { 1335, "0", "14", "09", "012", "14201", "09", "2 de Octubre", "Ciudad de México", "14739", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2270" },
                    { 1336, "0", "14", "09", "012", "14201", "09", "Lomas de Padierna Sur", "Ciudad de México", "14740", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2272" },
                    { 1337, "0", "14", "09", "012", "14201", "09", "Mirador I", "Ciudad de México", "14748", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2273" },
                    { 1338, "0", "14", "09", "012", "14201", "09", "Mirador II", "Ciudad de México", "14748", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2274" },
                    { 1339, "0", "14", "09", "012", "14201", "09", "Chimilli", "Ciudad de México", "14749", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2275" },
                    { 1340, "0", "14", "09", "012", "14201", "09", "Héroes de 1910", "Ciudad de México", "14760", "14201", "Ciudad de México", "Tlalpan", "Colonia", "Urbano", "2278" },
                    { 1341, "0", "14", "09", "012", "14091", "28", "Parres El Guarda", "Ciudad de México", "14900", "14091", "Ciudad de México", "Tlalpan", "Pueblo", "Urbano", "2286" },
                    { 1342, "0", "15", "09", "017", "15001", "09", "General Ignacio Zaragoza", "Ciudad de México", "15000", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2287" },
                    { 1343, "0", "15", "09", "017", "15001", "09", "Valentín Gómez Farias", "Ciudad de México", "15010", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2289" },
                    { 1344, "0", "15", "09", "017", "15001", "09", "Puebla", "Ciudad de México", "15020", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2290" },
                    { 1345, "0", "15", "09", "017", "15001", "09", "Zona Centro", "Ciudad de México", "15100", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2291" },
                    { 1346, "0", "15", "09", "017", "15001", "09", "Janitzio", "Ciudad de México", "15200", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2293" },
                    { 1347, "0", "15", "09", "017", "15001", "09", "Valle Gómez", "Ciudad de México", "15210", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2294" },
                    { 1348, "0", "15", "09", "017", "15001", "09", "Nicolás Bravo", "Ciudad de México", "15220", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2295" },
                    { 1349, "0", "15", "09", "017", "15001", "09", "Popular Rastro", "Ciudad de México", "15220", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2296" },
                    { 1350, "0", "15", "09", "017", "15001", "09", "Emilio Carranza", "Ciudad de México", "15230", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2297" },
                    { 1351, "0", "15", "09", "017", "15001", "09", "Michoacana", "Ciudad de México", "15240", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2298" },
                    { 1352, "0", "15", "09", "017", "15001", "09", "Ampliación Michoacana", "Ciudad de México", "15250", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2299" },
                    { 1353, "0", "15", "09", "017", "15001", "09", "Ampliación 20 de Noviembre", "Ciudad de México", "15260", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2300" },
                    { 1354, "0", "15", "09", "017", "15001", "09", "Morelos", "Ciudad de México", "15270", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2301" },
                    { 1355, "0", "15", "09", "017", "15001", "09", "Penitenciaria", "Ciudad de México", "15280", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2302" },
                    { 1356, "0", "15", "09", "017", "15001", "09", "10 de Mayo", "Ciudad de México", "15290", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2303" },
                    { 1357, "0", "15", "09", "017", "15001", "09", "20 de Noviembre", "Ciudad de México", "15300", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2305" },
                    { 1358, "0", "15", "09", "017", "15001", "09", "5o Tramo 20 de Noviembre", "Ciudad de México", "15309", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2307" },
                    { 1359, "0", "15", "09", "017", "15001", "09", "Felipe Ángeles", "Ciudad de México", "15310", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2308" },
                    { 1360, "0", "15", "09", "017", "15001", "09", "Azteca", "Ciudad de México", "15320", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2309" },
                    { 1361, "0", "15", "09", "017", "15001", "09", "Tres Mosqueteros", "Ciudad de México", "15330", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2310" },
                    { 1362, "0", "15", "09", "017", "15001", "09", "Ampliación Venustiano Carranza", "Ciudad de México", "15339", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2311" },
                    { 1363, "0", "15", "09", "017", "15001", "09", "Venustiano Carranza", "Ciudad de México", "15340", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2312" },
                    { 1364, "0", "15", "09", "017", "15001", "09", "Ampliación Penitenciaria", "Ciudad de México", "15350", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2313" },
                    { 1365, "0", "15", "09", "017", "15001", "09", "Progresista", "Ciudad de México", "15370", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2315" },
                    { 1366, "0", "15", "09", "017", "15001", "09", "Escuela de Tiro", "Ciudad de México", "15380", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2316" },
                    { 1367, "0", "15", "09", "017", "15001", "09", "7 de Julio", "Ciudad de México", "15390", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2319" },
                    { 1368, "0", "15", "09", "017", "15001", "09", "Romero Rubio", "Ciudad de México", "15400", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2320" },
                    { 1369, "0", "15", "09", "017", "15001", "09", "Simón Bolívar", "Ciudad de México", "15410", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2321" },
                    { 1370, "0", "15", "09", "017", "15001", "09", "Ampliación Simón Bolívar", "Ciudad de México", "15420", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2322" },
                    { 1371, "0", "15", "09", "017", "15001", "09", "Aquiles Serdán", "Ciudad de México", "15430", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2323" },
                    { 1372, "0", "15", "09", "017", "15001", "09", "1° de Mayo", "Ciudad de México", "15440", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2324" },
                    { 1373, "0", "15", "09", "017", "15001", "09", "Damián Carmona", "Ciudad de México", "15450", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2325" },
                    { 1374, "0", "15", "09", "017", "15001", "09", "Revolución", "Ciudad de México", "15460", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2326" },
                    { 1375, "0", "15", "09", "017", "15001", "09", "Miguel Hidalgo", "Ciudad de México", "15470", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2327" },
                    { 1376, "0", "15", "09", "017", "15001", "09", "Moctezuma 1a Sección", "Ciudad de México", "15500", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2328" },
                    { 1377, "0", "15", "09", "017", "15001", "09", "Pensador Mexicano", "Ciudad de México", "15510", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2330" },
                    { 1378, "0", "15", "09", "017", "15001", "09", "Peñón de los Baños", "Ciudad de México", "15520", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2331" },
                    { 1379, "0", "15", "09", "017", "15001", "09", "Moctezuma 2a Sección", "Ciudad de México", "15530", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2332" },
                    { 1380, "0", "15", "09", "017", "15001", "09", "Santa Cruz Aviación", "Ciudad de México", "15540", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2333" },
                    { 1381, "0", "15", "09", "017", "15001", "09", "Arenal 1a Sección", "Ciudad de México", "15600", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2334" },
                    { 1382, "0", "15", "09", "017", "15001", "09", "Cuchilla Pantitlán", "Ciudad de México", "15610", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2335" },
                    { 1383, "0", "15", "09", "017", "15001", "01", "México (Lic. Benito Juárez)", "Ciudad de México", "15620", "15001", "Ciudad de México", "Venustiano Carranza", "Aeropuerto", "Urbano", "2336" },
                    { 1384, "0", "15", "09", "017", "15001", "09", "Caracol", "Ciudad de México", "15630", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2340" },
                    { 1385, "0", "15", "09", "017", "15001", "09", "Arenal 4a Sección", "Ciudad de México", "15640", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2342" },
                    { 1386, "0", "15", "09", "017", "15001", "09", "Arenal Puerto Aéreo", "Ciudad de México", "15640", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2351" },
                    { 1387, "0", "15", "09", "017", "15001", "09", "Ampliación Caracol", "Ciudad de México", "15650", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2343" },
                    { 1388, "0", "15", "09", "017", "15001", "09", "Arenal 3a Sección", "Ciudad de México", "15660", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2344" },
                    { 1389, "0", "15", "09", "017", "15001", "09", "Adolfo López Mateos", "Ciudad de México", "15670", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2346" },
                    { 1390, "0", "15", "09", "017", "15001", "09", "Arenal 2a Sección", "Ciudad de México", "15680", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2347" },
                    { 1391, "0", "15", "09", "017", "15001", "09", "Federal", "Ciudad de México", "15700", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2349" },
                    { 1392, "0", "15", "09", "017", "15001", "09", "Industrial Puerto Aéreo", "Ciudad de México", "15710", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2350" },
                    { 1393, "0", "15", "09", "017", "15001", "09", "4 Árboles", "Ciudad de México", "15730", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2353" },
                    { 1394, "0", "15", "09", "017", "15001", "09", "Aviación Civil", "Ciudad de México", "15740", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2354" },
                    { 1395, "0", "15", "09", "017", "15001", "09", "Ampliación Aviación Civil", "Ciudad de México", "15750", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2355" },
                    { 1396, "0", "15", "09", "017", "15001", "09", "Jamaica", "Ciudad de México", "15800", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2356" },
                    { 1397, "0", "15", "09", "017", "15001", "09", "Merced Balbuena", "Ciudad de México", "15810", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2358" },
                    { 1398, "0", "15", "09", "017", "15001", "09", "Lorenzo Boturini", "Ciudad de México", "15820", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2359" },
                    { 1399, "0", "15", "09", "017", "15001", "09", "Artes Gráficas", "Ciudad de México", "15830", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2360" },
                    { 1400, "0", "15", "09", "017", "15001", "09", "Sevilla", "Ciudad de México", "15840", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2361" },
                    { 1401, "0", "15", "09", "017", "15001", "09", "Magdalena Mixiuhca", "Ciudad de México", "15850", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2362" },
                    { 1402, "0", "15", "09", "017", "15001", "28", "La Magdalena Mixiuhca", "Ciudad de México", "15860", "15001", "Ciudad de México", "Venustiano Carranza", "Pueblo", "Urbano", "2363" },
                    { 1403, "0", "15", "09", "017", "15001", "09", "Aarón Sáenz", "Ciudad de México", "15870", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2364" },
                    { 1404, "0", "15", "09", "017", "15001", "09", "Jardín Balbuena", "Ciudad de México", "15900", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2365" },
                    { 1405, "0", "15", "09", "017", "15001", "09", "Del Parque", "Ciudad de México", "15960", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2372" },
                    { 1406, "0", "15", "09", "017", "15001", "09", "Aeronáutica Militar", "Ciudad de México", "15970", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2376" },
                    { 1407, "0", "15", "09", "017", "15001", "09", "24 de Abril", "Ciudad de México", "15980", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2377" },
                    { 1408, "0", "15", "09", "017", "15001", "09", "Álvaro Obregón", "Ciudad de México", "15990", "15001", "Ciudad de México", "Venustiano Carranza", "Colonia", "Urbano", "2378" },
                    { 1409, "0", "16", "09", "013", "16001", "02", "La Concepción Tlacoapa", "Ciudad de México", "16000", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2379" },
                    { 1410, "0", "16", "09", "013", "16001", "02", "San Antonio", "Ciudad de México", "16000", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2380" },
                    { 1411, "0", "16", "09", "013", "16001", "02", "San Juan", "Ciudad de México", "16000", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2381" },
                    { 1412, "0", "16", "09", "013", "16001", "09", "Bosque Residencial del Sur", "Ciudad de México", "16010", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2385" },
                    { 1413, "0", "16", "09", "013", "16001", "09", "Las Peritas", "Ciudad de México", "16010", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2386" },
                    { 1414, "0", "16", "09", "013", "16001", "09", "Paseos del Sur", "Ciudad de México", "16010", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2388" },
                    { 1415, "0", "16", "09", "013", "16001", "09", "San Bartolo El Chico", "Ciudad de México", "16010", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2832" },
                    { 1416, "0", "16", "09", "013", "16001", "09", "San Juan Tepepan", "Ciudad de México", "16020", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2395" },
                    { 1417, "0", "16", "09", "013", "16001", "28", "Santa María Tepepan", "Ciudad de México", "16020", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2396" },
                    { 1418, "0", "16", "09", "013", "16001", "09", "Ampliación Tepepan", "Ciudad de México", "16029", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2399" },
                    { 1419, "0", "16", "09", "013", "16001", "09", "Huichapan", "Ciudad de México", "16030", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2401" },
                    { 1420, "0", "16", "09", "013", "16001", "09", "La Noria", "Ciudad de México", "16030", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2402" },
                    { 1421, "0", "16", "09", "013", "16001", "09", "Potrero de San Bernardino", "Ciudad de México", "16030", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2403" },
                    { 1422, "0", "16", "09", "013", "16001", "09", "Ampliación La Noria", "Ciudad de México", "16030", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2919" },
                    { 1423, "0", "16", "09", "013", "16001", "02", "18", "Ciudad de México", "16034", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2405" },
                    { 1424, "0", "16", "09", "013", "16001", "09", "San Lorenzo La Cebada", "Ciudad de México", "16035", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2407" },
                    { 1425, "0", "16", "09", "013", "16001", "09", "Rinconada Coapa", "Ciudad de México", "16035", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2833" },
                    { 1426, "0", "16", "09", "013", "16001", "17", "Mercado de Flores Plantas y Hortalizas", "Ciudad de México", "16036", "16001", "Ciudad de México", "Xochimilco", "Equipamiento", "Urbano", "2408" },
                    { 1427, "0", "16", "09", "013", "16001", "09", "Ampliación San Marcos Norte", "Ciudad de México", "16038", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2409" },
                    { 1428, "0", "16", "09", "013", "16001", "02", "La Asunción", "Ciudad de México", "16040", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2411" },
                    { 1429, "0", "16", "09", "013", "16001", "02", "San Lorenzo", "Ciudad de México", "16040", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2412" },
                    { 1430, "0", "16", "09", "013", "16001", "09", "Jardines del Sur", "Ciudad de México", "16050", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2413" },
                    { 1431, "0", "16", "09", "013", "16001", "02", "San Marcos", "Ciudad de México", "16050", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2414" },
                    { 1432, "0", "16", "09", "013", "16001", "09", "Tierra Nueva", "Ciudad de México", "16050", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2415" },
                    { 1433, "0", "16", "09", "013", "16001", "09", "Pblo. Stgo.Tepalcatlalpan, U. H. Rinconada del Sur", "Ciudad de México", "16059", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2420" },
                    { 1434, "0", "16", "09", "013", "16001", "09", "El Mirador", "Ciudad de México", "16060", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2421" },
                    { 1435, "0", "16", "09", "013", "16001", "02", "Belén", "Ciudad de México", "16070", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2423" },
                    { 1436, "0", "16", "09", "013", "16001", "02", "El Rosario", "Ciudad de México", "16070", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2424" },
                    { 1437, "0", "16", "09", "013", "16001", "02", "La Guadalupita", "Ciudad de México", "16070", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2425" },
                    { 1438, "0", "16", "09", "013", "16001", "02", "Santa Crucita", "Ciudad de México", "16070", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2426" },
                    { 1439, "0", "16", "09", "013", "16001", "02", "La Santísima", "Ciudad de México", "16080", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2427" },
                    { 1440, "0", "16", "09", "013", "16001", "02", "San Cristóbal", "Ciudad de México", "16080", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2428" },
                    { 1441, "0", "16", "09", "013", "16001", "02", "San Diego", "Ciudad de México", "16080", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2429" },
                    { 1442, "0", "16", "09", "013", "16001", "02", "San Esteban", "Ciudad de México", "16080", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2430" },
                    { 1443, "0", "16", "09", "013", "16001", "02", "San Pedro", "Ciudad de México", "16090", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2432" },
                    { 1444, "0", "16", "09", "013", "16001", "09", "Tablas de San Lorenzo", "Ciudad de México", "16090", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2433" },
                    { 1445, "0", "16", "09", "013", "16001", "02", "Xaltocan", "Ciudad de México", "16090", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2434" },
                    { 1446, "0", "16", "09", "013", "16001", "28", "Santa Cruz Xochitepec", "Ciudad de México", "16100", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2439" },
                    { 1447, "0", "16", "09", "013", "16001", "28", "Santiago Tepalcatlalpan", "Ciudad de México", "16200", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2443" },
                    { 1448, "0", "16", "09", "013", "16001", "09", "La Concha", "Ciudad de México", "16210", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2444" },
                    { 1449, "0", "16", "09", "013", "16001", "28", "San Lucas Xochimanca", "Ciudad de México", "16300", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2458" },
                    { 1450, "0", "16", "09", "013", "16001", "09", "La Cañada", "Ciudad de México", "16310", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2459" },
                    { 1451, "0", "16", "09", "013", "16001", "09", "San Lucas Oriente", "Ciudad de México", "16320", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2460" },
                    { 1452, "0", "16", "09", "013", "16001", "09", "Texmic", "Ciudad de México", "16340", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2462" },
                    { 1453, "0", "16", "09", "013", "16001", "28", "San Lorenzo Atemoaya", "Ciudad de México", "16400", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2464" },
                    { 1454, "0", "16", "09", "013", "16001", "09", "Lomas de Tonalco", "Ciudad de México", "16410", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2465" },
                    { 1455, "0", "16", "09", "013", "16001", "09", "San Jerónimo", "Ciudad de México", "16420", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2466" },
                    { 1456, "0", "16", "09", "013", "16001", "09", "El Jazmín", "Ciudad de México", "16428", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2467" },
                    { 1457, "0", "16", "09", "013", "16001", "09", "Rancho Tejomulco", "Ciudad de México", "16429", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2468" },
                    { 1458, "0", "16", "09", "013", "16001", "09", "Xochipilli", "Ciudad de México", "16430", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2470" },
                    { 1459, "0", "16", "09", "013", "16001", "09", "Año de Juárez", "Ciudad de México", "16440", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2471" },
                    { 1460, "0", "16", "09", "013", "16001", "02", "Pocitos", "Ciudad de México", "16443", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2899" },
                    { 1461, "0", "16", "09", "013", "16001", "28", "Santa María Nativitas", "Ciudad de México", "16450", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2472" },
                    { 1462, "0", "16", "09", "013", "16001", "09", "Lomas de Nativitas", "Ciudad de México", "16457", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2480" },
                    { 1463, "0", "16", "09", "013", "16001", "09", "Ampliación Nativitas", "Ciudad de México", "16459", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2473" },
                    { 1464, "0", "16", "09", "013", "16001", "28", "Santa Cruz Acalpixca", "Ciudad de México", "16500", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2475" },
                    { 1465, "0", "16", "09", "013", "16001", "02", "Apatlaco", "Ciudad de México", "16513", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2900" },
                    { 1466, "0", "16", "09", "013", "16001", "02", "Del Puente", "Ciudad de México", "16513", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2901" },
                    { 1467, "0", "16", "09", "013", "16001", "02", "La Gallera", "Ciudad de México", "16514", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2902" },
                    { 1468, "0", "16", "09", "013", "16001", "02", "Tetitla", "Ciudad de México", "16514", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2903" },
                    { 1469, "0", "16", "09", "013", "16001", "02", "Calpulco", "Ciudad de México", "16514", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2904" },
                    { 1470, "0", "16", "09", "013", "16001", "02", "La Planta", "Ciudad de México", "16520", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2478" },
                    { 1471, "0", "16", "09", "013", "16001", "02", "Las Cruces", "Ciudad de México", "16530", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2479" },
                    { 1472, "0", "16", "09", "013", "16001", "02", "Las Flores", "Ciudad de México", "16530", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2834" },
                    { 1473, "0", "16", "09", "013", "16001", "02", "Ahualapa", "Ciudad de México", "16533", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2905" },
                    { 1474, "0", "16", "09", "013", "16001", "09", "Valle de Santa María", "Ciudad de México", "16550", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2481" },
                    { 1475, "0", "16", "09", "013", "16001", "28", "San Gregorio Atlapulco", "Ciudad de México", "16600", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2482" },
                    { 1476, "0", "16", "09", "013", "16001", "02", "San Andrés", "Ciudad de México", "16604", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2906" },
                    { 1477, "0", "16", "09", "013", "16001", "02", "Los Reyes", "Ciudad de México", "16605", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2907" },
                    { 1478, "0", "16", "09", "013", "16001", "02", "3 de Mayo", "Ciudad de México", "16606", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2908" },
                    { 1479, "0", "16", "09", "013", "16001", "02", "San Antonio", "Ciudad de México", "16607", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2909" },
                    { 1480, "0", "16", "09", "013", "16001", "02", "La Candelaria", "Ciudad de México", "16609", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2483" },
                    { 1481, "0", "16", "09", "013", "16001", "28", "San Luis Tlaxialtemalco", "Ciudad de México", "16610", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2484" },
                    { 1482, "0", "16", "09", "013", "16001", "02", "Niños Héroes", "Ciudad de México", "16614", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2910" },
                    { 1483, "0", "16", "09", "013", "16001", "02", "La Asunción", "Ciudad de México", "16615", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2911" },
                    { 1484, "0", "16", "09", "013", "16001", "02", "Santa Cecilia", "Ciudad de México", "16616", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2913" },
                    { 1485, "0", "16", "09", "013", "16001", "02", "San Sebastián", "Ciudad de México", "16617", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2912" },
                    { 1486, "0", "16", "09", "013", "16001", "02", "San José", "Ciudad de México", "16620", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2485" },
                    { 1487, "0", "16", "09", "013", "16001", "02", "La Guadalupana", "Ciudad de México", "16629", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2487" },
                    { 1488, "0", "16", "09", "013", "16001", "02", "San Juan", "Ciudad de México", "16629", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2489" },
                    { 1489, "0", "16", "09", "013", "16001", "02", "San Juan Moyotepec", "Ciudad de México", "16630", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2490" },
                    { 1490, "0", "16", "09", "013", "16001", "02", "San Juan Minas", "Ciudad de México", "16640", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2491" },
                    { 1491, "0", "16", "09", "013", "16001", "09", "Quirino Mendoza", "Ciudad de México", "16710", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2494" },
                    { 1492, "0", "16", "09", "013", "16001", "09", "Del Carmen", "Ciudad de México", "16720", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2495" },
                    { 1493, "0", "16", "09", "013", "16001", "09", "San Isidro", "Ciudad de México", "16739", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2498" },
                    { 1494, "0", "16", "09", "013", "16001", "09", "Guadalupita", "Ciudad de México", "16740", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2499" },
                    { 1495, "0", "16", "09", "013", "16001", "09", "Las Animas", "Ciudad de México", "16749", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2500" },
                    { 1496, "0", "16", "09", "013", "16001", "02", "Calyequita", "Ciudad de México", "16750", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2501" },
                    { 1497, "0", "16", "09", "013", "16001", "09", "San Felipe", "Ciudad de México", "16770", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2502" },
                    { 1498, "0", "16", "09", "013", "16001", "09", "Santiaguito", "Ciudad de México", "16776", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2503" },
                    { 1499, "0", "16", "09", "013", "16001", "09", "El Mirador", "Ciudad de México", "16776", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2600" },
                    { 1500, "0", "16", "09", "013", "16001", "09", "Cerrillos Primera Sección", "Ciudad de México", "16780", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2504" },
                    { 1501, "0", "16", "09", "013", "16001", "09", "El Sacrificio", "Ciudad de México", "16780", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2602" },
                    { 1502, "0", "16", "09", "013", "16001", "09", "Cristo Rey", "Ciudad de México", "16780", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2604" },
                    { 1503, "0", "16", "09", "013", "16001", "09", "Cerrillos Segunda Sección", "Ciudad de México", "16780", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2835" },
                    { 1504, "0", "16", "09", "013", "16001", "09", "Cerrillos Tercera Sección", "Ciudad de México", "16780", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2836" },
                    { 1505, "0", "16", "09", "013", "16001", "09", "Nativitas", "Ciudad de México", "16797", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2508" },
                    { 1506, "0", "16", "09", "013", "16001", "09", "Las Mesitas", "Ciudad de México", "16799", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2509" },
                    { 1507, "0", "16", "09", "013", "16001", "28", "San Mateo Xalpa", "Ciudad de México", "16800", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2510" },
                    { 1508, "0", "16", "09", "013", "16001", "28", "San Andrés Ahuayucan", "Ciudad de México", "16810", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2515" },
                    { 1509, "0", "16", "09", "013", "16001", "09", "Santa Inés", "Ciudad de México", "16810", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2516" },
                    { 1510, "0", "16", "09", "013", "16001", "09", "Rosario Tlali", "Ciudad de México", "16810", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2607" },
                    { 1511, "0", "16", "09", "013", "16001", "02", "El Calvario", "Ciudad de México", "16813", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2914" },
                    { 1512, "0", "16", "09", "013", "16001", "09", "Santa Cruz Chavarrieta", "Ciudad de México", "16840", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2519" },
                    { 1513, "0", "16", "09", "013", "16001", "02", "Chapultepec", "Ciudad de México", "16850", "16001", "Ciudad de México", "Xochimilco", "Barrio", "Urbano", "2520" },
                    { 1514, "0", "16", "09", "013", "16001", "09", "Santa Cruz de Guadalupe", "Ciudad de México", "16860", "16001", "Ciudad de México", "Xochimilco", "Colonia", "Urbano", "2521" },
                    { 1515, "0", "16", "09", "013", "16001", "28", "Santa Cecilia Tepetlapa", "Ciudad de México", "16880", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2527" },
                    { 1516, "0", "16", "09", "013", "16001", "28", "San Francisco Tlalnepantla", "Ciudad de México", "16900", "16001", "Ciudad de México", "Xochimilco", "Pueblo", "Urbano", "2530" }
                });

            migrationBuilder.InsertData(
                table: "CatCorpCents",
                columns: new[] { "IdCorpCent", "CorpCentDesc", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico" },
                values: new object[,]
                {
                    { 1, "CORPORATIVO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "CENTRO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "CatEscolaridades",
                columns: new[] { "IdEscolaridad", "EscolaridadDesc", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico" },
                values: new object[,]
                {
                    { 1, "PRIMERO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "SEGUNDO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, "TERCERO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 4, "CUARTO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 5, "QUINTO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 6, "SEXTO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "CatEstatus",
                columns: new[] { "IdEstatusRegistro", "EstatusDesc", "FechaRegistro", "IdUsuarioModifico" },
                values: new object[,]
                {
                    { 1, "ACTIVO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "DESACTIVO", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "CatGeneros",
                columns: new[] { "IdGenero", "FechaRegistro", "GeneroDesc", "IdEstatusRegistro", "IdUsuarioModifico" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), "HOMBRE", 1, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), "MUJER", 1, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "CatNivelEscolares",
                columns: new[] { "IdNivelEscolar", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "NivelEscolarDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "PREESCOLAR" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "PRIMARIA" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "SECUNDARIA" },
                    { 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "BACHILLERATO" },
                    { 5, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "UNIVERSIDAD" }
                });

            migrationBuilder.InsertData(
                table: "CatPerfiles",
                columns: new[] { "IdPerfil", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "PerfilDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "DIRECTOR" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "ADMINISTRADOR" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "GERENTE" },
                    { 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "EJECUTIVO" },
                    { 5, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "DOCENTE" }
                });

            migrationBuilder.InsertData(
                table: "CatPeriodosAmortizaciones",
                columns: new[] { "IdPeriodoAmortiza", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "PeriodoAmortizaDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "1 MES" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "3 MES" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "6 MES" },
                    { 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "9 MES" },
                    { 5, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "12 MES" },
                    { 6, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "18 MES" },
                    { 7, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "24 MES" },
                    { 8, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "36 MES" }
                });

            migrationBuilder.InsertData(
                table: "CatProdServs",
                columns: new[] { "IdProdServ", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "ProdServDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), "PRODUCTO" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), "SERVICIO" }
                });

            migrationBuilder.InsertData(
                table: "CatRoles",
                columns: new[] { "IdRol", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "RolDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "DESARROLLADOR" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "ADMINISTRADOR" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "SUPERVISOR" },
                    { 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "OPERADOR" }
                });

            migrationBuilder.InsertData(
                table: "CatTipoCentros",
                columns: new[] { "IdTipoCentro", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "TipoCentroDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "INTERNO" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "LICENCIA" }
                });

            migrationBuilder.InsertData(
                table: "CatTipoFormaPagos",
                columns: new[] { "IdTipoFormaPago", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "TipoFormaPagoDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "SEMANAL" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "QUINCENAL" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "MENSUAL" }
                });

            migrationBuilder.InsertData(
                table: "CatTipoPagos",
                columns: new[] { "IdTipoPago", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "TipoPagoDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "EFECTIVO" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "TRANSFERENCIA" },
                    { 3, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "CREDITO" },
                    { 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "TDC" },
                    { 5, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 1, new Guid("00000000-0000-0000-0000-000000000000"), "TDD" }
                });

            migrationBuilder.InsertData(
                table: "CatTipoPrestamos",
                columns: new[] { "IdTipoPrestamo", "FechaRegistro", "IdEstatusRegistro", "IdUsuarioModifico", "TipoPrestamoDesc" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), "INTERNO" },
                    { 2, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("00000000-0000-0000-0000-000000000000"), "EXTERNO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelCompraProductos_TblCompraIdCompra",
                table: "RelCompraProductos",
                column: "TblCompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_RelVentaProducto_TblVentaIdVenta",
                table: "RelVentaProducto",
                column: "TblVentaIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_CatNivelEscolarIdNivelEscolar",
                table: "TblUsuarios",
                column: "CatNivelEscolarIdNivelEscolar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CatAreas");

            migrationBuilder.DropTable(
                name: "CatCategorias");

            migrationBuilder.DropTable(
                name: "CatCodigosPostales");

            migrationBuilder.DropTable(
                name: "CatCorpCents");

            migrationBuilder.DropTable(
                name: "CatEscolaridades");

            migrationBuilder.DropTable(
                name: "CatEstatus");

            migrationBuilder.DropTable(
                name: "CatGeneros");

            migrationBuilder.DropTable(
                name: "CaTipotLicencias");

            migrationBuilder.DropTable(
                name: "CatPerfiles");

            migrationBuilder.DropTable(
                name: "CatPeriodosAmortizaciones");

            migrationBuilder.DropTable(
                name: "CatProdServs");

            migrationBuilder.DropTable(
                name: "CatProductos");

            migrationBuilder.DropTable(
                name: "CatRoles");

            migrationBuilder.DropTable(
                name: "CatTipoAlumnos");

            migrationBuilder.DropTable(
                name: "CatTipoCentros");

            migrationBuilder.DropTable(
                name: "CatTipoContrataciones");

            migrationBuilder.DropTable(
                name: "CatTipoDirecciones");

            migrationBuilder.DropTable(
                name: "CatTipoFormaPagos");

            migrationBuilder.DropTable(
                name: "CatTipoPagos");

            migrationBuilder.DropTable(
                name: "CatTipoPrestamos");

            migrationBuilder.DropTable(
                name: "CatTipoServicios");

            migrationBuilder.DropTable(
                name: "CatTipoSuministros");

            migrationBuilder.DropTable(
                name: "FilesOnDatabase");

            migrationBuilder.DropTable(
                name: "FilesOnFileSystem");

            migrationBuilder.DropTable(
                name: "RelCompraPagos");

            migrationBuilder.DropTable(
                name: "RelCompraProductos");

            migrationBuilder.DropTable(
                name: "RelVentaProducto");

            migrationBuilder.DropTable(
                name: "RelVentasPagos");

            migrationBuilder.DropTable(
                name: "TblAlumnoContactos");

            migrationBuilder.DropTable(
                name: "TblAlumnoDirecciones");

            migrationBuilder.DropTable(
                name: "TblAlumnos");

            migrationBuilder.DropTable(
                name: "TblBancos");

            migrationBuilder.DropTable(
                name: "TblCentros");

            migrationBuilder.DropTable(
                name: "TblCorporativos");

            migrationBuilder.DropTable(
                name: "TblEmpresas");

            migrationBuilder.DropTable(
                name: "TblPrestamos");

            migrationBuilder.DropTable(
                name: "TblProveedorContactos");

            migrationBuilder.DropTable(
                name: "TblProveedorDirecciones");

            migrationBuilder.DropTable(
                name: "TblProveedores");

            migrationBuilder.DropTable(
                name: "TblServicio");

            migrationBuilder.DropTable(
                name: "TblSuministros");

            migrationBuilder.DropTable(
                name: "TblUsuarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblCompras");

            migrationBuilder.DropTable(
                name: "TblVenta");

            migrationBuilder.DropTable(
                name: "CatNivelEscolares");
        }
    }
}
