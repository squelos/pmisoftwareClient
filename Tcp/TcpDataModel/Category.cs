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
    
    public partial class Category
    {
        public Category()
        {
            this.Player = new ObservableCollection<Player>();
        }
    
        public int Id { get; set; }
        public string categoryName { get; set; }
    
        public virtual ObservableCollection<Player> Player { get; set; }
    }
}
