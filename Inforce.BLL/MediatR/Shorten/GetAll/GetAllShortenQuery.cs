using FluentResults;
using Inforce.BLL.DTO.Shorten;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.GetAll;

public record GetAllShortenQuery : IRequest<Result<IEnumerable<ShortenDTO>>>;
