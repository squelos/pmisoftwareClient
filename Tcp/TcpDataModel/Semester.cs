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
    
    public partial class Semester
    {
        public Semester()
        {
            this.Payment = new ObservableCollection<Payment>();
        }
    
        public int ID { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
    
        public virtual ObservableCollection<Payment> Payment { get; set; }
        public virtual Season Season { get; set; }
    }
}
