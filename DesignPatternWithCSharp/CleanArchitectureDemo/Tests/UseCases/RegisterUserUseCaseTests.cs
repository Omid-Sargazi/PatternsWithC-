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
    }
}