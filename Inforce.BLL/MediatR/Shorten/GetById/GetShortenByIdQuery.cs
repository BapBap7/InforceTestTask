using FluentResults;
using Inforce.BLL.DTO.Shorten;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.GetById;

public record GetShortenByIdQuery(int shortenId)
    : IRequest<Result<ShortenDTO>>;