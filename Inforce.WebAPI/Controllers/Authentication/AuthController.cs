using Inforce.BLL.DTO.Authentication.Login;
using Inforce.BLL.DTO.Authentication.Register;
using Inforce.BLL.MediatR.Authentication.Login;
using Inforce.BLL.MediatR.Authentication.Register;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.WebAPI.Controllers.Authentication;

public class AuthController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDto)
    {
        return HandleResult(await Mediator.Send(new LoginQuery(loginDto)));
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerDto)
    {
        Console.WriteLine(registerDto);
        return HandleResult(await Mediator.Send(new RegisterQuery(registerDto)));
    }
}