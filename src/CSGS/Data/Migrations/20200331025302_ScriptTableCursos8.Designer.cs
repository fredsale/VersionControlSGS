using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSGS.Data;

namespace CSGS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200331025302_ScriptTableCursos8")]
    partial class ScriptTableCursos8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSGS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DNI");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CSGS.Models.Entities.CursoExt", b =>
                {
                    b.Property<int>("IdCursoExt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionCursoExt")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("IdAdmin");

                    b.Property<string>("TituloCursoExt")
                        .HasAnnotation("MaxLength", 120);

                    b.HasKey("IdCursoExt");

                    b.ToTable("CursoExt");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreEstado");

                    b.HasKey("IdEstado");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("CSGS.Models.Entities.MatriculaDoc", b =>
                {
                    b.Property<int>("IdMatriculaDoc")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Fechamatricula");

                    b.Property<int>("IdCursoExt");

                    b.Property<string>("IdEstudiante")
                        .HasAnnotation("MaxLength", 450);

                    b.HasKey("IdMatriculaDoc");

                    b.HasIndex("IdCursoExt");

                    b.ToTable("MatriculaDoc");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Motivo", b =>
                {
                    b.Property<int>("IdMotivo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreMotivo");

                    b.HasKey("IdMotivo");

                    b.ToTable("Motivo");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Prueba1", b =>
                {
                    b.Property<int>("IdPrueba1")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionViaje");

                    b.Property<int>("DuracionViaje");

                    b.Property<DateTime?>("FechaViaje");

                    b.Property<decimal>("GastosHotel");

                    b.Property<decimal>("GastosMovilidad");

                    b.Property<int>("IdPrueba2");

                    b.Property<string>("IdSolicitante")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("IdSupervisor");

                    b.Property<decimal>("MontoGastar");

                    b.Property<string>("SustentoSupervisor");

                    b.HasKey("IdPrueba1");

                    b.HasIndex("IdPrueba2");

                    b.ToTable("Prueba1");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Prueba2", b =>
                {
                    b.Property<int>("IdPrueba2")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdPrueba3");

                    b.Property<string>("NombrePrueba2");

                    b.HasKey("IdPrueba2");

                    b.HasIndex("IdPrueba3");

                    b.ToTable("Prueba2");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Prueba3", b =>
                {
                    b.Property<int>("IdPrueba3")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombrePrueba3");

                    b.HasKey("IdPrueba3");

                    b.ToTable("Prueba3");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Solicitud", b =>
                {
                    b.Property<int>("IdSolicitud")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionViaje");

                    b.Property<int>("DuracionViaje");

                    b.Property<DateTime?>("FechaViaje");

                    b.Property<decimal>("GastosHotel");

                    b.Property<decimal>("GastosMovilidad");

                    b.Property<int>("IdEstado");

                    b.Property<int>("IdMotivo");

                    b.Property<string>("IdSolicitante")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("IdSupervisor");

                    b.Property<decimal>("MontoGastar");

                    b.Property<string>("SustentoSupervisor");

                    b.HasKey("IdSolicitud");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdMotivo");

                    b.ToTable("Solicitud");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CSGS.Models.Entities.MatriculaDoc", b =>
                {
                    b.HasOne("CSGS.Models.Entities.CursoExt", "CursoExt")
                        .WithMany("MatriculaDoc")
                        .HasForeignKey("IdCursoExt")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSGS.Models.Entities.Prueba1", b =>
                {
                    b.HasOne("CSGS.Models.Entities.Prueba2", "Prueba2")
                        .WithMany("Prueba1")
                        .HasForeignKey("IdPrueba2")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSGS.Models.Entities.Prueba2", b =>
                {
                    b.HasOne("CSGS.Models.Entities.Prueba3", "Prueba3")
                        .WithMany("Prueba2")
                        .HasForeignKey("IdPrueba3")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSGS.Models.Entities.Solicitud", b =>
                {
                    b.HasOne("CSGS.Models.Entities.Estado", "Estado")
                        .WithMany("Solicitud")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSGS.Models.Entities.Motivo", "Motivo")
                        .WithMany("Solicitud")
                        .HasForeignKey("IdMotivo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CSGS.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CSGS.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSGS.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
