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
        public AccountDetailsContext() : base("name=CentricTeam15")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CentricTeam15.DAL.AccountDetailsContext, CentricTeam15.Migrations.DbContext.Configuration>("CentricTeam15"));
        }

        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<RecognizeMe> RecognizeMes { get; set; }
        //public DbSet<CommitToDeliveryExcellence> CommitToDeliveryExcellences { get; set; }
        //public DbSet<EmbraceIntegrityandOpenness> EmbraceIntegrityandOpennesses { get; set; }
        //public DbSet<IgnitePassionForTheGreaterGood> IgnitePassionForTheGreaterGoods { get; set; }
        //public DbSet<InvestInAnExceptionalCulture> InvestInAnExceptionalCultures { get; set; }
        //public DbSet<LiveABalancedLife> LiveABalancedLifes { get; set; }
        //public DbSet<PracticeResponsibleStewardship> PracticeResponsibleStewardships { get; set; }
        //public DbSet<StriveToInnovate> StriveToInnovates { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        object placeHolderVariable;
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

