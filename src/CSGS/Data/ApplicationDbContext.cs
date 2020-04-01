using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CSGS.Models;
using CSGS.Models.Entities;

namespace CSGS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


                
        public virtual DbSet<MatriculaDoc> MatriculaDoc { get; set; }

        public virtual DbSet<CursoExt> CursoExt { get; set; }

        public virtual DbSet<CategoriaExt> CategoriaExt { get; set; }


        public ApplicationDbContext()
        {

        }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer("Server=MI302-VS2015-ST;Database=SGS;Trusted_Connection=True;");
            builder.UseSqlServer("Server=FRED;Database=SGS;Trusted_Connection=True;");
        }


    }
}
