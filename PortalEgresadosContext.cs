using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraduatesPortalAPI;

public partial class PortalEgresadosContext : DbContext
{
    public PortalEgresadosContext()
    {
    }

    public PortalEgresadosContext(DbContextOptions<PortalEgresadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccionUsuario> AccionUsuarios { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<DocumentoEgresado> DocumentoEgresados { get; set; }

    public virtual DbSet<Educacion> Educacions { get; set; }

    public virtual DbSet<Egresado> Egresados { get; set; }

    public virtual DbSet<EgresadoDestacado> EgresadoDestacados { get; set; }

    public virtual DbSet<EgresadoHabilidad> EgresadoHabilidads { get; set; }

    public virtual DbSet<EgresadoIdioma> EgresadoIdiomas { get; set; }

    public virtual DbSet<ExperienciaLaboral> ExperienciaLaborals { get; set; }

    public virtual DbSet<Formacion> Formacions { get; set; }

    public virtual DbSet<Habilidad> Habilidads { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<LocalidadPostal> LocalidadPostals { get; set; }

    public virtual DbSet<LogUsuario> LogUsuarios { get; set; }

    public virtual DbSet<Nivel> Nivels { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoContacto> TipoContactos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoParticipante> TipoParticipantes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\MONOGRAFICO53;Initial Catalog=PortalEgresados;User ID=sa;Password=Ab123456; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccionUsuario>(entity =>
        {
            entity.HasKey(e => e.AccionUsuarioId).HasName("PK__AccionUs__2FAB39B432919605");

            entity.ToTable("AccionUsuario");

            entity.HasIndex(e => e.Nombre, "UQ__AccionUs__75E3EFCF50394538").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK__Ciudad__E826E7704F3C99E8");

            entity.ToTable("Ciudad");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ciudad__PaisId__2E1BDC42");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ContactoId).HasName("PK__Contacto__8E0F85E8F9C2CE9C");

            entity.ToTable("Contacto");

            entity.HasIndex(e => e.Nombre, "UQ__Contacto__75E3EFCF83F1428E").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.Participante).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contacto__Partic__37703C52");

            entity.HasOne(d => d.TipoContacto).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.TipoContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contacto__TipoCo__3864608B");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D64D7C69BF2");

            entity.ToTable("Direccion");

            entity.Property(e => e.DireccionPrincipal)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.LocalidadPostal).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.LocalidadPostalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__Local__3C69FB99");
        });

        modelBuilder.Entity<DocumentoEgresado>(entity =>
        {
            entity.HasKey(e => e.DocumentoEgresadoId).HasName("PK__Document__3AED1AA2BCA6964C");

            entity.ToTable("DocumentoEgresado");

            entity.HasIndex(e => e.DocumentoNo, "UQ__Document__5DDB97EC46F6D48F").IsUnique();

            entity.Property(e => e.DocumentoNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Egresado).WithMany(p => p.DocumentoEgresados)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documento__Egres__7D439ABD");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.DocumentoEgresados)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Documento__TipoD__7C4F7684");
        });

