﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class entityContainer : DbContext
    {
        public entityContainer()
            : base("name=entityContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Season> SeasonJeu { get; set; }
        public virtual DbSet<Semester> SemesterJeu { get; set; }
        public virtual DbSet<Payment> PaymentJeu { get; set; }
        public virtual DbSet<Badge> BadgeJeu { get; set; }
        public virtual DbSet<BookingAggregation> BookingAggregationJeu { get; set; }
        public virtual DbSet<Booking> BookingJeu { get; set; }
        public virtual DbSet<Court> CourtJeu { get; set; }
        public virtual DbSet<Opening> OpeningJeu { get; set; }
        public virtual DbSet<Player> PlayerJeu { get; set; }
        public virtual DbSet<PreferencePeriod> PreferencePeriodJeu { get; set; }
        public virtual DbSet<Category> CategorySet { get; set; }
        public virtual DbSet<TrainingPreferences> TrainingPreferencesSet { get; set; }
    }
}
