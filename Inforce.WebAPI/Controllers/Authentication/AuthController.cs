using Inforce.BLL.DTO.Authentication.Register;
using Inforce.BLL.MediatR.Authentication.Register;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.WebAPI.Controllers.Authentication;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthController : BaseApiController
{
    // [HttpPost]
    // public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
    // {
    //     return HandleResult(await Mediator.Send(new LoginQuery(loginDTO)));
    // }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerDto)
    {
        Console.WriteLine(registerDto);
        return HandleResult(await Mediator.Send(new RegisterQuery(registerDto)));
    }
}