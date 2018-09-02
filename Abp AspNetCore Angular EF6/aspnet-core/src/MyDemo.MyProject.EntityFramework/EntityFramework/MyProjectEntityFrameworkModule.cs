using System.Data.Entity;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFramework;
using MyDemo.MyProject.EntityFramework.Seed;

namespace MyDemo.MyProject.EntityFramework
{
    [DependsOn(
        typeof(MyProjectCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkModule))]
    public class MyProjectEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<MyProjectDbContext>());
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
