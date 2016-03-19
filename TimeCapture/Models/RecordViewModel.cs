using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeCapture.Models
{
    public class RecordViewModel
    {
        public int LawyerID { get; set; }
        public string LawyerName { get; set; }
        public DateTime RecordingDate { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public int TimeZone { get; set; }


    }
}