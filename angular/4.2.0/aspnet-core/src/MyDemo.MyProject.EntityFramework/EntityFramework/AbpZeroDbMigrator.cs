using Abp.Data;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using System;
using System.Data.Entity;
using System.Transactions;

namespace MyDemo.MyProject.EntityFramework
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<MyProjectDbContext, Configuration>
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IDbPerTenantConnectionStringResolver _connectionStringResolver;
        private readonly IIocResolver _iocResolver;

        public AbpZeroDbMigrator(
           IUnitOfWorkManager unitOfWorkManager,
           IDbPerTenantConnectionStringResolver connectionStringResolver,
           IIocResolver iocResolver)
           : base(
               unitOfWorkManager,
               connectionStringResolver,
               iocResolver)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
            _iocResolver = iocResolver;
        }

        public virtual void CreateOrMigrateForHost(Action<MyProjectDbContext> seedAction)
        {
            CreateOrMigrate(null, seedAction);
        }

        public virtual void CreateOrMigrateForTenant(AbpTenantBase tenant, Action<MyProjectDbContext> seedAction)
        {
            if (tenant.ConnectionString.IsNullOrEmpty())
            {
                return;
            }

            CreateOrMigrate(tenant, seedAction);
        }

        protected override void CreateOrMigrate(AbpTenantBase tenant)
        {
            CreateOrMigrate(tenant, null);
        }

        protected virtual void CreateOrMigrate(AbpTenantBase tenant, Action<MyProjectDbContext> seedAction)
        {
            var args = new DbPerTenantConnectionStringResolveArgs(
                tenant == null ? (int?)null : (int?)tenant.Id,
                tenant == null ? MultiTenancySides.Host : MultiTenancySides.Tenant
            );

            args["DbContextType"] = typeof(MyProjectDbContext);
            args["DbContextConcreteType"] = typeof(MyProjectDbContext);

            var nameOrConnectionString = ConnectionStringHelper.GetConnectionString(
                _connectionStringResolver.GetNameOrConnectionString(args)
            );

            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                using (var dbContext = _iocResolver.ResolveAsDisposable<MyProjectDbContext>(new { nameOrConnectionString = nameOrConnectionString }))
                {
                    var dbInitializer = new MigrateDatabaseToLatestVersion<MyProjectDbContext, Configuration>(
                        true,
                        new Configuration
                        {
                            Tenant = tenant
                        });

                    dbInitializer.InitializeDatabase(dbContext.Object);
                    seedAction?.Invoke(dbContext.Object);
                    _unitOfWorkManager.Current.SaveChanges();
                    uow.Complete();
                }
            }
        }
    }
}
