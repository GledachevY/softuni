using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        public void CreateUser(string username, string email, string password);
        public string GetUserId(string usename, string password);
        public bool IsEmailAvailable(string email);
        public bool IsUsernameAvailable(string username);
    }
}
