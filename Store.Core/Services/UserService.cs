using Store.Core.Access;
using Store.Core.Interfaces;
using System.Linq;

namespace Store.Core.Services
{
    public class UserService
    {
        private readonly IEntityRepository<User> _user;

        public UserService(IEntityRepository<User> user)
        {
            _user = user;
        }

        public User GetUser(string name)
        {
            return _user.All.FirstOrDefault(u => u.Name.Equals(name) && u.IsDeleted == false);
        }
    }
}
