using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity;
namespace Repository.dbcontext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquiler { get; set; }
        public virtual DbSet<Calle> Calle { get; set; }
        public virtual DbSet<Cancha> Cancha { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DetalleParticipante> DetalleParticipante { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<Propietario> Propietario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Repository Source=localhost;Initial Catalog=SoccerMatch;Persist Security Info=True;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.Calquiler)
                    .HasName("Alquiler_pk");

                entity.Property(e => e.Calquiler).HasColumnName("CAlquiler");

                entity.Property(e => e.Ccancha).HasColumnName("CCancha");

                entity.Property(e => e.Cequipo).HasColumnName("CEquipo");

                entity.Property(e => e.DfechaInicio)
                    .HasColumnName("DFechaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fpagado).HasColumnName("FPagado");

                entity.Property(e => e.Mdescuento)
                    .HasColumnName("MDescuento")
                    .HasColumnType("money");

                entity.Property(e => e.Mtotal)
                    .HasColumnName("MTotal")
                    .HasColumnType("money");

                entity.HasOne(d => d.CcanchaNavigation)
                    .WithMany(p => p.Alquiler)
                    .HasForeignKey(d => d.Ccancha)
                    .HasConstraintName("Alquiler_Cancha");

                entity.HasOne(d => d.CequipoNavigation)
                    .WithMany(p => p.Alquiler)
                    .HasForeignKey(d => d.Cequipo)
                    .HasConstraintName("Alquiler_Equipo");
            });

            modelBuilder.Entity<Calle>(entity =>
            {
                entity.HasKey(e => e.Ccalle)
                    .HasName("Calle_pk");

                entity.Property(e => e.Ccalle).HasColumnName("CCalle");

                entity.Property(e => e.Cdistrito).HasColumnName("CDistrito");

                entity.Property(e => e.Ncalle)
                    .IsRequired()
                    .HasColumnName("NCalle")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdistritoNavigation)
                    .WithMany(p => p.Calle)
                    .HasForeignKey(d => d.Cdistrito)
                    .HasConstraintName("Calle_Distrito");
            });

            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(e => e.Ccancha)
                    .HasName("Cancha_pk");

                entity.Property(e => e.Ccancha).HasColumnName("CCancha");

                entity.Property(e => e.Ccalle).HasColumnName("CCalle");

                entity.Property(e => e.Cpropietario).HasColumnName("CPropietario");

                entity.Property(e => e.ImgFoto1).HasColumnType("image");

                entity.Property(e => e.ImgFoto2).HasColumnType("image");

                entity.Property(e => e.MprecioHora)
                    .HasColumnName("MPrecioHora")
                    .HasColumnType("money");

                entity.Property(e => e.Ncancha)
                    .IsRequired()
                    .HasColumnName("NCancha")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasColumnName("TDireccion")
                    .HasColumnType("text");

                entity.HasOne(d => d.CcalleNavigation)
                    .WithMany(p => p.Cancha)
                    .HasForeignKey(d => d.Ccalle)
                    .HasConstraintName("Cancha_Calle");

                entity.HasOne(d => d.CpropietarioNavigation)
                    .WithMany(p => p.Cancha)
                    .HasForeignKey(d => d.Cpropietario)
                    .HasConstraintName("Cancha_Propietario");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Cciudad)
                    .HasName("Ciudad_pk");

                entity.Property(e => e.Cciudad).HasColumnName("CCiudad");

                entity.Property(e => e.Cdepartamento).HasColumnName("CDepartamento");

                entity.Property(e => e.Nciudad)
                    .IsRequired()
                    .HasColumnName("NCiudad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdepartamentoNavigation)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.Cdepartamento)
                    .HasConstraintName("Ciudad_Departamento");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Cdepartamento)
                    .HasName("Departamento_pk");

                entity.Property(e => e.Cdepartamento).HasColumnName("CDepartamento");

                entity.Property(e => e.Ndepartamento)
                    .IsRequired()
                    .HasColumnName("NDepartamento")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleParticipante>(entity =>
            {
                entity.HasKey(e => e.CdetalleParticipante)
                    .HasName("DetalleParticipante_pk");

                entity.Property(e => e.CdetalleParticipante).HasColumnName("CDetalleParticipante");

                entity.Property(e => e.Calquiler).HasColumnName("CAlquiler");

                entity.Property(e => e.Cparticipante).HasColumnName("CParticipante");

                entity.Property(e => e.FpartePagada).HasColumnName("FPartePagada");

                entity.Property(e => e.Mcuota)
                    .HasColumnName("MCuota")
                    .HasColumnType("money");

                entity.Property(e => e.Ncupos).HasColumnName("NCupos");

                entity.HasOne(d => d.CalquilerNavigation)
                    .WithMany(p => p.DetalleParticipante)
                    .HasForeignKey(d => d.Calquiler)
                    .HasConstraintName("Alquiler_Jugador_Equipo_Alquiler");

                entity.HasOne(d => d.CparticipanteNavigation)
                    .WithMany(p => p.DetalleParticipante)
                    .HasForeignKey(d => d.Cparticipante)
                    .HasConstraintName("Alquiler_Jugador_Equipo_Participante");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.Cdistrito)
                    .HasName("Distrito_pk");

                entity.Property(e => e.Cdistrito).HasColumnName("CDistrito");

                entity.Property(e => e.Cciudad).HasColumnName("CCiudad");

                entity.Property(e => e.Ndistrito)
                    .IsRequired()
                    .HasColumnName("NDistrito")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CciudadNavigation)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => d.Cciudad)
                    .HasConstraintName("Distrito_Ciudad");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.Cequipo)
                    .HasName("Equipo_pk");

                entity.Property(e => e.Cequipo).HasColumnName("CEquipo");

                entity.Property(e => e.Cdistrito).HasColumnName("CDistrito");

                entity.Property(e => e.DfechaJuego)
                    .HasColumnName("DFechaJuego")
                    .HasColumnType("date");

                entity.Property(e => e.ImgFoto).HasColumnType("image");

                entity.Property(e => e.Nequipo)
                    .IsRequired()
                    .HasColumnName("NEquipo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tdescripcion)
                    .IsRequired()
                    .HasColumnName("TDescripcion")
                    .HasColumnType("text");

                entity.HasOne(d => d.CdistritoNavigation)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.Cdistrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Equipo_Distrito");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.Cjugador)
                    .HasName("Jugador_pk");

                entity.Property(e => e.Cjugador)
                    .HasColumnName("CJugador")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasColumnName("TDireccion")
                    .HasColumnType("text");

                entity.HasOne(d => d.CjugadorNavigation)
                    .WithOne(p => p.Jugador)
                    .HasForeignKey<Jugador>(d => d.Cjugador)
                    .HasConstraintName("Jugador_Usuario");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.HasKey(e => e.Cparticipante)
                    .HasName("Participante_pk");

                entity.Property(e => e.Cparticipante).HasColumnName("CParticipante");

                entity.Property(e => e.Cequipo).HasColumnName("CEquipo");

                entity.Property(e => e.Cjugador).HasColumnName("CJugador");

                entity.Property(e => e.FesAdministrador).HasColumnName("FEsAdministrador");

                entity.HasOne(d => d.CequipoNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.Cequipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Equipo_Equipo");

                entity.HasOne(d => d.CjugadorNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.Cjugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Jugador_Equipo_Jugador");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.Cpropietario)
                    .HasName("Propietario_pk");

                entity.Property(e => e.Cpropietario)
                    .HasColumnName("CPropietario")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CpropietarioNavigation)
                    .WithOne(p => p.Propietario)
                    .HasForeignKey<Propietario>(d => d.Cpropietario)
                    .HasConstraintName("Propietario_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cusuario)
                    .HasName("Usuario_pk");

                entity.Property(e => e.Cusuario).HasColumnName("CUsuario");

                entity.Property(e => e.Cdni).HasColumnName("CDNI");

                entity.Property(e => e.ImgFoto).HasColumnType("image");

                entity.Property(e => e.Nusuario)
                    .IsRequired()
                    .HasColumnName("NUsuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pswd)
                    .HasColumnName("pswd")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("usuario")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
