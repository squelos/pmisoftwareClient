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
    using System.Collections.Generic;
    
    public partial class BookingAggregation
    {
        public BookingAggregation()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int ID { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
