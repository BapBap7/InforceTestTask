using MediatR;

namespace Inforce.BLL.MediatR.Shorten.Redirect;

public record RedirectUrlCommand(string code)
    : IRequest<Task<IResult>>;