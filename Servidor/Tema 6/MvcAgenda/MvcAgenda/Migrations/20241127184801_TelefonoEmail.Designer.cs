﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcAgenda.Data;

#nullable disable

namespace MvcAgenda.Migrations
{
    [DbContext(typeof(MvcAgendaContexto))]
    [Migration("20241127184801_TelefonoEmail")]
    partial class TelefonoEmail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MvcAgenda.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("MvcAgenda.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("MvcAgenda.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("MvcAgenda.Models.Empleado", b =>
                {
                    b.HasOne("MvcAgenda.Models.Departamento", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("MvcAgenda.Models.Tarea", b =>
                {
                    b.HasOne("MvcAgenda.Models.Empleado", "Empleado")
                        .WithMany("Tareas")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("MvcAgenda.Models.Departamento", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("MvcAgenda.Models.Empleado", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}