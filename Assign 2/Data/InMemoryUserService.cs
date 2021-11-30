using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Models;
using System.Threading.Tasks;

namespace Assign2.Data{
public class InMemoryUserService : IUserService {
    private List<User> users;

    public InMemoryUserService() {
        users = new[] {
            new User {
                City = "Horsens",
                Domain = "via.dk",
                Password = "123456",
                Role = "Student",
                BirthYear = 1997,
                SecurityLevel = 5,
                UserName = "Mads"
            },
            new User {
                City = "Vejle",
                Domain = "via.com",
                Password = "123456",
                Role = "Guest",
                BirthYear = 1995,
                SecurityLevel = 1,
                UserName = "Frederik"
            }
        }.ToList();
    }


    public async Task<User> ValidateUser(string userName, string password) {
        User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
        if (first == null) {
            throw new Exception("User not found");
        }

        if (!first.Password.Equals(password)) {
            throw new Exception("Incorrect password");
        }

        return first;
    }
}
}