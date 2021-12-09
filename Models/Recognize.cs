using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Centric_FINAL.Models
{
    public class Recognize
    {
        [Key]
        public int RecognizeID { get; set; }
        public Guid EmployeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public enum CoreValue { Stewardship, Culture, Innovation, [Display(Name = "Delivery Excellence")] DeliveryExcellence, [Display(Name = "Greater Good")] GreaterGood, [Display(Name = "Integrity and Openness")] IntegrityandOpenness, Balance }
        public CoreValue CoreValueIndicator { get; set; }
        public enum TxtorEmail { Text, Email }
        public TxtorEmail MessageOption { get; set; }
        public string Message { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Profile Profile { get; set; }
        public string EmployeeFullName
        {
            get
            {
                return lastName + "," + firstName;
            }
        }
    }
}