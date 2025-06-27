using Application.DTOs;
using Application.UseCases;
using Domain.Entities;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Tests.UseCases
{
    public class LoginUserUseCaseTests
    {
        private readonly InMemoryUserRepository _repo;
        public LoginUserUseCaseTests()
        {
            _repo = new InMemoryUserRepository();

            var user = new User("john@example.com", "Password123");
            _repo.Save(user);
        }


        [Fact]
        public void Should_Login_Successfully()
        {
            var useCase = new LoginUserUseCase(_repo);
            var request = new LoginUserRequest
            {
                Email = "john@example.com",
                Password = "Password123"
            };

            var result = useCase.Execute(request);

            result.Success.Should().BeTrue();
            result.Message.Should().Be("Welcome, john@example.com");
        }

        [Fact]
        public void Should_Fail_When_Email_Is_Invalid()
        {
            var useCase = new LoginUserUseCase(_repo);
            var request = new LoginUserRequest
            {
                Email = "wrong@example.com",
                Password = "Password123",
            };

            var result = useCase.Execute(request);

            result.Success.Should().BeFalse();
            result.Message.Should().Be("Invalid email or password.");
        }


       
    }
}