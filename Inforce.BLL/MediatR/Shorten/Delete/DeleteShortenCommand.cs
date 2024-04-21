using FluentResults;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.Delete;

public record DeleteShortenCommand(int id)
    : IRequest<Result<int>>;