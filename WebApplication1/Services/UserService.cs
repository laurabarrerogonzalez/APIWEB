using Data;
using Entities;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    public class UserService : BaseContextService, IUserService
    {
        public UserService(ServiceContext serviceContext) : base(serviceContext)
        {

        }

        public int insertUser(UserItem userItem)
        {
            _serviceContext.Users.Add(userItem);
            _serviceContext.SaveChanges();
            return userItem.IdUser;
        }

        public int insertUsers(UserItem userItem)
        {
            throw new NotImplementedException();
        }


        void IUserService.UpdateUser(UserItem existingUserItem)
        {
            _serviceContext.Users.Update(existingUserItem);
            _serviceContext.SaveChanges();
        }

        public void DeleteUser(UserItem userItem)
        {
            _serviceContext.Set<UserItem>().Remove(userItem);
            _serviceContext.SaveChanges();
        }



        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
