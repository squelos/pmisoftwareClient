//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TcpDataModel
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class PreferencePeriod
    {
        public int ID { get; set; }
        public int beginningHour { get; set; }
        public int endHour { get; set; }
        public int beginningMin { get; set; }
        public int endmin { get; set; }
        public Days day { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
