using Inforce.DAL.Repositories.Interfaces.ShortenedUrl;
using Inforce.DAL.Repositories.Interfaces.Users;

namespace Inforce.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    IUserRepository UserRepository { get; }
    
    IShortenedUrlRepository ShortenedUrlRepository { get; }
    
    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}