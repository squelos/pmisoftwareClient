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
    
    public partial class Day
    {
        public Day()
        {
            this.PreferencePeriod = new ObservableCollection<PreferencePeriod>();
            this.TrainingPreferences = new ObservableCollection<TrainingPreferences>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
    
        public virtual ObservableCollection<PreferencePeriod> PreferencePeriod { get; set; }
        public virtual ObservableCollection<TrainingPreferences> TrainingPreferences { get; set; }
    }
}