using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_FINAL.Models
{
    public class TrackProgress
    {
        [Key]
        public int  TrackID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string BusinessUnitName { get; set; }
        public string BusinessTitle { get; set; }

    }
}