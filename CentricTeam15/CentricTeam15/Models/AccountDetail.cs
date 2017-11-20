using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CentricTeam15.Models
{
    public class AccountDetail
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Employee Name")]
        public string fullName { get { return lastName + ", " + firstName; } }

        [Required]
        [Display(Name = "Bussiness Unit")]
        public string bussinessUnit { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Hire Date")]
        public string hireDate { get; set; }

        [Display(Name = "Photo")]
        public string photo { get; set; }

        //[Display(Name = "Biography")]
        //public string userBiography { get; set; }



    }
}