using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using EntityFramework.DynamicFilters;
using MyDemo.MyProject.EntityFramework.Seed.Host;
using MyDemo.MyProject.EntityFramework.Seed.Tenants;

namespace MyDemo.MyProject.EntityFramework
{
    public sealed class Configuration : DbMigrationsConfiguration<MyProjectDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyProject";
        }

        protected override void Seed(MyProjectDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantBuilder(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}