using Inforce.DAL.Entities.Users;
using Inforce.DAL.Persistence;
using Inforce.DAL.Repositories.Interfaces.Users;
using Inforce.DAL.Repositories.Realizations.Base;

namespace Inforce.DAL.Repositories.Realizations.Users;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(MyDbContext dbContext)
        : base(dbContext)
    {
    }
}