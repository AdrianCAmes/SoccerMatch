﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.dbcontext;

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190707021456_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Alquiler", b =>
                {
                    b.Property<int>("Calquiler")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CAlquiler")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ccancha")
                        .HasColumnName("CCancha");

                    b.Property<int>("Cequipo")
                        .HasColumnName("CEquipo");

                    b.Property<DateTime>("DfechaInicio")
                        .HasColumnName("DFechaInicio")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DfechaRegistro")
                        .HasColumnName("DFechaRegistro")
                        .HasColumnType("datetime");

                    b.Property<bool>("Fpagado")
                        .HasColumnName("FPagado");

                    b.Property<decimal>("Mdescuento")
                        .HasColumnName("MDescuento")
                        .HasColumnType("money");

                    b.Property<decimal>("Mtotal")
                        .HasColumnName("MTotal")
                        .HasColumnType("money");

                    b.Property<int>("NumHoras");

                    b.HasKey("Calquiler")
                        .HasName("Alquiler_pk");

                    b.HasIndex("Ccancha");

                    b.HasIndex("Cequipo");

                    b.ToTable("Alquiler");
                });

            modelBuilder.Entity("Entity.Calle", b =>
                {
                    b.Property<int>("Ccalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CCalle")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cdistrito")
                        .HasColumnName("CDistrito");

                    b.Property<string>("Ncalle")
                        .IsRequired()
                        .HasColumnName("NCalle")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Ccalle")
                        .HasName("Calle_pk");

                    b.HasIndex("Cdistrito");

                    b.ToTable("Calle");
                });

            modelBuilder.Entity("Entity.Cancha", b =>
                {
                    b.Property<int>("Ccancha")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CCancha")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ccalle")
                        .HasColumnName("CCalle");

                    b.Property<int>("Cpropietario")
                        .HasColumnName("CPropietario");

                    b.Property<decimal>("MprecioHora")
                        .HasColumnName("MPrecioHora")
                        .HasColumnType("money");

                    b.Property<string>("Ncancha")
                        .IsRequired()
                        .HasColumnName("NCancha")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Tdireccion")
                        .IsRequired()
                        .HasColumnName("TDireccion")
                        .HasColumnType("text");

                    b.HasKey("Ccancha")
                        .HasName("Cancha_pk");

                    b.HasIndex("Ccalle");

                    b.HasIndex("Cpropietario");

                    b.ToTable("Cancha");
                });

            modelBuilder.Entity("Entity.Ciudad", b =>
                {
                    b.Property<int>("Cciudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CCiudad")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cdepartamento")
                        .HasColumnName("CDepartamento");

                    b.Property<string>("Nciudad")
                        .IsRequired()
                        .HasColumnName("NCiudad")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Cciudad")
                        .HasName("Ciudad_pk");

                    b.HasIndex("Cdepartamento");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("Entity.Departamento", b =>
                {
                    b.Property<int>("Cdepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CDepartamento")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ndepartamento")
                        .IsRequired()
                        .HasColumnName("NDepartamento")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Cdepartamento")
                        .HasName("Departamento_pk");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Entity.DetalleParticipante", b =>
                {
                    b.Property<int>("CdetalleParticipante")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CDetalleParticipante")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calquiler")
                        .HasColumnName("CAlquiler");

                    b.Property<int>("Cparticipante")
                        .HasColumnName("CParticipante");

                    b.Property<bool>("FpartePagada")
                        .HasColumnName("FPartePagada");

                    b.Property<decimal>("Mcuota")
                        .HasColumnName("MCuota")
                        .HasColumnType("money");

                    b.Property<int>("Ncupos")
                        .HasColumnName("NCupos");

                    b.HasKey("CdetalleParticipante")
                        .HasName("DetalleParticipante_pk");

                    b.HasIndex("Calquiler");

                    b.HasIndex("Cparticipante");

                    b.ToTable("DetalleParticipante");
                });

            modelBuilder.Entity("Entity.Distrito", b =>
                {
                    b.Property<int>("Cdistrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CDistrito")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cciudad")
                        .HasColumnName("CCiudad");

                    b.Property<string>("Ndistrito")
                        .IsRequired()
                        .HasColumnName("NDistrito")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Cdistrito")
                        .HasName("Distrito_pk");

                    b.HasIndex("Cciudad");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("Entity.Equipo", b =>
                {
                    b.Property<int>("Cequipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CEquipo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cdistrito")
                        .HasColumnName("CDistrito");

                    b.Property<DateTime>("DfechaJuego")
                        .HasColumnName("DFechaJuego")
                        .HasColumnType("date");

                    b.Property<string>("Nequipo")
                        .IsRequired()
                        .HasColumnName("NEquipo")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("NumParticipantes");

                    b.Property<string>("Tdescripcion")
                        .IsRequired()
                        .HasColumnName("TDescripcion")
                        .HasColumnType("text");

                    b.HasKey("Cequipo")
                        .HasName("Equipo_pk");

                    b.HasIndex("Cdistrito");

                    b.ToTable("Equipo");
                });

            modelBuilder.Entity("Entity.Jugador", b =>
                {
                    b.Property<int>("Cjugador")
                        .HasColumnName("CJugador");

                    b.Property<string>("Tdireccion")
                        .IsRequired()
                        .HasColumnName("TDireccion")
                        .HasColumnType("text");

                    b.HasKey("Cjugador")
                        .HasName("Jugador_pk");

                    b.ToTable("Jugador");
                });

            modelBuilder.Entity("Entity.Participante", b =>
                {
                    b.Property<int>("Cparticipante")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CParticipante")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cequipo")
                        .HasColumnName("CEquipo");

                    b.Property<int>("Cjugador")
                        .HasColumnName("CJugador");

                    b.Property<DateTime>("DfechaUnion")
                        .HasColumnName("DFechaUnion")
                        .HasColumnType("datetime");

                    b.Property<bool>("FesAdministrador")
                        .HasColumnName("FEsAdministrador");

                    b.HasKey("Cparticipante")
                        .HasName("Participante_pk");

                    b.HasIndex("Cequipo");

                    b.HasIndex("Cjugador");

                    b.ToTable("Participante");
                });

            modelBuilder.Entity("Entity.Propietario", b =>
                {
                    b.Property<int>("Cpropietario")
                        .HasColumnName("CPropietario");

                    b.HasKey("Cpropietario")
                        .HasName("Propietario_pk");

                    b.ToTable("Propietario");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<int>("Cusuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CUsuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cdni")
                        .HasColumnName("CDNI");

                    b.Property<long>("NumTelefono");

                    b.Property<string>("Nusuario")
                        .IsRequired()
                        .HasColumnName("NUsuario")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Pswd")
                        .HasColumnName("pswd")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Usuario1")
                        .HasColumnName("usuario")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Cusuario")
                        .HasName("Usuario_pk");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Entity.Alquiler", b =>
                {
                    b.HasOne("Entity.Cancha", "CcanchaNavigation")
                        .WithMany("Alquiler")
                        .HasForeignKey("Ccancha")
                        .HasConstraintName("Alquiler_Cancha")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Equipo", "CequipoNavigation")
                        .WithMany("Alquiler")
                        .HasForeignKey("Cequipo")
                        .HasConstraintName("Alquiler_Equipo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Calle", b =>
                {
                    b.HasOne("Entity.Distrito", "CdistritoNavigation")
                        .WithMany("Calle")
                        .HasForeignKey("Cdistrito")
                        .HasConstraintName("Calle_Distrito")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Cancha", b =>
                {
                    b.HasOne("Entity.Calle", "CcalleNavigation")
                        .WithMany("Cancha")
                        .HasForeignKey("Ccalle")
                        .HasConstraintName("Cancha_Calle")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Propietario", "CpropietarioNavigation")
                        .WithMany("Cancha")
                        .HasForeignKey("Cpropietario")
                        .HasConstraintName("Cancha_Propietario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Ciudad", b =>
                {
                    b.HasOne("Entity.Departamento", "CdepartamentoNavigation")
                        .WithMany("Ciudad")
                        .HasForeignKey("Cdepartamento")
                        .HasConstraintName("Ciudad_Departamento")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.DetalleParticipante", b =>
                {
                    b.HasOne("Entity.Alquiler", "CalquilerNavigation")
                        .WithMany("DetalleParticipante")
                        .HasForeignKey("Calquiler")
                        .HasConstraintName("Alquiler_Jugador_Equipo_Alquiler")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entity.Participante", "CparticipanteNavigation")
                        .WithMany("DetalleParticipante")
                        .HasForeignKey("Cparticipante")
                        .HasConstraintName("Alquiler_Jugador_Equipo_Participante")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Distrito", b =>
                {
                    b.HasOne("Entity.Ciudad", "CciudadNavigation")
                        .WithMany("Distrito")
                        .HasForeignKey("Cciudad")
                        .HasConstraintName("Distrito_Ciudad")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Equipo", b =>
                {
                    b.HasOne("Entity.Distrito", "CdistritoNavigation")
                        .WithMany("Equipo")
                        .HasForeignKey("Cdistrito")
                        .HasConstraintName("Equipo_Distrito");
                });

            modelBuilder.Entity("Entity.Jugador", b =>
                {
                    b.HasOne("Entity.Usuario", "CjugadorNavigation")
                        .WithOne("Jugador")
                        .HasForeignKey("Entity.Jugador", "Cjugador")
                        .HasConstraintName("Jugador_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entity.Participante", b =>
                {
                    b.HasOne("Entity.Equipo", "CequipoNavigation")
                        .WithMany("Participante")
                        .HasForeignKey("Cequipo")
                        .HasConstraintName("Usuario_Equipo_Equipo");

                    b.HasOne("Entity.Jugador", "CjugadorNavigation")
                        .WithMany("Participante")
                        .HasForeignKey("Cjugador")
                        .HasConstraintName("Jugador_Equipo_Jugador");
                });

            modelBuilder.Entity("Entity.Propietario", b =>
                {
                    b.HasOne("Entity.Usuario", "CpropietarioNavigation")
                        .WithOne("Propietario")
                        .HasForeignKey("Entity.Propietario", "Cpropietario")
                        .HasConstraintName("Propietario_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
