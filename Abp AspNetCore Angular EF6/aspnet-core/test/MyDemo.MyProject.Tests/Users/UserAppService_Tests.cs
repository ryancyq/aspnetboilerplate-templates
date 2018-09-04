using System.Threading.Tasks;
using System.Linq;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using MyDemo.MyProject.Users;
using MyDemo.MyProject.Users.Dto;

namespace MyDemo.MyProject.Tests.Users
{
    public class UserAppService_Tests : MyProjectTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAll(new PagedResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            UsingDbContext(context =>
            {
                var johnNashUser = context.Users.FirstOrDefault(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }
    }
}
