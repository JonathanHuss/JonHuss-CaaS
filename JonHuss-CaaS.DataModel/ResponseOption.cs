//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JonHuss_CaaS.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResponseOption
    {
        public int ID { get; set; }
        public int StepID { get; set; }
        public string Text { get; set; }
        public int NextStepID { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Step NextStep { get; set; }
    }
}
