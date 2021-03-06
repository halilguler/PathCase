using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PathCase.Domain.Commands;
using PathCase.Models.Authentication;

namespace PathCase.MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            var command = new LoginCommand()
            {
                UserName = loginRequestModel.UserName
            };
            LoginResponseModel response;
            try
            {
                response = await _mediator.Send(command);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Ok(response);
        }
    }
}