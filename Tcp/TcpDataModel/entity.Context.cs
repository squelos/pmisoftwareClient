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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<Status> StatusSet { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethodSet { get; set; }
        public virtual DbSet<Day> DaySet { get; set; }
        public virtual DbSet<BallLevel> BallLevelSet { get; set; }
        public virtual DbSet<News> NewsSet { get; set; }
        public virtual DbSet<AuthorizedTagsVersion> AuthorizedTagsVersion { get; set; }
        public virtual DbSet<authorizedUserTags> authorizedUserTags { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<LogEntry> LogEntry { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<Nullable<bool>> dummyQuery()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("dummyQuery");
        }
    
        public virtual ObjectResult<Nullable<long>> getAuthorizedUsersTagsNumbers(Nullable<int> userStatus)
        {
            var userStatusParameter = userStatus.HasValue ?
                new ObjectParameter("userStatus", userStatus) :
                new ObjectParameter("userStatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("getAuthorizedUsersTagsNumbers", userStatusParameter);
        }
    
        public virtual ObjectResult<getFilmedHours_Result> getFilmedHours()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getFilmedHours_Result>("getFilmedHours");
        }
    
        public virtual int incrementAuthorizedTagsVersionNumber()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("incrementAuthorizedTagsVersionNumber");
        }
    
        public virtual int invalidateOverdues()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("invalidateOverdues");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int addLogEntry(string entryDate, string readerName, Nullable<int> tagNumber, Nullable<int> readerResponse)
        {
            var entryDateParameter = entryDate != null ?
                new ObjectParameter("entryDate", entryDate) :
                new ObjectParameter("entryDate", typeof(string));
    
            var readerNameParameter = readerName != null ?
                new ObjectParameter("readerName", readerName) :
                new ObjectParameter("readerName", typeof(string));
    
            var tagNumberParameter = tagNumber.HasValue ?
                new ObjectParameter("tagNumber", tagNumber) :
                new ObjectParameter("tagNumber", typeof(int));
    
            var readerResponseParameter = readerResponse.HasValue ?
                new ObjectParameter("readerResponse", readerResponse) :
                new ObjectParameter("readerResponse", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addLogEntry", entryDateParameter, readerNameParameter, tagNumberParameter, readerResponseParameter);
        }
    
        public virtual ObjectResult<mostBookedCourtsForPlayerCategory_Result> mostBookedCourtsForPlayerCategory(Nullable<int> category_Id)
        {
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<mostBookedCourtsForPlayerCategory_Result>("mostBookedCourtsForPlayerCategory", category_IdParameter);
        }
    
        public virtual int mostBookedCourtsForPlayerCategory1(Nullable<int> category_Id)
        {
            var category_IdParameter = category_Id.HasValue ?
                new ObjectParameter("Category_Id", category_Id) :
                new ObjectParameter("Category_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("mostBookedCourtsForPlayerCategory1", category_IdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> tryPeriodBooking(string name, Nullable<bool> isSpecial, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<bool> isFilmed, Nullable<int> bookingAggregation, Nullable<int> courtId, Nullable<int> player1, Nullable<int> player2)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var isSpecialParameter = isSpecial.HasValue ?
                new ObjectParameter("isSpecial", isSpecial) :
                new ObjectParameter("isSpecial", typeof(bool));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            var isFilmedParameter = isFilmed.HasValue ?
                new ObjectParameter("isFilmed", isFilmed) :
                new ObjectParameter("isFilmed", typeof(bool));
    
            var bookingAggregationParameter = bookingAggregation.HasValue ?
                new ObjectParameter("bookingAggregation", bookingAggregation) :
                new ObjectParameter("bookingAggregation", typeof(int));
    
            var courtIdParameter = courtId.HasValue ?
                new ObjectParameter("courtId", courtId) :
                new ObjectParameter("courtId", typeof(int));
    
            var player1Parameter = player1.HasValue ?
                new ObjectParameter("player1", player1) :
                new ObjectParameter("player1", typeof(int));
    
            var player2Parameter = player2.HasValue ?
                new ObjectParameter("player2", player2) :
                new ObjectParameter("player2", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("tryPeriodBooking", nameParameter, isSpecialParameter, startDateParameter, endDateParameter, isFilmedParameter, bookingAggregationParameter, courtIdParameter, player1Parameter, player2Parameter);
        }
    }
}
