using FluentResults;
using Inforce.BLL.ResultVariations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseApiController : ControllerBase
{
    
    private IMediator? _mediator;
    
    public BaseApiController()
    {
        
    }
    
    protected IMediator Mediator => _mediator ??=
        HttpContext.RequestServices.GetService<IMediator>() !;
    
    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result is NullResult<T>)
            {
                return Ok(result.Value);
            }

            return (result.Value is null) ?
                NotFound("Not Found") : Ok(result.Value);
        }

        return BadRequest(result.Reasons);
    }
}