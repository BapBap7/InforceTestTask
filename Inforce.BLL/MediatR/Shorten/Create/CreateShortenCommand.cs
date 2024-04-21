using FluentResults;
using Inforce.BLL.DTO.Shorten;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.Create;

public record CreateShortenCommand(ShortShortenDTO shortenUrl, HttpContext httpContext)
    : IRequest<Result<ShortenDTO>>;