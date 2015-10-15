using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Model.Common;

namespace Core.Model.Users
{
    public interface IUserService
    {
        User CreateUser(string username, string password);
        User CreateUser(string username, string password, string userRole);
        User LogInUser(string username, string password);
        User GetUserByEmail(string email);
        User GetUserById(Guid userId);
        User GetUserByUsername(string username);
    }
}
