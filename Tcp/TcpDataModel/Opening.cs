//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TcpDataModel
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Opening
    {
        public int ID { get; set; }
        public System.DateTime time { get; set; }
    
        public virtual Court Court { get; set; }
        public virtual Badge Badge { get; set; }
    }
}
