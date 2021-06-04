using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedTrip.Data;
using SharedTrip.Data.Models;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(string username, string email, string password)
        {
            User user = new User()
            {
                Email = email,
                Password = ComputeHash(password),
                Username = username
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashPass = ComputeHash(password);

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPass);

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(u => u.Email == email);
        }
        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(u => u.Username == username);
        }


        public static string ComputeHash(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
