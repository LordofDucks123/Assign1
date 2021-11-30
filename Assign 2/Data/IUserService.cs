using ClassLibrary1.Models;
using System.Threading.Tasks;

namespace Assign2.Data {
public interface IUserService {
   Task<User> ValidateUser(string userName, string password);
}
}