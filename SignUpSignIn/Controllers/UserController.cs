using Application.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignUpSignIn.DTOs.User;

namespace SignUpSignIn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        
    }



}
