using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyDemo.MyProject.Authorization.Roles;
using MyDemo.MyProject.Authorization.Users;
using MyDemo.MyProject.MultiTenancy;

namespace MyDemo.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options)
            : base(options)
        {
        }
    }
}
