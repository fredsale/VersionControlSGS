using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSGS.Data;

namespace CSGS.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200331012503_ScriptTableTest")]
    partial class ScriptTableTest
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

            modelBuilder.Entity("CSGS.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreCategoria");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Cursos", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AudienciaCurso");

                    b.Property<string>("DescripcionCurso")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int>("DuracionCurso");

                    b.Property<DateTime?>("FechaFinMat");

                    b.Property<DateTime?>("FechaInicioClases");

                    b.Property<DateTime?>("FechaInicioMat");

                    b.Property<string>("IdAdmin");

                    b.Property<int>("IdCategoria");

                    b.Property<string>("NivelCurso")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("ObjetivosCurso")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<string>("ReqCurso")
                        .HasAnnotation("MaxLength", 254);

                    b.Property<string>("TemarioCurso")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<string>("TituloCurso")
                        .HasAnnotation("MaxLength", 120);

                    b.HasKey("IdCurso");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreEstado");

                    b.HasKey("IdEstado");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Matricula", b =>
                {
                    b.Property<int>("IdMatricula")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Fechamatricula");

                    b.Property<int>("IdCurso");

                    b.Property<string>("IdEstudiante")
                        .HasAnnotation("MaxLength", 450);

                    b.HasKey("IdMatricula");

                    b.HasIndex("IdCurso");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("CSGS.Models.Entities.Motivo", b =>
                {
                    b.Property<int>("IdMotivo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NombreMotivo");

                    b.HasKey("IdMotivo");

                    b.ToTable("Motivo");
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

            modelBuilder.Entity("CSGS.Models.Entities.Cursos", b =>
                {
                    b.HasOne("CSGS.Models.Entities.Categoria", "Categoria")
                        .WithMany("Cursos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSGS.Models.Entities.Matricula", b =>
                {
                    b.HasOne("CSGS.Models.Entities.Cursos", "Cursos")
                        .WithMany("Matricula")
                        .HasForeignKey("IdCurso")
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
