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
    
    public partial class ProductSet
    {
        public ProductSet()
        {
            this.ProductQuantitySet = new ObservableCollection<ProductQuantitySet>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
    
        public virtual ObservableCollection<ProductQuantitySet> ProductQuantitySet { get; set; }
    }
}