        modelBuilder.Entity<Educacion>(entity =>
        {
            entity.HasKey(e => e.EducacionId).HasName("PK__Educacio__6301DF6E612BB3E4");

            entity.ToTable("Educacion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaEntrada).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("date");
            entity.Property(e => e.Organizacion)
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.Egresado).WithMany(p => p.Educacions)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Educacion__Egres__29221CFB");

            entity.HasOne(d => d.Formacion).WithMany(p => p.Educacions)
                .HasForeignKey(d => d.FormacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Educacion__Forma__2A164134");
        });

        modelBuilder.Entity<Egresado>(entity =>
        {
            entity.HasKey(e => e.EgresadoId).HasName("PK__Egresado__CE4D75864EA655F1");

            entity.ToTable("Egresado");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNac).HasColumnType("date");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MatriculaEgresado)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.MatriculaGrado)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.NacionalidadNavigation).WithMany(p => p.Egresados)
                .HasForeignKey(d => d.Nacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Egresado__Nacion__6D0D32F4");

            entity.HasOne(d => d.Participante).WithMany(p => p.Egresados)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Egresado__Partic__6C190EBB");
        });

        modelBuilder.Entity<EgresadoDestacado>(entity =>
        {
            entity.HasKey(e => e.EgresadoDestacadoId).HasName("PK__Egresado__C3C0C83CDD6258B7");

            entity.ToTable("EgresadoDestacado");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaDesde).HasColumnType("date");
            entity.Property(e => e.FechaHasta).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Egresado).WithMany(p => p.EgresadoDestacados)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresadoD__Egres__4B7734FF");
        });

        modelBuilder.Entity<EgresadoHabilidad>(entity =>
        {
            entity.HasKey(e => e.EgresadoHabilidadId).HasName("PK__Egresado__7107424831F03983");

            entity.ToTable("EgresadoHabilidad");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Egresado).WithMany(p => p.EgresadoHabilidads)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresadoH__Egres__44CA3770");

            entity.HasOne(d => d.Habilidad).WithMany(p => p.EgresadoHabilidads)
                .HasForeignKey(d => d.HabilidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresadoH__Habil__45BE5BA9");
        });

        modelBuilder.Entity<EgresadoIdioma>(entity =>
        {
            entity.HasKey(e => e.EgresadoIdiomaId).HasName("PK__Egresado__95C75C4281B1C1DB");

            entity.ToTable("EgresadoIdioma");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Egresado).WithMany(p => p.EgresadoIdiomas)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresadoI__Egres__0A9D95DB");

            entity.HasOne(d => d.Idioma).WithMany(p => p.EgresadoIdiomas)
                .HasForeignKey(d => d.IdiomaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EgresadoI__Idiom__0B91BA14");
        });

        modelBuilder.Entity<ExperienciaLaboral>(entity =>
        {
            entity.HasKey(e => e.ExperienciaLaboralId).HasName("PK__Experien__90603FE69EAB7BA0");

            entity.ToTable("ExperienciaLaboral");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaEntrada).HasColumnType("date");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("date");
            entity.Property(e => e.Posicion)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.Egresado).WithMany(p => p.ExperienciaLaborals)
                .HasForeignKey(d => d.EgresadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Experienc__Egres__14270015");
        });

        modelBuilder.Entity<Formacion>(entity =>
        {
            entity.HasKey(e => e.FormacionId).HasName("PK__Formacio__10CF6859CCD0996A");

            entity.ToTable("Formacion");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.Nivel).WithMany(p => p.Formacions)
                .HasForeignKey(d => d.NivelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Formacion__Nivel__22751F6C");
        });

        modelBuilder.Entity<Habilidad>(entity =>
        {
            entity.HasKey(e => e.HabilidadId).HasName("PK__Habilida__7341FE2241250182");

            entity.ToTable("Habilidad");

            entity.HasIndex(e => e.Nombre, "UQ__Habilida__75E3EFCF21DFB275").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.IdiomaId).HasName("PK__Idioma__7341FE2241250182");

            entity.ToTable("Idioma");

            entity.HasIndex(e => e.Nombre, "UQ__Idioma__75E3EFCF21DFB275").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Iso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ISO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LocalidadPostal>(entity =>
        {
            entity.HasKey(e => e.LocalidadPostalId).HasName("PK__Localida__A44BA845A4C0BA84");

            entity.ToTable("LocalidadPostal");

            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.LocalidadPostals)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Localidad__Ciuda__34C8D9D1");
        });

        modelBuilder.Entity<LogUsuario>(entity =>
        {
            entity.HasKey(e => e.LogUsuarioId).HasName("PK__LogUsuar__7DCF8168A2985296");

            entity.ToTable("LogUsuario");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.AccionUsuario).WithMany(p => p.LogUsuarios)
                .HasForeignKey(d => d.AccionUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LogUsuari__Accio__5535A963");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LogUsuari__Usuar__5441852A");
        });

        modelBuilder.Entity<Nivel>(entity =>
        {
            entity.HasKey(e => e.NivelId).HasName("PK__Nivel__316FA27709A6853B");

            entity.ToTable("Nivel");

            entity.HasIndex(e => e.Nombre, "UQ__Nivel__75E3EFCF90705A45").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.PaisId).HasName("PK__Pais__B501E185CD29A4C1");

            entity.HasIndex(e => e.Nombre, "UQ__Pais__75E3EFCF4244D8B7").IsUnique();

            entity.HasIndex(e => e.Iso, "UQ__Pais__C4979A232DBAEF01").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.GenticilioNac)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Iso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.ParticipanteId).HasName("PK__Particip__E6DEAC5F1F0D7968");

            entity.ToTable("Participante");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FotoPerfilUrl)
                .HasColumnType("text")
                .HasColumnName("FotoPerfilURL");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.DireccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Direc__6477ECF3");

            entity.HasOne(d => d.TipoParticipante).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.TipoParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__TipoP__628FA481");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Usuar__6383C8BA");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F17E975A95");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCF3B6CB729").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoContacto>(entity =>
        {
            entity.HasKey(e => e.TipoContactoId).HasName("PK__TipoCont__2A6E82DC9EF1EDFF");

            entity.ToTable("TipoContacto");

            entity.HasIndex(e => e.Nombre, "UQ__TipoCont__75E3EFCFEAED2FDE").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__TipoDocu__A329EA87104DF547");

            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.Nombre, "UQ__TipoDocu__75E3EFCFAF9FB396").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoParticipante>(entity =>
        {
            entity.HasKey(e => e.TipoParticipanteId).HasName("PK__TipoPart__5CEAA5C3AA8B36BA");

            entity.ToTable("TipoParticipante");

            entity.HasIndex(e => e.Nombre, "UQ__TipoPart__75E3EFCFAB065D36").IsUnique();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798F7564030");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__RolId__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
