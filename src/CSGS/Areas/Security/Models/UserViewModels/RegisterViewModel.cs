using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace CSGS.Areas.Security.Models.UserViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public string UserName { get; set; }

        public string UserId { get; set; }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(8, ErrorMessage = "El DNI debe ser de 8 digitos")]
        [MinLength(8, ErrorMessage = "El DNI debe ser de 8 digitos")]
        public string DNI { get; set; }

        [Required]
        public string Address { get; set; }


        public List<IdentityRole> Roles { get; set; }

        //este representaria el NormalizedName
        public string RoleId { get; set; }

    }
}
