using Application.DTOs;
using Application.UseCases;
using FluentAssertions;
using Infrastructure.Repositories;

namespace Tests.UseCases
{
    public class RegisterUserUseCaseTests
    {
        [Fact]
        public void Should_RegisterUser_Successfully()
        {
            var repo = new InMemoryUserRepository();
            var useCase = new RegisterUserUseCase(repo);
            var request = new RegisterUserRequest
            {
                Email = "test@example.com",
                Password = "secure123",
            };

            var result = useCase.Execute(request);

            result.Success.Should().BeTrue();
            result.Message.Should().Be("User registered successfully.");
        }
        [Fact]
        public void Should_Fail_When_Email_Is_Already_Registered()
        {
            var repo = new InMemoryUserRepository();
            var useCase = new RegisterUserUseCase(repo);
            var request01 = new RegisterUserRequest { Email = "duplicate@example.com", Password = "secure123" };
            var request02 = new RegisterUserRequest { Email = "duplicate@example.com", Password = "Secure1234" };

            useCase.Execute(request01);
            var result = useCase.Execute(request02);

            result.Success.Should().BeFalse();
            result.Message.Should().Be("Email already registered!");
        }
    }
}