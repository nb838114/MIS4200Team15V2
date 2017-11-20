using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentricTeam15.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CentricTeam15.DAL
{
    public class AccountDetailsContext : DbContext
    {
        public AccountDetailsContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));
        }

        public DbSet<AccountDetail> AccountDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<CentricTeam15.Models.RecognizeMe> RecognizeMes { get; set; }
    }

    // Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));


    /*public DbContext() : base("name=DefaultConnection")  
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("DefaultConnection"));
    }*/


    /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }*/
}

