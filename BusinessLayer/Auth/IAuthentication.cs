using DomainLayer.Models;

namespace BusinessLayer.Auth
{
    public interface IAuthentication
    {
        bool Authenticate(AuthModel obj);
    }
}