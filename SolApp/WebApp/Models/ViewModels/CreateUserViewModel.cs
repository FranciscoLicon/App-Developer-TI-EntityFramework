using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models.ViewModels
{
    public class CreateUserViewModel
    {
        public int Id_User { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}