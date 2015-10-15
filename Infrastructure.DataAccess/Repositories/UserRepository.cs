using Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.Repositories
{
    public class UserRepository : Repository<Guid, User>, IUserRepository
    {
        public UserRepository(DBContextProvider contextProvider)
            : base(contextProvider)
        {
        }
    }
}
