using ELearningApi.Api.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyntaxErrorist.Core.MediatRHandlers.Auth.RegisterUser;

namespace SyntaxErrorist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
    }
}
