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
    
    public partial class Player
    {
        public Player()
        {
            this.Badge = new ObservableCollection<Badge>();
            this.PreferencePeriod = new ObservableCollection<PreferencePeriod>();
            this.Booking = new ObservableCollection<Booking>();
            this.Payment = new ObservableCollection<Payment>();
            this.Category = new ObservableCollection<Category>();
            this.TrainingPreferences = new ObservableCollection<TrainingPreferences>();
            this.Booking1 = new ObservableCollection<Booking>();
        }
    
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public System.DateTime birthDate { get; set; }
        public string ranking { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string zipCode { get; set; }
        public string city { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public bool isEnabled { get; set; }
        public string passwordHash { get; set; }
        public System.DateTime lastLogin { get; set; }
        public string licenceNumber { get; set; }
        public string login { get; set; }
    
        public virtual ObservableCollection<Badge> Badge { get; set; }
        public virtual ObservableCollection<PreferencePeriod> PreferencePeriod { get; set; }
        public virtual ObservableCollection<Booking> Booking { get; set; }
        public virtual ObservableCollection<Payment> Payment { get; set; }
        public virtual ObservableCollection<Category> Category { get; set; }
        public virtual ObservableCollection<TrainingPreferences> TrainingPreferences { get; set; }
        public virtual Status Status { get; set; }
        public virtual BallLevel BallLevel { get; set; }
        public virtual ObservableCollection<Booking> Booking1 { get; set; }
    }
}
