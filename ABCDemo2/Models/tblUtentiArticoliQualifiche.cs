//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCDemo2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUtentiArticoliQualifiche
    {
        public int IDUtenteArticoloQualifica { get; set; }
        public Nullable<int> IDUtente { get; set; }
        public Nullable<int> IDArticoloQualifica { get; set; }
    
        public virtual tblArticoliQualifiche tblArticoliQualifiche { get; set; }
        public virtual tblUtenti tblUtenti { get; set; }
    }
}
