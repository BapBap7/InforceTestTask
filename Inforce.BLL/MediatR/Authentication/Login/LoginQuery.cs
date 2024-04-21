using FluentResults;
using Inforce.BLL.DTO.Authentication.Login;
using MediatR;

namespace Inforce.BLL.MediatR.Authentication.Login;

public record LoginQuery(LoginRequestDTO UserLogin) : IRequest<Result<LoginResponseDTO>>;
