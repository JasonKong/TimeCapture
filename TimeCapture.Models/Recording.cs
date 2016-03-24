//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeCapture.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recording
    {
        public int ID { get; set; }
        public int LawyerID { get; set; }
        public int ClientID { get; set; }
        public int TaskID { get; set; }
        public int AcitivityID { get; set; }
        public int OfficeID { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public Nullable<int> TimeZoneID { get; set; }
        public decimal Duration { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public System.DateTime CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime UpdateOn { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Client Client { get; set; }
        public virtual TimeZone TimeZone { get; set; }
        public virtual User User { get; set; }
    }
}
