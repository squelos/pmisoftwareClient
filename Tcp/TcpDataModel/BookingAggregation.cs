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
    
    public partial class BookingAggregation
    {
        public BookingAggregation()
        {
            this.Booking = new ObservableCollection<Booking>();
        }
    
        public int ID { get; set; }
        public string name { get; set; }
    
        public virtual ObservableCollection<Booking> Booking { get; set; }
    }
}
