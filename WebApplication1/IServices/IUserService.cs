using Entities;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        int insertUsers(UserItem userItem);
        void UpdateUser(UserItem existingUserItem);
        void DeleteUser(int userId);
    }
}
