using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PrzychodniaBackend.Api.Authentication;
using PrzychodniaBackend.Api.Controllers;
using PrzychodniaBackend.Api.Controllers.User;
using PrzychodniaBackend.Api.Controllers.User.Dto;
using PrzychodniaBackend.Application.UserService;
using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.UnitTests.ApiTests
{
    [TestFixture]
    class UserControllerTests
    {
        private UserController _controller;

        [SetUp]
        public void SetUpMocks()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(m => m.Login(new LoginCredentials("correctUsername", "correctPassword")))
                .Returns(new LoggedInUser("correctName", "correctSurname"));
            var jwtServiceMock = new Mock<IJwtService>();
            _controller = new UserController(userServiceMock.Object, jwtServiceMock.Object);
        }

        [Test]
        public void Login_ReturnOkWithUserAndToken_WhenExistsAndCorrectCredentials()
        {
            var response = _controller.Login(new LoginCredentialsDto{Username = "correctUsername", Password = "correctPassword" });

            Assert.IsInstanceOf<OkObjectResult>(response);
            var identifiedResponse = response as OkObjectResult;
            Assert.IsInstanceOf<LoggedInUserDto>(identifiedResponse.Value);
            var result = identifiedResponse.Value as LoggedInUserDto;
        }

        [Test]
        public void Login_ReturnBadRequest_WhenMissingUsernameOrPassword()
        {
            var response = _controller.Login(new LoginCredentialsDto{Username = "correctUsername", Password = null });

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
            var identifiedResponse = response as BadRequestObjectResult;
            Assert.IsInstanceOf<string>(identifiedResponse.Value);
            var result = identifiedResponse.Value as string;
            Assert.AreEqual("No username or password provided", result);
        }

        [Test]
        public void Login_ReturnBadRequest_WhenIncorrectUsernameOrPassword()
        {
            var response = _controller.Login(new LoginCredentialsDto{Username = "wrongUsername", Password = "wrongPassword" });

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
            var identifiedResponse = response as BadRequestObjectResult;
            Assert.IsInstanceOf<string>(identifiedResponse.Value);
            var result = identifiedResponse.Value as string;
            Assert.AreEqual("Invalid username or password", result);
        }
    }
}
