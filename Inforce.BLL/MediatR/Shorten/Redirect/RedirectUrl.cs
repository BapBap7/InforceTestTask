using System.Data.Entity;
using FluentResults;
using Inforce.BLL.DTO.Shorten;
using Inforce.DAL.Entities.Shortener;
using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.BLL.MediatR.Shorten.Redirect;

public class RedirectUrl
{
    private readonly MyDbContext _dbContext;
    
    public RedirectUrl(IRepositoryWrapper repositoryWrapper, MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IResult> Handle(RedirectUrlCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var shortenedUrl = await _dbContext.ShortenedUrls.FirstOrDefaultAsync(s => s.Code == request.code);

            if (shortenedUrl is null)
            {
                return Results.NotFound();
            }

            return Results.Redirect(shortenedUrl.LongUrl);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}