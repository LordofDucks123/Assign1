using Models;

namespace Assign1.Data {
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}