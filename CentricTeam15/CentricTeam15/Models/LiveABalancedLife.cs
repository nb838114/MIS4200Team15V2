using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricTeam15.Models
{
    public class LiveABalancedLife
    {
        [Key]
        public int lblID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string fistName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Suggestion")]
        public string lblSuggestion { get; set; }

    }
}