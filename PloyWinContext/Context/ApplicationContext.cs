using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Context
{
    public partial class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public ApplicationContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=(local);Database=PolyWinDB;User Id=youssef;password=01009615946;Trusted_Connection=False;MultipleActiveResultSets=true;");
                optionsBuilder.UseSqlServer("Server=SQL5102.site4now.net;Database=db_a7769c_mamsre;User Id=db_a7769c_mamsre_admin;password=Aa@123Ee@123;Trusted_Connection=False;MultipleActiveResultSets=true;");
            }
        }


        public DbSet<TblCategory> TblCategory { get; set; }
        public DbSet<TblDescount> TblDescount { get; set; }
        public DbSet<TblProducts> TblProducts { get; set; }
        public DbSet<TblInvoices> TblInvoices { get; set; }
        public DbSet<TblInvoicesDetails> TblInvoicesDetails { get; set; }
        public DbSet<TblAgent> TblAgent { get; set; }
        public DbSet<TblStores> TblStores { get; set; }
        public DbSet<TblClient> TblClient { get; set; }
        public DbSet<TblClientType> TblClientType { get; set; }
        public DbSet<TblContractClient> TblContractClient { get; set; }
        public DbSet<TblPayedContractClient> TblPayedContractClient { get; set; }
        public DbSet<TblGallaryUser> TblGallaryUser { get; set; }
        public DbSet<TblGallery> TblGallery { get; set; }
        public DbSet<TblCategoryGallary> TblCategoryGallary { get; set; }
        public DbSet<TblCategoryChildGallery> TblCategoryChildGallery { get; set; }
        public DbSet<TblCategoryType> TblCategoryType { get; set; }
        public DbSet<TblDataSheets> TblDataSheets { get; set; }
        public DbSet<TblCatalogue> TblCatalogue { get; set; }
        public DbSet<TblCompanyInfo> TblCompanyInfo { get; set; }
        public DbSet<TblParentCategory> TblParentCategories { get; set; }
        public DbSet<TblSubCategory> TblSubCategories { get; set; }
        public DbSet<TblProductIngredients> TblProductIngredients { get; set; }
        public DbSet<TblProductIngredientAccessory> TblProductIngredientAccessory { get; set; }
        public DbSet<TblColors> TblColors { get; set; }
        public DbSet<TblParentProductCategory> TblParentProductCategory { get; set; }
        public DbSet<TblProductName> TblProductName { get; set; }
        public DbSet<TblCostCalculation> TblCostCalculation { get; set; }
        public DbSet<TblCostCalculationItems> TblCostCalculationItems { get; set; }
        public DbSet<TblInstallment> TblInstallment { get; set; }
        public DbSet<TblWarrantyContracts> TblWarrantyContracts { get; set; }
        public DbSet<TblContractCostCalc> TblContractCostCalc { get; set; }
        public DbSet<TblFactor> TblFactor { get; set; }
        public DbSet<TblClientOpinions> TblClientOpinions { get; set; }
        public DbSet<TblPriceList> TblPriceList { get; set; }
        public DbSet<TblMessage> TblMessage { get; set; }
        public DbSet<TblSupplier> TblSupplier { get; set; }
        public DbSet<TblStoreData> TblStoreData { get; set; }
        public DbSet<TblItemType> TblItemType { get; set; }
        public DbSet<TbltreasuryBank> TbltreasuryBank { get; set; }
        public DbSet<TblPurchase> TblPurchase { get; set; }
        public DbSet<TblCurrency> TblCurrency { get; set; }
        public DbSet<TblBank> TblBank { get; set; }
        public DbSet<TblPaymentMethods> TblPaymentMethods { get; set; }
        public DbSet<TblEmplyees> TblEmplyees { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TblPurchase_Invoice> TblPurchase_Invoice { get; set; }
        public DbSet<TblPurchase_Invoices_Details> TblPurchase_Invoices_Details { get; set; }

    }
}
