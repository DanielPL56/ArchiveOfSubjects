namespace SubjectsDAL.EF
{
    using SubjectsDAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SubjectEntities : DbContext
    {
        // Your context has been configured to use a 'SubjectEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SubjectsDAL.EF.SubjectEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SubjectEntities' 
        // connection string in the application configuration file.
        public SubjectEntities()
            : base("name=SubjectEntitiesConnection")
        {
        }

        public virtual DbSet<Human> Humans { get; set; }
        public virtual DbSet<Android> Androids { get; set; }
    }
}