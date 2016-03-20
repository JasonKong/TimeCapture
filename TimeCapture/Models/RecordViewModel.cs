using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeCapture.Models
{
    public class RecordViewModel
    {
        public int LawyerID { get; set; }
        public int ClientID { get; set; }
        public int OfficeID { get; set; }
        public int TaskId { get; set; }
        public int ActivityID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TimeZoneID { get; set; }
        public string Comment { get; set; }


    }
}