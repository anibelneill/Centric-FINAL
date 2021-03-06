using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace Centric_FINAL.Models
{
    public class Profile
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Full Name")]
        public string EmployeeFullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }


        [Display(Name = "Primary Phone")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Business Unit")]
        public BusinessUnitName BusinessUnit { get; set; }
        public enum BusinessUnitName { Boston, Charlotte, Chicago, Cincinnati, Cleveland, Columbus, Detroit, India, Indianapolis, Louisville, Miami, Seattle, [Display(Name = "Saint Louis")] StLouis }

        [Display(Name = "Position")]
        public BusinessTitle Title { get; set; }
        public enum BusinessTitle { Consultant, [Display(Name = "Senior Consultant")] SeniorConsultant, Manager, [Display(Name = "Senior Manager")] SeniorManager, Architect, [Display(Name = "Senior Consultant")] SeniorArchitect, Partner, National }


        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }
        public ICollection<Recognize> Recognize { get; set; }
    }
}