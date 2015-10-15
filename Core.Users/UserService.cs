using Core.Model.Users;
using Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Core.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;

        }
        public User CreateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("username cannot be empty");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password cannot be empty");

            if (!UserNameIsFree(userName)) throw new ArgumentNullException("Username exist");

            var hash = _securityService.Compute(password);
               
            var newUser = new User();
            newUser.Username = userName;
            newUser.PasswordHash = hash.HashedText;
            newUser.PasswordSalt = hash.Salt;
            newUser.ContactDetails.AddressDetails.Email = "as@as.pl";

           _userRepository.SaveOrUpdate(newUser);
           _userRepository.DbContext.CommitChanges();
           return newUser;
        }

        public User CreateUser(string userName, string password, string userRole)
        {
            var newUser = CreateUser(userName, password);
            newUser.UserRoles = new Collection<UserRole>() { new UserRole() { Name = userRole } };

            _userRepository.SaveOrUpdate(newUser);
            _userRepository.DbContext.CommitChanges();
            return newUser;
        }

        public User LogInUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username cannot be empty");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password cannot be empty");

            var user = _userRepository.Get(z => z.Username == username).FirstOrDefault();
            if (user == null) throw new ArgumentNullException("User not found");

            var isValid = _securityService.ValidateHash(password, new HashObject(user.PasswordHash, user.PasswordSalt));

            return isValid ? user : null;
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid userId)
        {
            return _userRepository.Get(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.Get(x => x.Username == username).FirstOrDefault();
        }

        private bool UserNameIsFree(string username){
            var user = GetUserByUsername(username);

            if(user != null)
                return false;

            return true;
        }
    }
}
