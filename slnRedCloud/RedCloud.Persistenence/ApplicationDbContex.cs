using Microsoft.EntityFrameworkCore;
using RedCloud.Application.Contract;
using RedCloud.Application.Features.Reseller.AssignCredit.Queries;
using RedCloud.Domain.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace RedCloud.Persistenence
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use this to configure the model
            modelBuilder.Entity<OrganizationAdmin>()
               .HasOne(oa => oa.State)
               .WithMany()
               .HasForeignKey(oa => oa.StateId)
               .OnDelete(DeleteBehavior.Restrict); // Specify NO ACTION on delete
            modelBuilder.Entity<TotalReport>().HasNoKey();//new
            modelBuilder.Entity<AdminInboundMessageReport>().HasNoKey();
            modelBuilder.Entity<AdminCount>().HasNoKey();
            modelBuilder.Entity<GetRatedUsage>().HasNoKey();
            modelBuilder.Entity<GetAllAssignNumber>().HasNoKey();

            modelBuilder.Entity<ResellerInboundMessagesReport>().HasNoKey();//new

            //By setting the table to be excluded from migrations,
            modelBuilder.Entity<AssignCreditDetailsVM>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<GetRatedUsage>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<getRatedUsageList>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.Entity<GetAllAssignNumber>().Metadata.SetIsTableExcludedFromMigrations(true);

        }

        public DbSet<Role> Role { get; set; }

        public DbSet<RoleMapper> RoleMapper { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<RedCloudAdmin> RedCloudAdmins { get; set; }

        public DbSet<ResellerAdminUser> ResellerAdminUsers { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<OrganizationAdmin> OrganizationAdmins { get; set; }

        public DbSet<AssignmentType> AssignmentTypes { get; set; }

        public DbSet<Types> Type { get; set; }

        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Number> Numbers { get; set; }   
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Template> Templates { get; set; }
        public DbSet<MessagingUser> MessagingUser { get; set; }




        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<OrganizationResellerMapping> OrganizationResellerMapping { get; set; }
        public DbSet<ResellerUser> ResellerUsers { get; set; }


        public DbSet<CreditsType> CreditsType { get; set; }
        public DbSet<RateAssignCredit> RateAssignCredit { get; set; }


        public DbSet<Rate> Rates { get; set; }
        public DbSet<GetRate> GetRates { get; set; }//Fake Entity

        public DbSet<ResellerInboundMessagesReport> ResellerInboundMessagesReports { get; set; }//Fake Entity

        public DbSet<TotalReport> TotalReports { get; set; }//Fake Entity

        public DbSet<AdminInboundMessageReport> AdminInboundMessageReports { get; set; }//Fake Entity

        public DbSet<AdminCount> AdminCounts { get; set; }//Fake Entity




        public DbSet<GetAllAssignCredit> GetAllAssignCredit { get; set; }

        public DbSet<UsersNumberMapper> UserNumberMapper { get; set; }


        // fake Entities
        public DbSet<AssignCreditDetailsVM> AssignCreditDetailsVM { get; set; }
        public DbSet<GetRatedUsage> GetRatedUsage { get; set; }
        public DbSet<getRatedUsageList> getRatedUsageList { get; set; }
        public DbSet<GetAllAssignNumber> getAllAssignNumbers { get; set; }



        


    }
}