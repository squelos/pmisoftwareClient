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
    
    public partial class Category
    {
        public Category()
        {
            this.Player = new HashSet<Player>();
        }
    
        public int Id { get; set; }
        public PlayerCategory category { get; set; }
    
        public virtual ICollection<Player> Player { get; set; }
    }
}
