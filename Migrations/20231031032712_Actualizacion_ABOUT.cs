using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduatesPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion_ABOUT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccionUsuario",
                columns: table => new
                {
                    AccionUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AccionUs__2FAB39B432919605", x => x.AccionUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Habilidad",
                columns: table => new
                {
                    HabilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Habilida__7341FE2241250182", x => x.HabilidadId);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    IdiomaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    ISO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Idioma__7341FE2241250182", x => x.IdiomaId);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    NivelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nivel__316FA27709A6853B", x => x.NivelId);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    GenticilioNac = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    ISO = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pais__B501E185CD29A4C1", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__F92302F17E975A95", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TipoContacto",
                columns: table => new
                {
                    TipoContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoCont__2A6E82DC9EF1EDFF", x => x.TipoContactoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoDocu__A329EA87104DF547", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoParticipante",
                columns: table => new
                {
                    TipoParticipanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoPart__5CEAA5C3AA8B36BA", x => x.TipoParticipanteId);
                });

            migrationBuilder.CreateTable(
                name: "Formacion",
                columns: table => new
                {
                    FormacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Formacio__10CF6859CCD0996A", x => x.FormacionId);
                    table.ForeignKey(
                        name: "FK__Formacion__Nivel__22751F6C",
                        column: x => x.NivelId,
                        principalTable: "Nivel",
                        principalColumn: "NivelId");
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ciudad__E826E7704F3C99E8", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK__Ciudad__PaisId__2E1BDC42",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "PaisId");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__2B3DE798F7564030", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK__Usuario__RolId__47DBAE45",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "LocalidadPostal",
                columns: table => new
                {
                    LocalidadPostalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Localida__A44BA845A4C0BA84", x => x.LocalidadPostalId);
                    table.ForeignKey(
                        name: "FK__Localidad__Ciuda__34C8D9D1",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadId");
                });

            migrationBuilder.CreateTable(
                name: "LogUsuario",
                columns: table => new
                {
                    LogUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AccionUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LogUsuar__7DCF8168A2985296", x => x.LogUsuarioId);
                    table.ForeignKey(
                        name: "FK__LogUsuari__Accio__5535A963",
                        column: x => x.AccionUsuarioId,
                        principalTable: "AccionUsuario",
                        principalColumn: "AccionUsuarioId");
                    table.ForeignKey(
                        name: "FK__LogUsuari__Usuar__5441852A",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalidadPostalId = table.Column<int>(type: "int", nullable: false),
                    DireccionPrincipal = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MostrarDireccionPrincipal = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__68906D64D7C69BF2", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK__Direccion__Local__3C69FB99",
                        column: x => x.LocalidadPostalId,
                        principalTable: "LocalidadPostal",
                        principalColumn: "LocalidadPostalId");
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoParticipanteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    EsEgresado = table.Column<bool>(type: "bit", nullable: true),
                    FotoPerfilURL = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Particip__E6DEAC5F1F0D7968", x => x.ParticipanteId);
                    table.ForeignKey(
                        name: "FK__Participa__Direc__6477ECF3",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "DireccionId");
                    table.ForeignKey(
                        name: "FK__Participa__TipoP__628FA481",
                        column: x => x.TipoParticipanteId,
                        principalTable: "TipoParticipante",
                        principalColumn: "TipoParticipanteId");
                    table.ForeignKey(
                        name: "FK__Participa__Usuar__6383C8BA",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    TipoContactoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contacto__8E0F85E8F9C2CE9C", x => x.ContactoId);
                    table.ForeignKey(
                        name: "FK__Contacto__Partic__37703C52",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "ParticipanteId");
                    table.ForeignKey(
                        name: "FK__Contacto__TipoCo__3864608B",
                        column: x => x.TipoContactoId,
                        principalTable: "TipoContacto",
                        principalColumn: "TipoContactoId");
                });

            migrationBuilder.CreateTable(
                name: "Egresado",
                columns: table => new
                {
                    EgresadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<int>(type: "int", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    FechaNac = table.Column<DateTime>(type: "date", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    MatriculaGrado = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    MatriculaEgresado = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Egresado__CE4D75864EA655F1", x => x.EgresadoId);
                    table.ForeignKey(
                        name: "FK__Egresado__Nacion__6D0D32F4",
                        column: x => x.Nacionalidad,
                        principalTable: "Pais",
                        principalColumn: "PaisId");
                    table.ForeignKey(
                        name: "FK__Egresado__Partic__6C190EBB",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "ParticipanteId");
                });

            migrationBuilder.CreateTable(
                name: "DocumentoEgresado",
                columns: table => new
                {
                    DocumentoEgresadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    DocumentoNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3AED1AA2BCA6964C", x => x.DocumentoEgresadoId);
                    table.ForeignKey(
                        name: "FK__Documento__Egres__7D439ABD",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                    table.ForeignKey(
                        name: "FK__Documento__TipoD__7C4F7684",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumento",
                        principalColumn: "TipoDocumentoId");
                });

            migrationBuilder.CreateTable(
                name: "Educacion",
                columns: table => new
                {
                    EducacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    FormacionId = table.Column<int>(type: "int", nullable: false),
                    Organizacion = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Educacio__6301DF6E612BB3E4", x => x.EducacionId);
                    table.ForeignKey(
                        name: "FK__Educacion__Egres__29221CFB",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                    table.ForeignKey(
                        name: "FK__Educacion__Forma__2A164134",
                        column: x => x.FormacionId,
                        principalTable: "Formacion",
                        principalColumn: "FormacionId");
                });

            migrationBuilder.CreateTable(
                name: "EgresadoDestacado",
                columns: table => new
                {
                    EgresadoDestacadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "date", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "date", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Egresado__C3C0C83CDD6258B7", x => x.EgresadoDestacadoId);
                    table.ForeignKey(
                        name: "FK__EgresadoD__Egres__4B7734FF",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                });

            migrationBuilder.CreateTable(
                name: "EgresadoHabilidad",
                columns: table => new
                {
                    EgresadoHabilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    HabilidadId = table.Column<int>(type: "int", nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Egresado__7107424831F03983", x => x.EgresadoHabilidadId);
                    table.ForeignKey(
                        name: "FK__EgresadoH__Egres__44CA3770",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                    table.ForeignKey(
                        name: "FK__EgresadoH__Habil__45BE5BA9",
                        column: x => x.HabilidadId,
                        principalTable: "Habilidad",
                        principalColumn: "HabilidadId");
                });

            migrationBuilder.CreateTable(
                name: "EgresadoIdioma",
                columns: table => new
                {
                    EgresadoIdiomaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    IdiomaId = table.Column<int>(type: "int", nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Egresado__95C75C4281B1C1DB", x => x.EgresadoIdiomaId);
                    table.ForeignKey(
                        name: "FK__EgresadoI__Egres__0A9D95DB",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                    table.ForeignKey(
                        name: "FK__EgresadoI__Idiom__0B91BA14",
                        column: x => x.IdiomaId,
                        principalTable: "Idioma",
                        principalColumn: "IdiomaId");
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaLaboral",
                columns: table => new
                {
                    ExperienciaLaboralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgresadoId = table.Column<int>(type: "int", nullable: false),
                    Posicion = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Salario = table.Column<int>(type: "int", nullable: true),
                    FechaEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: true),
                    Mostrar = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Experien__90603FE69EAB7BA0", x => x.ExperienciaLaboralId);
                    table.ForeignKey(
                        name: "FK__Experienc__Egres__14270015",
                        column: x => x.EgresadoId,
                        principalTable: "Egresado",
                        principalColumn: "EgresadoId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__AccionUs__75E3EFCF50394538",
                table: "AccionUsuario",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_PaisId",
                table: "Ciudad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_ParticipanteId",
                table: "Contacto",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_TipoContactoId",
                table: "Contacto",
                column: "TipoContactoId");

            migrationBuilder.CreateIndex(
                name: "UQ__Contacto__75E3EFCF83F1428E",
                table: "Contacto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_LocalidadPostalId",
                table: "Direccion",
                column: "LocalidadPostalId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoEgresado_EgresadoId",
                table: "DocumentoEgresado",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentoEgresado_TipoDocumentoId",
                table: "DocumentoEgresado",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "UQ__Document__5DDB97EC46F6D48F",
                table: "DocumentoEgresado",
                column: "DocumentoNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educacion_EgresadoId",
                table: "Educacion",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Educacion_FormacionId",
                table: "Educacion",
                column: "FormacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Egresado_Nacionalidad",
                table: "Egresado",
                column: "Nacionalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Egresado_ParticipanteId",
                table: "Egresado",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_EgresadoDestacado_EgresadoId",
                table: "EgresadoDestacado",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EgresadoHabilidad_EgresadoId",
                table: "EgresadoHabilidad",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EgresadoHabilidad_HabilidadId",
                table: "EgresadoHabilidad",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EgresadoIdioma_EgresadoId",
                table: "EgresadoIdioma",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EgresadoIdioma_IdiomaId",
                table: "EgresadoIdioma",
                column: "IdiomaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaLaboral_EgresadoId",
                table: "ExperienciaLaboral",
                column: "EgresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Formacion_NivelId",
                table: "Formacion",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "UQ__Habilida__75E3EFCF21DFB275",
                table: "Habilidad",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Idioma__75E3EFCF21DFB275",
                table: "Idioma",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadPostal_CiudadId",
                table: "LocalidadPostal",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_LogUsuario_AccionUsuarioId",
                table: "LogUsuario",
                column: "AccionUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogUsuario_UsuarioId",
                table: "LogUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "UQ__Nivel__75E3EFCF90705A45",
                table: "Nivel",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Pais__75E3EFCF4244D8B7",
                table: "Pais",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Pais__C4979A232DBAEF01",
                table: "Pais",
                column: "ISO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participante_DireccionId",
                table: "Participante",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_TipoParticipanteId",
                table: "Participante",
                column: "TipoParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Participante_UsuarioId",
                table: "Participante",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "UQ__Rol__75E3EFCF3B6CB729",
                table: "Rol",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TipoCont__75E3EFCFEAED2FDE",
                table: "TipoContacto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TipoDocu__75E3EFCFAF9FB396",
                table: "TipoDocumento",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TipoPart__75E3EFCFAB065D36",
                table: "TipoParticipante",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "DocumentoEgresado");

            migrationBuilder.DropTable(
                name: "Educacion");

            migrationBuilder.DropTable(
                name: "EgresadoDestacado");

            migrationBuilder.DropTable(
                name: "EgresadoHabilidad");

            migrationBuilder.DropTable(
                name: "EgresadoIdioma");

            migrationBuilder.DropTable(
                name: "ExperienciaLaboral");

            migrationBuilder.DropTable(
                name: "LogUsuario");

            migrationBuilder.DropTable(
                name: "TipoContacto");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "Formacion");

            migrationBuilder.DropTable(
                name: "Habilidad");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "Egresado");

            migrationBuilder.DropTable(
                name: "AccionUsuario");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "TipoParticipante");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "LocalidadPostal");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
