using FluentResults;
using Inforce.BLL.DTO.Authentication.Register;
using MediatR;

namespace Inforce.BLL.MediatR.Authentication.Register;

public record RegisterQuery(RegisterRequestDTO registerRequestDTO) : IRequest<Result<RegisterResponseDTO>>;
