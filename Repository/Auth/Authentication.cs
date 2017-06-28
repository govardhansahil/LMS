using DomainLayer.Models;
using System.Linq;

namespace Repository.Auth
{
    internal class Authentication : IAuthentication
    {
        public bool Authenticate(AuthModel obj)
        {
            return StaticDatabase._usersList
            .Any(m => m.Email == obj.Email && m.Password == obj.Password
                   && m.IsAdmin == true && m.IsActive == true);
        }
    }
}