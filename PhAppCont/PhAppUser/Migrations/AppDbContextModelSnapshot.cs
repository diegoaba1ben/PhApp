﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhAppUser.Infrastructure.Context;

#nullable disable

namespace PhAppUser.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PhAppUser.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EsRepresentanteLegal")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Cargos", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("PerfilUsuarioCargoId")
                        .HasColumnType("int");

                    b.Property<int?>("PerfilUsuarioUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilUsuarioUsuarioId", "PerfilUsuarioCargoId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.EntSalud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NroAfiliacion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("EntsSalud", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Pension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NroAfiliacion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pensiones", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.PerfilUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "CargoId");

                    b.HasIndex("CargoId");

                    b.ToTable("PerfilUsuarios", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("CreadorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Permisos", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.RepLegal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlcaldiaEmisora")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaExpedicion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("RepLegales", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("EntSaludId")
                        .HasColumnType("int");

                    b.Property<int?>("EntSaludId1")
                        .HasColumnType("int");

                    b.Property<string>("IdenTributaria")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nombre1")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nombre2")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PensionId")
                        .HasColumnType("int");

                    b.Property<int?>("PensionId1")
                        .HasColumnType("int");

                    b.Property<string>("TarjProf")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("EntSaludId")
                        .IsUnique();

                    b.HasIndex("EntSaludId1")
                        .IsUnique();

                    b.HasIndex("PensionId")
                        .IsUnique();

                    b.HasIndex("PensionId1")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("PhAppUser.Domain.Entities.PerfilUsuario", null)
                        .WithMany("Categorias")
                        .HasForeignKey("PerfilUsuarioUsuarioId", "PerfilUsuarioCargoId");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.PerfilUsuario", b =>
                {
                    b.HasOne("PhAppUser.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Perfiles")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhAppUser.Domain.Entities.Usuario", "Usuario")
                        .WithMany("PerfileUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Permiso", b =>
                {
                    b.HasOne("PhAppUser.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Permisos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.RepLegal", b =>
                {
                    b.HasOne("PhAppUser.Domain.Entities.Cargo", "Cargo")
                        .WithMany("RepresentantesLegales")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("PhAppUser.Domain.Entities.EntSalud", "EntSalud")
                        .WithOne()
                        .HasForeignKey("PhAppUser.Domain.Entities.Usuario", "EntSaludId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PhAppUser.Domain.Entities.EntSalud", null)
                        .WithOne("usuario")
                        .HasForeignKey("PhAppUser.Domain.Entities.Usuario", "EntSaludId1");

                    b.HasOne("PhAppUser.Domain.Entities.Pension", "Pension")
                        .WithOne()
                        .HasForeignKey("PhAppUser.Domain.Entities.Usuario", "PensionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PhAppUser.Domain.Entities.Pension", null)
                        .WithOne("Usuario")
                        .HasForeignKey("PhAppUser.Domain.Entities.Usuario", "PensionId1");

                    b.Navigation("EntSalud");

                    b.Navigation("Pension");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("Perfiles");

                    b.Navigation("RepresentantesLegales");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Permisos");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.EntSalud", b =>
                {
                    b.Navigation("usuario");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Pension", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.PerfilUsuario", b =>
                {
                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("PhAppUser.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("PerfileUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
