using Entities;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        int insertUser(UserItem userItem);
        void UpdateUser(UserItem existingUserItem);
        void DeleteUser(UserItem userItem);
    }
}
