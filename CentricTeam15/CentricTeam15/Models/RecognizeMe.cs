using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CentricTeam15.Models
{
    public class RecognizeMe
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Business Unit")]
        public string bussinessUnit { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Core Value")]
        public string coreValue { get; set; }

    }
}