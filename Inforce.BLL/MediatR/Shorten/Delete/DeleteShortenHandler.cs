using FluentResults;
using Inforce.DAL.Repositories.Interfaces.Base;
using MediatR;

namespace Inforce.BLL.MediatR.Shorten.Delete;

public class DeleteShortenHandler : IRequestHandler<DeleteShortenCommand, Result<int>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DeleteShortenHandler(IRepositoryWrapper repository)
    {
        _repositoryWrapper = repository;
    }

    public async Task<Result<int>> Handle(DeleteShortenCommand request, CancellationToken cancellationToken)
    {
        var url =
            await _repositoryWrapper.ShortenedUrlRepository.GetFirstOrDefaultAsync(x => x.Id == request.id);
        if (url is null)
        {
            string exMessage = $"No shorten found by entered Id - {request.id}";
            Console.WriteLine(exMessage);
            return Result.Fail(exMessage);
        }

        try
        {
            _repositoryWrapper.ShortenedUrlRepository.Delete(url);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(request.id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}