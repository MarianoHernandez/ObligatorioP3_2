﻿// <auto-generated />
using System;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20230614020449_inicio")]
    partial class inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Negocio.Entidades.Cabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<bool>("Jacuzzi")
                        .HasColumnType("bit");

                    b.Property<int>("TipoCabaniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoCabaniaId");

                    b.ToTable("Cabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabaniaId")
                        .HasColumnType("int");

                    b.Property<decimal>("costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("trabajador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabaniaId");

                    b.ToTable("Mantenimiento");
                });

            modelBuilder.Entity("Negocio.Entidades.TipoCabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TipoCabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Negocio.EntidadesAuxiliares.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ValorMaximo")
                        .HasColumnType("int");

                    b.Property<int>("ValorMinimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Parametro");
                });

            modelBuilder.Entity("Negocio.Entidades.Cabania", b =>
                {
                    b.HasOne("Negocio.Entidades.TipoCabania", "TipoCabania")
                        .WithMany()
                        .HasForeignKey("TipoCabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Negocio.ValueObjects.DescripcionCabania", "Descripcion", b1 =>
                        {
                            b1.Property<int>("CabaniaId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("CabaniaId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasFilter("[Descripcion_Value] IS NOT NULL");

                            b1.ToTable("Cabania");

                            b1.WithOwner()
                                .HasForeignKey("CabaniaId");
                        });

                    b.OwnsOne("Negocio.ValueObjects.NombreCabania", "Nombre", b1 =>
                        {
                            b1.Property<int>("CabaniaId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("CabaniaId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasFilter("[Nombre_Value] IS NOT NULL");

                            b1.ToTable("Cabania");

                            b1.WithOwner()
                                .HasForeignKey("CabaniaId");
                        });

                    b.Navigation("Descripcion");

                    b.Navigation("Nombre");

                    b.Navigation("TipoCabania");
                });

            modelBuilder.Entity("Negocio.Entidades.Mantenimiento", b =>
                {
                    b.HasOne("Negocio.Entidades.Cabania", "cabania")
                        .WithMany()
                        .HasForeignKey("CabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Negocio.ValueObjects.DescripcionMantenimiento", "descripcion", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("MantenimientoId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Mantenimiento");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.Navigation("cabania");

                    b.Navigation("descripcion")
                        .IsRequired();
                });

            modelBuilder.Entity("Negocio.Entidades.TipoCabania", b =>
                {
                    b.OwnsOne("Negocio.ValueObjects.DescripcionTipoCabania", "Descripcion", b1 =>
                        {
                            b1.Property<int>("TipoCabaniaId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("TipoCabaniaId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("TipoCabania");

                            b1.WithOwner()
                                .HasForeignKey("TipoCabaniaId");
                        });

                    b.Navigation("Descripcion")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}