using Infrastructure.Domain.DataInterfaces;
using System;
using System.Collections.Generic;

namespace Core.Model.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {

    }
}
