using Book_Libary.Controllers;
using Book_Libary.Models.Admin;
using Book_Libary.Models.Inventory;
using Book_Libary.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book_Libary.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=BookDb") { 
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }


        //User Tables
        public DbSet<UserLoginInfo> LoginDetails { get; set; }
        public DbSet<UserBasicInfo> BasicInfo { get; set; }
        public DbSet<UserLocationInfo> LocationInfo { get; set; }
        public DbSet<UserLoginLog> UserLoginLogs { get; set; }
        
        //Admin Tables
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<AdminDetails> AdminInfo { get; set; }
        public DbSet<AdminLoginLog> AdminLoginLogs { get; set; }
        public DbSet<AdminOperationLog> AdminOperationLogs { get; set; }

        //Inventory Tables
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(DbModelBuilder dbModel)
        {
            //dbModel.Entity<LoginController>().
        }
    }
}