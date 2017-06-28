using DomainLayer.Models;

namespace Repository.Auth
{
    public interface IAuthentication
    {
        bool Authenticate(AuthModel obj);
    }
}