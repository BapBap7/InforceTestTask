using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.ShortenedUrl;
using Inforce.DAL.Repositories.Realizations.Base;

namespace Inforce.DAL.Repositories.Realizations.ShortenedUrl;

public class ShortenedUrlRepository: RepositoryBase<Entities.Shortener.ShortenedUrl>, IShortenedUrlRepository
{
    public ShortenedUrlRepository(MyDbContext context)
        : base(context)
    {
    }
}