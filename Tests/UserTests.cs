using CookingBlog.DataAccess.Models;
using CookingBlog.DataAccess.Repositories.Interfaces;
using CookingBlog.Models;
using CookingBlog.Models.Core;
using CookingBlog.Models.Requests;
using CookingBlog.Models.Responces;
using CookingBlog.Services;
using CookingBlog.Services.Interfaces;
using CookingBlog.Services.Mappers;
using Moq;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class Tests
    {
        private readonly Mock<IUserRepository> userRepository = new();
        private readonly Mock<IRegistrationService> registrationService = new();
        private readonly Mock<IPasswordHashService> passwordHashService = new();
        private readonly Mock<ITokenGenService> tokenGenService = new();
        private readonly Mock<IUserTokensService> userTokensService = new();
        private readonly Mock<IUserService> userServiceMock = new();
        private Mock<AuthService> authServiceMock;

        private IUserService userService = null!;
        private IAuthService authService = null!;

        [SetUp]
        public void Setup()
        {
            userService = new UserService(userRepository.Object, passwordHashService.Object);
            authService = new AuthService(userService, tokenGenService.Object, userTokensService.Object);
            authServiceMock = new Mock<AuthService>(userService, tokenGenService.Object, userTokensService.Object) { CallBase = true };
        }

        [Test]
        public async Task TestAuthorize_ValidCredentials_ReturnsTrue()
        {
            // Arrange
        //    var email = "demo@mail.ru";
        //    var password = "demo";
        //    var passwordHash = "$2b$10$ivk7/D9SZejwU0fp/0VVCOfRxSRSnyVlEneI.3Icu8i9TDwt3LBh6";
        //    var userId = 1;

        //    //authServiceMock.Setup(x => x.GenerateTokens(It.IsAny<User>()))
        //    //    .ReturnsAsync(new AuthResponse
        //    //    {
        //    //        User = user,
        //    //        AccessToken = "access-token",
        //    //        RefreshToken = new Token
        //    //        {
        //    //            Token = "refresh-token",
        //    //            Expires = DateTime.Now.AddMinutes(5)
        //    //        }
        //    //    });
        //    userTokensService.Setup(service => service.Add(It.IsAny<UserToken>())).ReturnsAsync(new UserToken
        //    {
        //        UserId = userId,
        //        RefreshToken = "refresh-token",
        //        RefreshExpire = DateTime.Now.AddMinutes(5),
        //        AccessToken = "access-token",
        //        CreatedDate = DateTime.Now
        //    });

        //var authorizationRequest = new AuthorizationRequest
        //    {
        //        Email = email,
        //        Password = password,
        //    };

        //    var user = new User
        //    {
        //        Email = email,
        //        PasswordHash = passwordHash,
        //        Roles = new List<Role> { Role.User }
        //    };

        //    userServiceMock.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()))
        //                  .ReturnsAsync(user);

        //    //authService.Setup(x => x.GenerateTokens(It.IsAny<User>()))
        //    //       .ReturnsAsync(new AuthResponse { User = user, Token = "someToken" });


        //    // Act
        //    var result = await authService.Authorization(authorizationRequest);

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(email, result.User.Email);
        }

        [Test]
        public void TestRefreshToken_ValidData_ReturnsUser()
        {
            // Arrange
            //var refreshToken = "";

            //var authorizationRequest = new RefreshRequest
            //{
            //    Email = email,
            //    Password = password,
            //};

            //var authorizationRequest = new RefreshRequest
            //{
            //    Email = email,
            //    Password = password,
            //}; 

            //userTokensService.Setup(x => x.Get(refreshToken)).ReturnsAsync(employee);

            //var result = await employeeWorkplaceService.GetById(accountId, employeeId, userId);

            //Assert.That(employee.Id, Is.EqualTo(result!.Id));

            //var result = await authService.Refresh(authorizationRequest);
            //// Act
            //var result = authService.CreateUser(username, password);

            //// Assert
            //Assert.AreEqual(username, result.Username);
            //Assert.AreEqual(password, result.Password);
        }

        [Test]
        public async Task TestGetUserById_ValidId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User
            {
                Id = userId,
                Email = "user@example.com",
                PasswordHash = "hashedpassword"
            };

            userRepository.Setup(repo => repo.GetById(userId)).Returns(expectedUser.Map());

            // Act
            var result = await userService.GetById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
            Assert.AreEqual(expectedUser.Email, result.Email);
        }

        [Test]
        public async Task TestGetUserById_InvalidId_ReturnsNull()
        {
            // Arrange
            var userId = 2;
            userRepository.Setup(repo => repo.GetById(userId)).Returns((DbUser?)null);

            // Act
            var result = await userService.GetById(userId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task TestGetUserByEmail_ValidEmail_ReturnsUser()
        {
            // Arrange
            var email = "user@example.com";
            var expectedUser = new User
            {
                Id = 1,
                Email = email,
                PasswordHash = "hashedpassword"
            };

            userRepository.Setup(repo => repo.GetByEmail(email)).Returns(expectedUser.Map());

            // Act
            var result = await userService.GetByEmail(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
            Assert.AreEqual(expectedUser.Email, result.Email);
        }

        [Test]
        public async Task TestGetUserByEmail_InvalidEmail_ReturnsNull()
        {
            // Arrange
            var email = "nonexistent@example.com";
            userRepository.Setup(repo => repo.GetByEmail(email)).Returns((DbUser?)null);

            // Act
            var result = await userService.GetByEmail(email);

            // Assert
            Assert.IsNull(result);
        }
    }
}