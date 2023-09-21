﻿// <auto-generated />
using IntegradorSofftek.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntegradorSofftek.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IntegradorSofftek.Models.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.HasKey("CodProyecto");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 1,
                            Direccion = "Direccion 1",
                            Estado = 1,
                            Nombre = "Proyecto 1"
                        },
                        new
                        {
                            CodProyecto = 2,
                            Direccion = "Direccion 2",
                            Estado = 3,
                            Nombre = "Proyecto 2"
                        });
                });

            modelBuilder.Entity("IntegradorSofftek.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rol_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit")
                        .HasColumnName("rol_activo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rol_descripcion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rol_nombre");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Descripcion = "Admin",
                            Nombre = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Activo = true,
                            Descripcion = "Consulta",
                            Nombre = "Consulta"
                        });
                });

            modelBuilder.Entity("IntegradorSofftek.Models.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CodServicio");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            CodServicio = 1,
                            Descr = "Servicio 1",
                            Estado = true,
                            ValorHora = 10000m
                        },
                        new
                        {
                            CodServicio = 2,
                            Descr = "Servicio 2",
                            Estado = true,
                            ValorHora = 20000m
                        });
                });

            modelBuilder.Entity("IntegradorSofftek.Models.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("VARCHAR (250)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR (100)");

                    b.Property<int>("RolId")
                        .HasColumnType("int")
                        .HasColumnName("rol_id");

                    b.HasKey("CodUsuario");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Clave = "cb096c1ca77084ae25d67db3826eba376c48cf53aa308e30ccf52179628f88e8",
                            Dni = 1234,
                            Nombre = "admin",
                            RolId = 1
                        });
                });

            modelBuilder.Entity("IntegradorSofftek.Models.Usuario", b =>
                {
                    b.HasOne("IntegradorSofftek.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
