using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.Base;
using Inforce.DAL.Repositories.Interfaces.Users;
using Inforce.DAL.Repositories.Realizations.Users;

namespace Inforce.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly MyDbContext _dbContext;
    
    private IUserRepository _userRepository;
    
    public RepositoryWrapper(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository is null)
            {
                _userRepository = new UserRepository(_dbContext);
            }

            return _userRepository;
        }
    }
    
    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    
}