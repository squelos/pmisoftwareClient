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
    
    public partial class ProductQuantity
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
    
        public virtual Payment Payment { get; set; }
        public virtual Product Product { get; set; }
    }
}
