using AutoMapper;
using FluentResults;
using Inforce.BLL.DTO.Shorten;
using Inforce.DAL.Repositories.Interfaces.Base;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.GetAll;

public class GetAllShortenHandler : IRequestHandler<GetAllShortenQuery, Result<IEnumerable<ShortenDTO>>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public GetAllShortenHandler(IRepositoryWrapper repository, IMapper mapper)
    {
        _repositoryWrapper = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ShortenDTO>>> Handle(GetAllShortenQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var urls = await _repositoryWrapper.ShortenedUrlRepository.GetAllAsync();
            var urlsDto = _mapper.Map<IEnumerable<ShortenDTO>>(urls);
            return Result.Ok(urlsDto);
        }
        catch(Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}