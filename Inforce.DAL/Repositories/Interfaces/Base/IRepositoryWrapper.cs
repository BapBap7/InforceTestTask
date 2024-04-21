using Inforce.DAL.Repositories.Interfaces.Users;

namespace Inforce.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    IUserRepository UserRepository { get; }
    
    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}