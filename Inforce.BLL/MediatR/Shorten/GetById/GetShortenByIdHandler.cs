using AutoMapper;
using FluentResults;
using Inforce.BLL.DTO.Shorten;
using Inforce.DAL.Repositories.Interfaces.Base;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.GetById;

public class GetShortenByIdHandler : IRequestHandler<GetShortenByIdQuery, Result<ShortenDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetShortenByIdHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<ShortenDTO>> Handle(GetShortenByIdQuery request, CancellationToken cancellationToken)
    {
        var url = await _repositoryWrapper.ShortenedUrlRepository.GetFirstOrDefaultAsync(j => j.Id == request.shortenId);

        if (url is null)
        {
            string exceptionMessege = $"No url found by entered Id - {request.shortenId}";
            return Result.Fail(exceptionMessege);
        }

        try
        {
            var urlDto = _mapper.Map<ShortenDTO>(url);
            return Result.Ok(urlDto);
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}