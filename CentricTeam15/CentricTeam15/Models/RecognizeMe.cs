using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CentricTeam15.Models
{
    public class RecognizeMe
    {
        [Key]
        public int recognitionID { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "BU of Person Being Recognized")]
        public string bussinessUnit { get; set; }

        [Display(Name = "Comment")]
        public string description { get; set; }

        [Display(Name = "Core Value")]
        public award CoreValue { get; set; }

        public enum award
        {
            Commit_to_Delivery_Excellence = 1,
            Invest_in_an_Exceptional_Culture = 2,
            Embrace_Integrity_and_Openness = 3,
            Practice_Responsible_Stewardship = 4,
            Strive_to_Innovate = 5,
            Ignite_Passion_for_the_Greater_Good = 6,
            Live_a_Balanced_Life = 7,

        }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("ID")]

        public virtual AccountDetail PersonGettingAward { get; set; }

        [Display(Name = "Date Recognition is Given")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime CurrentDateTime { get; set; }

    }
}