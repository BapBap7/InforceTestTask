using Inforce.BLL.DTO.Shorten;
using Inforce.BLL.MediatR.Shorten.Create;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.WebAPI.Controllers.Shorten;

[ApiController]
[Route("api/[controller]/[action]")]
public class ShortenerController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShortShortenDTO shortenDto)
    {
        return HandleResult(await Mediator.Send(new CreateShortenCommand(shortenDto, HttpContext)));
    }
}