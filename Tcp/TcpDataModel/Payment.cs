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
    
    public partial class Payment
    {
        public Payment()
        {
            this.Semester = new ObservableCollection<Semester>();
        }
    
        public int ID { get; set; }
        public double amount { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual ObservableCollection<Semester> Semester { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
