using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AdventureWorksAPI.Middlewares.AuthorizationHandlers
{
    public class ProjectAuthorizationHandler : AuthorizationHandler<ProjectRequirement>
    {
        private readonly ILogger<ProjectAuthorizationHandler> _logger;

        public ProjectAuthorizationHandler(ILogger<ProjectAuthorizationHandler> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProjectRequirement requirement)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value;


            if (context.Resource is Project project)
            {
                if (userRole == "Admin" || project.OwnerId == userId)
                {
                    context.Succeed(requirement);
                    _logger.LogInformation("Access granted to user {UserID for project {ProjectID}}", userId, project.Id);
                }
                else
                {
                    _logger.LogWarning("Access denied to user {UserId} for project {ProjectId}", userId, project.Id);
                }
            }
            else
            {
                _logger.LogError("Project resource not provided for authorization.");
            }

            return Task.CompletedTask;
        }
    }
}


public class ProjectRequirement : IAuthorizationRequirement
{

}